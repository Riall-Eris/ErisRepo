namespace Eris.Access
{
    partial class FormUserGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserGroup));
            Janus.Windows.GridEX.GridEXLayout grdUserGroup_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grpUserGroup = new System.Windows.Forms.GroupBox();
            this.txtUserGroupCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtUserGroupName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpbtn = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.grdUserGroup = new Janus.Windows.GridEX.GridEX();
            this.UserGroupBS = new System.Windows.Forms.BindingSource(this.components);
            this.grpUserGroup.SuspendLayout();
            this.grpbtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserGroupBS)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "rubic.png");
            this.imageList1.Images.SetKeyName(1, "products.png");
            this.imageList1.Images.SetKeyName(2, "Ingredients.png");
            // 
            // grpUserGroup
            // 
            this.grpUserGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpUserGroup.Controls.Add(this.txtUserGroupCode);
            this.grpUserGroup.Controls.Add(this.label2);
            this.grpUserGroup.Controls.Add(this.txtUserGroupName);
            this.grpUserGroup.Controls.Add(this.label1);
            this.grpUserGroup.Enabled = false;
            this.grpUserGroup.Location = new System.Drawing.Point(339, 12);
            this.grpUserGroup.Name = "grpUserGroup";
            this.grpUserGroup.Size = new System.Drawing.Size(496, 130);
            this.grpUserGroup.TabIndex = 2;
            this.grpUserGroup.TabStop = false;
            // 
            // txtUserGroupCode
            // 
            this.txtUserGroupCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserGroupCode.Location = new System.Drawing.Point(353, 38);
            this.txtUserGroupCode.MaxLength = 10;
            this.txtUserGroupCode.Name = "txtUserGroupCode";
            this.txtUserGroupCode.Size = new System.Drawing.Size(56, 23);
            this.txtUserGroupCode.TabIndex = 0;
            this.txtUserGroupCode.Text = " ";
            this.txtUserGroupCode.Leave += new System.EventHandler(this.txtUserGroupCode_Leave);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(415, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "کد گروه";
            // 
            // txtUserGroupName
            // 
            this.txtUserGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserGroupName.Location = new System.Drawing.Point(172, 77);
            this.txtUserGroupName.MaxLength = 50;
            this.txtUserGroupName.Name = "txtUserGroupName";
            this.txtUserGroupName.Size = new System.Drawing.Size(237, 23);
            this.txtUserGroupName.TabIndex = 1;
            this.txtUserGroupName.Text = " ";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(415, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "نام گروه";
            // 
            // grpbtn
            // 
            this.grpbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbtn.Controls.Add(this.btnRefresh);
            this.grpbtn.Controls.Add(this.btnDelete);
            this.grpbtn.Controls.Add(this.btnEdit);
            this.grpbtn.Controls.Add(this.btnCancel);
            this.grpbtn.Controls.Add(this.btnSave);
            this.grpbtn.Controls.Add(this.btnNew);
            this.grpbtn.Location = new System.Drawing.Point(339, 148);
            this.grpbtn.Name = "grpbtn";
            this.grpbtn.Size = new System.Drawing.Size(496, 76);
            this.grpbtn.TabIndex = 1;
            this.grpbtn.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnRefresh.Image = global::Eris.Access.Properties.Resources.MGenerate;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.Location = new System.Drawing.Point(17, 27);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(79, 36);
            this.btnRefresh.TabIndex = 15;
            this.btnRefresh.Text = "بازخوانی\r\n   F5";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnDelete.Image = global::Eris.Access.Properties.Resources.MDelete;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.Location = new System.Drawing.Point(102, 27);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(71, 36);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "حذف\r\n F8";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnEdit.Image = global::Eris.Access.Properties.Resources.MEdit;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.Location = new System.Drawing.Point(179, 27);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(71, 36);
            this.btnEdit.TabIndex = 14;
            this.btnEdit.Text = "اصلاح\r\n  F4";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancel.Image = global::Eris.Access.Properties.Resources.MRedo;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(256, 27);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 36);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "انصراف\r\n  Esc";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSave.Image = global::Eris.Access.Properties.Resources.MSave;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(333, 27);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 36);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "ثبت\r\nF3";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnNew.Image = global::Eris.Access.Properties.Resources.MNew;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.Location = new System.Drawing.Point(410, 27);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(77, 36);
            this.btnNew.TabIndex = 12;
            this.btnNew.Text = "جدید\r\n F2";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // grdUserGroup
            // 
            this.grdUserGroup.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.False;
            this.grdUserGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdUserGroup.DataSource = this.UserGroupBS;
            this.grdUserGroup.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            grdUserGroup_DesignTimeLayout.LayoutString = resources.GetString("grdUserGroup_DesignTimeLayout.LayoutString");
            this.grdUserGroup.DesignTimeLayout = grdUserGroup_DesignTimeLayout;
            this.grdUserGroup.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic;
            this.grdUserGroup.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdUserGroup.GroupByBoxVisible = false;
            this.grdUserGroup.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.grdUserGroup.Location = new System.Drawing.Point(12, 21);
            this.grdUserGroup.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdUserGroup.Name = "grdUserGroup";
            this.grdUserGroup.RecordNavigator = true;
            this.grdUserGroup.RowFormatStyle.BackColor = System.Drawing.SystemColors.Menu;
            this.grdUserGroup.RowFormatStyle.BackColorGradient = System.Drawing.Color.White;
            this.grdUserGroup.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdUserGroup.Size = new System.Drawing.Size(321, 366);
            this.grdUserGroup.TabIndex = 0;
            this.grdUserGroup.TableHeaderFormatStyle.BackColor = System.Drawing.Color.White;
            this.grdUserGroup.TableHeaderFormatStyle.BackColorGradient = System.Drawing.Color.White;
            this.grdUserGroup.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.grdUserGroup.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.grdUserGroup.VisualStyleAreas.HeadersStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.grdUserGroup.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // UserGroupBS
            // 
            this.UserGroupBS.DataSource = typeof(Eris.Entity.UserGroupEntity);
            // 
            // FormUserGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(847, 400);
            this.Controls.Add(this.grdUserGroup);
            this.Controls.Add(this.grpbtn);
            this.Controls.Add(this.grpUserGroup);
            this.Name = "FormUserGroup";
            this.Text = "گروه کاربران";
            this.Load += new System.EventHandler(this.FormUserGroup_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormUserGroup_KeyDown);
            this.grpUserGroup.ResumeLayout(false);
            this.grpUserGroup.PerformLayout();
            this.grpbtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UserGroupBS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpUserGroup;
        private System.Windows.Forms.TextBox txtUserGroupCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtUserGroupName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpbtn;
        private System.Windows.Forms.ImageList imageList1;
        private Janus.Windows.GridEX.GridEX grdUserGroup;
        private System.Windows.Forms.BindingSource UserGroupBS;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnNew;
    }
}
