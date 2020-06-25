using Eris.Data;
using Eris.Entity;
using Eris.Helper;
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
    public partial class FormCompany : FormBase
    {
        public UserEntity CurrentUser = new UserEntity();
        public string DBName = "";
        private bool m_ForTransfer = false;

        public FormCompany(bool ForTransfer)
        {
            InitializeComponent();
            m_ForTransfer = ForTransfer;
            DBConfigBS.DataSource = DBConfigData.SelectAllCompany();
            DBConfigBS.PositionChanged += DBConfigBS_PositionChanged;
            DBConfigBS_PositionChanged(null, null);
        }

        void DBConfigBS_PositionChanged(object sender, EventArgs e)
        {
            DBConfigYearsBS.Clear();
            if (DBConfigBS.Count == 0)
                return;

            DBConfigYearsBS.DataSource = DBConfigData.SelectAllYear(((DBConfigEntity)DBConfigBS.Current).CompanyNameLatin);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            DBName = ((DBConfigEntity)DBConfigYearsBS.Current).DBName;
            //CompanyName = CmbCompany.Text + " /// " + CmbYears.Text;
            if (ConfigValues.CnnName == DBName)
            {
                EMessage.Show("مقصد انتخاب شده با دوره جاری، یکسان میباشد.", "خطا در انتخاب مقصد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}