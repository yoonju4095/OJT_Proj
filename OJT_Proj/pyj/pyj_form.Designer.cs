
using DevExpress.XtraEditors;

namespace OJT_Proj.pyj
{
    partial class pyj_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(pyj_form));
            this.PnlMainTitle = new DevExpress.XtraEditors.PanelControl();
            this.BtnSave = new DevExpress.XtraEditors.SimpleButton();
            this.LblMainTitle = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.Gc_Corp = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.Btn_Row_Del = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Row_Add = new DevExpress.XtraEditors.SimpleButton();
            this.Btn_Row_Ins = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.PnlMainTitle)).BeginInit();
            this.PnlMainTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Gc_Corp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
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
            this.PnlMainTitle.TabIndex = 269;
            // 
            // BtnSave
            // 
            this.BtnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BtnSave.ImageOptions.Image")));
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
            this.LblMainTitle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("LblMainTitle.ImageOptions.Image")));
            this.LblMainTitle.Location = new System.Drawing.Point(8, 8);
            this.LblMainTitle.Name = "LblMainTitle";
            this.LblMainTitle.Size = new System.Drawing.Size(300, 23);
            this.LblMainTitle.TabIndex = 59;
            this.LblMainTitle.Text = "사업장정보";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.Gc_Corp);
            this.groupControl1.Controls.Add(this.panelControl1);
            this.groupControl1.Location = new System.Drawing.Point(12, 57);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1181, 497);
            this.groupControl1.TabIndex = 270;
            this.groupControl1.Text = "사업장정보";
            // 
            // Gc_Corp
            // 
            this.Gc_Corp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Gc_Corp.Font = new System.Drawing.Font("나눔고딕", 9F);
            this.Gc_Corp.Location = new System.Drawing.Point(2, 60);
            this.Gc_Corp.MainView = this.gridView1;
            this.Gc_Corp.Name = "Gc_Corp";
            this.Gc_Corp.Size = new System.Drawing.Size(1177, 435);
            this.Gc_Corp.TabIndex = 1;
            this.Gc_Corp.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.Gc_Corp.Click += new System.EventHandler(this.Gc_Corp_Click);
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.Gc_Corp;
            this.gridView1.Name = "gridView1";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.Btn_Row_Del);
            this.panelControl1.Controls.Add(this.Btn_Row_Add);
            this.panelControl1.Controls.Add(this.Btn_Row_Ins);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(2, 23);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1177, 37);
            this.panelControl1.TabIndex = 0;
            // 
            // Btn_Row_Del
            // 
            this.Btn_Row_Del.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Row_Del.ImageOptions.Image")));
            this.Btn_Row_Del.Location = new System.Drawing.Point(705, 6);
            this.Btn_Row_Del.Name = "Btn_Row_Del";
            this.Btn_Row_Del.Size = new System.Drawing.Size(70, 23);
            this.Btn_Row_Del.TabIndex = 281;
            this.Btn_Row_Del.Text = "행삭제";
            this.Btn_Row_Del.Click += new System.EventHandler(this.Btn_RowEdit);
            // 
            // Btn_Row_Add
            // 
            this.Btn_Row_Add.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Row_Add.ImageOptions.Image")));
            this.Btn_Row_Add.Location = new System.Drawing.Point(629, 6);
            this.Btn_Row_Add.Name = "Btn_Row_Add";
            this.Btn_Row_Add.Size = new System.Drawing.Size(70, 23);
            this.Btn_Row_Add.TabIndex = 280;
            this.Btn_Row_Add.Text = "행추가";
            this.Btn_Row_Add.Click += new System.EventHandler(this.Btn_RowEdit);
            // 
            // Btn_Row_Ins
            // 
            this.Btn_Row_Ins.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("Btn_Row_Ins.ImageOptions.Image")));
            this.Btn_Row_Ins.Location = new System.Drawing.Point(553, 6);
            this.Btn_Row_Ins.Name = "Btn_Row_Ins";
            this.Btn_Row_Ins.Size = new System.Drawing.Size(70, 23);
            this.Btn_Row_Ins.TabIndex = 279;
            this.Btn_Row_Ins.Text = "행삽입";
            this.Btn_Row_Ins.Click += new System.EventHandler(this.Btn_RowEdit);
            // 
            // pyj_form
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1205, 566);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.PnlMainTitle);
            this.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "pyj_form";
            this.Text = "pyj_form";
            ((System.ComponentModel.ISupportInitialize)(this.PnlMainTitle)).EndInit();
            this.PnlMainTitle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Gc_Corp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private PanelControl PnlMainTitle;
        private DevExpress.XtraEditors.SimpleButton BtnSave;
        private DevExpress.XtraEditors.LabelControl LblMainTitle;
        private GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl Gc_Corp;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton Btn_Row_Del;
        private DevExpress.XtraEditors.SimpleButton Btn_Row_Add;
        private DevExpress.XtraEditors.SimpleButton Btn_Row_Ins;
    }
}