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
    class TripRecords
    {
        public SqlConnection con;
        public TripRecords()
        {
            con = null;
        }
        public TripRecords(string str)
        {
            con = new SqlConnection(str);
        }

        public SqlDataReader get_trip_record(int id)                                        //出行记录
        {
            Card card = new Card(SQLSERVER.sqlstring);
            //if (!card.check_card_isexist(id))
            //{
            //    return false;
            //}
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string mystr = "for_get_trip_record";
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
            sp.Value = id;
            SqlDataReader myreader = mycmd.ExecuteReader();



            return myreader;
        }

        public bool inorout_station(int card_id, int station_id,float price)
        {
            DateTime datetime = new DateTime();
            datetime = DateTime.Now;

            Card card = new Card(SQLSERVER.sqlstring);
            if (!card.check_card_isexist(card_id))
                return false;
            int balance = card.check_balance(card_id);


            SqlDataReader tempreader = card.get_card_information(card_id);
            int missing = 0;
            if (tempreader.Read())
            {
                missing = int.Parse(tempreader["missing"].ToString());
            }
            tempreader.Close();

            if (missing != 0)
                return false;


            if (balance <= 0)
                return false;
            string mystr = "for_inorout_station";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;

            SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
            sp.Value = card_id;
            sp = mycmd.Parameters.Add("@station_id", SqlDbType.Int);
            sp.Value = station_id;
            sp = mycmd.Parameters.Add("@time", SqlDbType.DateTime);
            sp.Value = datetime;
            sp = mycmd.Parameters.Add("@price", SqlDbType.Float);
            sp.Value = price;

            mycmd.ExecuteNonQuery();
            con.Close();
            return true;

        }
    }
}
