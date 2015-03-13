using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;

namespace CentralControl
{
    public class DBUtil
    {
        private static String ConnectionString = "data source = LAB229\\SQLEXPRESS;initial catalog = gtltest; user id = gtltest;password = jiaoda";


        private static SqlConnection getConnection() 
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConnectionString;
            return conn;
        }

        public static ArrayList getTableList() 
        {
            ArrayList list = new ArrayList();
            SqlConnection conn = getConnection();
            try
            {
                conn.Open();
                DataTable tables = conn.GetSchema("Tables");
                foreach (DataRow row in tables.Rows)
                {
                    list.Add(row[2].ToString());
                }  
            }
            catch (Exception ex)
            {
            
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }

        public static ArrayList getTableColumns(String tableName) 
        {
            ArrayList list = new ArrayList();
            SqlConnection conn = getConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("Select Name FROM SysColumns Where id=Object_Id('" + tableName + "')", conn);
                SqlDataReader objReader = cmd.ExecuteReader();

                while (objReader.Read())
                {
                    list.Add(objReader[0].ToString());

                }  
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }

        public static ArrayList executeQueryCmd(string cmdStr,int numCol) 
        {
            SqlConnection conn = getConnection();
            ArrayList list = new ArrayList();
            String[] ele;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ele = new String[numCol];
                    for (int i = 0; i < numCol; i++) 
                    {
                        ele[i] = reader[i].ToString();
                    }
                    list.Add(ele);
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return list;
        }

        public static int executedNonQueryCmd(string cmdStr) 
        {
            SqlConnection conn = getConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmdStr, conn);
                return cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return -1;
        }
    }
}
