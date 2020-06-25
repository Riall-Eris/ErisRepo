namespace Eris.Access
{
    partial class FormUserGroupToMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUserGroupToMenu));
            Janus.Windows.GridEX.GridEXLayout grdLevelAccess_DesignTimeLayout = new Janus.Windows.GridEX.GridEXLayout();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grpbtn = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tvMenu = new System.Windows.Forms.TreeView();
            this.tvGroupUser = new System.Windows.Forms.TreeView();
            this.grdLevelAccess = new Janus.Windows.GridEX.GridEX();
            this.LevelAccessBS = new System.Windows.Forms.BindingSource(this.components);
            this.btnSaveLevel = new System.Windows.Forms.Button();
            this.grpbtn.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdLevelAccess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LevelAccessBS)).BeginInit();
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
            // grpbtn
            // 
            this.grpbtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grpbtn.Controls.Add(this.btnRefresh);
            this.grpbtn.Controls.Add(this.btnCancel);
            this.grpbtn.Controls.Add(this.btnSave);
            this.grpbtn.Location = new System.Drawing.Point(375, 367);
            this.grpbtn.Name = "grpbtn";
            this.grpbtn.Size = new System.Drawing.Size(421, 76);
            this.grpbtn.TabIndex = 2;
            this.grpbtn.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnRefresh.Image = global::Eris.Access.Properties.Resources.MGenerate;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.Location = new System.Drawing.Point(326, 25);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(79, 36);
            this.btnRefresh.TabIndex = 13;
            this.btnRefresh.Text = "بازخوانی\r\n   F5";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnCancel.Image = global::Eris.Access.Properties.Resources.MRedo;
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.Location = new System.Drawing.Point(172, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 36);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "انصراف\r\n  Esc";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSave.Image = global::Eris.Access.Properties.Resources.MSave;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.Location = new System.Drawing.Point(249, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 36);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "ثبت\r\nF3";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tvMenu
            // 
            this.tvMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvMenu.CheckBoxes = true;
            this.tvMenu.ImageIndex = 0;
            this.tvMenu.ImageList = this.imageList1;
            this.tvMenu.Location = new System.Drawing.Point(3, 12);
            this.tvMenu.Name = "tvMenu";
            this.tvMenu.RightToLeftLayout = true;
            this.tvMenu.SelectedImageIndex = 0;
            this.tvMenu.Size = new System.Drawing.Size(353, 143);
            this.tvMenu.TabIndex = 3;
            this.tvMenu.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvMenu_AfterCheck);
            this.tvMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMenu_AfterSelect);
            // 
            // tvGroupUser
            // 
            this.tvGroupUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvGroupUser.ImageIndex = 0;
            this.tvGroupUser.ImageList = this.imageList1;
            this.tvGroupUser.Location = new System.Drawing.Point(375, 12);
            this.tvGroupUser.Name = "tvGroupUser";
            this.tvGroupUser.RightToLeftLayout = true;
            this.tvGroupUser.SelectedImageIndex = 0;
            this.tvGroupUser.Size = new System.Drawing.Size(421, 349);
            this.tvGroupUser.TabIndex = 4;
            this.tvGroupUser.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvUserGroup_AfterSelect);
            // 
            // grdLevelAccess
            // 
            this.grdLevelAccess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdLevelAccess.DataSource = this.LevelAccessBS;
            this.grdLevelAccess.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains;
            grdLevelAccess_DesignTimeLayout.LayoutString = resources.GetString("grdLevelAccess_DesignTimeLayout.LayoutString");
            this.grdLevelAccess.DesignTimeLayout = grdLevelAccess_DesignTimeLayout;
            this.grdLevelAccess.Font = new System.Drawing.Font("Tahoma", 9.75F);
            this.grdLevelAccess.GroupByBoxVisible = false;
            this.grdLevelAccess.HeaderFormatStyle.TextAlignment = Janus.Windows.GridEX.TextAlignment.Center;
            this.grdLevelAccess.Location = new System.Drawing.Point(12, 204);
            this.grdLevelAccess.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdLevelAccess.Name = "grdLevelAccess";
            this.grdLevelAccess.RecordNavigator = true;
            this.grdLevelAccess.RowFormatStyle.BackColor = System.Drawing.SystemColors.Menu;
            this.grdLevelAccess.RowFormatStyle.BackColorGradient = System.Drawing.Color.White;
            this.grdLevelAccess.RowHeaders = Janus.Windows.GridEX.InheritableBoolean.True;
            this.grdLevelAccess.Size = new System.Drawing.Size(344, 239);
            this.grdLevelAccess.TabIndex = 5;
            this.grdLevelAccess.TableHeaderFormatStyle.BackColor = System.Drawing.Color.White;
            this.grdLevelAccess.TableHeaderFormatStyle.BackColorGradient = System.Drawing.Color.White;
            this.grdLevelAccess.TableHeaders = Janus.Windows.GridEX.InheritableBoolean.Default;
            this.grdLevelAccess.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.grdLevelAccess.VisualStyleAreas.HeadersStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            this.grdLevelAccess.VisualStyleAreas.ScrollBarsStyle = Janus.Windows.GridEX.VisualStyle.Office2003;
            // 
            // LevelAccessBS
            // 
            this.LevelAccessBS.DataSource = typeof(Eris.Entity.LevelAccessEntity);
            // 
            // btnSaveLevel
            // 
            this.btnSaveLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveLevel.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSaveLevel.Image = global::Eris.Access.Properties.Resources.MSave;
            this.btnSaveLevel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveLevel.Location = new System.Drawing.Point(12, 161);
            this.btnSaveLevel.Name = "btnSaveLevel";
            this.btnSaveLevel.Size = new System.Drawing.Size(344, 36);
            this.btnSaveLevel.TabIndex = 12;
            this.btnSaveLevel.Text = "ثبت تعییرات";
            this.btnSaveLevel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveLevel.UseVisualStyleBackColor = true;
            this.btnSaveLevel.Click += new System.EventHandler(this.btnSaveLevel_Click);
            // 
            // FormUserGroupToMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(808, 456);
            this.Controls.Add(this.btnSaveLevel);
            this.Controls.Add(this.grdLevelAccess);
            this.Controls.Add(this.tvGroupUser);
            this.Controls.Add(this.tvMenu);
            this.Controls.Add(this.grpbtn);
            this.Name = "FormUserGroupToMenu";
            this.Text = "تعیین سطوح دسترسی گروه ها";
            this.Load += new System.EventHandler(this.FormUserGroupToMenu_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormUserGroupToMenu_KeyDown);
            this.grpbtn.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdLevelAccess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LevelAccessBS)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbtn;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TreeView tvMenu;
        private System.Windows.Forms.TreeView tvGroupUser;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private Janus.Windows.GridEX.GridEX grdLevelAccess;
        private System.Windows.Forms.BindingSource LevelAccessBS;
        private System.Windows.Forms.Button btnSaveLevel;
    }
}
