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
    public class ReportLossHttpRequestHandler : HttpRequestHandler
    {
        public const string NAME = "/ReportLoss";

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
            card.report_loss(cardid);

            ManagermentAction managermentaction = new ManagermentAction(SQLSERVER.sqlstring);
            //int manager_id,int card_id,
            //        int action,DateTime action_time,string description,float money)
            DateTime time = DateTime.Now;
            managermentaction.insert_managerment_action(managerid, cardid, 4, time, "挂失", 0);

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