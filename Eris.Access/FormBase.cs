using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eris.Access
{
    public partial class FormBase : Form
    {
        protected FormState CurrentState;

        public FormBase()
        {
            InitializeComponent();
        }

        protected void ShowForm(Form childForm)
        {
            this.Refresh();
            this.MdiParent.Refresh();

            foreach (Form frm in this.MdiParent.MdiChildren)
            {
                if (frm.Name == childForm.Name)
                {
                    frm.Activate();
                    frm.WindowState = FormWindowState.Normal;
                    return;
                }
            }
            childForm.MdiParent = this.MdiParent;
            childForm.WindowState = FormWindowState.Normal;
            childForm.Show();
        }

        protected void ShowMainForm(Form childForm)
        {
            this.Refresh();
            foreach (Form frm in this.MdiChildren)
            {
                if (frm.Name == childForm.Name)
                {
                    frm.Activate();
                    frm.WindowState = FormWindowState.Normal;
                    return;
                }
            }
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void FormBase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                base.ProcessTabKey(true);
                e.Handled = true;
            }
        }

        private void FormBase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape && CurrentState == FormState.View)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }
    }
}
