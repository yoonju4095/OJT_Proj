using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMT_MES.Model;
using System.Data;

namespace OJT_Proj.jkj.Model.SystemCode
{
    class SC_Switch
    {
        Database db = new Database();
        string query = "";

        public DataTable Select_Switch(string task = null)
        {
            //사업부관리(Frm_SC_Corp) 호출 Query
            query = $@"SELECT '' AS Status
                            , Task_Div
                            , Option_Nm
                            , Value
                            , Rmk
                              
                            , Ins_Emp_No
                            , Ins_Date_Time
                            , Upd_Emp_No
                            , Upd_Date_Time

                         FROM SC_Switch
                        WHERE Corp_Cd = '{WrGlobal.Corp_Cd}'";

            if (task != null)
            {
                query += $"\nAND Task_Div = '{task}'";
            }

            return db.GetDataTable(query);
        }
    }
}
