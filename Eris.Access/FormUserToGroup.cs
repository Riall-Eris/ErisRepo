using Eris.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Eris.Bussiness;
using Eris.Data;
using Eris.Entity;
using Janus.Windows.GridEX;

namespace Eris.Access
{
    public partial class FormUserToGroup : FormBase
    {
        private List<UserToGroupEntity> LstUserToGroup;

        public FormUserToGroup()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveUserToGroup();
        }

        private bool SaveUserToGroup()
        {
            TreeNode TnRoot = tvUsers.Nodes[0];
            LstUserToGroup = new List<UserToGroupEntity>();
            GetAllCheckedBox(TnRoot);

            UserToGroupData.DeleteByUserGroupID(GetCurrentUserGroupID());

            UserToGroupData.GroupInsert(LstUserToGroup);

            MessageBox.Show("ثبت عملیات انجام پذیرفت");
            return true;
        }

        private void GetAllCheckedBox(TreeNode root)
        {
            foreach (TreeNode childNode in root.Nodes)
            {
                if (new Guid(childNode.Tag.ToString()) == new Guid())
                    continue;
                if (childNode.Checked)
                {
                    UserToGroupEntity UserToGroup = new UserToGroupEntity();
                    UserToGroup.UserGroupID = GetCurrentUserGroupID();
                    UserToGroup.UserID = new Guid(childNode.Tag.ToString());
                    UserToGroup.UserToGroupDate = FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(DateTime.Now).ToString("YYYY/MM/DD");
                    LstUserToGroup.Add(UserToGroup);
                }

                if (childNode.Nodes.Count > 0)
                {
                    GetAllCheckedBox(childNode);
                }
            }
        }

        private void FormUserToGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 && btnSave.Enabled)
                btnSave_Click(null, null);

            if (e.KeyCode == Keys.Escape && CurrentState != FormState.View)
                btnCancel_Click(null, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTree_UserGroup();
            LoadTree_User();
            tvUsers.ExpandAll();
            tvUserGroup_AfterSelect(null, null);
        }

        private bool FoundInList(Guid UserID)
        {
            foreach (UserToGroupEntity item in LstUserToGroup)
            {
                if (item.UserID == UserID)
                    return true;
            }
            return false;
        }

        private void FormUserToGroup_Load(object sender, EventArgs e)
        {
            btnRefresh_Click(null, null);
        }

        private void LoadTree_UserGroup()
        {
            List<UserGroupEntity> LstUserGroups = UserGroupData.SelectAll();

            tvGroupUser.Nodes.Clear();

            TreeNode TnRoot = new TreeNode();
            TnRoot.Text = "[ریشه] گروه کاربران";
            TnRoot.Tag = new Guid();
            TnRoot.ImageIndex = 0;
            tvGroupUser.Nodes.Add(TnRoot);

            foreach (UserGroupEntity item in LstUserGroups)
            {
                TreeNode TnUserGroups = new TreeNode();
                TnUserGroups.Text = "[" + item.UserGroupCode + "] " + item.UserGroupName;
                TnUserGroups.Tag = item.UserGroupID;
                TnUserGroups.Expand();
                TnUserGroups.ImageIndex = 1;
                TnRoot.Nodes.Add(TnUserGroups);
            }
            CurrentState = FormState.View;
        }

        private void LoadTree_User()
        {
            List<UserEntity> LstUsers = UserData.SelectAll();

            tvUsers.Nodes.Clear();

            TreeNode TnRoot = new TreeNode();
            TnRoot.Text = "[ریشه] کاربران";
            TnRoot.Tag = new Guid();
            TnRoot.ImageIndex = 0;
            tvUsers.Nodes.Add(TnRoot);

            foreach (UserEntity item in LstUsers)
            {
                TreeNode TnUsers = new TreeNode();
                TnUsers.Text = "[" + item.UserName + "] " + item.UserFulName;
                TnUsers.Tag = item.UserId;
                TnUsers.Expand();
                TnUsers.ImageIndex = 1;
                TnRoot.Nodes.Add(TnUsers);
            }
            CurrentState = FormState.View;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void tvUserGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (NoSelectedNode())
                return;

            Guid UserGroupID = GetCurrentUserGroupID();

            if (UserGroupID == new Guid())
                return;

            LstUserToGroup = UserToGroupData.SelectAllByUserGroupID(UserGroupID);

            TreeNode TnRoot = tvUsers.Nodes[0];
            tvUsers.Nodes[0].Checked = false;
            FillUserCheckBoxes(TnRoot);
        }

        private void FillUserCheckBoxes(TreeNode root)
        {
            foreach (TreeNode childNode in root.Nodes)
            {
                childNode.Checked = false;
                if (new Guid(childNode.Tag.ToString()) != new Guid())
                {
                    if (FoundInList(new Guid(childNode.Tag.ToString())))
                        childNode.Checked = true;
                }

                if (childNode.Nodes.Count > 0)
                {
                    FillUserCheckBoxes(childNode);
                }
            }
        }

        private bool NoSelectedNode()
        {
            if (GetUserGroupCount() == 0)
                return true;

            if (tvGroupUser.SelectedNode == null)
                return true;

            if (new Guid(tvGroupUser.SelectedNode.Tag.ToString()) == new Guid())
                return true;

            return false;
        }

        private int GetUserGroupCount()
        {
            return tvGroupUser.Nodes[0].Nodes.Count;
        }

        private Guid GetCurrentUserGroupID()
        {
            if (tvGroupUser.SelectedNode == null)
                return new Guid();

            return new Guid(tvGroupUser.SelectedNode.Tag.ToString());
        }

        private void tvUsers_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!e.Node.Checked)
            {
                if (tvGroupUser.SelectedNode.Text.Contains("0001") &&
                    e.Node.Text.ToLower().Contains("[admin]"))
                    e.Node.Checked = true;
            }
        }
    }
}