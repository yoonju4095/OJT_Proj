
namespace OJT_Proj.pjh.View
{
    partial class Frm_LoginLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_LoginLogin));
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
            this.panelControl1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.Btn_Exit);
            this.panelControl1.Controls.Add(this.Btn_Setting);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(986, 51);
            this.panelControl1.TabIndex = 4;
            // 
            // Btn_Exit
            // 
            this.Btn_Exit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Exit.ImageOptions.Image")));
            this.Btn_Exit.Location = new System.Drawing.Point(946, 10);
            this.Btn_Exit.Name = "Btn_Exit";
            this.Btn_Exit.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.Btn_Exit.Size = new System.Drawing.Size(35, 30);
            this.Btn_Exit.TabIndex = 0;
            this.Btn_Exit.Click += new System.EventHandler(this.Btn_Exit_Click);
            // 
            // Btn_Setting
            // 
            this.Btn_Setting.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.Btn_Setting.Appearance.Options.UseForeColor = true;
            this.Btn_Setting.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Setting.ImageOptions.Image")));
            this.Btn_Setting.Location = new System.Drawing.Point(896, 10);
            this.Btn_Setting.Name = "Btn_Setting";
            this.Btn_Setting.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.Btn_Setting.Size = new System.Drawing.Size(35, 30);
            this.Btn_Setting.TabIndex = 0;
            this.Btn_Setting.Click += new System.EventHandler(this.Btn_Setting_Click);
            // 
            // Txt_ID
            // 
            this.Txt_ID.Location = new System.Drawing.Point(370, 404);
            this.Txt_ID.Name = "Txt_ID";
            this.Txt_ID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_ID.Properties.Appearance.Options.UseFont = true;
            this.Txt_ID.Size = new System.Drawing.Size(246, 32);
            this.Txt_ID.TabIndex = 11;
            this.Txt_ID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            // 
            // Txt_PW
            // 
            this.Txt_PW.Location = new System.Drawing.Point(370, 447);
            this.Txt_PW.Name = "Txt_PW";
            this.Txt_PW.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_PW.Properties.Appearance.Options.UseFont = true;
            this.Txt_PW.Size = new System.Drawing.Size(246, 32);
            this.Txt_PW.TabIndex = 10;
            this.Txt_PW.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            // 
            // Btn_Login
            // 
            this.Btn_Login.Appearance.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Login.Appearance.Options.UseFont = true;
            this.Btn_Login.Location = new System.Drawing.Point(370, 493);
            this.Btn_Login.Name = "Btn_Login";
            this.Btn_Login.Size = new System.Drawing.Size(246, 66);
            this.Btn_Login.TabIndex = 8;
            this.Btn_Login.Text = "LOGIN";
            this.Btn_Login.Click += new System.EventHandler(this.Btn_Login_Click);
            this.Btn_Login.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Enter_KeyDown);
            // 
            // Chk_SaveID
            // 
            this.Chk_SaveID.Location = new System.Drawing.Point(446, 565);
            this.Chk_SaveID.Name = "Chk_SaveID";
            this.Chk_SaveID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chk_SaveID.Properties.Appearance.Options.UseFont = true;
            this.Chk_SaveID.Properties.Caption = "Check ID";
            this.Chk_SaveID.Size = new System.Drawing.Size(90, 22);
            this.Chk_SaveID.TabIndex = 9;
            // 
            // Frm_LoginLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(988, 618);
            this.Controls.Add(this.Txt_PW);
            this.Controls.Add(this.Txt_ID);
            this.Controls.Add(this.Chk_SaveID);
            this.Controls.Add(this.Btn_Login);
            this.Controls.Add(this.panelControl1);
            this.Name = "Frm_LoginLogin";
            this.Text = "Frm_Login";
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Txt_ID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Txt_PW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chk_SaveID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_Exit;
        private DevExpress.XtraEditors.SimpleButton Btn_Setting;
        private DevExpress.XtraEditors.TextEdit Txt_PW;
        private DevExpress.XtraEditors.TextEdit Txt_ID;
        private DevExpress.XtraEditors.CheckEdit Chk_SaveID;
        private DevExpress.XtraEditors.SimpleButton Btn_Login;
    }
}