using Eris.Data;
using Eris.Entity;
using Eris.Helper;
using System;
using System.Windows.Forms;

namespace Eris.Access
{
    public partial class FormLogin : FormBase
    {
        public UserEntity CurrentUser = new UserEntity();
        public string DBName = "";

        public FormLogin()
        {
            InitializeComponent();
            DBConfigBS.DataSource = DBConfigData.SelectAllCompany();
            DBConfigBS.PositionChanged += DBConfigBS_PositionChanged;
            DBConfigBS_PositionChanged(null, null);

            DBConfigYearsBS.PositionChanged += DBConfigYearsBS_PositionChanged;
            DBConfigYearsBS_PositionChanged(null, null);
        }

        void DBConfigYearsBS_PositionChanged(object sender, EventArgs e)
        {
            UserBS.Clear();
            if (DBConfigYearsBS.Count == 0)
                return;

            ConfigValues.CnnName = ((DBConfigEntity)DBConfigYearsBS.Current).DBName;

            UserBS.DataSource = UserData.SelectAllByDB(((DBConfigEntity)DBConfigYearsBS.Current).DBName);
        }

        void DBConfigBS_PositionChanged(object sender, EventArgs e)
        {
            DBConfigYearsBS.Clear();
            if (DBConfigBS.Count == 0)
                return;

            DBConfigYearsBS.DataSource = DBConfigData.SelectAllYear(((DBConfigEntity)DBConfigBS.Current).CompanyNameLatin);
            DBConfigYearsBS_PositionChanged(null, null);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string UserName = CmbUsers.Text;
            string Password = CmbUsers.SelectedValue.ToString().ToLower() + CmbYears.SelectedValue.ToString().ToLower() + txtuPW.Text;

            CurrentUser = UserData.SelectByUserPass(UserName, Password);
            if (CurrentUser == null)
            {
                EMessage.Show("اطلاعات وارد شده صحیح نمی باشد و یا حساب کاربری فعال نیست.", "کاربر نامعتبر", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

			if (DBName == ((DBConfigEntity)DBConfigYearsBS.Current).DBName)
			{
				EMessage.Show("سال مالی / شرکت انتخاب شده فعال می باشد.", "انتخاب اشتباه", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

            DBName = ((DBConfigEntity)DBConfigYearsBS.Current).DBName;
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void txtuPW_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnOk_Click(null, null);
        }
    }
}