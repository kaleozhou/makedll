using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MySql.Data .MySqlClient ;
using System.Data.OleDb;

namespace Common
{
  public  abstract class ConnectData
    {
     public static string DataType = "MSSQL";
     public  abstract bool Open();
     public  abstract  string  TestOpen(string serverIP,string dataName,string userName,string pwd);    
     public  abstract void  Close();
     public  abstract DataSet  Fill(string Sql);
     public  abstract bool ExecNonSql(string Sql);
     public  string GetData(string Sql)
     {
         try
         {
             DataSet Ds = Fill(Sql);
             DataTable MyDt = Ds.Tables[0];
             if (MyDt.Rows.Count > 0)
                 return MyDt.Rows[0][0].ToString();
             else
                 return "";
         }
         catch
         {
             return "";
         }
     }
     public  DataRow GetRs(string Sql)
     {

         DataRow Rs=null;
         try
         {
             DataSet Ds = Fill(Sql);
             DataTable MyDt = Ds.Tables[0];
             if (MyDt.Rows.Count > 0)
                 Rs = MyDt.Rows[0];
         }
         catch
         { }        
         return Rs;
     }
     /// <summary>
     /// 合并数据表
     /// </summary>
     /// <param name="Dt">表1</param>
     /// <param name="Dt1">表2</param>
     /// <param name="Num">要合并成的记录数</param>
     /// <returns></returns>
     public DataTable HebingDataTable(DataTable Dt, DataTable Dt1, int Num)
     {
         int i = 0, j = 0, k = 0;

         int Num1 = Num - Dt.Rows.Count;
         for (i = 0; i < Dt1.Rows.Count; i++)
         {
             try
             {
                 DataRow Rs = Dt.NewRow();
                 for (j = 0; j < Dt.Columns.Count; j++)
                 {
                     Rs[j] = Dt1.Rows[i][j];
                 }
                 Dt.Rows.Add(Rs);
                 k = k + 1;
             }
             catch
             { }
             if (k == Num1) break;
         }
         return Dt;
     }
     public string Serverip, DataName, UserName, Pwd;
     public static string StaticServerIP, StaticDataName, StaticUserName, StaticPwd;
     public static  string CheckSql(string Sql)
    {
         Sql=Sql.ToLower() ;
         Sql=Sql.Replace ("'","’");
         Sql=Sql.Replace("%", "％");
         Sql=Sql.Replace( ",", "，");
         Sql=Sql.Replace( " ", "");
         Sql=Sql.Replace( "insert", "ＩnＳerＴ");
         Sql=Sql.Replace( "select", "ＳeＬecＴ");
         Sql=Sql.Replace( "update", "ＵpＤatＥ");
         Sql=Sql.Replace( "count", "ＣoＵnt");
         Sql=Sql.Replace( "delete", "ＤeＬetＥ");
         Sql=Sql.Replace( "where", "ＷheＲe");
         Sql = Sql.Replace("execute", "ＥxＥcutＥ");
        return Sql;
     }
     public string ConvertSql(string Sql)
     {
         switch ( DataType .ToUpper() )
         {
             case "MYSQL":
                 break;
             case "ACCESS":
                 break;
         }
         return Sql;
     }
     /// <summary>
     /// 生成SQL语句
     /// </summary>
     /// <param name="TableName">表名</param>
     /// <param name="MakeType">生成的类型分别是insert,update,select,delete</param>
     /// <param name="SqlField">主要针对生成类型为insert,update,为一个字符串数组的一个或多个数据库字段名，数组的个数一定要和SqlValue相同</param>
     /// <param name="SqlVale">主要针对生成类型为insert,update,为一个字符串数组的一个或多个对应数据库字段名的值，数组的个数一定要和SqlField相同</param>
     /// <param name="SqlSelect">主要针对生成类型为select</param>
     /// <param name="SqlWhere">生成的条件</param>
     /// <returns></returns>
     public static string MakeSql(string TableName, string MakeType, string[] SqlField, string[] SqlVale, string SqlSelect="*", string SqlWhere = "",string SqlOrder="")
     {
         string Sql = "";
         string TempSql1 = "", TempSql2 = "";
                 switch (MakeType.ToLower())
                 {
                     case "insert":
                         Sql = "Insert Into " + TableName;                         
                         for (int i = 0; i < SqlField.Length ;i++)
                         {
                             if (TempSql1 == "")
                             {
                                 TempSql1 = SqlField[i];
                                 TempSql2 = SqlVale[i];
                             }
                             else
                             {
                                 TempSql1 +="," + SqlField[i];
                                 TempSql2 +="," + SqlVale[i];
                             }
                          }
                             Sql = Sql + " (" + TempSql1 + ") Values (" + TempSql2 + ")";
                         break;
                     case "update":
                         Sql = "Update " + TableName + " set ";
                         for (int i = 0; i < SqlField.Length ;i++)
                         {
                             if (TempSql1 == "")
                             {
                                 TempSql1 = SqlField[i] + "=" + SqlVale[i];
                             }
                             else
                             {
                                 TempSql1 += "," + SqlField[i] + "=" + SqlVale[i];
                             }
                          }
                         Sql = Sql + TempSql1 + " where " + SqlWhere;
                             break;
                     case "select":
                             if (SqlWhere != "")
                                 SqlWhere = " where " + SqlWhere;
                             SqlOrder = " " + SqlOrder;
                             if (DataType.ToUpper() == "MYSQL")
                             {
                                 string[] TempArray = SqlSelect.Split(' ');
                                 if (TempArray[0].ToLower() == "top")
                                 {
                                     Sql = "Select " + TempArray [2] + " from " + TableName  + SqlWhere+ SqlOrder + " limit 0,"+TempArray [1];
                                 }
                                 else
                                     Sql = "Select " + SqlSelect + " from " + TableName + SqlWhere + SqlOrder;
                                
                             }
                             else
                                 Sql = "Select " + SqlSelect + " from " + TableName  + SqlWhere+SqlOrder ;
                         break;
                     case "delete":
                         Sql = "Delete " + TableName + " where " + SqlWhere;
                         break;
                 }
         return Sql;
     }
   }
  public  class ConnectSql:ConnectData 
    {
       public SqlConnection Conn;

        public override bool Open()
        {
            try
            {
                string MyConnStr = "data source=" + Serverip + ";initial catalog=" + DataName + ";User ID=" + UserName + ";Password=" + Pwd + ";";
                Conn = new SqlConnection(MyConnStr);
                Conn.Open ();
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public override  string TestOpen(string serverIP, string dataName, string userName, string pwd)
        {
            try
            {
                string MyConnStr = "data source=" + serverIP  + ";initial catalog=" + dataName  + ";User ID=" + userName  + ";Password=" + pwd  + ";";
                Conn = new SqlConnection(MyConnStr);
                Conn.Open ();
                return "测试成功,连接MSSQL成功!";
            }
            catch(Exception ex)
            {
                return ex.Message ;
            }
            finally 
            { 
                Close ();
            }
        }
        public override void Close()
        {
            if (Conn.State == ConnectionState.Open )
                Conn.Close();
        }
        public override bool ExecNonSql(string Sql)
        {
            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Open();
                SqlCommand MyCommand = new SqlCommand(Sql,Conn );
                MyCommand.ExecuteNonQuery();
                MyCommand = null;
                return true;
            }
            catch
            { return false; }
            finally
            { Close(); }
        }
        public override DataSet Fill(string Sql)
        {
            DataSet Ds = new DataSet();
            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Open();
                SqlDataAdapter MyDataAdAapter = new SqlDataAdapter(Sql, Conn);
                MyDataAdAapter.TableMappings.Add("Table", "MyTable");
                SqlCommandBuilder Scb = new SqlCommandBuilder(MyDataAdAapter);
                MyDataAdAapter.Fill(Ds);
                int count = Ds.Tables[0].Rows.Count;
                return Ds;
            }
            catch
            {
                return Ds;
            }
            finally
            { Close(); }
        }
       
    }       
  public class ConnectMySql:ConnectData
    {
        public MySqlConnection Conn;
        public override bool Open()
        {
            try
            {
                Conn = new MySqlConnection("datasource=" + Serverip + ";username=" + UserName + ";password=" + Pwd + ";database=" + DataName + ";charset=gb2312;allow zero datetime=true");
                Conn.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public override string TestOpen(string serverIP, string dataName, string userName, string pwd)
        {
            try
            {
                Conn = new MySqlConnection("datasource=" + serverIP  + ";username=" + userName  + ";password=" + pwd  + ";database=" + dataName  + ";charset=gb2312");
                Conn.Open();
                Conn.Close();
                return "测试成功,MySql数据库连接成功!";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public override void Close()
        {
            if (Conn.State == ConnectionState.Open)
                Conn.Close();

        }
        public override DataSet Fill(string Sql)
        {
            DataSet Ds = new DataSet();
            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Open();
                MySqlDataAdapter MyDataAdAapter = new MySqlDataAdapter(Sql, Conn);
                MyDataAdAapter.TableMappings.Add("Table", "MyTable");
                MySqlCommandBuilder Scb = new MySqlCommandBuilder(MyDataAdAapter);
                MyDataAdAapter.Fill(Ds);
                return Ds;
            }
            catch
            {
                return Ds;
            }
            finally
            { Close(); }
        }
        public override bool ExecNonSql(string Sql)
        {

            try
            {
                if (Conn.State == ConnectionState.Closed )
                    Open();
                MySqlCommand  MyCommand = new MySqlCommand (Sql,Conn );
                MyCommand.ExecuteNonQuery();
                MyCommand = null;
                return true;
            }
            catch
            { return false; }
            finally
            { Close(); }
        }
 
    }
  public  class ConnectAccess:ConnectData
    {
        public  OleDbConnection Conn;
        public override bool Open()
        {
            try
            {
                Conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + DataName);
                Conn.Open();
                return true;
            }
            catch
            {
                return false ;
            }
        }
        public override string TestOpen(string serverIP, string dataName, string userName, string pwd)
        {
            try
            {
                Conn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dataName);
                Conn.Open();
                Conn.Close();
                return "测试成功,Access数据库连接成功!";
            }
            catch(Exception ex)
            {
                return ex.Message ;
            }
        }
        public override void Close()
        {
            if (Conn.State == ConnectionState.Open)
                Conn.Close();
        }
        public override DataSet Fill(string Sql)
        {
            DataSet Ds = new DataSet();
            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Open();
                OleDbDataAdapter MyDataAdAapter = new OleDbDataAdapter(Sql, Conn);
                MyDataAdAapter.TableMappings.Add("Table", "MyTable");
                OleDbCommandBuilder Scb = new OleDbCommandBuilder(MyDataAdAapter);
                MyDataAdAapter.Fill(Ds);
                return Ds;
            }
            catch
            {
                return Ds;
            }
            finally
            { Close(); }
        }
        public override bool ExecNonSql(string Sql)
        {
            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Open();
                OleDbCommand  MyCommand = new OleDbCommand (Sql,Conn );
                MyCommand.ExecuteNonQuery();
                MyCommand = null;
                return true;
            }
            catch
            { return false; }
            finally
            { Close(); }
        }
     }
  public class GetConnect
  {
      public static ConnectData GetConn()
      {

          return GetConn(ConnectData.StaticServerIP, ConnectData.StaticDataName, ConnectData.StaticUserName, ConnectData.StaticPwd);
      }

      public static ConnectData GetConn(string dataIP, string dataName, string dataUser, string pwd)
      {
          ConnectData SqlDataConnect;
          switch (ConnectData.DataType.ToUpper())
          {
              case "MSSQL":
                  SqlDataConnect = new ConnectSql();                  
                  break;
              case "MYSQL":
                  SqlDataConnect = new ConnectMySql();
                  break;
              case "ACCESS":
                  SqlDataConnect = new ConnectAccess();
                  break;
              default:
                  SqlDataConnect = new ConnectSql();
                  break;
          }
          SqlDataConnect.Serverip = dataIP;
          SqlDataConnect.UserName = dataUser;
          SqlDataConnect.DataName = dataName;
          SqlDataConnect.Pwd = pwd;
          if (SqlDataConnect.Open() == false)
          {
              SqlDataConnect = null;
          }
          return SqlDataConnect;

      }
      public static void ClearMssqlLog(string DataName, ConnectData MyData)
      {
          MyData.ExecNonSql("DUMP TRANSACTION [" + DataName + "] WITH  NO_LOG \r\n BACKUP LOG [" + DataName + "] WITH NO_LOG \r\n DBCC SHRINKDATABASE([" + DataName + "])");
      }
  }
}
