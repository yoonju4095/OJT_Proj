
using System;

namespace OJT_Proj.pjh
{
    partial class pjh_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pjh_form));
            this.Gc_Corp = new DevExpress.XtraGrid.GridControl();
            this.Gv_Corp = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.Btn_Row_Ins = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Row_Del = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Row_Add = new DevExpress.XtraEditors.SimpleButton();
            this.PnlMainTitle = new DevExpress.XtraEditors.PanelControl();
            this.BtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.LblMainTitle = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.Gc_Corp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gv_Corp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PnlMainTitle)).BeginInit();
            this.PnlMainTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // Gc_Corp
            // 
            this.Gc_Corp.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Gc_Corp.Location = new System.Drawing.Point(2, 66);
            this.Gc_Corp.MainView = this.Gv_Corp;
            this.Gc_Corp.Name = "Gc_Corp";
            this.Gc_Corp.Size = new System.Drawing.Size(1014, 474);
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
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.groupControl2.AppearanceCaption.Options.UseFont = true;
            this.groupControl2.CaptionImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("groupControl2.CaptionImageOptions.Image")));
            this.groupControl2.Controls.Add(this.panelControl3);
            this.groupControl2.Controls.Add(this.Gc_Corp);
            this.groupControl2.Location = new System.Drawing.Point(8, 56);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1018, 542);
            this.groupControl2.TabIndex = 271;
            this.groupControl2.Text = "사업장정보";
            // 
            // panelControl3
            // 
            this.panelControl3.ContentImageAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.panelControl3.Controls.Add(this.Btn_Row_Ins);
            this.panelControl3.Controls.Add(this.Btn_Row_Del);
            this.panelControl3.Controls.Add(this.Btn_Row_Add);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(2, 33);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(1014, 33);
            this.panelControl3.TabIndex = 1;
            // 
            // Btn_Row_Ins
            // 
            this.Btn_Row_Ins.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Row_Ins.ImageOptions.Image")));
            this.Btn_Row_Ins.Location = new System.Drawing.Point(22, 5);
            this.Btn_Row_Ins.Name = "Btn_Row_Ins";
            this.Btn_Row_Ins.Size = new System.Drawing.Size(90, 22);
            this.Btn_Row_Ins.TabIndex = 282;
            this.Btn_Row_Ins.Text = "행삽입";
            this.Btn_Row_Ins.Click += new System.EventHandler(this.Btn_RowEdit);
            // 
            // Btn_Row_Del
            // 
            this.Btn_Row_Del.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Row_Del.ImageOptions.Image")));
            this.Btn_Row_Del.Location = new System.Drawing.Point(213, 5);
            this.Btn_Row_Del.Name = "Btn_Row_Del";
            this.Btn_Row_Del.Size = new System.Drawing.Size(90, 22);
            this.Btn_Row_Del.TabIndex = 284;
            this.Btn_Row_Del.Text = "행삭제";
            this.Btn_Row_Del.Click += new System.EventHandler(this.Btn_RowEdit);
            // 
            // Btn_Row_Add
            // 
            this.Btn_Row_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Row_Add.ImageOptions.Image")));
            this.Btn_Row_Add.Location = new System.Drawing.Point(118, 5);
            this.Btn_Row_Add.Name = "Btn_Row_Add";
            this.Btn_Row_Add.Size = new System.Drawing.Size(90, 22);
            this.Btn_Row_Add.TabIndex = 283;
            this.Btn_Row_Add.Text = "행추가";
            this.Btn_Row_Add.Click += new System.EventHandler(this.Btn_RowEdit);
            // 
            // PnlMainTitle
            // 
            this.PnlMainTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PnlMainTitle.Controls.Add(this.BtnSave);
            this.PnlMainTitle.Controls.Add(this.LblMainTitle);
            this.PnlMainTitle.Location = new System.Drawing.Point(8, 1);
            this.PnlMainTitle.Name = "PnlMainTitle";
            this.PnlMainTitle.Size = new System.Drawing.Size(1018, 49);
            this.PnlMainTitle.TabIndex = 272;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.ImageOptions.Image")));
            this.BtnSave.Location = new System.Drawing.Point(882, 7);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new System.Drawing.Size(121, 35);
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
            this.LblMainTitle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("LblMainTitle.ImageOptions.Image")));
            this.LblMainTitle.Location = new System.Drawing.Point(16, 9);
            this.LblMainTitle.Name = "LblMainTitle";
            this.LblMainTitle.Size = new System.Drawing.Size(321, 29);
            this.LblMainTitle.TabIndex = 60;
            this.LblMainTitle.Text = "사업장정보";
            // 
            // pjh_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 602);
            this.Controls.Add(this.PnlMainTitle);
            this.Controls.Add(this.groupControl2);
            this.Name = "pjh_form";
            this.Text = "pjh_form";
            this.Load += new System.EventHandler(this.Frm_SC_Corp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Gc_Corp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Gv_Corp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PnlMainTitle)).EndInit();
            this.PnlMainTitle.ResumeLayout(false);
            this.ResumeLayout(false);

        }



        #endregion

        private DevExpress.XtraGrid.GridControl Gc_Corp;
        private DevExpress.XtraGrid.Views.Grid.GridView Gv_Corp;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.SimpleButton Btn_Row_Ins;
        private DevExpress.XtraEditors.SimpleButton Btn_Row_Del;
        private DevExpress.XtraEditors.SimpleButton Btn_Row_Add;
        private DevExpress.XtraEditors.PanelControl PnlMainTitle;
        private DevExpress.XtraEditors.SimpleButton BtnSave;
        private DevExpress.XtraEditors.LabelControl LblMainTitle;
    }
}