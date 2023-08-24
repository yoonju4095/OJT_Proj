using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OJT_Proj.jkj.Controls
{
    public static class cls_ObjectExtended
    {
        public static string ConvertString_Null_To_Empty(this object obj)
        {
            if (obj == null || obj == DBNull.Value)
                return string.Empty;
            else
                return obj.ToString().Trim();
        }

        public static int ConvertInt_Null_To_Zero(this object obj)
        {
            if (obj == null || obj == DBNull.Value || obj.ToString() == "")
                return 0;
            else
                return Convert.ToInt32(obj);
        }
    }
}
