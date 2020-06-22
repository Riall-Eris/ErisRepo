using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Eris
{
    public partial class FormConfig : Eris.FormBase
    {
        public FormConfig()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!TestConnection())
                return;

            if (!CreateFile())
                return;

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private bool CreateFile()
        {
            bool Create = true;
            try
            {
                string fileCng = Application.StartupPath + "\\Eris.exe.config";

                using (var stream = File.Open(fileCng, FileMode.OpenOrCreate))
                {
                    stream.Position = stream.Length;
                    using (var writer = new StreamWriter(stream))
                    {
                        writer.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                        writer.WriteLine("<configuration>");
                        writer.WriteLine("  "+"<appSettings>");
                        writer.WriteLine("    "+"<add key=\"SND\" value=\"" +  txtServer.Text.Trim() + "\"/>");
                        writer.WriteLine("    "+"<add key=\"SID\" value=\"" + txtUID.Text.Trim()+ "\"/>");
                        writer.WriteLine("    "+"<add key=\"SPD\" value=\"" + txtPWD.Text.Trim()+ "\"/>");
                        writer.WriteLine("    "+"<add key=\"EBD\" value=\"" + txtDBName.Text.Trim()+ "\"/>");
                        writer.WriteLine("  "+"</appSettings>");
                        writer.WriteLine("<startup>");
                        writer.WriteLine("<supportedRuntime version=\"v4.0\" sku=\".NETFramework,Version=v4.5\"/>");
                        writer.WriteLine("</startup>");
                        writer.WriteLine("</configuration>");
                    }
                }
            }
            catch (Exception exp)
            {
                Create = false;
                MessageBox.Show(exp.Message);
            }
            return Create;
        }

        private bool TestConnection()
        {
            bool Create = true;
            string ConStr = "Server=" + txtServer.Text.Trim() + ";Database=Master;Persist Security Info=True;MultipleActiveResultSets=true;User ID=" + txtUID.Text.Trim() + ";Password=" + txtPWD.Text.Trim() + ";";
            SqlConnection sqlCon = new SqlConnection(ConStr);
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT TOP 1 1 FROM sys.databases WHERE [name] LIKE '" + txtDBName.Text.Trim() + "%'", sqlCon);
                sqlCon.Open();
                object obj = cmd.ExecuteScalar();
                if (obj != null && obj.ToString() == "1")
                    Create = true;
                else
                    Create = false;
            }
            catch (Exception exp)
            {
                Create = false;
                MessageBox.Show(exp.Message,"خطا در ارتباط با سرویس دهنده لطفا نام سرویس دهنده را بررسی نمایید");
            }
            finally
            {
                sqlCon.Close();
            }
            return Create;
        }
    }
}