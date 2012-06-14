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
    class PurchaseRecord
    {
        public SqlConnection con;
        public PurchaseRecord()
        {
            con = null;
        }
        public PurchaseRecord(string str)
        {
            con = new SqlConnection(str);
        }
        public bool get_purchase_record(int id)                                   //消费记录
        {
            string str = SQLSERVER.sqlstring;
            Card card = new Card(str);
            if (!card.check_card_isexist(id))
            {
                return false;
            }
            string mystr = "for_get_purchase_record";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
            sp.Value = id;
            SqlDataReader myreader = mycmd.ExecuteReader();              //以下待定
            while (myreader.Read())
            {
                System.Console.WriteLine(myreader["purchase_id"].ToString());
                System.Console.WriteLine(myreader["price"].ToString());
                System.Console.WriteLine(myreader["buy_time"].ToString());
                System.Console.WriteLine(myreader["card_id"].ToString());
                System.Console.WriteLine(myreader["goods_id"].ToString());
            }
            myreader.Close();
            con.Close();
            return true;
        }


        public bool buy_something(int card_id, int goods_id)
        {
            Card card = new Card(SQLSERVER.sqlstring);
            Goods goods = new Goods(SQLSERVER.sqlstring);
            if (!card.check_card_isexist(card_id))
            {
                return false;
            }
            if (!goods.check_goods_isexist(goods_id))
            {
                return false;
            }

            SqlDataReader tempreader = card.get_card_information(card_id);
            int balance = 0,price = 0,missing = 0;
            if (tempreader.Read())
            {
                balance = int.Parse(tempreader["balance"].ToString());
                missing = int.Parse(tempreader["missing"].ToString());
            }
            tempreader.Close();

            if (missing == 1)
                return false;
            price = goods.get_goods_price(goods_id);
            if (balance < price)
                return false;

            DateTime datetime = new DateTime();
            datetime = DateTime.Now;

            string mystr = "for_buy_something";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            
            SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
            sp.Value = card_id;
            sp = mycmd.Parameters.Add("@goods_id", SqlDbType.Int);
            sp.Value = goods_id;
            sp = mycmd.Parameters.Add("@price", SqlDbType.Int);
            sp.Value = price;
            sp = mycmd.Parameters.Add("@time", SqlDbType.DateTime);
            sp.Value = datetime;
            mycmd.ExecuteNonQuery();
            
            con.Close();
            return true;
        }
    }
}
