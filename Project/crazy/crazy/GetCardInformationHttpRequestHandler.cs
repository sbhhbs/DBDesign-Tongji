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
    public class GetCardInformationHttpRequestHandler : HttpRequestHandler
    {
        public const string NAME = "/CardInformation";

        public void Handle(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            response.StatusCode = (int)HttpStatusCode.OK;
            // Get name from query string
            int cardid = int.Parse(context.Request.QueryString["cardId"]);
            int managerid = int.Parse(context.Request.QueryString["managerId"]);
            StringWriter sw = new StringWriter();
            JsonWriter jsonWriter = new JsonTextWriter(sw);


            Card card = new Card(SQLSERVER.sqlstring);
            SqlDataReader myreader = card.get_card_information(cardid);

            CardInfo cardInfo = new CardInfo();

            while (myreader.Read())
            {

                cardInfo.CardID = myreader["card_id"].ToString();
                cardInfo.Balance = myreader["balance"].ToString();
                cardInfo.Missing = myreader["missing"].ToString();
                cardInfo.ValidateTime = myreader["validate_time"].ToString();
                cardInfo.CardType = myreader["card_type"].ToString();
                cardInfo.RecentTripID = myreader["recent_trip_id"].ToString();
                cardInfo.UserID = myreader["user_id"].ToString();
                cardInfo.CardValue = myreader["card_value"].ToString();
                cardInfo.Version = myreader["version"].ToString();
            }
            myreader.Close();

            new JsonSerializer().Serialize(jsonWriter, cardInfo);

            ManagermentAction managermentaction = new ManagermentAction(SQLSERVER.sqlstring);
            //int manager_id,int card_id,
            //        int action,DateTime action_time,string description,float money)
            DateTime time  = DateTime.Now;
            managermentaction.insert_managerment_action(managerid, cardid, 1, time, "获取卡号信息", 0);


            string jsonText = sw.GetStringBuilder().ToString();
            byte[] messageBytes = Encoding.Default.GetBytes(jsonText);
            response.OutputStream.Write(messageBytes, 0, messageBytes.Length);
            response.Close();
        } // end public void Handle(HttpListenerContext context)



        public string GetName()
        {
            return NAME;
        }
    } // end public class MorningHttpRequestHandler


}