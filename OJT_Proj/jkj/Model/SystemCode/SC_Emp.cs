using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMT_MES.Model;
using System.Data;

namespace OJT_Proj.jkj.Model.SystemCode
{
    class SC_Emp
    {

        public string Emp_No { get; set; }
        public string Emp_Password { get; set; }

        Database db = new Database();
        string query = "";

        public DataRow Select_LoginUser()
        {
            //로그인시 로그인 유저 조회
            db.Edit_Property(this);

            query = $@"SELECT TOP 1
                              ep.Corp_Cd
                            , cr.Corp_Nm

                            , ep.Emp_No
                            , ep.Emp_Nm

                         FROM SC_Emp ep
                        INNER JOIN SC_Corp cr ON ep.Corp_Cd = cr.Corp_Cd

                        WHERE ep.Use_Yn = 'Y'
                          AND ep.Emp_No = '{Emp_No}'
                          AND ep.Emp_Password = '{Emp_Password}'";

            return db.GetDataRow(query);
        }
    }
}
