using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Eris.Helper
{
    public partial class FormWareMessage : FormBase
    {
        public FormWareMessage(string Msg, string Caption, MessageBoxButtons btns, MessageBoxIcon icon, List<Eris.Entity.WareErrorEntity> Lst)
        {
            InitializeComponent();
            txtMSG.Text = Msg;
            this.Text = Caption;

            btnYes.Visible = false;
            btnOK.Visible = false;
            btnCancel.Visible = false;

            switch (btns)
            {
                case MessageBoxButtons.AbortRetryIgnore:
                    break;
                case MessageBoxButtons.OK:
                    btnOK.Visible = true;
                    btnOK.Text = "تائید";
                    btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
                    break;
                case MessageBoxButtons.OKCancel:
                    btnYes.Visible = true;
                    btnCancel.Visible = true;
                    btnYes.Text = "تائید";
                    btnCancel.Text = "انصراف";
                    btnYes.DialogResult = System.Windows.Forms.DialogResult.OK;
                    btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    break;
                case MessageBoxButtons.RetryCancel:
                    break;
                case MessageBoxButtons.YesNo:
                    btnYes.Visible = true;
                    btnCancel.Visible = true;
                    btnYes.Text = "بلی";
                    btnCancel.Text = "خیر";
                    btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
                    btnCancel.DialogResult = System.Windows.Forms.DialogResult.No;
                    break;
                case MessageBoxButtons.YesNoCancel:
                    break;
                default:
                    break;
            }

            switch (icon)
            {
                case MessageBoxIcon.Error:
                    Img.Image = Eris.Helper.Properties.Resources.Error;
                    break;
                case MessageBoxIcon.Information:
                    Img.Image = Eris.Helper.Properties.Resources.Information;
                    break;
                case MessageBoxIcon.None:
                    break;
                case MessageBoxIcon.Question:
                    Img.Image = Eris.Helper.Properties.Resources.Question;
                    break;
                case MessageBoxIcon.Warning:
                    Img.Image = Eris.Helper.Properties.Resources.Warning;
                    break;
                default:
                    Img.Image = Eris.Helper.Properties.Resources.Error;
                    break;
            }

            JanusSetting.GridFormatConditionSetting(GrdListData, GrdListData.RootTable.Columns[0], 2, Janus.Windows.GridEX.ConditionOperator.Equal, Color.Aqua);
            JanusSetting.GridFormatConditionSetting(GrdListData, GrdListData.RootTable.Columns[0], 3, Janus.Windows.GridEX.ConditionOperator.Equal, Color.Red);
            JanusSetting.GridFormatConditionSetting(GrdListData, GrdListData.RootTable.Columns[0], 4, Janus.Windows.GridEX.ConditionOperator.Equal, Color.DarkOrange);
            JanusSetting.GridFormatConditionSetting(GrdListData, GrdListData.RootTable.Columns[0], 5, Janus.Windows.GridEX.ConditionOperator.Equal, Color.DarkGreen);

            MessageBS.DataSource = Lst;
            GrdListData.Refetch();
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            CreateXLSFile("WareError.xls", GrdListData, Janus.Windows.GridEX.ExportMode.AllRows);
        }
    }
}