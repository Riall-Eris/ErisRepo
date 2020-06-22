using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Eris.Reporter
{
    public partial class FormReplaceReport : Form
    {
        private SqlConnection SqlCon;
        public FormReplaceReport(string SqlConnectionString)
        {
            SqlCon = new SqlConnection(SqlConnectionString);
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtPath.Text == string.Empty)
            {
                MessageBox.Show("مسیر فایلها را انتخاب نمایید.");
                return;
            }
            string StrCmd = @"IF NOT EXISTS (SELECT * FROM ReportFile WHERE ReportFileName = @ReportFileName)
BEGIN
    INSERT INTO ReportFile (ReportFileName, ReportFileDoc, GCreatedBy, CreatedDate, GLastUpdatedBy, LastUpdatedDate) 
              VALUES (@ReportFileName, @ReportFileDoc, @GCreatedBy, @CreatedDate, @GLastUpdatedBy, @LastUpdatedDate)
END
ELSE
BEGIN
    UPDATE ReportFile SET ReportFileDoc = @ReportFileDoc WHERE ReportFileName = @ReportFileName
END";

            DirectoryInfo dir = new DirectoryInfo(txtPath.Text);

            if (!Directory.Exists(dir.FullName))
                return;

            FileInfo[] files = dir.GetFiles("*.frx");

            SqlCommand Cmd = new SqlCommand(StrCmd, SqlCon);
            if (SqlCon.State != ConnectionState.Open)
                SqlCon.Open();
            foreach (FileInfo item in files)
            {
                try
                {
                    byte[] bt;
                    FileStream fs = new FileStream(item.FullName, FileMode.Open);
                    bt = new byte[fs.Length];
                    int fSize = fs.Read(bt, 0, (int)fs.Length);

                    Cmd.Parameters.Clear();

                    Cmd.Parameters.AddWithValue("ReportFileName", item.Name);
                    Cmd.Parameters.AddWithValue("ReportFileDoc", bt);
                    Cmd.Parameters.AddWithValue("GCreatedBy", new Guid());
                    Cmd.Parameters.AddWithValue("CreatedDate", FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(DateTime.Now).ToString("YYY/MM/DD"));
                    Cmd.Parameters.AddWithValue("GLastUpdatedBy", new Guid());
                    Cmd.Parameters.AddWithValue("LastUpdatedDate", string.Empty);
                    Cmd.ExecuteNonQuery();
                }
                catch
                { }
            }
            SqlCon.Close();
            this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FormReplaceReport_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.F5:
                    btnOk_Click(null, null);
                    break;
                case Keys.Escape:
                    btnCancel_Click(null, null);
                    break;
                case Keys.Enter:
                    base.ProcessTabKey(true);
                    e.Handled = true;
                    break;
                default:
                    break;
            }
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            if (FBrowser.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtPath.Text = FBrowser.SelectedPath;
        }
    }
}