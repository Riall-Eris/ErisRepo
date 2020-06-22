using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Xml.Serialization;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Eris.Entity;
using FarsiLibrary.Utils;
using DevComponents.DotNetBar;
using FastReport;
using FastReport.Utils;

namespace Eris.Reporter
{
    public partial class ErisReport : Office2007Form
    {
        #region [Private Members]
        private DataSet m_MasterDataSet;
        private DataSet m_DetailDataSet;
        public Report FReport;
        private string FReportFile;
        private string m_ImagePath;
        private DataMode m_DataMode;
        private List<ERParameter> m_Param;
        private string ReportFileName = "";
        private string ReportPath = "";
        private UserEntity CurrentUser;
        #endregion

        #region [Form Constractor]
        public ErisReport(DataSet DataSet, string FileName, List<ERParameter> parameter, UserEntity User)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            InitializeComponent();
            ReportPath = Application.StartupPath;
            m_DataMode = DataMode.AloneData;
            m_MasterDataSet = DataSet;
            m_DetailDataSet = null;
            FReportFile = ReportPath + "\\EReports\\" + FileName;
            CurrentUser = User;
            CheckFileExist(FReportFile);
            m_Param = parameter;
            m_ImagePath = ReportPath + "\\Eris.jpg";
            InitReport();
        }

        public ErisReport(object MasterObject, object DetailObject, string FileName, List<ERParameter> parameter, UserEntity User)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            InitializeComponent();
            ReportPath = Application.StartupPath;
            if (DetailObject == null)
            {
                m_DataMode = DataMode.MasterDetail;
                m_MasterDataSet = ConvertObjectToDataSet(MasterObject);
                m_DetailDataSet = ConvertObjectToDataSet(DetailObject);
            }
            else
            {
                m_DataMode = DataMode.AloneData;
                m_MasterDataSet = ConvertObjectToDataSet(MasterObject);
                m_DetailDataSet = null;
            }
            FReportFile = ReportPath + "\\EReports\\" + FileName;
            CurrentUser = User;
            CheckFileExist(FReportFile);
            m_Param = parameter;
            m_ImagePath = ReportPath + "\\Eris.jpg";
            InitReport();
        }

        private DataSet ConvertObjectToDataSet(object obj)
        {
            string XmlFileName = Application.StartupPath + "\\Temp.Xml";
            XmlSerializer serializer = new XmlSerializer(obj.GetType());

            if (File.Exists(XmlFileName))
                File.Delete(XmlFileName);

            TextWriter writer = new StreamWriter(XmlFileName);
            serializer.Serialize(writer, obj);
            writer.Close();
            DataSet ds = new DataSet();
            ds.ReadXml(XmlFileName);
            File.Delete(XmlFileName);
            return ds;
        }

        private void CheckFileExist(string FilePath)
        {
            string[] ReportPath = FilePath.Split('\\');
            ReportFileName = ReportPath[ReportPath.Length - 1];
            string ReportFilePath = FilePath.Replace(ReportFileName, "");

            if (!Directory.Exists(ReportFilePath))
                Directory.CreateDirectory(ReportFilePath);

            try
            {
                IDataReader dr = GetReportFile(ReportFileName);
                if (dr.Read())
                {
                    Byte[] bt = null;
                    bt = (Byte[])dr["ErisFileDoc"];
                    FileStream fs = new FileStream(FilePath, System.IO.FileMode.Create);

                    fs.Write(bt, 0, bt.Length);
                    fs.Flush();
                    fs.Close();
                }
            }
            catch
            {
 
            }

            if (File.Exists(FilePath))
                return;
            FastReport.Report r = new Report();

            r.Save(FilePath);
            r.Dispose();
            InsertReportFilesIntoDB();
        }

        private IDataReader GetReportFile(string ERName)
        {
            Database db = DatabaseFactory.CreateDatabase(ConfigValues.CnnName);

            //Database db = DatabaseFactory.CreateDatabase();
            DbCommand dbCommand = db.GetSqlStringCommand("SELECT TOP 1 [ErisFileDoc] FROM ERFile WHERE ERName = @ERName");

            db.AddInParameter(dbCommand, "ERName", DbType.String, ERName);

            return db.ExecuteReader(dbCommand);
        }
        
        private void InitReport()
        {
            FReport = new Report();
            FReport.Preview = previewControl1;

            FReport.Load(FReportFile);
            RegisterData();
        }

        #endregion

        #region [Form Events]
        private void RegisterData()
        {
            FReport.RegisterData(m_MasterDataSet, "MasterData");
            if (m_DataMode == DataMode.MasterDetail)
                FReport.RegisterData(m_DetailDataSet, "DetailData");

            SetImage();

            if (m_Param == null)
                return;

            foreach (ERParameter Param in m_Param)
            {
                FReport.SetParameterValue(Param.ParameterName, Param.ParameterValue);
            }
        }

        private void DesignReport()
        {
            if (FReport.IsRunning)
                return;
            FReport.Load(FReportFile);
            RegisterData();
            FReport.Design();

            //  فایل در دیتابیس آپدیت شود
            UpdateDesignedRportFile();

            PreviewReport();
        }

        private void UpdateDesignedRportFile()
        {
            try
            {
                string StrCmd = @"UPDATE ERFile SET 
ErisFileDoc = @ErisFileDoc,
UserEditId = @UserEditId, 
DateEdit = @DateEdit
WHERE ERName = @ERName";

                Database db = DatabaseFactory.CreateDatabase(ConfigValues.CnnName);
                DbCommand dbCommand = db.GetSqlStringCommand(StrCmd);
                byte[] bt;
                FileStream fs = new FileStream(FReportFile, FileMode.Open);
                bt = new byte[fs.Length];
                int fSize = fs.Read(bt, 0, (int)fs.Length);
                fs.Close();

                db.AddInParameter(dbCommand, "ERName", DbType.String, ReportFileName);
                db.AddInParameter(dbCommand, "ErisFileDoc", DbType.Binary, bt);
                db.AddInParameter(dbCommand, "UserEditId", DbType.Guid, CurrentUser.UserId);
                db.AddInParameter(dbCommand, "DateEdit", DbType.String, PersianDateConverter.ToPersianDate(DateTime.Now).ToString("YYYY/MM/DD"));

                db.ExecuteNonQuery(dbCommand);
            }
            catch
            { }
        }

        private void InsertReportFilesIntoDB()
        {
            try
            {
                string StrCmd = @"IF NOT EXISTS (SELECT * FROM ERFile WHERE ERName = @ERName)
INSERT INTO ERFile (ERName, ErisFileDoc, UserSaveId, DateSave, UserEditId, DateEdit) 
          VALUES (@ERName, @ErisFileDoc, @UserSaveId, @DateSave, @UserEditId, @DateEdit)";

                Database db = DatabaseFactory.CreateDatabase(ConfigValues.CnnName);
                DbCommand dbCommand = db.GetSqlStringCommand(StrCmd);
                byte[] bt;
                FileStream fs = new FileStream(FReportFile, FileMode.Open);
                bt = new byte[fs.Length];
                int fSize = fs.Read(bt, 0, (int)fs.Length);
                fs.Close();

                db.AddInParameter(dbCommand, "ERName", DbType.String, ReportFileName);
                db.AddInParameter(dbCommand, "ErisFileDoc", DbType.Binary, bt);
                db.AddInParameter(dbCommand, "UserSaveId", DbType.Guid, CurrentUser.UserId);
                db.AddInParameter(dbCommand, "DateSave", DbType.String, FarsiLibrary.Utils.PersianDateConverter.ToPersianDate(DateTime.Now).ToString("YYY/MM/DD"));
                db.AddInParameter(dbCommand, "UserEditId", DbType.Guid, new Guid());
                db.AddInParameter(dbCommand, "DateEdit", DbType.String, string.Empty);

                db.ExecuteNonQuery(dbCommand);
            }
            catch
            { 
            }
        }

        private void PreviewReport()
        {
            if (FReport.IsRunning)
                return;

            FReport.Load(FReportFile);
            RegisterData();
            FReport.Show();
        }

        private void SetImage()
        {

            DataTable Logo = new DataTable("آرم و لوگو");
            DataColumn dc;
            DataRow dr;
            dc = new DataColumn("آرم", typeof(Image));
            Logo.Columns.Add(dc);

            DataSet ds = new DataSet();
            ds.Tables.Add(Logo);
            dr = Logo.NewRow();

            Image Img = null;

            try
            {
                Img = Image.FromFile(m_ImagePath);
            }
            catch
            {
            }

            dr["آرم"] = Img;

            Logo.Rows.Add(dr);

            FReport.RegisterData(ds, "آرم و لوگو");

        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            DesignReport();
        }

        private void CmbShowType_SelectedIndexChanged(object sender, EventArgs e)
        {
            UIStyle style = (UIStyle)btnChangeSkin.SelectedIndex;
            Office2007ColorTable = UIStyleUtils.GetOffice2007ColorScheme(style);
            Config.UIStyle = style;
            previewControl1.UIStyle = style;
            Refresh();
        }

        private void FormFastReport_Load(object sender, EventArgs e)
        {
            btnChangeSkin.SelectedIndex = (int)Config.UIStyle;

            Config.ReportSettings.ShowPerformance = true;
            PreviewReport();
        }

        private void FormFastReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            FReport.Dispose();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Color color = SystemColors.ControlDark;

            switch (Config.UIStyle)
            {
                case UIStyle.Office2003:
                case UIStyle.Office2007Blue:
                    color = Color.FromArgb(150, 180, 224);
                    break;

                case UIStyle.Office2007Silver:
                    color = Color.FromArgb(156, 160, 167);
                    break;

                case UIStyle.Office2007Black:
                case UIStyle.VistaGlass:
                    color = Color.FromArgb(84, 84, 84);
                    break;
            }

            using (Brush b = new SolidBrush(color))
            {
                g.FillRectangle(b, ClientRectangle);
            }
            using (Brush b = new SolidBrush(Color.FromArgb(128, Color.White)))
            {
                g.FillEllipse(b, new Rectangle(-300, -50, ClientRectangle.Width + 600, 220));
            }
        }

        private void btnSendFax_Click(object sender, EventArgs e)
        {
            if (FReport.IsRunning)
                return;

            Eris.SendAndReceive.Entity.SendFaxEntity SendFax = new SendAndReceive.Entity.SendFaxEntity();
            SendFax.FaxFileName = ExportToPDF();
            //SendFax.FaxNumber = m_FaxNumber;
            //SendFax.FaxSubject = m_FaxSubject;
            //SendFax.FinancialYear = m_FinancialYear;
            //SendFax.GCustomerID = m_GCustomerID;
            //SendFax.GOperID = m_GOperID;
            //SendFax.OperKind = m_OperKind;
            SendFax.GuCode = ConfigValues.User.UserId;
            
            Eris.SendAndReceive.FormFaxInfo frm = new SendAndReceive.FormFaxInfo(SendFax);
            frm.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnEmail_Click(object sender, EventArgs e)
        {
            if (FReport.IsRunning)
                return;

            Eris.SendAndReceive.Entity.SendMailEntity SendMail = new SendAndReceive.Entity.SendMailEntity();
            SendMail.MailFileName = ExportToPDF();
            //SendMail.MailSubject = m_FaxSubject;
            //SendMail.FinancialYear = m_FinancialYear;
            //SendMail.GCustomerID = m_GCustomerID;
            //SendMail.GOperID = m_GOperID;
            //SendMail.OperKind = m_OperKind;
            SendMail.GuCode = ConfigValues.User.UserId;

            Eris.SendAndReceive.FormMailInfo frm = new SendAndReceive.FormMailInfo(SendMail);
            frm.ShowDialog();
        }

        private string ExportToPDF()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\EmailPDF");
            if (!dir.Exists)
                dir.Create();

            Random rnd = new Random();
            rnd.Next(10000);
            string fileName = dir + "\\tmpMail" + rnd.Next(10000).ToString().PadLeft(4, '0') + ".pdf";
            FileInfo fi = new FileInfo(fileName);
            Stream sr = fi.Create();

            FastReport.Export.Pdf.PDFExport imgExp = new FastReport.Export.Pdf.PDFExport();
            imgExp.Export(previewControl1.Report, sr);

            sr.Close();
            return fileName;
        }

        private string ExportToJpg()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\EmailJPG");
            if (!dir.Exists)
                dir.Create();

            Random rnd = new Random();
            rnd.Next(10000);
            string fileName = dir + "\\tmpMail" + rnd.Next(10000).ToString().PadLeft(4, '0') + ".Jpg";
            FileInfo fi = new FileInfo(fileName);
            Stream sr = fi.Create();

            FastReport.Export.Image.ImageExport imgExp = new FastReport.Export.Image.ImageExport();
            imgExp.Export(previewControl1.Report, sr);

            sr.Close();
            return fileName;
        }

        private void FormFastReport_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
                btnDesign_Click(null, null);

            if (e.KeyCode == Keys.F6)
                btnSendFax_Click(null, null);

            if (e.KeyCode == Keys.F7)
                btnEmail_Click(null, null);

            if (e.KeyCode == Keys.F9)
                btnQuickPrint_Click(null, null);

            if (e.KeyCode == Keys.Escape)
                btnExit_Click(null, null);
        }

        private void btnQuickPrint_Click(object sender, EventArgs e)
        {
            previewControl1.Print();
        }
        #endregion
    }
}