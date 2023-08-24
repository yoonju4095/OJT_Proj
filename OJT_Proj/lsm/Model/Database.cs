using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Threading;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Configuration;
using System.Reflection;

namespace OJT_Proj.lsm
{
    public class Database
    {
        private SqlConnection adoCon = new SqlConnection();
        private DataView returnView = null;

        public static string DbName = string.Empty;
        public static string Url = string.Empty;

        public Database()
        {
            string conStr = $"Data Source=smtv.iptime.org,2433;"
                          + $"Initial Catalog=develop;"
                          + $"User ID=smtv;"
                          + $"Password=#smtv@9150$";
            adoCon.ConnectionString = conStr;
        }

        public DataTable GetDataTable(string strQuery)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter SqlAdapter = new SqlDataAdapter(strQuery, adoCon);
            try
            {
                SqlAdapter.SelectCommand = new SqlCommand(strQuery, adoCon);
                SqlAdapter.SelectCommand.CommandTimeout = 180;
                SqlAdapter.Fill(ds);

                if (ds.Tables.Count == 0)
                {
                    ds.Tables.Add(new DataTable());
                }

                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                WriteLog(strQuery);
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
            }
        }//end function

        public DataSet GetDataSet(string tableName, string strQuery)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter SqlAdapter = new SqlDataAdapter(strQuery, adoCon);
            try
            {
                SqlAdapter.SelectCommand = new SqlCommand(strQuery, adoCon);
                SqlAdapter.Fill(ds, tableName);
                return ds;

            }
            catch (Exception ex)
            {
                WriteLog(strQuery);
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;

            }
            finally
            {
            }

        }//end function

        public DataRow GetDataRow(string strQuery)
        {

            DataSet ds = new DataSet();
            DataTable dt;
            SqlDataAdapter SqlAdapter = new SqlDataAdapter(strQuery, adoCon);

            try
            {
                SqlAdapter.SelectCommand = new SqlCommand(strQuery, adoCon);
                SqlAdapter.Fill(ds, "OneRow");

                dt = ds.Tables["OneRow"];
                if (dt != null && dt.Rows.Count == 1)
                {
                    return dt.Rows[0];
                }
                return null;
            }
            catch (Exception ex)
            {
                WriteLog(strQuery);
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public DataView GetDataView(string tableName, string strQuery)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter SqlAdapter = new SqlDataAdapter(strQuery, adoCon);
            try
            {
                SqlAdapter.SelectCommand = new SqlCommand(strQuery, adoCon);
                SqlAdapter.SelectCommand.CommandTimeout = 180;
                SqlAdapter.Fill(ds, tableName);

                returnView = ds.Tables[tableName].DefaultView;
                return returnView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
            }
        }

        public bool ExecuteQuery(string strQuery)
        {
            SqlCommand cmd = new SqlCommand(strQuery, adoCon);
            bool blRtv;

            try
            {
                cmd.CommandTimeout = 180;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();

                blRtv = true;
            }
            catch (Exception ex)
            {
                WriteLog(strQuery);
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                blRtv = false;
            }
            finally
            {
                cmd.Connection.Close();
                //a.Dispose();
            }//end try

            return blRtv;

        }//end function

        public bool ExecuteQueryImage(string strQuery, byte[] image)
        {
            SqlCommand cmd = new SqlCommand(strQuery, adoCon);
            if (image == null)
            {   //이미지가 null(No Image Data)인경우 null값 입력
                SqlParameter parameter = new SqlParameter();
                parameter.SqlDbType = SqlDbType.Image;
                parameter.Value = DBNull.Value;
                parameter.ParameterName = "@Pic";

                cmd.Parameters.Add(parameter);
            }
            else
            {
                cmd.Parameters.AddWithValue("@Pic", image);
            }


            bool blRtv = true;

            try
            {
                cmd.CommandTimeout = 180;
                cmd.Connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                blRtv = false;
                MessageBox.Show(ex.Message, "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                cmd.Connection.Close();
                //a.Dispose();
            }//end try

            return blRtv;

        }//end function

        public void WriteBulkInsert(DataTable dt)
        {
            //ExecuteQuery("Truncate Table " + dt.TableName);

            SqlBulkCopy bulkCopy = new SqlBulkCopy(adoCon, SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers | SqlBulkCopyOptions.UseInternalTransaction, null);
            //  Insert 할 데이터베이스의 테이블 이름을 지정한다.
            bulkCopy.DestinationTableName = dt.TableName;
            adoCon.Open();
            bulkCopy.NotifyAfter = 1000;
            bulkCopy.BatchSize = 1000;

            foreach (DataColumn col in dt.Columns)
            {
                bulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
            }

            bulkCopy.WriteToServer(dt);
            adoCon.Close();
        }

        public void Edit_Property(object cls)
        {
            //속성에 작은따옴료(')있으면 '' 로 수정
            foreach (PropertyInfo property in cls.GetType().GetProperties())    //속성(Property) 탐색
            {
                string value = Convert.ToString(property.GetValue(cls));    //속성값 가져오기

                if (value.Contains("'"))
                {
                    //작은따옴표 있으면 수정
                    value = value.Replace("'", "''");
                    property.SetValue(cls, value);
                }
            }
        }

        //로그 작성
        private void WriteLog(string logTxt)
        {
            //로그파일 탐색
            string path = System.IO.Directory.GetCurrentDirectory();
            string fileName = "Log_ExcuteDB.txt";
            string fullPath = path + "\\" + fileName;

            //파일 경로에 파일이 있는지 확인
            if (System.IO.File.Exists(fullPath))
            {
                //있으면 텍스트파일 작성
                WriteQuery(fullPath, logTxt);
            }
            else
            {
                //없으면 파일 생성 후 작성
                System.IO.FileStream file = System.IO.File.Create(fullPath);
                file.Close();

                WriteQuery(fullPath, logTxt);
            }
        }

        private void WriteQuery(string path, string log)
        {
            //텍스트파일 작성
            string LogFront = "DB Query Fail\nError Query : \n";
            string LogBack = "\nLogTime : " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n\n";

            System.IO.StreamWriter writer;
            writer = System.IO.File.AppendText(path);
            writer.WriteLine(LogFront + log + LogBack);
            writer.Close();
        }
    }
}
