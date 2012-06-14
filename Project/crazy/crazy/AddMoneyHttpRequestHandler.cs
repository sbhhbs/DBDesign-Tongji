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
    public class AddMoneyHttpRequestHandler : HttpRequestHandler
    {
        public const string NAME = "/AddMoney";

        public void Handle(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            response.StatusCode = (int)HttpStatusCode.OK;
            // Get name from query string
            int cardid = int.Parse(context.Request.QueryString["cardId"]);
            int managerid = int.Parse(context.Request.QueryString["managerId"]);
                int money = int.Parse(context.Request.QueryString["money"]);
            StringWriter sw = new StringWriter();
            JsonWriter jsonWriter = new JsonTextWriter(sw);


            Card card = new Card(SQLSERVER.sqlstring);
            card.add_money(cardid, money);

            ManagermentAction managermentaction = new ManagermentAction(SQLSERVER.sqlstring);
            //int manager_id,int card_id,
            //        int action,DateTime action_time,string description,float money)
            DateTime time = DateTime.Now;
            managermentaction.insert_managerment_action(managerid, cardid, 2, time, "充值", money);

            jsonWriter.WriteValue(true);

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