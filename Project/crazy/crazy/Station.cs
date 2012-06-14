using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Odbc;
using System.Data;
using System.Data.SqlClient;

namespace crazy
{
    class Station
    {
        SqlConnection con;
        public Station()
        {
            con = null;
        }
        public Station(string str)
        {
            con = new SqlConnection(str);
        }

        public void insert_station(int station_id, string station_name, int position_x,int position_y,
               int exit_count, string region,string telephone,string create_time)
        {
            string mystr = "insert_station";
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@station_id", SqlDbType.Int);
            sp.Value = station_id;
            sp = mycmd.Parameters.Add("@station_name", SqlDbType.VarChar,45);
            sp.Value = station_name;
            sp = mycmd.Parameters.Add("@position_x", SqlDbType.Int);
            sp.Value = position_x;
            sp = mycmd.Parameters.Add("@position_y", SqlDbType.Int);
            sp.Value = position_y;
            sp = mycmd.Parameters.Add("@exit_count", SqlDbType.Int);
            sp.Value = exit_count;
            sp = mycmd.Parameters.Add("@region", SqlDbType.VarChar,45);
            sp.Value = region;
            sp = mycmd.Parameters.Add("@telephone", SqlDbType.VarChar,45);
            sp.Value = telephone;
            sp = mycmd.Parameters.Add("@create_time", SqlDbType.Date);
            sp.Value = create_time;

            mycmd.ExecuteNonQuery();

            con.Close();
        }

        public string get_station_name(int station_id)
        {
            if(con.State == ConnectionState.Closed)
                con.Open();
            string mystr = "for_get_station_name";
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;

            SqlParameter sp = mycmd.Parameters.Add("@station_id", SqlDbType.Int);
            sp.Value = station_id;
            sp = mycmd.Parameters.Add("@station_name", SqlDbType.VarChar,45);
            mycmd.Parameters["@station_name"].Direction = ParameterDirection.Output;
            mycmd.ExecuteNonQuery();

            string temp = mycmd.Parameters["@station_name"].Value.ToString();
            con.Close();
            return temp;
             
        }

        public int get_station_id(string station_name)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string mystr = "for_get_station_id";
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;

            SqlParameter sp = mycmd.Parameters.Add("@station_name", SqlDbType.VarChar,45);
            sp.Value = station_name;
            sp = mycmd.Parameters.Add("@station_id", SqlDbType.Int);
            mycmd.Parameters["@station_id"].Direction = ParameterDirection.Output;
            mycmd.ExecuteNonQuery();

            int  temp = int.Parse(mycmd.Parameters["@station_id"].Value.ToString());
            con.Close();
            return temp;
        }

    }
}
