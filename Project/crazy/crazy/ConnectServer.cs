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
//    public class ConnectServer
//    {

//        SqlConnection con;
//        const int MAX_DEBT = -100;
//        static void Main(string[] args)
//        {
//            string sqlstr = "server=localhost;UId = sa;Pwd=sa;database=transportation";
//            ConnectServer program = new ConnectServer(sqlstr);
//            program.con.Open();
//     //       program.register(301, "102886");
//          //   int number=MAX_DEBT;
//         //    program.check_balance(101);
//         //   program.add_money(101, 2);
//         //    program.check_balance(101);
//        //    program.change_card_type(101, "student_card");
//        //    program.report_loss(101);
//    //        program.get_purchase_record(101);
//            program.get_trip_record(101);
//            program.con.Close();
//        }



//        public ConnectServer()
//        {
//            con = null;
//        }

//        public ConnectServer(string sqlstr)
//        {
//            con = new SqlConnection(sqlstr);
//        }

//        bool register(int id, string passward)// 管理员登陆,返回是否成功
//        {
//            string mystr = "for_register";
//            SqlCommand mycmd = new SqlCommand(mystr, con);
//            mycmd.CommandType = CommandType.StoredProcedure;
//            SqlParameter sp = mycmd.Parameters.Add("@manager_id", SqlDbType.Int);
//            sp.Value = id;
//            sp = mycmd.Parameters.Add("@passward", SqlDbType.VarChar, 45);
//            sp.Value = passward;
//            sp = mycmd.Parameters.Add("@count", SqlDbType.Int);

//            mycmd.Parameters["@count"].Direction = ParameterDirection.Output;
//            mycmd.ExecuteNonQuery();
//            string str = mycmd.Parameters["@count"].Value.ToString();
//            if (str.Equals("1"))
//            {
//                System.Console.WriteLine("true");
//                return true;
//            }
//            else
//            {
//                System.Console.WriteLine("false");
//                return false;
//            }
//        }

//        int check_balance(int id )         //余额查询 ，返回balance，若无此卡，返回  MAX_DEBT
//        {
//            int balance = MAX_DEBT;
//            string mystr = "for_check_balance";
//            SqlCommand mycmd = new SqlCommand(mystr, con);
//            mycmd.CommandType = CommandType.StoredProcedure;
//            SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
//            sp.Value = id;
//            SqlDataReader myreader = mycmd.ExecuteReader();
//            if (myreader.Read())
//            {
//                System.Console.WriteLine("true");
//                balance = int.Parse(myreader["balance"].ToString());
//                System.Console.WriteLine(balance);
//                myreader.Close();
//                return balance;
//            }
//            else
//            {
//                System.Console.WriteLine("false");
//                myreader.Close();
//                return balance;
//            }
//        }

//        bool check_card_isexist(int id)              //检查卡名是否存在
//        {
//            string mystr = "for_check_card_isexist";
//            SqlCommand mycmd = new SqlCommand(mystr, con);
//            mycmd.CommandType = CommandType.StoredProcedure;
//            SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
//            sp.Value = id;
//            sp = mycmd.Parameters.Add("@count", SqlDbType.Int);
//            mycmd.Parameters["@count"].Direction = ParameterDirection.Output;
//            mycmd.ExecuteNonQuery();
//            string temp = mycmd.Parameters["@count"].Value.ToString();
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

//        bool add_money(int id, int money)                   //充值,返回是否成功
//        {
//            if (!check_card_isexist(id))
//                return false;
//            string mystr = "for_add_money";
//            SqlCommand mycmd = new SqlCommand(mystr, con);
//            mycmd.CommandType = CommandType.StoredProcedure;
//            SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
//            sp.Value = id;
//            sp = mycmd.Parameters.Add("@money", SqlDbType.Int);
//            sp.Value = money;
//            mycmd.ExecuteNonQuery();
//            return true;
//        }

//        bool change_card_type(int cid, string type_you_want)  // 更改卡号类型
//        {
//            if (!check_card_isexist(cid))
//            {
//                return false;
//            }

//            if (type_you_want == "normal_card" || type_you_want == "student_card" || type_you_want == "oldmen_card")
//            {
                
//                string mystr = "for_change_card_type";
//                SqlCommand mycmd = new SqlCommand(mystr, con);
//                mycmd.CommandType = CommandType.StoredProcedure;

//                SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
//                sp.Value = cid;
//                sp = mycmd.Parameters.Add("@card_type", SqlDbType.VarChar,45);
//                sp.Value = type_you_want;
//                mycmd.ExecuteNonQuery();
//                return true;
//            }
//            else return false;
            


//        }

//        bool report_loss(int id)                                //挂失
//        {
//            if (!check_card_isexist(id))
//            {
//                return false;
//            }
//            string mystr = "for_report_loss";
//            SqlCommand mycmd = new SqlCommand(mystr, con);
//            mycmd.CommandType = CommandType.StoredProcedure;
//            SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
//            sp.Value = id;
//            mycmd.ExecuteNonQuery();
//            return true;

//        }

//        bool get_purchase_record(int id)                                   //消费记录
//        {
//            if (!check_card_isexist(id))
//            {
//                return false;
//            }
//            string mystr = "for_get_purchase_record";
//            SqlCommand mycmd = new SqlCommand(mystr, con);
//            mycmd.CommandType = CommandType.StoredProcedure;
//            SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);
//            sp.Value = id;
//            SqlDataReader myreader = mycmd.ExecuteReader();              //以下待定
//            while (myreader.Read())
//            {
//                System.Console.WriteLine(myreader["purchase_id"].ToString());
//                System.Console.WriteLine(myreader["price"].ToString());
//                System.Console.WriteLine(myreader["buy_time"].ToString());
//                System.Console.WriteLine(myreader["card_id"].ToString());
//                System.Console.WriteLine(myreader["goods_id"].ToString());
//            }
//            myreader.Close();

//            return true;
//        }

//        bool get_trip_record(int id)                                        //出行记录
//        {
//            if (!check_card_isexist(id))
//            {
//                return false;
//            }
//            string mystr = "for_get_trip_record";
//            SqlCommand mycmd = new SqlCommand(mystr, con);
//            mycmd.CommandType = CommandType.StoredProcedure;
//            SqlParameter sp = mycmd.Parameters.Add("@card_id", SqlDbType.Int);  
//            sp.Value = id;
//            SqlDataReader myreader = mycmd.ExecuteReader();                 //以下待定
//            while (myreader.Read())
//            {
//                System.Console.WriteLine(myreader["trip_records_id"].ToString());
//                System.Console.WriteLine(myreader["start_time"].ToString());
//                System.Console.WriteLine(myreader["end_time"].ToString());
//                System.Console.WriteLine(myreader["start_station_id"].ToString());
//                System.Console.WriteLine(myreader["end_station_id"].ToString());
//                System.Console.WriteLine(myreader["card_id"].ToString());
//                System.Console.WriteLine(myreader["discountted"].ToString());
//                System.Console.WriteLine(myreader["price"].ToString());
//            }
//            myreader.Close();
//            return true;
//        }


//    }


    
//}

