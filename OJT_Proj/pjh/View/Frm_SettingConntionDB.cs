using DevExpress.XtraEditors;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OJT_Proj.pjh.View
{
    public partial class Frm_SettingConntionDB : DevExpress.XtraEditors.XtraForm
    {
        public Frm_SettingConntionDB()
        {
            InitializeComponent();
        }

        private void Frm_SetConnectionDB_Load(object sender, EventArgs e)
        {
            ReadRegConInfo();
        }

        public void ReadRegConInfo()
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SMARTMES", true);

                if (reg == null)
                {
                    return;
                }

                TxtUrl.Text = (string)reg.GetValue("Url");
                TxtDBName.Text = (string)reg.GetValue("DbName");

                reg.Close();
            }
            catch { }
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            SqlConnection adoCon = new SqlConnection();
            try
            {
                string str_con = $"Data Source={TxtUrl.Text};Initial Catalog={TxtDBName.Text};User ID=smtv;Password=#smtv@9150$";
                adoCon.ConnectionString = str_con;
                adoCon.Open();

                MessageBox.Show("DB 연결 성공", "DB 연결");
            }
            catch
            {
                if (adoCon.State != ConnectionState.Open)
                {
                    MessageBox.Show("DB 연결 실패", "DB 연결");
                    return;
                }
            }//end try
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            WriteRegValue();
            this.DialogResult = DialogResult.OK;
        }

        public void WriteRegValue()
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SMARTMES", true);

                if (reg == null)
                {
                    reg = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\SMARTMES");
                }

                reg.SetValue("Url", TxtUrl.Text.Trim());
                reg.SetValue("DbName", TxtDBName.Text.Trim().ToUpper());

                reg.Close();
            }
            catch (Exception ex)
            {

            }
        }

        private void BtnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}