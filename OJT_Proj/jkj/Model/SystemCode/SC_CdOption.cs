using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMT_MES.Model;
using System.Data;

namespace OJT_Proj.jkj.Model.SystemCode
{
    class SC_CdOption
    {
        Database db = new Database();
        string query = "";

        public DataTable Select_CdOption(string div = null)
        {
            //사업부관리(Frm_SC_Corp) 호출 Query
            query = $@"SELECT '' AS Status
                            , Cd_Div_Cd
                            , Field_ID
                            , Caption_Nm
                            , Disp_Seq
                            , Disp_Yn
                            , Lock_Yn

                         FROM SC_CdOption";

            if (div != null)
            {
                query += $"\nWHERE Cd_Div_Cd = '{div}'";
            }

            query += $@" ORDER BY 
                         CASE 
                         	WHEN Disp_Seq IS NULL OR ISNULL(Disp_Seq, '0') = '0' THEN 1
                         	ELSE 0 
                         END
                         , Disp_Seq ASC ";

            return db.GetDataTable(query);
        }
    }
}
