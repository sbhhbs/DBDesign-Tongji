using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.Odbc;
using System.Data;
using System.Data.SqlClient;
using System.IO;
//using System.Windows.Forms;


namespace crazy
{   
    public class SQLSERVER
    {
        public static string sqlstring = @"server=.\myinstance;UId = sa;Pwd= daijia;database=transportation";
        public static int purchase = 0;
        public static int fortrip = 0;
    }
   
    public class Manager
    {
        public SqlConnection con;
        static void Main(string[] args)
        {

            //Manager manager = new Manager(SQLSERVER.sqlstring);// 1
            //if (manager.register(20000,"1000"))
            //{
            //    System.Console.WriteLine("true");
            //}
            //else System.Console.WriteLine("false");


            //ManagermentAction managermentaction = new ManagermentAction(SQLSERVER.sqlstring); //2
            //SqlDataReader myreader = managermentaction.manageroperation(1000);
            //while (myreader.Read())
            //{
            //    System.Console.WriteLine(myreader["manager_id"].ToString());
            //    System.Console.WriteLine(myreader["card_id"].ToString());
            //    System.Console.WriteLine(myreader["action"].ToString());
            //    System.Console.WriteLine(myreader["action_time"].ToString());
            //    System.Console.WriteLine(myreader["description"].ToString());
            //    System.Console.WriteLine(myreader["money"].ToString());
            //}
            //myreader.Close();
            //managermentaction.con.Close();



            //Card car = new Card(SQLSERVER.sqlstring);//3
            //if (car.check_card_isexist(10000))
            //    System.Console.WriteLine("card is exist");
            //else System.Console.WriteLine("card is not exist");


            //User user = new User(SQLSERVER.sqlstring); //4
            //SqlDataReader myreader =  user.get_user_information(10);
            //while (myreader.Read())
            //{
            //    System.Console.WriteLine(myreader["user_id"].ToString());
            //    System.Console.WriteLine(myreader["user_name"].ToString());
            //    System.Console.WriteLine(myreader["birthday"].ToString());
            //    System.Console.WriteLine(myreader["telephone"].ToString());
            //    System.Console.WriteLine(myreader["gender"].ToString());

            //}
            //myreader.Close();
            //user.con.Close();


            //Card card = new Card(SQLSERVER.sqlstring); //5
            //SqlDataReader myreader = card.get_card_information(100000);
            //while (myreader.Read())
            //{
            //    System.Console.WriteLine(myreader["card_id"].ToString());
            //    System.Console.WriteLine(myreader["balance"].ToString());
            //    System.Console.WriteLine(myreader["missing"].ToString());
            //    System.Console.WriteLine(myreader["validate_time"].ToString());
            //    System.Console.WriteLine(myreader["card_type"].ToString());
            //    System.Console.WriteLine(myreader["recent_trip_id"].ToString());
            //    System.Console.WriteLine(myreader["user_id"].ToString());
            //    System.Console.WriteLine(myreader["card_value"].ToString());
            //    System.Console.WriteLine(myreader["version"].ToString());
            //}
            //myreader.Close();
            //card.con.Close();

            //Card card = new Card(SQLSERVER.sqlstring); // 6
            //card.add_money(100000, 10);


            //Card card = new Card(SQLSERVER.sqlstring); // 7
            //card.report_loss(100000);


            //Card card = new Card(SQLSERVER.sqlstring); // 8
            //card.change_card_type(100000,"student_card");


            //TripRecords triprecords = new TripRecords(SQLSERVER.sqlstring);//9
            //SqlDataReader myreader = triprecords.get_trip_record(100000);
            //while (myreader.Read())
            //{
            //    System.Console.WriteLine(myreader["trip_records_id"].ToString());
            //    System.Console.WriteLine(myreader["start_time"].ToString());
            //    System.Console.WriteLine(myreader["end_time"].ToString());
            //    System.Console.WriteLine(myreader["start_station_id"].ToString());
            //    System.Console.WriteLine(myreader["end_station_id"].ToString());
            //    System.Console.WriteLine(myreader["card_id"].ToString());
            //    System.Console.WriteLine(myreader["discountted"].ToString());
            //    System.Console.WriteLine(myreader["price"].ToString());
            //}
            //myreader.Close();
            //triprecords.con.Close();


            //PurchaseRecord purchase = new PurchaseRecord(SQLSERVER.sqlstring);//10
            //if (purchase.buy_something(10000, 702))
            //    System.Console.WriteLine("buy sucess");
            //else System.Console.WriteLine("buy fail");


            //TripRecords triprecords = new TripRecords(SQLSERVER.sqlstring);//11,12
            //int price = 0;
            //if (triprecords.inorout_station(100000, 0,price))
            //{
            //    System.Console.WriteLine("trip success");
            //}
            //else System.Console.WriteLine("trip fail");


            //Card card = new Card(SQLSERVER.sqlstring);
            //  card.add_money(100000, 10);

            //BelongsTo belongsto = new BelongsTo(SQLSERVER.sqlstring);





            //Station station = new Station(SQLSERVER.sqlstring);
            //Line line = new Line(SQLSERVER.sqlstring);
            //SqlDataReader myreader = line.set_line(); //= belongsto.read();

            //int station_id, line1_id, line2_id;
            //string station_name;
            //while (myreader.Read())
            //{
            //    line1_id = int.Parse(myreader["first"].ToString());
            //    line2_id = int.Parse(myreader["second"].ToString());
            //    station_id = int.Parse(myreader["station_id"].ToString());
            //    station_name = station.get_station_name(station_id);

            //    System.Console.WriteLine(line1_id + "   " + line2_id + "  " + station_name);
            //}
            //myreader.Close();




            HttpServer server = new HttpServer("http://localhost:8080/");
          //  Add the HttpRequestHandlers
            // server.AddHttpRequestHandler(new RegisterHttpRequestHandler());

                  server.AddHttpRequestHandler(new ManagermentActionHttpRequestHandler());
            server.AddHttpRequestHandler(new CardInActionHttpRequestHandler());

            server.AddHttpRequestHandler(new RegisterHttpRequestHandler());
           // server.AddHttpRequestHandler(new RegisterHttpRequestHandler());
           // server.AddHttpRequestHandler(new CardInActionHttpRequestHandler());
            server.AddHttpRequestHandler(new GetUserInformationHttpRequestHandler());
            server.AddHttpRequestHandler(new GetCardInformationHttpRequestHandler());
            server.AddHttpRequestHandler(new AddMoneyHttpRequestHandler());
            server.AddHttpRequestHandler(new GetTripRecordsAddMoneyHttpRequestHandler());
            server.AddHttpRequestHandler(new ReportLossHttpRequestHandler());
            server.AddHttpRequestHandler(new ChangeTypeHttpRequestHandler());
            server.AddHttpRequestHandler(new InStationHttpRequestHandler());
            server.AddHttpRequestHandler(new OutStationHttpRequestHandler());
            server.AddHttpRequestHandler(new QueryHttpRequestHandler());
            server.AddHttpRequestHandler(new BuyGoodsHttpRequestHandler());

            server.Start();

            for (; ; ) ;




            //for (int i = 0; i < 245; i++)
            //{
            //    name = sb.ReadLine();
            //    id = int.Parse(sa.ReadLine());
            //    x = int.Parse(sc.ReadLine());
            //    y = int.Parse(sd.ReadLine());

            //    string str = arr[i % 17];
            //    int exit = (i + 5) % 10 + 1;
            //    string phone = "659857458";
            //    string time = "2001-10-10";

            //    Station station = new Station(SQLSERVER.sqlstring);
            //    station.insert_station(id, name, x, y, exit, str, phone, time);

            //}




         //   server.AddHttpRequestHandler(new )
            // Start the server
           
            //Console.ReadKey();






            //RouteQuery query = new RouteQuery();
            //query.InitData();
            ////StationNode sn = query.GetStation("南京西路");
            //List<string> list = query.Query("人民广场", "富锦路");
            //for (int i = 0; i < list.Count; i++)
            //    System.Console.WriteLine(list[i]);



            //Station station = new Station(SQLSERVER.sqlstring);
            //Line line = new Line(SQLSERVER.sqlstring);
            //SqlDataReader myreader = line.set_line(); //= belongsto.read();

            //int station_id, line1_id, line2_id;
            //string station_name;
            //while (myreader.Read())
            //{
            //    line1_id = int.Parse(myreader["first"].ToString());
            //    line2_id = int.Parse(myreader["second"].ToString());
            //    station_id = int.Parse(myreader["station_id"].ToString());
            //    station_name = station.get_station_name(station_id);

            //    // SetUpAll(line1_id, line2_id, station_name, 1);
            //    System.Console.WriteLine(line1_id + "   " + line2_id + "  " + station_name);
            //}


            //myreader.Close();
            //line.con.Close();
        

        }
        


        public Manager()
        {
            con = null;
        }

        public Manager(string sqlstr)
        {
            con = new SqlConnection(sqlstr);
        }

        public bool register(int id, string passward)// 管理员登陆,返回是否成功
        {
            string mystr = "for_register";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@manager_id", SqlDbType.Int);
            sp.Value = id;
            sp = mycmd.Parameters.Add("@password", SqlDbType.VarChar, 45);
            sp.Value = passward;
            sp = mycmd.Parameters.Add("@count", SqlDbType.Int);
            mycmd.Parameters["@count"].Direction = ParameterDirection.Output;
            mycmd.ExecuteNonQuery();
            string str = mycmd.Parameters["@count"].Value.ToString();
            con.Close();
            if (str.Equals("1"))
            {
                System.Console.WriteLine("true");
                return true;
            }
            else
            {
                System.Console.WriteLine("false");
                return false;
            }
        }

        public bool check_manager_isexist(int id)              //检查卡名是否存在
        {
            string mystr = "for_check_manager_isexist";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand mycmd = new SqlCommand(mystr, con);
            mycmd.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = mycmd.Parameters.Add("@manager_id", SqlDbType.Int);
            sp.Value = id;
            sp = mycmd.Parameters.Add("@count", SqlDbType.Int);
            mycmd.Parameters["@count"].Direction = ParameterDirection.Output;
            mycmd.ExecuteNonQuery();
            string temp = mycmd.Parameters["@count"].Value.ToString();
            con.Close();
            if (temp.Equals("0"))
            {
             //   System.Console.WriteLine("false");
                return false;
            }
            else
            {
             //   System.Console.WriteLine("true");
                return true;
            }
        }

    }



}

