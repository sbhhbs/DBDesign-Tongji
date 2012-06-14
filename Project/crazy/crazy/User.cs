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
    class User
    {
        public SqlConnection con;
        public User()
        { con = null; }
        public User(string str)
        {
            con = new SqlConnection(str);
        }

        public SqlDataReader get_user_information(int user_id)
        {
            User user = new User(SQLSERVER.sqlstring);
            //if (!user.check_user_isexist(user_id))
            //{
            //    return false;
            //}
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string mystr = "for_get_user_information";
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@user_id", SqlDbType.Int);
            sp.Value = user_id;
            SqlDataReader myreader = mycmd.ExecuteReader();              //以下待定
            return myreader;
        }

        public void insert_user(string user_id, string user_name,string brithday
            ,string telephone,
            int gender,string school, int staff_id,
            string department,string work_station_time,string emergency_tel)
        {
            string mystr = "insert_user";
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@user_id", SqlDbType.Char,18);
            sp.Value = user_id;
            sp = mycmd.Parameters.Add("@user_name", SqlDbType.VarChar,45);
            sp.Value = user_name;
            sp = mycmd.Parameters.Add("@brithday", SqlDbType.Date);
            sp.Value = brithday;
            sp = mycmd.Parameters.Add("@telephone", SqlDbType.VarChar, 45);
            sp.Value = telephone;
            sp = mycmd.Parameters.Add("@gender", SqlDbType.Int);
            sp.Value = gender;
            sp = mycmd.Parameters.Add("@school", SqlDbType.VarChar,45);
            sp.Value = school;
            sp = mycmd.Parameters.Add("@staff_id", SqlDbType.Int);
            sp.Value = staff_id;
            sp = mycmd.Parameters.Add("@department", SqlDbType.VarChar,45);
            sp.Value = department;
            sp = mycmd.Parameters.Add("@work_station_time", SqlDbType.VarChar, 45);
            sp.Value = work_station_time;
            sp = mycmd.Parameters.Add("@emergency_tel", SqlDbType.VarChar, 45);
            sp.Value = emergency_tel;

            mycmd.ExecuteNonQuery();

            con.Close();
        }

        public bool check_user_isexist(int user_id)
        {
            string mystr = "for_check_user_isexist";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@user_id", SqlDbType.Int);
            sp.Value = user_id;
            sp = mycmd.Parameters.Add("@count", SqlDbType.Int);
            mycmd.Parameters["@count"].Direction = ParameterDirection.Output;
            mycmd.ExecuteNonQuery();
            string temp = mycmd.Parameters["@count"].Value.ToString();
            con.Close();
            if (temp.Equals("0"))
            {
                System.Console.WriteLine("false");
                return false;
            }
            else
            {
                System.Console.WriteLine("true");
                return true;
            }
        }
    }
}
