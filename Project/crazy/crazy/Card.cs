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
    class Card
    {
        const int MAX_DEBT = -100;
        public SqlConnection con;
        public Card()
        { con = null; }
        public Card(string str)
        {
            con = new SqlConnection(str);
        }

        public int check_balance(int id)         //余额查询 ，返回balance，若无此卡，返回  MAX_DEBT
        {
            int balance = MAX_DEBT;
            string mystr = "for_check_balance";
            if(con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
            sp.Value = id;
            SqlDataReader myreader1 = mycmd.ExecuteReader();
            if (myreader1.Read())
            {
                System.Console.WriteLine("true");
                balance = int.Parse(myreader1["balance"].ToString());
                System.Console.WriteLine(balance);
                myreader1.Close();
                con.Close();
                return balance;
            }
            else
            {
                System.Console.WriteLine("false");
                myreader1.Close();
                con.Close();
                return balance;
            }
        }

        public void insert_card(int card_id, float balance, int missing,
            string validate_time,string card_type,int recent_trip_id,string user_id
            , float card_value,string version)
        {
            string mystr = "insert_card";
            if (con.State == ConnectionState.Closed)
                con.Open();
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
            sp.Value = card_id;
            sp = mycmd.Parameters.Add("@balance", SqlDbType.Float);
            sp.Value = balance;
            sp = mycmd.Parameters.Add("@missing", SqlDbType.Int);
            sp.Value = missing;
            sp = mycmd.Parameters.Add("@validate_time", SqlDbType.VarChar,45);
            sp.Value = validate_time;
            sp = mycmd.Parameters.Add("@card_type", SqlDbType.VarChar,45);
            sp.Value = card_type;
            sp = mycmd.Parameters.Add("@recent_trip_id", SqlDbType.Int);
            sp.Value = recent_trip_id;
            sp = mycmd.Parameters.Add("@user_id", SqlDbType.Char,18);
            sp.Value = user_id;
            sp = mycmd.Parameters.Add("@card_value", SqlDbType.Float);
            sp.Value = card_value;
            sp = mycmd.Parameters.Add("@version", SqlDbType.VarChar,45);
            sp.Value = version;

            mycmd.ExecuteNonQuery();

            con.Close();
        }

        public bool check_card_isexist(int id)              //检查卡名是否存在
        {
            string mystr = "for_check_card_isexist";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
            sp.Value = id;
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



        public void add_money(int id, int money)                   //充值,返回是否成功
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string mystr = "for_add_money";
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
            sp.Value = id;
            sp = mycmd.Parameters.Add("@money", SqlDbType.Int);
            sp.Value = money;
            mycmd.ExecuteNonQuery();
            con.Close();


        }

        public bool change_card_type(int cid, string type_you_want)  // 更改卡号类型
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            if (type_you_want == "normal_card" || type_you_want == "student_card" || type_you_want == "oldman_card" || type_you_want == "staff_card")
            {

                string mystr = "for_change_card_type";
                SqlCommand mycmd = new SqlCommand(mystr, con);
                mycmd.CommandType = CommandType.StoredProcedure;
                SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
                sp.Value = cid;
                sp = mycmd.Parameters.Add("@card_type", SqlDbType.VarChar, 45);
                sp.Value = type_you_want;
                mycmd.ExecuteNonQuery();
                con.Close();


                return true;
            }
            else
            {
                if(con.State == ConnectionState.Open)
                    con.Close();
                return false;
            }


        }

        public void report_loss(int id)                                //挂失
        {
            //if (!check_card_isexist(id))
            //{
            //    return false;
            //}
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string mystr = "for_report_loss";
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
            sp.Value = id;
            mycmd.ExecuteNonQuery();
            con.Close();

 

            //return true;
        }

        public SqlDataReader get_card_information(int card_id)
        {
            Card card= new Card(SQLSERVER.sqlstring);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string mystr = "for_get_card_information";
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
            sp.Value = card_id;


            //int manager_id,int card_id,
            //        int action,DateTime action_time,string description,float money

            SqlDataReader myreader = mycmd.ExecuteReader();
  
            return myreader;
        }

        public bool inorout_station(int card_id, int station_id,float price)
        { 
            Card card = new Card(SQLSERVER.sqlstring);
            Station station = new Station(SQLSERVER.sqlstring);
            if (!card.check_card_isexist(card_id))
                return false;

            if (con.State == ConnectionState.Closed)
                con.Open();

            string mystr = "for_inorout_station";
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
            sp.Value = card_id;
            sp = mycmd.Parameters.Add("@station_id", SqlDbType.Int);
            sp.Value = station_id;
            DateTime datetime = new DateTime();
            datetime = DateTime.Now;
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
