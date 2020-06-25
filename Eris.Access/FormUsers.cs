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
    public partial class FormUser : FormBase
    {
        private UserEntity CurrentUser;
        private UserEntity m_User;
        private string DBName;

        public FormUser(string _DBName, UserEntity User)
        {
            InitializeComponent();

            DBName = _DBName;
            m_User = User;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (CurrentState != FormState.View)
                if (!SaveUser())
                    return;

            CurrentState = FormState.Insert;
            EmptyFields();
            EnableItems(false);
            txtFullName.Focus();
        }

        private void EmptyFields()
        {
            txtUserName.Text = "";
            txtFullName.Text = "";
            CmbBDate.SelectedDateTime = DateTime.Now;
            txtUserPass.Text = "";
            CmbUserType.SelectedIndex = 1;
            txtUserName.Tag = new Guid();
        }

        private void EnableItems(bool flg)
        {
            btnRefresh.Enabled = btnEdit.Enabled = btnDelete.Enabled = grdUser.Enabled = flg;
            btnSave.Enabled = btnCancel.Enabled = !flg;
            grpUser.Enabled = !flg;

            if (txtUserName.Text.ToLower() == "admin")
            {
                txtUserName.Enabled = false;
                CmbUserType.Enabled = false;
            }
            else
            {
                txtUserName.Enabled = true;
                CmbUserType.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EnableItems(true);
            CurrentState = FormState.View;
            UserBS_PositionChanged(null, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveUser())
                CurrentState = FormState.View;
        }

        private bool SaveUser()
        {
            if (!CanSave())
                return false;

            UserEntity User = new UserEntity();

            User.Active = CmbUserType.SelectedIndex == 0? false : true;
            User.UserPass = txtUserPass.Text.Trim();
            User.UserFulName = txtFullName.Text;
            User.UserbDate = CmbBDate.Text;
            User.UserName = txtUserName.Text;

            User.UserId = new Guid(txtUserName.Tag.ToString());

            if (User.UserId == new Guid())
            {
                User.UserId = UserData.Insert(User, DBName.ToLower());
                UserToEffectOperationTypeData.InsertForNewUser(User);
                DefaultData.InsertForNewUser(User);
                UserBS.Add(User);
            }
            else
            {
                if (User.UserPass == string.Empty)
                    UserData.Update(User);
                else
                    UserData.UpdateWithPassword(User, DBName.ToLower());
                CurrentUser = User;
            }

            grdUser.Refetch();

            EnableItems(true);

            return true;
        }

        private bool CanSave()
        {
            if (txtFullName.Text == string.Empty)
            {
                EMessage.Show("نام و نام خانوادگی وارد نشده است", "خطا در ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFullName.Focus();
                return false;
            }

            if (txtUserName.Text == string.Empty)
            {
                EMessage.Show("نام کاربری وارد نشده است", "خطا در ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return false;
            }
            string Code = txtUserName.Text;
            if (UserData.IsDuplicate(Code, new Guid(txtUserName.Tag.ToString())))
            {
                EMessage.Show("نام کاربری تکراری است", "خطا در ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return false;
            }

            if (CmbBDate.SelectedDateTime == DateTime.MinValue)
            {
                EMessage.Show("تاریخ تولد را انتخاب کنید.", "خطا در ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CmbBDate.Focus();
                return false;
            }

            if (CmbUserType.SelectedIndex < 0)
            {
                EMessage.Show("وضعیت را انتخاب کنید.", "خطا در ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CmbUserType.Focus();
                return false;
            }

            return true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (UserBS.Count == 0)
                return;

            if (m_User.UserName.ToLower() != "admin" && m_User.UserId != CurrentUser.UserId)
                return;

            CurrentState = FormState.Update;
            EnableItems(false);
            txtUserName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (UserBS.Count == 0)
                return;

            if (!CanDelete())
            {
                EMessage.Show("این آیتم بدلیل داشتن گردش، غیرقابل حذف می باشد", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (EMessage.Show("آیا انبار مورد نظر حذف گردد؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            UserData.Delete(((UserEntity)UserBS.Current).UserId);
            UserBS.RemoveCurrent();

            UserBS_PositionChanged(null, null);
        }

        private bool CanDelete()
        {
            if (txtUserName.Text.ToLower() == "admin")
                return false;
            
            return true;
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
            CurrentState = FormState.View;
            UserBS.PositionChanged += UserBS_PositionChanged;
            UserBS_PositionChanged(null, null);
        }

        void UserBS_PositionChanged(object sender, EventArgs e)
        {
            EmptyFields();
            CurrentUser = new UserEntity();
            if (UserBS.Count == 0)
                return;

            CurrentUser = (UserEntity)UserBS.Current;

            txtUserName.Text = CurrentUser.UserName;
            txtFullName.Text = CurrentUser.UserFulName;
            CmbBDate.SelectedDateTime = PersianDateConverter.ToGregorianDateTime(new PersianDate(CurrentUser.UserbDate));
            CmbUserType.SelectedIndex = CurrentUser.Active ? 1 : 0;

            txtUserName.Tag = CurrentUser.UserId;
        }

        private void FormUser_KeyDown(object sender, KeyEventArgs e)
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            UserBS.DataSource = UserData.SelectAll();
        }
    }
}