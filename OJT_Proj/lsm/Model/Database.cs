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
            {   //�̹����� null(No Image Data)�ΰ�� null�� �Է�
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
            //  Insert �� �����ͺ��̽��� ���̺� �̸��� �����Ѵ�.
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
            //�Ӽ��� �������ȷ�(')������ '' �� ����
            foreach (PropertyInfo property in cls.GetType().GetProperties())    //�Ӽ�(Property) Ž��
            {
                string value = Convert.ToString(property.GetValue(cls));    //�Ӽ��� ��������

                if (value.Contains("'"))
                {
                    //��������ǥ ������ ����
                    value = value.Replace("'", "''");
                    property.SetValue(cls, value);
                }
            }
        }

        //�α� �ۼ�
        private void WriteLog(string logTxt)
        {
            //�α����� Ž��
            string path = System.IO.Directory.GetCurrentDirectory();
            string fileName = "Log_ExcuteDB.txt";
            string fullPath = path + "\\" + fileName;

            //���� ��ο� ������ �ִ��� Ȯ��
            if (System.IO.File.Exists(fullPath))
            {
                //������ �ؽ�Ʈ���� �ۼ�
                WriteQuery(fullPath, logTxt);
            }
            else
            {
                //������ ���� ���� �� �ۼ�
                System.IO.FileStream file = System.IO.File.Create(fullPath);
                file.Close();

                WriteQuery(fullPath, logTxt);
            }
        }

        private void WriteQuery(string path, string log)
        {
            //�ؽ�Ʈ���� �ۼ�
            string LogFront = "DB Query Fail\nError Query : \n";
            string LogBack = "\nLogTime : " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\n\n";

            System.IO.StreamWriter writer;
            writer = System.IO.File.AppendText(path);
            writer.WriteLine(LogFront + log + LogBack);
            writer.Close();
        }
    }
}
