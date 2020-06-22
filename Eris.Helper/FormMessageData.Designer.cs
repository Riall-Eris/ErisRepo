namespace Eris.Helper
{
    partial class FormMessageData
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
            this.components = new System.ComponentModel.Container();
            Janus.Windows.GridEX.GridEXLayout GrdListData_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMessageData));
            this.btnExcel = new System.Windows.Forms.Button();
            this.GrdListData = new Janus.Windows.GridEX.GridEX();
            this.MessageBS = new System.Windows.Forms.BindingSource(this.components);
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnYes = new System.Windows.Forms.Button();
            this.txtMSG = new System.Windows.Forms.TextBox();
            this.Img = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GrdListData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MessageBS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExcel
            // 
            this.btnExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExcel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExcel.Image = global::Eris.Helper.Properties.Resources.MExcel;
            this.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExcel.Location = new System.Drawing.Point(12, 363);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(71, 30);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Text = "اکسل";
            this.btnExcel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // GrdListData
            // 
            this.GrdListData.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.GrdListData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GrdListData.DataSource = this.MessageBS;
            this.GrdListData.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            GrdListData_DesignTimeLayout.LayoutString = resources.GetString("GrdListData_DesignTimeLayout.LayoutString");
            this.GrdListData.DesignTimeLayout = GrdListData_DesignTimeLayout;
            this.GrdListData.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.GrdListData.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.GrdListData.GroupByBoxVisible = false;
            this.GrdListData.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.GrdListData.Location = new System.Drawing.Point(12, 110);
            this.GrdListData.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GrdListData.Name = "GrdListData";
            this.GrdListData.RecordNavigator = true;
            this.GrdListData.RowFormatStyle.BackColor = System.Drawing.SystemColors.Menu;
            this.GrdListData.RowFormatStyle.BackColorGradient = System.Drawing.Color.White;
            this.GrdListData.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.GrdListData.Size = new System.Drawing.Size(759, 227);
            this.GrdListData.TabIndex = 4;
            this.GrdListData.TableHeaderFormatStyle.BackColor = System.Drawing.Color.White;
            this.GrdListData.TableHeaderFormatStyle.BackColorGradient = System.Drawing.Color.White;
            this.GrdListData.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.GrdListData.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.GrdListData.VisualStyleAreas.HeadersStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.GrdListData.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // MessageBS
            // 
            this.MessageBS.DataSource = typeof(Eris.Helper.MessageEntity);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(439, 363);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "انصراف";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnYes
            // 
            this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYes.Location = new System.Drawing.Point(562, 363);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(96, 30);
            this.btnYes.TabIndex = 0;
            this.btnYes.Text = "تائید";
            this.btnYes.UseVisualStyleBackColor = true;
            // 
            // txtMSG
            // 
            this.txtMSG.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMSG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            this.txtMSG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMSG.Location = new System.Drawing.Point(12, 20);
            this.txtMSG.Multiline = true;
            this.txtMSG.Name = "txtMSG";
            this.txtMSG.ReadOnly = true;
            this.txtMSG.Size = new System.Drawing.Size(689, 83);
            this.txtMSG.TabIndex = 3;
            this.txtMSG.TabStop = false;
            this.txtMSG.Text = "اوکی؟";
            // 
            // Img
            // 
            this.Img.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Img.Image = global::Eris.Helper.Properties.Resources.Warning;
            this.Img.Location = new System.Drawing.Point(707, 20);
            this.Img.Name = "Img";
            this.Img.Size = new System.Drawing.Size(64, 64);
            this.Img.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Img.TabIndex = 0;
            this.Img.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(501, 363);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 30);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "تائید";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // FormMessageData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 399);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.GrdListData);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.txtMSG);
            this.Controls.Add(this.Img);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MinimizeBox = false;
            this.Name = "FormMessageData";
            this.ShowInTaskbar = true;
            ((System.ComponentModel.ISupportInitialize)(this.GrdListData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MessageBS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Img;
        private System.Windows.Forms.TextBox txtMSG;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private Janus.Windows.GridEX.GridEX GrdListData;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.BindingSource MessageBS;
    }
}

