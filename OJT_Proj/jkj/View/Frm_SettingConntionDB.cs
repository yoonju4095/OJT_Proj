using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Win32;

namespace OJT_Proj.jkj.View
{
    public partial class Frm_SettingConntionDB : DevExpress.XtraEditors.XtraForm
    {
        public Frm_SettingConntionDB()
        {
            InitializeComponent();
        }

        // 취소
        private void BtnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // DB 연결 테스트
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
            }
        }

        // 레지스트리에 db서버, db명 저장
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

        // 저장 버튼 클릭
        public void BtnSave_Click(object sender, EventArgs e)
        {
            WriteRegValue();
            this.DialogResult = DialogResult.OK;
        }

        // 레지스트리에 저장된 db서버, db명을 가져옴
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
            catch
            {

            }
        }

        // 해당 폼이 로드 될 때 ReadRegConInfo 메소드 호출
        private void Frm_SetConnectionDB_Load(object sender, EventArgs e)
        {
            ReadRegConInfo();
        }
    }
}