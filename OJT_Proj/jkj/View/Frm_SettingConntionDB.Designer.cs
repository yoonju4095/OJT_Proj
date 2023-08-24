
namespace OJT_Proj.jkj.View
{
    partial class Frm_SettingConntionDB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_SettingConntionDB));
            this.PnlMainTitle = new DevExpress.XtraEditors.PanelControl();
            this.LblMainTitle = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.TxtDBName = new DevExpress.XtraEditors.TextEdit();
            this.Btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.TxtUrl = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.Btn_Test = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Cancle = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.PnlMainTitle)).BeginInit();
            this.PnlMainTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtDBName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUrl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMainTitle
            // 
            this.PnlMainTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlMainTitle.Controls.Add(this.LblMainTitle);
            this.PnlMainTitle.Location = new System.Drawing.Point(12, 12);
            this.PnlMainTitle.Name = "PnlMainTitle";
            this.PnlMainTitle.Padding = new System.Windows.Forms.Padding(3);
            this.PnlMainTitle.Size = new System.Drawing.Size(312, 39);
            this.PnlMainTitle.TabIndex = 0;
            // 
            // LblMainTitle
            // 
            this.LblMainTitle.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.LblMainTitle.Appearance.Options.UseFont = true;
            this.LblMainTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LblMainTitle.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.LblMainTitle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("LblMainTitle.ImageOptions.Image")));
            this.LblMainTitle.Location = new System.Drawing.Point(8, 8);
            this.LblMainTitle.Name = "LblMainTitle";
            this.LblMainTitle.Size = new System.Drawing.Size(300, 23);
            this.LblMainTitle.TabIndex = 1;
            this.LblMainTitle.Text = "연결 설정";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl2.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl2.CaptionImageOptions.Image")));
            this.groupControl2.Controls.Add(this.TxtDBName);
            this.groupControl2.Controls.Add(this.TxtUrl);
            this.groupControl2.Controls.Add(this.labelControl2);
            this.groupControl2.Controls.Add(this.labelControl1);
            this.groupControl2.Location = new System.Drawing.Point(12, 57);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Padding = new System.Windows.Forms.Padding(3);
            this.groupControl2.Size = new System.Drawing.Size(312, 89);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "연결 정보";
            // 
            // TxtDBName
            // 
            this.TxtDBName.Location = new System.Drawing.Point(114, 58);
            this.TxtDBName.Name = "TxtDBName";
            this.TxtDBName.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtDBName.Properties.Appearance.Options.UseFont = true;
            this.TxtDBName.Size = new System.Drawing.Size(194, 22);
            this.TxtDBName.TabIndex = 3;
            // 
            // Btn_Save
            // 
            this.Btn_Save.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Save.Appearance.Options.UseFont = true;
            this.Btn_Save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Save.ImageOptions.Image")));
            this.Btn_Save.Location = new System.Drawing.Point(118, 152);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(100, 23);
            this.Btn_Save.TabIndex = 3;
            this.Btn_Save.Text = "저장";
            this.Btn_Save.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // TxtUrl
            // 
            this.TxtUrl.Location = new System.Drawing.Point(114, 29);
            this.TxtUrl.Name = "TxtUrl";
            this.TxtUrl.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtUrl.Properties.Appearance.Options.UseFont = true;
            this.TxtUrl.Size = new System.Drawing.Size(194, 22);
            this.TxtUrl.TabIndex = 2;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Location = new System.Drawing.Point(8, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(100, 23);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "연결 주소";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Location = new System.Drawing.Point(8, 58);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(100, 23);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Database 명";
            // 
            // Btn_Test
            // 
            this.Btn_Test.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Test.Appearance.Options.UseFont = true;
            this.Btn_Test.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Test.ImageOptions.Image")));
            this.Btn_Test.Location = new System.Drawing.Point(12, 152);
            this.Btn_Test.Name = "Btn_Test";
            this.Btn_Test.Size = new System.Drawing.Size(100, 23);
            this.Btn_Test.TabIndex = 2;
            this.Btn_Test.Text = "테스트";
            this.Btn_Test.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // Btn_Cancle
            // 
            this.Btn_Cancle.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Cancle.Appearance.Options.UseFont = true;
            this.Btn_Cancle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.Btn_Cancle.Location = new System.Drawing.Point(224, 152);
            this.Btn_Cancle.Name = "Btn_Cancle";
            this.Btn_Cancle.Size = new System.Drawing.Size(100, 23);
            this.Btn_Cancle.TabIndex = 4;
            this.Btn_Cancle.Text = "취소";
            this.Btn_Cancle.Click += new System.EventHandler(this.BtnCancle_Click);

            // 
            // Frm_SettingConntionDB
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 187);
            this.Controls.Add(this.Btn_Cancle);
            this.Controls.Add(this.Btn_Save);
            this.Controls.Add(this.Btn_Test);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.PnlMainTitle);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(338, 219);
            this.MinimumSize = new System.Drawing.Size(338, 219);
            this.Name = "Frm_SettingConntionDB";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "연결 설정";
            ((System.ComponentModel.ISupportInitialize)(this.PnlMainTitle)).EndInit();
            this.PnlMainTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TxtDBName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtUrl.Properties)).EndInit();
            this.ResumeLayout(false);
            this.Load += new System.EventHandler(this.Frm_SetConnectionDB_Load);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl PnlMainTitle;
        private DevExpress.XtraEditors.LabelControl LblMainTitle;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit TxtDBName;
        private DevExpress.XtraEditors.SimpleButton Btn_Save;
        private DevExpress.XtraEditors.TextEdit TxtUrl;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_Test;
        private DevExpress.XtraEditors.SimpleButton Btn_Cancle;
    }
}