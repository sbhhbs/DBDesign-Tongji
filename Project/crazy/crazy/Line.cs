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
    class Line
    {
        public SqlConnection con;
        public Line()
        {
            con = null;
        }
        public Line(string str)
        {
            con = new SqlConnection(str);
        }

        public SqlDataReader set_line()
        {
            string str = SQLSERVER.sqlstring;
            string mystr = "for_set_line";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader myreader = mycmd.ExecuteReader();              //以下待定
            return myreader;
 
        }

        public SqlDataReader set_line2()
        {
            string str = SQLSERVER.sqlstring;
            string mystr = "for_set_line2";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader myreader = mycmd.ExecuteReader();              //以下待定
            return myreader;
        }


        public SqlDataReader set_single_station()
        {
            string str = SQLSERVER.sqlstring;
            string mystr = "for_set_single_station";
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader myreader = mycmd.ExecuteReader();              //以下待定
            return myreader;
        }

    }
}
