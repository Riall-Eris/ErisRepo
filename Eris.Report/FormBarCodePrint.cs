using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Collections;
using FastReport;
using DevComponents.DotNetBar;
using System.Xml.Serialization;
using FAXCOMLib;
using System.Net.Mail;
using System.Configuration;
using FastReport.Utils;

namespace Eris.Reporter
{
    public partial class FormBarCodePrint : Office2007Form
    {
        #region [Private Members]
        private DataSet m_MasterDataSet;
        public Report FReport;
        private string FReportsFolder;
        private string FReportFile;
        private string m_ImagePath;
        private List<ERParameter> m_Param;
        private List<BarCodeModel> m_LstBarCode;
        #endregion

        public static string UserName = string.Empty;

        #region [Form Constractor]
       
        private void InitReport()
        {
            FReport = new Report();
            FReport.Preview = previewControl1;
            
            FReport.Load(FReportFile);
            RegisterData();
            PreviewReport();
        }

        public FormBarCodePrint(List<BarCodeModel> LstBarCode, string FilePath, List<ERParameter> parameter, string ImagePath)
        {
           // SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            InitializeComponent();
            m_LstBarCode = LstBarCode;
            FReportFile = FilePath;
            FReportsFolder = Path.GetFullPath(FilePath);
            CheckFileExist(FilePath);
            m_Param = parameter;
            m_ImagePath = ImagePath;
            btnRefreshShow_Click(null, null);
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
            if (File.Exists(FilePath))
                return;
            FastReport.Report r = new Report();

            r.Save(FilePath);
            r.Dispose();
        }
        #endregion

        #region [Form Events]
        private void RegisterData()
        {
            FReport.RegisterData(m_MasterDataSet, "MasterData");

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
            PreviewReport();
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

            DataTable Logo = new DataTable("Logo");
            DataColumn dc;
            DataRow dr;
            dc = new DataColumn("ImageLogo", typeof(Image));
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

            dr["ImageLogo"] = Img;

            Logo.Rows.Add(dr);

            FReport.RegisterData(ds, "Logo");

        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            DesignReport();
        }

        private void FormBarCodePrint_Load(object sender, EventArgs e)
        {
           // btnDesign.Visible = false;
            if (UserName.Trim().ToLower() == "admin")
                btnDesign.Visible = true;

            Config.ReportSettings.ShowPerformance = true;
            PreviewReport();
        }

        private void FormBarCodePrint_FormClosed(object sender, FormClosedEventArgs e)
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRefreshShow_Click(object sender, EventArgs e)
        {
            //SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.ResizeRedraw, true);
            //InitializeComponent();
            List<BarCodeModel> LstBarCode = new List<BarCodeModel>();
            foreach (BarCodeModel item in m_LstBarCode)
            {
                decimal RowCount = item.Amount / txtRowCount.Value;
                long TotalRow = (long)RowCount;
                if (RowCount > TotalRow)
                    TotalRow++;
                for (int i = 0; i < TotalRow; i++)
                {
                    BarCodeModel BarCode = new BarCodeModel();
                    BarCode.BarCode = item.BarCode;
                    BarCode.KalaCode = item.KalaCode;
                    BarCode.KalaName = item.KalaName;
                    LstBarCode.Add(BarCode);
                }
            }
            m_MasterDataSet = ConvertObjectToDataSet((object)LstBarCode);
            InitReport();
        }
        #endregion
    }
    public class BarCodeModel
    {
        public BarCodeModel() { }

        public string BarCode { get; set; }
        public string KalaName { get; set; }
        public string KalaCode { get; set; }
        public long Amount { get; set; }
    }
}