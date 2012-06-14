//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Configuration;

//using System.Data.Odbc;
//using System.Data;
//using System.Data.SqlClient;

//namespace crazy
//{
//    public class Program
//    {
      
//        SqlConnection con;
//       // enum card_type { "daijia","baidu"}
        
//        static void Main(string[] args)
//        {
            
//            //string sqlstr = "server=localhost;UId = sa;Pwd=sa;database=cardsystem";
//            //SqlConnection con = new SqlConnection(sqlstr);
//            //con.Open();
//            //string daijia = "use cardsystem INSERT INTO manager VALUES (2,2,'',102886)";
//            //SqlCommand mycmd = new SqlCommand(daijia, con);
//            //mycmd.ExecuteNonQuery();
//            //con.Close();
//            string sqlstr = "server=localhost;UId = sa;Pwd=sa;database=cardsystem";

//          /*  string daijia = "create for_res @mid int as select manager_id from manager where manager_id = @mid";
//            SqlCommand mycmd = new SqlCommand(daijia, con);*/
//            Program program = new Program(sqlstr);

//            program.con.Open();
//            program.register(3, "102886");
//            program.check_balance(1001);
//            program.add_money(1002, 1);
//            program.change_card_type(1001, "normal_card");
//            program.report_loss(1001);
//            program.get_purchase_record(1001);
//            program.get_trip_record(1001);
//            program.con.Close();
//        }

//        public  Program()
//        {
//            con = null;
//        }

//        public Program(string sqlstr)
//        {
//            con = new SqlConnection(sqlstr);
//        }

//        bool register(int id, string passward)// 管理员登陆
//        {
//            string mystr = "for_res";
//            SqlCommand mycmd = new SqlCommand(mystr, con);
//            mycmd.CommandType = CommandType.StoredProcedure;

//            SqlParameter sp = mycmd.Parameters.Add("@mid", SqlDbType.Int);
//            sp.Value = id;

//            SqlDataReader myreader = mycmd.ExecuteReader();
//            string str = "";
//            while (myreader.Read())
//            {
//                str = myreader["passward"].ToString();
//            }
//            System.Console.WriteLine(str);
//            myreader.Close();
//            if (str.Equals(""))
//                return false;
//            else return true;
            
//        }

//        bool check_balance(int number)                       //余额查询
//        {
//            string mystr = "for_check_balance";
//            SqlCommand mycmd = new SqlCommand(mystr, con);
//            mycmd.CommandType = CommandType.StoredProcedure;
//            SqlParameter sp = mycmd.Parameters.Add("@cid", SqlDbType.Int);
//            sp.Value = number;
//            SqlDataReader myreader = mycmd.ExecuteReader();
//            string str = "";
//            while (myreader.Read())
//            {
//                str = myreader["balance"].ToString();
//            }
//            System.Console.WriteLine(str);
//            myreader.Close();
//            if (str.Equals(""))
//                return false;
//            else return true;
//        }

//        bool add_money(int id, int money)                   //充值
//        {
//            string mystr = "for_add_money";
//            SqlCommand mycmd = new SqlCommand(mystr, con);
//            mycmd.CommandType = CommandType.StoredProcedure;
//            SqlParameter sp = mycmd.Parameters.Add("@cid", SqlDbType.Int);
//            sp.Value = id;
//            sp = mycmd.Parameters.Add("@cbalance", SqlDbType.Int);
//            sp.Value = money;
//            sp = mycmd.Parameters.Add("@isexist", SqlDbType.Int);
//            mycmd.Parameters["@isexist"].Direction = ParameterDirection.Output;
//            mycmd.ExecuteNonQuery();
//            string temp = mycmd.Parameters["@isexist"].Value.ToString();
//            if (temp.Equals("0"))
//            {
//                System.Console.WriteLine("false");
//                return false;
//            }
//            else
//            {
//                System.Console.WriteLine("true");
//                return true;
//            }
//        }

//        bool change_card_type(int cid, string type_you_want)  // 更改卡号类型
//        {
//            if (type_you_want.Equals("normal_card") || type_you_want.Equals("student_card") || type_you_want.Equals("oldmen_card"))
//            {
//                string mystr = "for_change_card_type";
//                SqlCommand mycmd = new SqlCommand(mystr, con);
//                mycmd.CommandType = CommandType.StoredProcedure;

//                SqlParameter sp = mycmd.Parameters.Add("@cid", SqlDbType.Int);
//                sp.Value = cid;
//                sp = mycmd.Parameters.Add("@ctype", SqlDbType.VarChar, 30);
//                sp.Value = type_you_want;
//                sp = mycmd.Parameters.Add("@isexist", SqlDbType.Int);
//                mycmd.Parameters["@isexist"].Direction = ParameterDirection.Output;
//                mycmd.ExecuteNonQuery();
//                string temp = mycmd.Parameters["@isexist"].Value.ToString();
//                if (temp.Equals("0"))
//                {
//                    System.Console.WriteLine("false");
//                    return false;
//                }
//                else
//                {
//                    System.Console.WriteLine("true");
//                    return true;
//                }
//            }
//            System.Console.WriteLine("false");
//              return false;

//        }

//        bool report_loss(int id)                                //挂失
//        {
//            string mystr = "for_report_loss";
//            SqlCommand mycmd = new SqlCommand(mystr, con);
//            mycmd.CommandType = CommandType.StoredProcedure;

//            SqlParameter sp = mycmd.Parameters.Add("@cid", SqlDbType.Int);
//            sp.Value = id;
//            sp = mycmd.Parameters.Add("@isexist", SqlDbType.Int);
//            mycmd.Parameters["@isexist"].Direction = ParameterDirection.Output;
//            mycmd.ExecuteNonQuery();
//            string temp = mycmd.Parameters["@isexist"].Value.ToString();
//            if (temp.Equals("0"))
//            {
//                System.Console.WriteLine("false");
//                return false;
//            }
//            else
//            {
//                System.Console.WriteLine("true");
//                return true;
//            }
//        }

//        void get_purchase_record(int id)                                   //消费记录
//        {
//            string mystr = "for_purchase_record";
//            SqlCommand mycmd = new SqlCommand(mystr, con);
//            mycmd.CommandType = CommandType.StoredProcedure;

//            SqlParameter sp = mycmd.Parameters.Add("@cid", SqlDbType.Int);
//            sp.Value = id;
//            SqlDataReader myreader = mycmd.ExecuteReader();

            
//            while (myreader.Read())
//            {
//                System.Console.WriteLine(myreader["purchase_id"].ToString());
//                System.Console.WriteLine(myreader["price"].ToString());
//                System.Console.WriteLine(myreader["ref_card_id"].ToString());
//                System.Console.WriteLine(myreader["buy_time"].ToString());
//                System.Console.WriteLine(myreader["goods_goods_id"].ToString());
//            }
//            myreader.Close();
//        }

//        void get_trip_record(int id)                                        //出行记录
//        {
//            string mystr = "for_trip_record";
//            SqlCommand mycmd = new SqlCommand(mystr, con);
//            mycmd.CommandType = CommandType.StoredProcedure;
//            SqlParameter sp = mycmd.Parameters.Add("@cid", SqlDbType.Int);
//            sp.Value = id;
//            SqlDataReader myreader = mycmd.ExecuteReader();
//            while (myreader.Read())
//            {
//                System.Console.WriteLine(myreader["trip_records_id"].ToString());
//                System.Console.WriteLine(myreader["start_time"].ToString());
//                System.Console.WriteLine(myreader["end_time"].ToString());
//                System.Console.WriteLine(myreader["start_startion_id"].ToString());
//                System.Console.WriteLine(myreader["end_startion_id"].ToString());
//                System.Console.WriteLine(myreader["discounted"].ToString());
//                System.Console.WriteLine(myreader["price"].ToString());
//                System.Console.WriteLine(myreader["ref_card_id"].ToString());
//            }
//            myreader.Close();
//        }

        
//    }


//}
