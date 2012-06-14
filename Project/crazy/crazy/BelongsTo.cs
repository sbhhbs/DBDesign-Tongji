using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Odbc;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace crazy
{
    class BelongsTo
    {
        public SqlConnection con;
        public BelongsTo()
        {
            con = null;
        }
        public BelongsTo(string str)
        {
            con = new SqlConnection(str);
        }

        public SqlDataReader read()
        {
            if(con.State == ConnectionState.Closed)
                con.Open();
            string str = "select * from belongs_to";
            SqlCommand mycmd = new SqlCommand(str, con);
            SqlDataReader myreader = mycmd.ExecuteReader();
            return myreader;
        }

        public void insert_belongs_to(int station_id,int line_id,int position)
        {
            string mystr = "insert_belongs_to";
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@station_id", SqlDbType.Int);
            sp.Value = station_id;
            sp = mycmd.Parameters.Add("@line_id", SqlDbType.Int);
            sp.Value = line_id;
            sp = mycmd.Parameters.Add("@position", SqlDbType.Int);
            sp.Value = position;
            mycmd.ExecuteNonQuery();                

            con.Close();
        }
    }
}
