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
    public partial class FormUserGroupToMenu : FormBase
    {
        private List<UserGroupToMenuEntity> LstUserGroupToMenu;
        private List<UserGroupToMenuEntity> LstUnChecked;
        private int SysTypeCode;

        public FormUserGroupToMenu(int m_SysTypeCode)
        {
            InitializeComponent();
            SysTypeCode = m_SysTypeCode;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveUserGroupToMenu();
        }

        private bool SaveUserGroupToMenu()
        {
            TreeNode TnRoot = tvMenu.Nodes[0];
            LstUserGroupToMenu = new List<UserGroupToMenuEntity>();
            GetAllCheckedBox(TnRoot);

            LstUnChecked = new List<UserGroupToMenuEntity>();
            GetAllUnCheckedBox(TnRoot);

            UserGroupToMenuData.GroupDelete(LstUnChecked);

            UserGroupToMenuData.GroupInsert(LstUserGroupToMenu);

            return true;
        }

        private void GetAllUnCheckedBox(TreeNode root)
        {
            foreach (TreeNode childNode in root.Nodes)
            {
                if (new Guid(childNode.Tag.ToString()) == new Guid())
                    continue;
                if (!childNode.Checked)
                {
                    UserGroupToMenuEntity UserGroupToMenu = new UserGroupToMenuEntity();
                    UserGroupToMenu.UserGroupID = GetCurrentUserGroupID();
                    UserGroupToMenu.MenuID = new Guid(childNode.Tag.ToString());
                    UserGroupToMenu.LevelAccess = "000000000000";
                    LstUnChecked.Add(UserGroupToMenu);
                   
                }

                if (childNode.Nodes.Count > 0)
                {
                    GetAllUnCheckedBox(childNode);
                }
            }
        }

        private void GetAllCheckedBox(TreeNode root)
        {
            foreach (TreeNode childNode in root.Nodes)
            {
                if (new Guid(childNode.Tag.ToString()) == new Guid())
                    continue;
                if (childNode.Checked)
                {
                    UserGroupToMenuEntity UserGroupToMenu = new UserGroupToMenuEntity();
                    UserGroupToMenu.UserGroupID = GetCurrentUserGroupID();
                    UserGroupToMenu.MenuID = new Guid(childNode.Tag.ToString());
                    UserGroupToMenu.LevelAccess =  "11111111111";
                    LstUserGroupToMenu.Add(UserGroupToMenu);
                }

                if (childNode.Nodes.Count > 0)
                {
                    GetAllCheckedBox(childNode);
                }
            }
        }

        private void FormUserGroupToMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3 && btnSave.Enabled)
                btnSave_Click(null, null);

            if (e.KeyCode == Keys.Escape && CurrentState != FormState.View)
                btnCancel_Click(null, null);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadTree_UserGroup();
            LoadTree_Menu();
           // tvMenu.ExpandAll();
            tvUserGroup_AfterSelect(null, null);

            tvMenu_AfterSelect(null, null);
        }

        private bool FoundInList(Guid MenuID)
        {
            foreach (UserGroupToMenuEntity item in LstUserGroupToMenu)
            {
                if (item.MenuID == MenuID)
                    return true;
            }
            return false;
        }

        private void FormUserGroupToMenu_Load(object sender, EventArgs e)
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

        private void LoadTree_Menu()
        {
            List<MenuEntity> LstMenus = MenuData.SelectAllParent(SysTypeCode);

            tvMenu.Nodes.Clear();

            TreeNode TnRoot = new TreeNode();
            TnRoot.Text = "[ریشه] اریس";
            TnRoot.Tag = new Guid();
            TnRoot.ImageIndex = 0;
            tvMenu.Nodes.Add(TnRoot);

            foreach (MenuEntity item in LstMenus)
            {
                TreeNode TnMenus = new TreeNode();
                TnMenus.Text = "[" + item.MenuCode + "] " + item.MenuTitle;
                TnMenus.Tag = item.MenuID;
                //TnMenus.Expand();
                TnMenus.ImageIndex = 1;
                TnRoot.Nodes.Add(TnMenus);
                FillChild_Menu(TnMenus);
            }
            CurrentState = FormState.View;
        }

        private void FillChild_Menu(TreeNode TnMenus)
        {
            Guid MenuID = new Guid(TnMenus.Tag.ToString());
            List<MenuEntity> LstMenus = MenuData.SelectAllByParent(MenuID, SysTypeCode);

            foreach (MenuEntity item in LstMenus)
            {
                TreeNode TndMenus = new TreeNode();
                TndMenus.Text = "[" + item.MenuCode + "] " + item.MenuTitle;
                TndMenus.Tag = item.MenuID;
             //   TndMenus.Expand();
                TndMenus.ImageIndex = 2;
                TnMenus.Nodes.Add(TndMenus);

                FillChild_Menu(TndMenus);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tvUserGroup_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (NoSelectedNode())
                return;

            Guid UserGroupID = GetCurrentUserGroupID();

            if (UserGroupID == new Guid())
                return;

            LstUserGroupToMenu = UserGroupToMenuData.SelectAllByUserGroupID(UserGroupID);

            TreeNode TnRoot = tvMenu.Nodes[0];
            tvMenu.Nodes[0].Checked = false;
            FillUserCheckBoxes(TnRoot);

            tvMenu_AfterSelect(null, null);

            if (tvGroupUser.SelectedNode.Text.Contains("0001"))
            {
                tvMenu.Enabled = false;
                grdLevelAccess.Enabled = false;
                btnSaveLevel.Enabled = false;
            }
            else
            {
                tvMenu.Enabled = true;
                grdLevelAccess.Enabled = true;
                btnSaveLevel.Enabled = true;
            }
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

        private void tvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LevelAccessBS.Clear();

            if (NoSelectedNode())
                return;

            Guid MenuID = GetCurrentMenuID();

            Guid UserGroupID = GetCurrentUserGroupID();

            if (MenuID == new Guid() || UserGroupID == new Guid())
                return;

            #region [ Fill LevelAccess ]
            for (byte i = 1; i <= 11; i++)
            {
                LevelAccessEntity lvl = new LevelAccessEntity();
                lvl.LevelAccessCode = i;
                LevelAccessBS.Add(lvl);
            }
            grdLevelAccess.Refetch();
            #endregion

            if (tvMenu.SelectedNode.Checked)
            {
                string LevelAccess = UserGroupToMenuData.SelectLevelAccessByMenuID(UserGroupID, MenuID);
                foreach (GridEXRow row in grdLevelAccess.GetRows())
                {
                    LevelAccessEntity lvl = (LevelAccessEntity)row.DataRow;
                    if (LevelAccess.Substring(lvl.LevelAccessCode - 1, 1) == "1")
                        row.CheckState = RowCheckState.Checked;
                    else
                        row.CheckState = RowCheckState.Unchecked;
                }
            }
        }

        private Guid GetCurrentMenuID()
        {
            if (tvMenu.SelectedNode == null || tvMenu.SelectedNode.Text.Contains("00"))
                return new Guid();

            return new Guid(tvMenu.SelectedNode.Tag.ToString());
        }

        private void tvMenu_AfterCheck(object sender, TreeViewEventArgs e)
        {
            CheckedChange(e.Node);
        }

        private void CheckedChange(TreeNode treeNode)
        {
            if (treeNode == null)
                return;
            foreach (TreeNode item in treeNode.Nodes)
            {
                item.Checked = treeNode.Checked;
                
                CheckedChange(item);
            }
        }

        private void btnSaveLevel_Click(object sender, EventArgs e)
        {
            Guid MenuID = GetCurrentMenuID();

            Guid UserGroupID = GetCurrentUserGroupID();

            if (MenuID == new Guid() || UserGroupID == new Guid())
                return;

            string LevelAccess = "";

            foreach (GridEXRow row in grdLevelAccess.GetRows())
            {
                if (row.CheckState == RowCheckState.Checked)
                    LevelAccess += "1";
                else
                    LevelAccess += "0";
            }

            UserGroupToMenuData.UpdateLevelAccess(MenuID, UserGroupID, LevelAccess);
            MessageBox.Show("عملیات ثبت انجام شد");
        }
    }
}