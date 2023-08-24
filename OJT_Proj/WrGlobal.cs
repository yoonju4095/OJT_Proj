using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SMT_MES.Model
{
    public static class WrGlobal
    {
        public static string LoginID = string.Empty;        // 로그인한 사용자 ID
        public static string LoginUserNM = string.Empty;    // 로그인한 사용자 이름
        public static string Corp_Cd = string.Empty;        // 로그인한 사업장
        public static string Corp_Nm = string.Empty;        // 로그인한 사업장명
        public static DateTime LoginTime;                   // 로그인한 시간(로그아웃 시간 입력용)
        
        public static string HostName = System.Net.Dns.GetHostName();   //클라이언트 HostName
        public static string IpAddress = System.Net.Dns.GetHostAddresses(HostName).FirstOrDefault(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).ToString();

        //Process 옵션 : SC_Switch Table 에서 가져옴
        public static Dictionary<string, Dictionary<string, string>> ProcOption = new Dictionary<string, Dictionary<string, string>>();

        //Code 옵션 : SC_CdOption Table에서 가져옴
        public struct CodeOption
        {
            public string Nm;   //GridView Header 표기명
            public int Disp_Seq; //Column Edit 활성화화 여부(true:수정가능, false:수정불가)
            public bool DispYn; //Column Visible 여부(true:표기, false:숨김)
            public bool LockYn; //Column Edit 활성화화 여부(true:수정가능, false:수정불가)
        }
        public static Dictionary<string, Dictionary<string, CodeOption>> CdOption = new Dictionary<string, Dictionary<string, CodeOption>>();

        //기타
        public static Color EditBgColor = Color.PapayaWhip; //변경허용 Column 배경색

        //자동모니터링용
        public static bool   m_DisplayAuto    = false;
        public static string m_DisplayFormID  = "";
        public static string m_DisplayMachine = "";
                

        //FTP
        public static string m_ftpServerip = "ftp://smtv.iptime.org:21/FTP";
        public static string m_ftpFolderPath = Database.DbName;

        public static string m_ftpServerUser = "SMT";
        public static string m_ftpServerPwd = "@admin9150";



    }
}
