
namespace OJT_Proj.lsm
{
    partial class Frm_SC_Corp
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
            this.PnlMainTitle = new DevExpress.XtraEditors.PanelControl();
            this.BtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.LblMainTitle = new DevExpress.XtraEditors.LabelControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.Gc_Corp = new DevExpress.XtraGrid.GridControl();
            this.Gv_Corp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.Btn_Row_Del = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Row_Add = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Row_Ins = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.PnlMainTitle)).BeginInit();
            this.PnlMainTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gc_Corp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gv_Corp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlMainTitle
            // 
            this.PnlMainTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlMainTitle.Controls.Add(this.BtnSave);
            this.PnlMainTitle.Controls.Add(this.LblMainTitle);
            this.PnlMainTitle.Location = new System.Drawing.Point(12, 12);
            this.PnlMainTitle.Name = "PnlMainTitle";
            this.PnlMainTitle.Padding = new System.Windows.Forms.Padding(3);
            this.PnlMainTitle.Size = new System.Drawing.Size(1181, 39);
            this.PnlMainTitle.TabIndex = 268;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.BtnSave.Appearance.Options.UseFont = true;
            this.BtnSave.ImageOptions.Image = global::OJT_Proj.Properties.Resources.saveall_16x16;
            this.BtnSave.Location = new System.Drawing.Point(1073, 8);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(100, 23);
            this.BtnSave.TabIndex = 266;
            this.BtnSave.Text = "저  장";
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // LblMainTitle
            // 
            this.LblMainTitle.Appearance.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.LblMainTitle.Appearance.Options.UseFont = true;
            this.LblMainTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.LblMainTitle.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.LblMainTitle.ImageOptions.Image = global::OJT_Proj.Properties.Resources.bringforward_16x16;
            this.LblMainTitle.Location = new System.Drawing.Point(8, 8);
            this.LblMainTitle.Name = "LblMainTitle";
            this.LblMainTitle.Size = new System.Drawing.Size(300, 23);
            this.LblMainTitle.TabIndex = 59;
            this.LblMainTitle.Text = "사업장정보";
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.CaptionImageOptions.Image = global::OJT_Proj.Properties.Resources.hideproduct_16x16;
            this.groupControl2.Controls.Add(this.Gc_Corp);
            this.groupControl2.Controls.Add(this.panelControl3);
            this.groupControl2.Location = new System.Drawing.Point(12, 57);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1181, 497);
            this.groupControl2.TabIndex = 272;
            this.groupControl2.Text = "사업장정보";
            // 
            // Gc_Corp
            // 
            this.Gc_Corp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gc_Corp.Location = new System.Drawing.Point(2, 58);
            this.Gc_Corp.MainView = this.Gv_Corp;
            this.Gc_Corp.Name = "Gc_Corp";
            this.Gc_Corp.Size = new System.Drawing.Size(1177, 437);
            this.Gc_Corp.TabIndex = 1;
            this.Gc_Corp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Gv_Corp});
            // 
            // Gv_Corp
            // 
            this.Gv_Corp.GridControl = this.Gc_Corp;
            this.Gv_Corp.Name = "Gv_Corp";
            this.Gv_Corp.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.Btn_Row_Del);
            this.panelControl3.Controls.Add(this.Btn_Row_Add);
            this.panelControl3.Controls.Add(this.Btn_Row_Ins);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 23);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Padding = new System.Windows.Forms.Padding(3);
            this.panelControl3.Size = new System.Drawing.Size(1177, 35);
            this.panelControl3.TabIndex = 279;
            // 
            // Btn_Row_Del
            // 
            this.Btn_Row_Del.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Btn_Row_Del.Appearance.Options.UseFont = true;
            this.Btn_Row_Del.ImageOptions.Image = global::OJT_Proj.Properties.Resources.deletetablerows_16x16;
            this.Btn_Row_Del.Location = new System.Drawing.Point(784, 6);
            this.Btn_Row_Del.Name = "Btn_Row_Del";
            this.Btn_Row_Del.Size = new System.Drawing.Size(70, 23);
            this.Btn_Row_Del.TabIndex = 280;
            this.Btn_Row_Del.Text = "행삭제";
            this.Btn_Row_Del.Click += new System.EventHandler(this.Btn_RowEdit);
            // 
            // Btn_Row_Add
            // 
            this.Btn_Row_Add.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Btn_Row_Add.Appearance.Options.UseFont = true;
            this.Btn_Row_Add.ImageOptions.Image = global::OJT_Proj.Properties.Resources.inserttablerowsbelow_16x16;
            this.Btn_Row_Add.Location = new System.Drawing.Point(708, 6);
            this.Btn_Row_Add.Name = "Btn_Row_Add";
            this.Btn_Row_Add.Size = new System.Drawing.Size(70, 23);
            this.Btn_Row_Add.TabIndex = 279;
            this.Btn_Row_Add.Text = "행추가";
            this.Btn_Row_Add.Click += new System.EventHandler(this.Btn_RowEdit);
            // 
            // Btn_Row_Ins
            // 
            this.Btn_Row_Ins.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Btn_Row_Ins.Appearance.Options.UseFont = true;
            this.Btn_Row_Ins.ImageOptions.Image = global::OJT_Proj.Properties.Resources.inserttablerowsabove_16x161;
            this.Btn_Row_Ins.Location = new System.Drawing.Point(632, 6);
            this.Btn_Row_Ins.Name = "Btn_Row_Ins";
            this.Btn_Row_Ins.Size = new System.Drawing.Size(70, 23);
            this.Btn_Row_Ins.TabIndex = 278;
            this.Btn_Row_Ins.Text = "행삽입";
            this.Btn_Row_Ins.Click += new System.EventHandler(this.Btn_RowEdit);
            // 
            // Frm_SC_Corp
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 566);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.PnlMainTitle);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F);
            this.Name = "Frm_SC_Corp";
            this.Text = "SC_Corp";
            this.Load += new System.EventHandler(this.Frm_SC_Corp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PnlMainTitle)).EndInit();
            this.PnlMainTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Gc_Corp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gv_Corp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl PnlMainTitle;
        private DevExpress.XtraEditors.SimpleButton BtnSave;
        private DevExpress.XtraEditors.LabelControl LblMainTitle;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl Gc_Corp;
        private DevExpress.XtraGrid.Views.Grid.GridView Gv_Corp;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton Btn_Row_Del;
        private DevExpress.XtraEditors.SimpleButton Btn_Row_Add;
        private DevExpress.XtraEditors.SimpleButton Btn_Row_Ins;
    }
}