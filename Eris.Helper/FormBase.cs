using Janus.Windows.GridEX;
using Janus.Windows.GridEX.Export;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eris.Helper
{
    public partial class FormBase : Form
    {
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

        protected void CreateXLSFile(string XLSFileName, GridEX gridEX, ExportMode exportMode)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "Excel files (*.xls)|*.xls";
                saveFileDialog1.InitialDirectory = Application.StartupPath + "\\Excels";
                saveFileDialog1.FileName = XLSFileName;
                saveFileDialog1.FilterIndex = 2;
                saveFileDialog1.RestoreDirectory = true;
                DialogResult dr = saveFileDialog1.ShowDialog();
                if (dr == DialogResult.Cancel)
                    return;
                if (File.Exists(saveFileDialog1.FileName))
                    File.Delete(saveFileDialog1.FileName);
                GridEXExporter gridEXExporter1 = new GridEXExporter();
                gridEXExporter1.GridEX = gridEX;
                gridEXExporter1.ExportMode = exportMode;
                gridEXExporter1.Export(saveFileDialog1.OpenFile());

                Process process1 = new Process();
                process1.StartInfo.FileName = saveFileDialog1.FileName;
                process1.Start();
            }
            catch (Exception exp)
            {
                EMessage.Show("خطا در ایجاد فایل اکسل\r\n" + exp.Message, "خطا در ایجاد فایل اکسل", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
