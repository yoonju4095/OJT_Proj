
namespace OJT_Proj.jkj.View
{
    partial class Frm_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Login));
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.Btn_Exit = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Setting = new DevExpress.XtraEditors.SimpleButton();
            this.Txt_ID = new DevExpress.XtraEditors.TextEdit();
            this.Txt_PW = new DevExpress.XtraEditors.TextEdit();
            this.Btn_Login = new DevExpress.XtraEditors.SimpleButton();
            this.Chk_SaveID = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_ID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_PW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chk_SaveID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.Btn_Setting);
            this.panelControl1.Controls.Add(this.Btn_Exit);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(861, 33);
            this.panelControl1.TabIndex = 0;
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Exit.Appearance.Options.UseFont = true;
            this.Btn_Exit.Dock = System.Windows.Forms.DockStyle.Right;
            this.Btn_Exit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Exit.ImageOptions.Image")));
            this.Btn_Exit.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Btn_Exit.Location = new System.Drawing.Point(832, 0);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.Btn_Exit.Size = new System.Drawing.Size(29, 33);
            this.Btn_Exit.TabIndex = 1;
            this.Btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            // 
            // Btn_Setting
            // 
            this.Btn_Setting.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Setting.Appearance.Options.UseFont = true;
            this.Btn_Setting.Dock = System.Windows.Forms.DockStyle.Right;
            this.Btn_Setting.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Setting.ImageOptions.Image")));
            this.Btn_Setting.ImageOptions.Location = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.Btn_Setting.Location = new System.Drawing.Point(803, 0);
            this.Btn_Setting.Name = "Btn_Setting";
            this.Btn_Setting.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.Btn_Setting.Size = new System.Drawing.Size(29, 33);
            this.Btn_Setting.TabIndex = 1;
            this.Btn_Setting.Click += new System.EventHandler(this.Btn_Setting_Click);
            // 
            // Txt_ID
            // 
            this.Txt_ID.Location = new System.Drawing.Point(342, 375);
            this.Txt_ID.Name = "Txt_ID";
            this.Txt_ID.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(248)))), ((int)(((byte)(253)))));
            this.Txt_ID.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ID.Properties.Appearance.Options.UseBackColor = true;
            this.Txt_ID.Properties.Appearance.Options.UseFont = true;
            this.Txt_ID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Txt_ID.Size = new System.Drawing.Size(120, 24);
            this.Txt_ID.TabIndex = 1;
            // 
            // Txt_PW
            // 
            this.Txt_PW.Location = new System.Drawing.Point(342, 407);
            this.Txt_PW.Name = "Txt_PW";
            this.Txt_PW.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(248)))), ((int)(((byte)(253)))));
            this.Txt_PW.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_PW.Properties.Appearance.Options.UseBackColor = true;
            this.Txt_PW.Properties.Appearance.Options.UseFont = true;
            this.Txt_PW.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Txt_PW.Size = new System.Drawing.Size(120, 24);
            this.Txt_PW.TabIndex = 2;
            // 
            // Btn_Login
            // 
            this.Btn_Login.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login.Appearance.ForeColor = System.Drawing.Color.White;
            this.Btn_Login.Appearance.Options.UseFont = true;
            this.Btn_Login.Appearance.Options.UseForeColor = true;
            this.Btn_Login.Location = new System.Drawing.Point(345, 437);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.Btn_Login.Size = new System.Drawing.Size(117, 27);
            this.Btn_Login.TabIndex = 3;
            this.Btn_Login.Text = "로그인";
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            // 
            // Chk_SaveID
            // 
            this.Chk_SaveID.Location = new System.Drawing.Point(342, 470);
            this.Chk_SaveID.Name = "Chk_SaveID";
            this.Chk_SaveID.Properties.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chk_SaveID.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.Chk_SaveID.Properties.Appearance.Options.UseFont = true;
            this.Chk_SaveID.Properties.Appearance.Options.UseForeColor = true;
            this.Chk_SaveID.Properties.Caption = "아이디 저장";
            this.Chk_SaveID.Size = new System.Drawing.Size(87, 20);
            this.Chk_SaveID.TabIndex = 4;
            // 
            // Frm_Login
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Stretch;
            this.BackgroundImageStore = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImageStore")));
            this.ClientSize = new System.Drawing.Size(861, 534);
            this.Controls.Add(this.Chk_SaveID);
            this.Controls.Add(this.Btn_Login);
            this.Controls.Add(this.Txt_PW);
            this.Controls.Add(this.Txt_ID);
            this.Controls.Add(this.panelControl1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_Login";
            this.Text = "Frm_Login";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Txt_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_PW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chk_SaveID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.Load += new System.EventHandler(this.Frm_Login_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_Login_FormClosing);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_Setting;
        private DevExpress.XtraEditors.SimpleButton Btn_Exit;
        private DevExpress.XtraEditors.TextEdit Txt_ID;
        private DevExpress.XtraEditors.TextEdit Txt_PW;
        private DevExpress.XtraEditors.SimpleButton Btn_Login;
        private DevExpress.XtraEditors.CheckEdit Chk_SaveID;
    }
}