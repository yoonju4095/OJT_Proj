using SMT_MES.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJT_Proj.pjh.Model.SystemCode
{
    class SC_CorpM
    {
        #region Property

        public string Corp_Cd { get; set; }
        public string Corp_Nm { get; set; }
        public string Addr { get; set; }
        public string Tel { get; set; }
        public string Corp_No { get; set; }
        public string Prs_Nm { get; set; }
        public string BS_Con { get; set; }
        public string BS_Tp { get; set; }
        public string Mail { get; set; }
        public string Fax { get; set; }

        #endregion

        Database db = new Database();
        string query = "";

        public DataTable Select_SC_Corp()
        {
            //사업부관리(Frm_SC_Corp) 호출 Query
            query = $@"SELECT '' AS Status,
                              Corp_Cd,
                              Corp_Nm,
                              Addr,
                              Tel,

                              Corp_No,
                              Prs_Nm,
                              BS_Con,
                              BS_Tp,
                              Mail,

                              Fax,
                              
                              Ins_Emp_No, 
                              Ins_Date_Time, 
                              Upd_Emp_No, 
                              Upd_Date_Time

                         FROM SC_Corp
                        WHERE Corp_Cd = Corp_Cd";

            return db.GetDataTable(query);
            //WHERE Corp_Cd = CASE WHEN '{WrGlobal.LoginID}' = 'Dev' THEN Corp_Cd
            //ELSE '{WrGlobal.Corp_Cd}'
            //END
        }


        public bool Ins_Corp()
        {
            //사업부관리(Frm_SC_Corp) Insert Query
            db.Edit_Property(this);

            query = $@"INSERT INTO SC_Corp(Corp_Cd, Corp_Nm, Corp_No, Addr, Tel
                                         , Prs_Nm, BS_Con, BS_Tp, Mail, Fax
                                         , Ins_Emp_No, Ins_Date_Time)
                            VALUES('{Corp_Cd}',
                                    '{Corp_Nm}',
                                    '{Corp_No}',
                                    '{Addr}',
                                    '{Tel}',

                                    '{Prs_Nm}',
                                    '{BS_Con}',
                                    '{BS_Tp}',
                                    '{Mail}',
                                    '{Fax}',
                                    
                                    'Dev',
                                    GETDATE())";

            return db.ExecuteQuery(query);

            //                            VALUES (CASE WHEN '{WrGlobal.ProcOption["SC"]["Corp_AutoNo"]}' = 'Y' THEN dbo.FN_Create_Cd_Corp()
            //ELSE '{Corp_Cd}'
            //                        END,
        }

        public bool Upd_Corp()
        {
            //사업부관리(Frm_SC_Corp) Update Query
            db.Edit_Property(this);

            query = $@"UPDATE SC_Corp
                          SET Corp_Nm = '{Corp_Nm}',
                              Addr = '{Addr}',
                              Tel = '{Tel}',
                              Corp_No = '{Corp_No}',
                              Prs_Nm = '{Prs_Nm}',

                              BS_Con = '{BS_Con}',
                              BS_Tp = '{BS_Tp}',
                              Mail = '{Mail}',
                              Fax = '{Fax}',

                              Upd_Emp_No = 'Dev',
                              Upd_Date_Time = GETDATE()
                        WHERE Corp_Cd = '{Corp_Cd}'";

            return db.ExecuteQuery(query);
            //Upd_Emp_No = '{WrGlobal.LoginID}',
        }

        public bool Del_Corp()
        {
            //사업부관리(Frm_SC_Corp) Delete Query
            query = $@"DELETE SC_Corp
                        WHERE Corp_Cd = '{Corp_Cd}'";

            return db.ExecuteQuery(query);
        }
    }
}
