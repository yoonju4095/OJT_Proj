using SMT_MES.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJT_Proj.pjh.View
{
    public class SC_LoginOut_History
    {
        #region Property

        public string Corp_Cd { get; set; }
        public int Seq { get; set; }
        public string Emp_No { get; set; }
        public DateTime Login_Time { get; set; }
        public DateTime Logout_Time { get; set; }
        public string Login_IP { get; set; }
        #endregion

        Database db = new Database();
        string query;

        public DataTable Select_LoginOut_History(string startDate, string endDate, string dept_Cd = "", string emp_Nm = "")
        {
            query = $@"
                        SELECT 
                              lo.Emp_No
                            , lo.Login_Time
                            , lo.Logout_Time
                            , lo.Login_IP

                            , ep.Emp_Nm
                            , ep.Dept_Cd

                            , dp.Dept_Nm
                        
                        FROM SC_LoginOut_History lo 
                        LEFT JOIN SC_Emp ep ON lo.Corp_Cd = ep.Corp_Cd AND lo.Emp_No = ep.Emp_No
                        LEFT JOIN SC_Dept dp ON lo.Corp_Cd = dp.Corp_Cd AND ep.Dept_Cd = dp.Dept_Cd
                        WHERE lo.Corp_Cd = '{WrGlobal.Corp_Cd}'
                          AND lo.Login_Time BETWEEN '{startDate}' AND '{endDate} 23:59:59' ";

            if (Emp_No != "")
            {
                query += $" AND lo.Emp_No LIKE '%{Emp_No}%' ";
            }

            if (dept_Cd != "" && dept_Cd != "ALL")
            {
                query += $" AND ep.Dept_Cd = '{dept_Cd}' ";
            }

            if (emp_Nm != "")
            {
                query += $" AND ep.Emp_Nm LIKE '%{emp_Nm}%' ";
            }

            DataTable dt = db.GetDataTable(query);

            return dt;
        }

        public void Ins_LoginOut_History()
        {
            query = $@"
                        INSERT SC_LoginOut_History
                        (
                            Corp_Cd
                            , Emp_No
                            , Login_Time
                            , Login_IP
                        )
                        VALUES
                        (
                              '{WrGlobal.Corp_Cd}'
                            , '{Emp_No}'
                            , '{Login_Time:yyyy-MM-dd HH:mm:ss}'
                            , '{Login_IP}'
                        )
                    ";

            db.ExecuteQuery(query);
        }

        public void Upd_LoginOut_History()
        {
            query = $@"
                        UPDATE SC_LoginOut_History
                        SET Logout_Time = '{Logout_Time:yyyy-MM-dd HH:mm:ss}'
                        WHERE Corp_Cd = '{WrGlobal.Corp_Cd}'
                        AND Login_Time = '{WrGlobal.LoginTime:yyyy-MM-dd HH:mm:ss}'
                    ";

            db.ExecuteQuery(query);
        }
    }
}
