using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Data.Odbc;
using System.Data;
using System.Data.SqlClient;

namespace crazy
{
    public class GetTripRecordsAddMoneyHttpRequestHandler : HttpRequestHandler
    {
        public const string NAME = "/GetTripRecords";

        public void Handle(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            response.StatusCode = (int)HttpStatusCode.OK;
            // Get name from query string
            int cardid = int.Parse(context.Request.QueryString["cardId"]);
            int managerid = int.Parse(context.Request.QueryString["managerId"]);
            StringWriter sw = new StringWriter();
            JsonWriter jsonWriter = new JsonTextWriter(sw);

            TripRecords triprecords = new TripRecords(SQLSERVER.sqlstring);
            SqlDataReader myreader = triprecords.get_trip_record(cardid);
            List<TripRecord1> actions = new List<TripRecord1>();

            while (myreader.Read())
            {
                int trip_records_id = int.Parse(myreader["trip_records_id"].ToString());
                DateTime start_time = DateTime.Parse(myreader["start_time"].ToString());

                DateTime end_time = DateTime.Parse(myreader["end_time"].ToString());

                Station station = new Station(SQLSERVER.sqlstring);
                string  start_station_name = station.get_station_name(int.Parse(myreader["start_station_id"].ToString()));
                

                string end_station_name = station.get_station_name(int.Parse(myreader["end_station_id"].ToString()));

                int card_id = int.Parse(myreader["card_id"].ToString());

                int discounted;
                if (myreader["discountted"].ToString() == "")
                    discounted = 0;
                else
                    discounted = int.Parse(myreader["discountted"].ToString());

                int price = int.Parse(myreader["price"].ToString());
                TripRecord1 trip = new TripRecord1(trip_records_id,
                    start_time,
                    end_time,
                    start_station_name,
                    end_station_name,
                    card_id,
                    discounted,
                    price
                    );
                actions.Add(trip);
                //jsonWriter.WriteValue(int.Parse(myreader["card_id"].ToString()));
            }
            myreader.Close();

            new JsonSerializer().Serialize(jsonWriter, actions);

            ManagermentAction managermentaction = new ManagermentAction(SQLSERVER.sqlstring);
            //int manager_id,int card_id,
            //        int action,DateTime action_time,string description,float money)
            DateTime time = DateTime.Now;
            managermentaction.insert_managerment_action(managerid, cardid, 3, time, "获取交通卡出行历史记录", 0);


            string jsonText = sw.GetStringBuilder().ToString();
            byte[] messageBytes = Encoding.Unicode.GetBytes(jsonText);
            response.OutputStream.Write(messageBytes, 0, messageBytes.Length);
            response.Close();
        } // end public void Handle(HttpListenerContext context)



        public string GetName()
        {
            return NAME;
        }
    } // end public class MorningHttpRequestHandler

    public class TripRecord1
    {
        int trip_records_id;

        public int Trip_records_id
        {
            get { return trip_records_id; }
            set { trip_records_id = value; }
        }
        DateTime start_time;

        public DateTime Start_time
        {
            get { return start_time; }
            set { start_time = value; }
        }
        DateTime end_time;

        public DateTime End_time
        {
            get { return end_time; }
            set { end_time = value; }
        }
        string start_station_name;

        public string Start_station_name
        {
            get { return start_station_name; }
            set { start_station_name = value; }
        }
        string end_startion_name;

        public string End_startion_name
        {
            get { return end_startion_name; }
            set { end_startion_name = value; }
        }
        int card_id;

        public int Card_id
        {
            get { return card_id; }
            set { card_id = value; }
        }
        int discounted;

        public int Discounted
        {
            get { return discounted; }
            set { discounted = value; }
        }
        int price;

        public int Price
        {
            get { return price; }
            set { price = value; }
        }


        public TripRecord1(int trip_records_id,
        DateTime start_time,
        DateTime end_time,
        string  start_station_name,
        string end_startion_name,
        int card_id,
        int discounted,
        int price)
        {
            this.trip_records_id = trip_records_id;
            this.start_time = start_time;
            this.end_time = end_time;
            this.start_station_name = start_station_name;
            this.end_startion_name = end_startion_name;
            this.card_id = card_id;
            this.discounted = discounted;
            this.price = price;
        }
    }
}