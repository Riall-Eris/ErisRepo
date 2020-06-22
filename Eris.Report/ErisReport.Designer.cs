namespace Eris.Reporter
{
  partial class ErisReport
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErisReport));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnChangeSkin = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDesign = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSendFax = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnEmail = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnQuickPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.previewControl1 = new FastReport.Preview.PreviewControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnChangeSkin,
            this.toolStripSeparator1,
            this.btnDesign,
            this.toolStripSeparator4,
            this.btnSendFax,
            this.toolStripSeparator2,
            this.btnEmail,
            this.toolStripSeparator3,
            this.btnQuickPrint,
            this.toolStripSeparator5,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(851, 55);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnChangeSkin
            // 
            this.btnChangeSkin.AutoSize = false;
            this.btnChangeSkin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.btnChangeSkin.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold);
            this.btnChangeSkin.Items.AddRange(new object[] {
            "ویژوال استودیو",
            "آفیس 2003",
            "آفیس 2007 (آبی)",
            "آفیس 2007 (نقره ای)",
            "آفیس 2007 (سیاه)",
            "ویستا شیشه ای"});
            this.btnChangeSkin.Name = "btnChangeSkin";
            this.btnChangeSkin.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnChangeSkin.Size = new System.Drawing.Size(150, 29);
            this.btnChangeSkin.SelectedIndexChanged += new System.EventHandler(this.CmbShowType_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // btnDesign
            // 
            this.btnDesign.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDesign.Image = global::Eris.Reporter.Properties.Resources.custom_reports;
            this.btnDesign.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDesign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDesign.Name = "btnDesign";
            this.btnDesign.Size = new System.Drawing.Size(111, 52);
            this.btnDesign.Text = "طراحی گزارش\r\nF4";
            this.btnDesign.Click += new System.EventHandler(this.btnDesign_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 55);
            // 
            // btnSendFax
            // 
            this.btnSendFax.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSendFax.Image = global::Eris.Reporter.Properties.Resources.fax;
            this.btnSendFax.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSendFax.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSendFax.Name = "btnSendFax";
            this.btnSendFax.Size = new System.Drawing.Size(95, 52);
            this.btnSendFax.Text = "ارسال فکس\r\nF6";
            this.btnSendFax.Visible = false;
            this.btnSendFax.Click += new System.EventHandler(this.btnSendFax_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 55);
            this.toolStripSeparator2.Visible = false;
            // 
            // btnEmail
            // 
            this.btnEmail.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnEmail.Image = global::Eris.Reporter.Properties.Resources.mail;
            this.btnEmail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEmail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEmail.Name = "btnEmail";
            this.btnEmail.Size = new System.Drawing.Size(95, 52);
            this.btnEmail.Text = "ارسال ایمیل\r\nF7";
            this.btnEmail.Visible = false;
            this.btnEmail.Click += new System.EventHandler(this.btnEmail_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 55);
            // 
            // btnQuickPrint
            // 
            this.btnQuickPrint.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnQuickPrint.Image = global::Eris.Reporter.Properties.Resources.Pirinter;
            this.btnQuickPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnQuickPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnQuickPrint.Name = "btnQuickPrint";
            this.btnQuickPrint.Size = new System.Drawing.Size(90, 52);
            this.btnQuickPrint.Text = "چاپ سریع\r\nF9";
            this.btnQuickPrint.Click += new System.EventHandler(this.btnQuickPrint_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 55);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("B Titr", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnClose.Image = global::Eris.Reporter.Properties.Resources.Exit;
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 52);
            this.btnClose.Text = "خروج\r\nEsc";
            this.btnClose.ToolTipText = "Esc";
            this.btnClose.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // previewControl1
            // 
            this.previewControl1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.previewControl1.Buttons = ((FastReport.PreviewButtons)(((((((((((FastReport.PreviewButtons.Print | FastReport.PreviewButtons.Open) 
            | FastReport.PreviewButtons.Save) 
            | FastReport.PreviewButtons.Email) 
            | FastReport.PreviewButtons.Find) 
            | FastReport.PreviewButtons.Zoom) 
            | FastReport.PreviewButtons.Outline) 
            | FastReport.PreviewButtons.PageSetup) 
            | FastReport.PreviewButtons.Edit) 
            | FastReport.PreviewButtons.Watermark) 
            | FastReport.PreviewButtons.Navigator)));
            this.previewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewControl1.Font = new System.Drawing.Font("Tahoma", 8F);
            this.previewControl1.Location = new System.Drawing.Point(0, 55);
            this.previewControl1.Name = "previewControl1";
            this.previewControl1.PageOffset = new System.Drawing.Point(10, 10);
            this.previewControl1.Size = new System.Drawing.Size(851, 368);
            this.previewControl1.TabIndex = 18;
            this.previewControl1.UIStyle = FastReport.Utils.UIStyle.Office2003;
            // 
            // ErisReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(851, 423);
            this.Controls.Add(this.previewControl1);
            this.Controls.Add(this.toolStrip1);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ErisReport";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اریس - پیش نمایش چاپ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormFastReport_FormClosed);
            this.Load += new System.EventHandler(this.FormFastReport_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormFastReport_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripComboBox btnChangeSkin;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    private System.Windows.Forms.ToolStripButton btnDesign;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
    private System.Windows.Forms.ToolStripButton btnSendFax;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    private System.Windows.Forms.ToolStripButton btnEmail;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    private System.Windows.Forms.ToolStripButton btnQuickPrint;
    private FastReport.Preview.PreviewControl previewControl1;
    private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
    private System.Windows.Forms.ToolStripButton btnClose;
  }
}