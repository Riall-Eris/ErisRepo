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

namespace Eris.Access
{
    public partial class FormMenu : FormBase
    {
        private MenuEntity CurrentMenu;

        public FormMenu()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (CurrentState != FormState.View)
                if (!SaveMenu())
                    return;

            CurrentState = FormState.Insert;
            txtCode.Tag = new Guid();
            txtName.Tag = GetCurrentMenuID();
            string GroupName = GetCurrentGroupName();
            txtCode.Text = MenuData.GetNextCode(GetCurrentMenuID()).PadLeft(4, '0');
            txtName.Text = "";
            CmbLevel.SelectedIndex = tvMenu.SelectedNode.Level + 1;
            cmbMenuType.SelectedIndex = 3;
            EnableItems(false);
            txtName.Focus();
        }

        private string GetCurrentGroupName()
        {
            if (tvMenu.SelectedNode == null)
                return "";
            return tvMenu.SelectedNode.Text;
        }

        private void EnableItems(bool flg)
        {
            btnEdit.Enabled = btnDelete.Enabled = tvMenu.Enabled = flg;
            btnSave.Enabled = btnCancel.Enabled = !flg;
            grpMenu.Enabled = !flg;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EnableItems(true);
            CurrentState = FormState.View;
            tvMenu_AfterSelect(null, null);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (SaveMenu())
                CurrentState = FormState.View;
        }

        private bool SaveMenu()
        {
            if (!CanSave())
                return false;

            MenuEntity Menu = new MenuEntity();
            Menu.MenuTitle = txtName.Text;
            Menu.MenuParent = new Guid(txtName.Tag.ToString());
            Menu.MenuCode = txtCode.Text;
            Menu.MenuID = new Guid(txtCode.Tag.ToString());
            Menu.MenuLevel = CmbLevel.SelectedIndex;
            Menu.MenuTypeCode = cmbMenuType.SelectedIndex;
            Menu.MenuOrder = int.Parse(txtOrder.Text);

            MenuBussiness uBLL = new MenuBussiness();
            if (Menu.MenuID == new Guid())
            {
                Menu.MenuID = uBLL.Insert(Menu);
                if (GetCurrentMenuID() != new Guid())
                {
                    tvMenu.SelectedNode.Nodes.Clear();
                    FillChild(tvMenu.SelectedNode);
                }
                else
                {
                    LoadTree();
                    tvMenu_AfterSelect(null, null);
                }
            }
            else
            {
                uBLL.Update(Menu);

                TreeNode Tnd = tvMenu.SelectedNode.Parent;
                tvMenu.SelectedNode.Parent.Nodes.Clear();
                if (new Guid(Tnd.Tag.ToString()) != new Guid())
                    FillChild(Tnd);
                else
                    LoadTree();
            }

            EnableItems(true);
            tvMenu_AfterSelect(null, null);

            return true;
        }

        private bool CanSave()
        {
            FixMenuCode();

            //if (txtCode.Text == string.Empty)
            //{
            //    EMessage.Show("کد وارد نشده است", "خطا در ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtCode.Focus();
            //    return false;
            //}
            //if (MenuData.IsDuplicate(txtCode.Text, new Guid(txtCode.Tag.ToString())))
            //{
            //    EMessage.Show("کد تکراری است", "خطا در ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtCode.Focus();
            //    return false;
            //}

            //if (txtName.Text == string.Empty)
            //{
            //    EMessage.Show("نام وارد نشده است", "خطا در ذخیره", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtName.Focus();
            //    return false;
            //}

            return true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (GetCurrentMenuID() == new Guid())
                return;
            CurrentState = FormState.Update;
            EnableItems(false);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (GetCurrentMenuID() == new Guid())
                return;

            if (tvMenu.SelectedNode.Nodes.Count > 0)
            {
                EMessage.Show("این آیتم بدلیل داشتن زیرمجموعه، غیرقابل حذف می باشد", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (EMessage.Show("آیا آیتم انتخاب شده حذف گردد؟", "حذف", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            TreeNode Tnn = tvMenu.SelectedNode.Parent;
            MenuData.Delete(GetCurrentMenuID());
            tvMenu.Nodes.Remove(tvMenu.SelectedNode);
            //FillChild(Tnn);
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            LoadTree();
        }

        private void LoadTree()
        {
            List<MenuEntity> LstMenus = MenuData.SelectAllParent(3);

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
                TnMenus.Expand();
                TnMenus.ImageIndex = 1;
                TnRoot.Nodes.Add(TnMenus);
                FillChild(TnMenus);
            }
            CurrentState = FormState.View;
        }

        private void FillChild(TreeNode TnMenus)
        {
            Guid MenuID = new Guid(TnMenus.Tag.ToString());
            List<MenuEntity> LstMenus = MenuData.SelectAllByParent(MenuID, 3);

            foreach (MenuEntity item in LstMenus)
            {
                TreeNode TndMenus = new TreeNode();
                TndMenus.Text = "[" + item.MenuCode + "] " + item.MenuTitle;
                TndMenus.Tag = item.MenuID;
                TndMenus.Expand();
                TndMenus.ImageIndex = 2;
                TnMenus.Nodes.Add(TndMenus);

                FillChild(TndMenus);
            }
        }

        private bool NoSelectedNode()
        {
            if (GetMenuCount() == 0)
                return true;

            if (tvMenu.SelectedNode == null)
                return true;

            if (new Guid(tvMenu.SelectedNode.Tag.ToString()) == new Guid())
                return true;

            return false;
        }

        private int GetMenuCount()
        {
            return tvMenu.Nodes[0].Nodes.Count;
        }

        private Guid GetCurrentMenuID()
        {
            if (tvMenu.SelectedNode == null)
                return new Guid();

            return new Guid(tvMenu.SelectedNode.Tag.ToString());
        }

        private void tvMenu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (NoSelectedNode())
                return;

            CurrentMenu = MenuData.Select(GetCurrentMenuID());

            if (CurrentMenu == null)
                return;

            txtCode.Text = CurrentMenu.MenuCode;
            txtCode.Tag = CurrentMenu.MenuID;
            txtName.Text = CurrentMenu.MenuTitle;
            txtName.Tag = CurrentMenu.MenuParent;
            CmbLevel.SelectedIndex = CurrentMenu.MenuLevel;
            cmbMenuType.SelectedIndex = CurrentMenu.MenuTypeCode;
            txtOrder.Text = CurrentMenu.MenuOrder.ToString();
            if (CurrentMenu.MenuLevel == 3)
                btnNew.Enabled = false;
            else
                btnNew.Enabled = true;
        }

        private void txtCode_Leave(object sender, EventArgs e)
        {
            FixMenuCode();
        }

        private void FixMenuCode()
        {
            txtCode.Text = txtCode.Text.Trim().PadLeft(2, '0');
        }

        private void FormMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2 && btnNew.Enabled)
                btnNew_Click(null, null);

            if (e.KeyCode == Keys.F3 && btnSave.Enabled)
                btnSave_Click(null, null);

            if (e.KeyCode == Keys.F4 && btnEdit.Enabled)
                btnEdit_Click(null, null);

            if (e.KeyCode == Keys.F5 && btnDelete.Enabled)
                btnDelete_Click(null, null);

            if (e.KeyCode == Keys.Escape && CurrentState != FormState.View)
                btnCancel_Click(null, null);
        }
    }
}