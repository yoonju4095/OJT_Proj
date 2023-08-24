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

using Microsoft.Win32;
using System.Globalization;
using System.IO;
using System.Xml;
using SMT_MES.Model;
using OJT_Proj.jkj.Model.SystemCode;
using OJT_Proj.jkj.Controls;

namespace OJT_Proj.pjh.View
{
    public partial class Frm_LoginLogin : DevExpress.XtraEditors.XtraForm
    {
        private string userId = string.Empty;
        private string saveYn = string.Empty;

        string Uid = "";
        string Pwd = "";
        string FormID = "";
        string AutoOK = "";
        string Machine = "";

        public Frm_LoginLogin()
        {
            InitializeComponent();

            ReadXMLSetup();
        }

        #region Event

        private void Frm_Login_Load(object sender, EventArgs e)
        {
            ReadRegValue();

            if (saveYn == "Y")
            {
                Txt_ID.Text = userId;
                Chk_SaveID.Checked = true;

                Txt_PW.Focus();
            }

            if (AutoOK == "Y")
            {
                Txt_ID.Text = Uid;
                Txt_PW.Text = Pwd;

                WrGlobal.m_DisplayAuto = true;

                LoginProcess();
            }

        }

        private void Frm_Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            WriteRegValue();
        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            LoginProcess();
        }

        private void Enter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (sender == Txt_ID)
                {
                    Txt_PW.Focus();
                }
                else
                {
                    Btn_Login_Click(sender, e);
                }
            }
        }

        #endregion Event End

        #region Registry

        public void ReadRegValue()
        {
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SMARTMES", true);

                if (reg == null)
                {
                    return;
                }

                userId = (string)reg.GetValue("UserId");
                saveYn = (string)reg.GetValue("SaveYn");

                reg.Close();
            }
            catch (Exception ex)
            {
            }
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

                reg.SetValue("UserId", Txt_ID.Text.Trim());
                reg.SetValue("SaveYn", Chk_SaveID.Checked.ToString() == "True" ? "Y" : "N");

                reg.Close();
            }
            catch (Exception ex)
            {

            }
        }

        #endregion Registry End

        #region 로그인

        private void LoginProcess()
        {
            if (Txt_ID.Text == "")
            {
                MessageBox.Show("ID를 입력해주세요");
                return;
            }

            ReadRegConInfo();

            SC_Emp emp = new SC_Emp();
            emp.Emp_No = Txt_ID.Text;
            emp.Emp_Password = Txt_PW.Text;

            //ID, Pw 일치하는 유저 검색
            DataRow drUser = emp.Select_LoginUser();

            //유저정보가 있으면 진행
            if (drUser != null)
            {
                CreateWrGlobal(drUser);    //Global데이터 입력
                InsertLoGInOutHistory();    //로그인이력 입력

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("ID 또는 비밀번호가 틀렸습니다.");
            }
        }

        private void ReadXMLSetup()
        {

            string url = @"C:\AutoSetup.xml";

            try
            {
                try
                {
                    if (File.Exists(url))   //  xml 파일 존재 유무 검사
                    {
                        XmlTextReader xmlReadData = new XmlTextReader(url);    //  xml 파일 열기

                        while (xmlReadData.Read())
                        {
                            if (xmlReadData.NodeType == XmlNodeType.Element)
                            {
                                switch (xmlReadData.Name)
                                {
                                    case "Uid": Uid = xmlReadData.ReadString().ToString().Trim(); break;
                                    case "Pwd": Pwd = xmlReadData.ReadString().ToString().Trim(); break;

                                    case "FormID": FormID = xmlReadData.ReadString().ToString().Trim(); break;
                                    case "AutoOK": AutoOK = xmlReadData.ReadString().ToString().Trim(); break;
                                    case "Machine": Machine = xmlReadData.ReadString().ToString().Trim(); break;

                                }
                            }
                        }
                        xmlReadData.Close();

                        WrGlobal.m_DisplayMachine = Machine;
                        WrGlobal.m_DisplayFormID = FormID;

                    }

                }
                catch (Exception ex)
                {
                }

            }
            catch (Exception ex)
            {

            }
        }


        public void ReadRegConInfo()
        {
            //Registry에서 DB 연결주소, DB명 불러오기
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\SMARTMES", true);

                if (reg == null)
                {
                    return;
                }

                Database.Url = (string)reg.GetValue("Url");
                Database.DbName = (string)reg.GetValue("DbName");

                reg.Close();
            }
            catch { }
        }

        private void CreateWrGlobal(DataRow dataRow)
        {
            //Global데이터 입력
            WrGlobal.Corp_Cd = dataRow["Corp_Cd"].ToString();       //사업장번호
            WrGlobal.Corp_Nm = dataRow["Corp_Nm"].ToString();       //사업장명
            WrGlobal.LoginID = dataRow["Emp_No"].ToString();        //ID
            WrGlobal.LoginUserNM = dataRow["Emp_Nm"].ToString();    //사용자명

            //Process Option  호출
            try
            {
                SC_Switch procOption = new SC_Switch();
                DataTable dtProcOption = procOption.Select_Switch();

                foreach (DataRow dr in dtProcOption.Rows)
                {
                    string div = Convert.ToString(dr["Task_Div"]);
                    string option = Convert.ToString(dr["Option_Nm"]);
                    string value = Convert.ToString(dr["Value"]);

                    //업무구분
                    if (WrGlobal.ProcOption.ContainsKey(div))
                    {
                        WrGlobal.ProcOption[div].Add(option, value);
                    }
                    else
                    {
                        WrGlobal.ProcOption.Add(div, new Dictionary<string, string>() { { option, value } });
                    }
                }
                //CodeOption 호출
                SC_CdOption cdOption = new SC_CdOption();
                DataTable dtCdOption = cdOption.Select_CdOption();
                foreach (DataRow dr in dtCdOption.Rows)
                {
                    string div = Convert.ToString(dr["Cd_Div_Cd"]);
                    string fieldNm = Convert.ToString(dr["Field_ID"]);
                    string caption = Convert.ToString(dr["Caption_Nm"]);
                    int disp_Seq = dr["Disp_Seq"].ConvertString_Null_To_Empty() == "" ? 99 : dr["Disp_Seq"].ConvertInt_Null_To_Zero();
                    bool disp = Convert.ToString(dr["Disp_Yn"]) == "Y" ? true : false;
                    bool lockYn = Convert.ToString(dr["Lock_Yn"]) == "Y" ? true : false;

                    //Option 목록
                    WrGlobal.CodeOption optionList = new WrGlobal.CodeOption { Nm = caption, Disp_Seq = disp_Seq, DispYn = disp, LockYn = lockYn };

                    //옵션구분 존재 확인
                    if (WrGlobal.CdOption.ContainsKey(div))
                    {
                        //옵션구분이 존재시
                        WrGlobal.CdOption[div].Add(fieldNm, optionList);
                    }
                    else
                    {
                        //옵션구분이 없을 시
                        WrGlobal.CdOption.Add(div, new Dictionary<string, WrGlobal.CodeOption>() { { fieldNm, optionList } });
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void InsertLoGInOutHistory()
        {
            //로그인이력 입력

            SC_LoginOut_History loginOut = new SC_LoginOut_History();

            loginOut.Emp_No = WrGlobal.LoginID;
            loginOut.Login_Time = DateTime.Now;
            loginOut.Login_IP = WrGlobal.IpAddress;

            loginOut.Ins_LoginOut_History();

            WrGlobal.LoginTime = loginOut.Login_Time;
        }

        #endregion 로그인 End

        private void Btn_Setting_Click(object sender, EventArgs e)
        {
            Frm_SettingConntionDB setting = new Frm_SettingConntionDB();
            setting.ShowDialog();
        }

        private void Btn_Exit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

    }
}