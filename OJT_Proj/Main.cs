using OJT_Proj.jkj.View;
using OJT_Proj.jkj;
using OJT_Proj.pjh;
using OJT_Proj.psm;
using OJT_Proj.pyj;
using OJT_Proj.lsm;
using System;
using System.Windows.Forms;

namespace OJT_Proj
{
    public partial class Main : DevExpress.XtraEditors.XtraForm
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_SC_Corp frm = new Frm_SC_Corp();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //Frm_Login frm = new Frm_Login();
            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    frmMain main = new frmMain();
            //    main.Show();
            //}

            jkj.View.SystemCode.Frm_SC_Corp frm = new jkj.View.SystemCode.Frm_SC_Corp();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            psb_form frm = new psb_form();
            frm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Frm_LoginLogin frm = new Frm_LoginLogin();
            pjh_form frm = new pjh_form();
            frm.ShowDialog();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            pyj_form frm = new pyj_form();
            frm.ShowDialog();
        }
    }
}