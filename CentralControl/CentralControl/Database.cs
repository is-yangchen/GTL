using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Configuration;

namespace CentralControl
{

    class Database
    {
        protected static SqlDataReader sdr;
        SqlConnection conn;
        string error;
        List<List<int>> errorid;

        public Database()
        {
            conn = new SqlConnection();
            //conn.ConnectionString = "Data Source=LAB229\\SQLEXPRESS; Initial Catalog=mygtl;Integrated Security=True";
            conn.ConnectionString = ConfigurationSettings.AppSettings["connectionstring"];
        }

        public int insert(string query)
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                error = "connection fail:" + ex.Message;
                return -2;
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            int state = -3;
            try
            {
                state = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                error = "insertion fail:" + ex.Message;
            }
            conn.Close();
            return state;
        }

        public List<List<object>> search(string query)
        {
            List<List<object>> array = new List<List<object>>();
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                error = "connection fail:" + ex.Message;
                return null;
            }
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = query;
            try
            {
                sdr = cmd.ExecuteReader();
                while (sdr.Read())
                {
                    List<object> tmparr = new List<object>();
                    Object[] values = new Object[sdr.FieldCount];
                    int fieldCount = sdr.GetValues(values);
                    for (int i = 0; i < fieldCount; i++)
                        tmparr.Add(values[i]);
                    array.Add(tmparr);
                }
            }
            catch (Exception ex)
            {
                error = "search fail:" + ex.Message;
            }
            conn.Close();
            return array;
        }

        public int insertop(int current1, int current2, int current3, int current4, string barcode, int device_id, int device_state)
        {
            return insert("insert into OP values(" + current1.ToString() + "," + current2.ToString() + "," + current3.ToString() + "," + current4.ToString() + ",'" + barcode + "'," + device_state + ",'" + DateTime.Now.ToString() + "'," + device_id + ")");
        }

        public int insertmb(int current1, int current2, int current3, int current4, string barcode, int device_id, int device_state)
        {
            return insert("insert into MB values(" + current1.ToString() + "," + current2.ToString() + "," + current3.ToString() + "," + current4.ToString() + ",'" + barcode + "'," + device_state + ",'" + DateTime.Now.ToString() + "'," + device_id + ")");
        }

        public int insertlog(string dev_operator, int device_id, string direction)
        {
            return insert("insert into OPERATELOG values('" + dev_operator + "','" + DateTime.Now.ToString() + "'," + device_id + ",'" + direction + "')");
        }
        public int inserthaclumin(int device_id, int addr, int lumin, int x, int y, int pwm, int device_state)
        {
            return insert("insert into HAC_LUMIN values(" + device_state.ToString() + ",'" + DateTime.Now.ToString() + "'," + device_id.ToString() + "," + addr.ToString() + "," + lumin.ToString() + "," + x.ToString() + "," + y.ToString() + "," + pwm.ToString() + ")");
        }

        public bool inserthacod(int device_id, /*List<List<int>>*/int[][] value, int device_state)
        {
            int state;
            errorid = new List<List<int>>();
            bool fine = true;
            for (int i = 0; i < 8; i++)
            {
                List<int> line = new List<int>();
                for (int j = 0; j < 12; j++)
                {
                    state = insert("insert into HAC_OD values(" + device_state.ToString() + "," + j.ToString() + "," + i.ToString() + "," + value[i][j].ToString() + ",'" + DateTime.Now.ToString() + "'," + device_id + ")");
                    line.Add(state);
                    if (state != -1)
                    {
                        fine = false;
                    }
                }
                errorid.Add(line);
            }
            return fine;
        }

        public int inserthacengine(int device_id, int elecspeed, int power, int text_speed, int device_state)
        {
            return insert("insert into HAC_ENGINE values(" + device_state.ToString() + "," + text_speed.ToString() + "," + elecspeed.ToString() + "," + power.ToString() + ",'" + DateTime.Now.ToString() + "'," + device_id.ToString() + ")");
        }

        public int inserthacbarcode(string incode, string outcode, int device_id)
        {
            return insert("insert into HAC_BARCODE values('" + DateTime.Now.ToString() + "'," + device_id.ToString() + ",'" + incode + "','" + outcode + "')");
        }

        public int inserthactmpmod(int device_id, int device_state, int temperature1, int temperature2, int temperature3, int humidity1, int humidity2)
        {
            return insert("insert into HAC_TMPMOD values(" + temperature1.ToString() + "," + temperature2.ToString() + "," + temperature3.ToString() + "," + humidity1.ToString() + "," + humidity2.ToString() + "," + device_state.ToString() + ",'" + DateTime.Now.ToString() + "'," + device_id.ToString() + ")");
        }


        public int inserthacstate(int device_id, int device_state)
        {
            return insert("insert into HAC_STATE values('" + DateTime.Now.ToString() + "'," + device_id.ToString() + "," + device_state.ToString() + ")");
        }
        public string showerror()
        {
            return error;
        }

        public List<List<int>> showmatrixerror()
        {
            return errorid;
        }

    }
}
