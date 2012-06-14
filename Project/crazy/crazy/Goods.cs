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
    class Goods
    {
        public SqlConnection con;
        public Goods()
        {
            con = null;
        }
        public Goods(string str)
        {
            con = new SqlConnection(str);
        }

        public bool check_goods_isexist(int id)              //检查卡名是否存在
        {
            string mystr = "for_check_goods_isexist";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@goods_id", SqlDbType.Int);
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


        public int get_goods_price(int goods_id)
        {
            if (con.State == ConnectionState.Closed)
                con.Open();
            string mystr = "for_get_goods_price";
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;

            SqlParameter sp = mycmd.Parameters.Add("@goods_id", SqlDbType.Int);
            sp.Value = goods_id;

            sp = mycmd.Parameters.Add("@price", SqlDbType.Int);
            mycmd.Parameters["@price"].Direction = ParameterDirection.Output;
            mycmd.ExecuteNonQuery();

            string temp = mycmd.Parameters["@price"].Value.ToString();
            con.Close();
            return int.Parse(temp);
        }

    }
}
