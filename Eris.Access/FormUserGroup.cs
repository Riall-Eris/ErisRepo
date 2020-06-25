using Eris.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Eris.Bussiness;
using Eris.Data;
using Eris.Entity;
using FarsiLibrary.Utils;

namespace Eris.Access
{
    public partial class FormUserGroup : FormBase
    {
        private UserGroupEntity CurrentUserGroup;

        public FormUserGroup()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (CurrentState != FormState.View)
                if (!SaveUserGroup())
                    return;

            CurrentState = FormState.Insert;
            EmptyFields();
            EnableItems(false);
            txtUserGroupCode.Text = UserGroupData.GetNewCode();
            FixAccDetailCode();
            txtUserGroupCode.Focus();
        }

        private void EmptyFields()
        {
            txtUserGroupName.Text = "";
            txtUserGroupCode.Text = "";
            txtUserGroupCode.Tag = new Guid();
        }

        private void EnableItems(bool flg)
        {
            btnRefresh.Enabled = btnEdit.Enabled = btnDelete.Enabled = grdUserGroup.Enabled = flg;
            btnSave.Enabled = btnCancel.Enabled = !flg;
            grpUserGroup.Enabled = !flg;

            if (txtUserGroupCode.Text.ToLower() == "0001")
                txtUserGroupCode.Enabled = false;
            else
                txtUserGroupCode.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EnableItems(true);
            CurrentState = FormState.View;
            UserGroupBS_PositionChanged(null, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveUserGroup())
                CurrentState = FormState.View;
        }

        private bool SaveUserGroup()
        {
            if (!CanSave())
                return false;

            UserGroupEntity UserGroup = new UserGroupEntity();

            UserGroup.UserGroupCode = txtUserGroupCode.Text;
            UserGroup.UserGroupName = txtUserGroupName.Text;

            UserGroup.UserGroupID = new Guid(txtUserGroupCode.Tag.ToString());

            if (UserGroup.UserGroupID == new Guid())
            {
                UserGroup.UserGroupID = UserGroupData.Insert(UserGroup);
                UserGroupBS.Add(UserGroup);
            }
            else
            {
                UserGroupData.Update(UserGroup);
                CurrentUserGroup = UserGroup;
            }

            grdUserGroup.Refetch();

            EnableItems(true);

            return true;
        }

        private bool CanSave()
        {
            if (txtUserGroupCode.Text == string.Empty)
            {
                EMessage.Show("کد گروه وارد نشده است", "خطا در ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserGroupCode.Focus();
                return false;
            }
            string Code = txtUserGroupCode.Text;
            if (UserGroupData.IsDuplicate(Code, new Guid(txtUserGroupCode.Tag.ToString())))
            {
                EMessage.Show("کد گروه تکراری است", "خطا در ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserGroupCode.Focus();
                return false;
            }

            if (txtUserGroupName.Text == string.Empty)
            {
                EMessage.Show("نام گروه وارد نشده است", "خطا در ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserGroupName.Focus();
                return false;
            }

            return true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (UserGroupBS.Count == 0)
                return;
            CurrentState = FormState.Update;
            EnableItems(false);
            txtUserGroupName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (UserGroupBS.Count == 0)
                return;

            if (!CanDelete())
            {
                EMessage.Show("این آیتم بدلیل داشتن گردش، غیرقابل حذف می باشد", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (EMessage.Show("آیا انبار مورد نظر حذف گردد؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            UserGroupData.Delete(((UserGroupEntity)UserGroupBS.Current).UserGroupID);
            UserGroupBS.RemoveCurrent();

            UserGroupBS_PositionChanged(null, null);
        }

        private bool CanDelete()
        {
            if (txtUserGroupCode.Text.ToLower() == "0001")
                return false;
            
            return true;
        }

        private void FormUserGroup_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
            CurrentState = FormState.View;
            UserGroupBS.PositionChanged += UserGroupBS_PositionChanged;
            UserGroupBS_PositionChanged(null, null);
        }

        void UserGroupBS_PositionChanged(object sender, EventArgs e)
        {
            EmptyFields();
            CurrentUserGroup = new UserGroupEntity();
            if (UserGroupBS.Count == 0)
                return;

            CurrentUserGroup = (UserGroupEntity)UserGroupBS.Current;

            txtUserGroupName.Text = CurrentUserGroup.UserGroupName;
            txtUserGroupCode.Text = CurrentUserGroup.UserGroupCode;

            txtUserGroupCode.Tag = CurrentUserGroup.UserGroupID;
        }

        private void FormUserGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && btnNew.Enabled)
                btnNew_Click(null, null);

            if (e.KeyCode == Keys.F3 && btnSave.Enabled)
                btnSave_Click(null, null);

            if (e.KeyCode == Keys.F4 && btnEdit.Enabled)
                btnEdit_Click(null, null);

            if (e.KeyCode == Keys.F8 && btnDelete.Enabled)
                btnDelete_Click(null, null);

            if (e.KeyCode == Keys.F5 && btnRefresh.Enabled)
                btnRefresh_Click(null, null);

            if (e.KeyCode == Keys.Escape && CurrentState != FormState.View)
                btnCancel_Click(null, null);
        }

        private void txtUserGroupCode_Leave(object sender, EventArgs e)
        {
            FixAccDetailCode();
        }

        private void FixAccDetailCode()
        {
            txtUserGroupCode.Text = txtUserGroupCode.Text.Trim().PadLeft(4, '0');
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UserGroupBS.DataSource = UserGroupData.SelectAll();
        }
    }
}