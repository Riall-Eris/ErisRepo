namespace Eris.Reporter
{
    partial class FormBarCodePrint
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBarCodePrint));
        this.previewControl1 = new FastReport.Preview.PreviewControl();
        this.groupBox1 = new System.Windows.Forms.GroupBox();
        this.txtRowCount = new System.Windows.Forms.NumericUpDown();
        this.label1 = new System.Windows.Forms.Label();
        this.btnExit = new System.Windows.Forms.Button();
        this.btnRefreshShow = new System.Windows.Forms.Button();
        this.btnDesign = new System.Windows.Forms.Button();
        this.groupBox1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.txtRowCount)).BeginInit();
        this.SuspendLayout();
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
        this.previewControl1.Location = new System.Drawing.Point(0, 43);
        this.previewControl1.Name = "previewControl1";
        this.previewControl1.Size = new System.Drawing.Size(944, 703);
        this.previewControl1.TabIndex = 8;
        this.previewControl1.UIStyle = FastReport.Utils.UIStyle.Office2003;
        // 
        // groupBox1
        // 
        this.groupBox1.Controls.Add(this.txtRowCount);
        this.groupBox1.Controls.Add(this.label1);
        this.groupBox1.Controls.Add(this.btnExit);
        this.groupBox1.Controls.Add(this.btnRefreshShow);
        this.groupBox1.Controls.Add(this.btnDesign);
        this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
        this.groupBox1.Location = new System.Drawing.Point(0, 0);
        this.groupBox1.Name = "groupBox1";
        this.groupBox1.Size = new System.Drawing.Size(944, 43);
        this.groupBox1.TabIndex = 15;
        this.groupBox1.TabStop = false;
        // 
        // txtRowCount
        // 
        this.txtRowCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.txtRowCount.Location = new System.Drawing.Point(749, 15);
        this.txtRowCount.Name = "txtRowCount";
        this.txtRowCount.Size = new System.Drawing.Size(52, 21);
        this.txtRowCount.TabIndex = 16;
        this.txtRowCount.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
        // 
        // label1
        // 
        this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(807, 19);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(125, 13);
        this.label1.TabIndex = 15;
        this.label1.Text = "تعداد برچسب در هر سطر";
        // 
        // btnExit
        // 
        this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnExit.FlatAppearance.BorderColor = System.Drawing.Color.White;
        this.btnExit.Image = global::Eris.Reporter.Properties.Resources.Log_Out_icon16;
        this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnExit.Location = new System.Drawing.Point(12, 12);
        this.btnExit.Name = "btnExit";
        this.btnExit.Size = new System.Drawing.Size(53, 27);
        this.btnExit.TabIndex = 14;
        this.btnExit.Text = "خروج";
        this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnExit.UseVisualStyleBackColor = true;
        this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
        // 
        // btnRefreshShow
        // 
        this.btnRefreshShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        this.btnRefreshShow.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnRefreshShow.FlatAppearance.BorderColor = System.Drawing.Color.White;
        this.btnRefreshShow.Image = global::Eris.Reporter.Properties.Resources.DOTAB;
        this.btnRefreshShow.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnRefreshShow.Location = new System.Drawing.Point(672, 10);
        this.btnRefreshShow.Name = "btnRefreshShow";
        this.btnRefreshShow.Size = new System.Drawing.Size(71, 27);
        this.btnRefreshShow.TabIndex = 0;
        this.btnRefreshShow.Text = "محاسبه";
        this.btnRefreshShow.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnRefreshShow.UseVisualStyleBackColor = true;
        this.btnRefreshShow.Click += new System.EventHandler(this.btnRefreshShow_Click);
        // 
        // btnDesign
        // 
        this.btnDesign.Cursor = System.Windows.Forms.Cursors.Hand;
        this.btnDesign.FlatAppearance.BorderColor = System.Drawing.Color.White;
        this.btnDesign.Image = global::Eris.Reporter.Properties.Resources.DESKTOP;
        this.btnDesign.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        this.btnDesign.Location = new System.Drawing.Point(71, 12);
        this.btnDesign.Name = "btnDesign";
        this.btnDesign.Size = new System.Drawing.Size(105, 27);
        this.btnDesign.TabIndex = 0;
        this.btnDesign.Text = "طراحي گزارش";
        this.btnDesign.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        this.btnDesign.UseVisualStyleBackColor = true;
        this.btnDesign.Click += new System.EventHandler(this.btnDesign_Click);
        // 
        // FormBarCodePrint
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        this.BackColor = System.Drawing.Color.Lavender;
        this.ClientSize = new System.Drawing.Size(944, 746);
        this.Controls.Add(this.previewControl1);
        this.Controls.Add(this.groupBox1);
        this.EnableGlass = false;
        this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.KeyPreview = true;
        this.Name = "FormBarCodePrint";
        this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "تهيه گزارش";
        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        this.Load += new System.EventHandler(this.FormBarCodePrint_Load);
        this.groupBox1.ResumeLayout(false);
        this.groupBox1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.txtRowCount)).EndInit();
        this.ResumeLayout(false);

    }

    #endregion

    private FastReport.Preview.PreviewControl previewControl1;
    private System.Windows.Forms.Button btnDesign;
    private System.Windows.Forms.Button btnExit;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.NumericUpDown txtRowCount;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnRefreshShow;
  }
}

