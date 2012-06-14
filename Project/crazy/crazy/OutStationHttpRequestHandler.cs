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
using System.Web;


namespace crazy
{
    public class OutStationHttpRequestHandler : HttpRequestHandler
    {
        public const string NAME = "/OutStation";

        public void Handle(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            response.StatusCode = (int)HttpStatusCode.OK;
            // Get name from query string

            int cardid = int.Parse((context.Request.QueryString["cardId"]));
            string stationname = HttpUtility.UrlDecode((context.Request.QueryString["stationName"]) );
            float price = float.Parse((context.Request.QueryString["price"]));
            Station station = new Station(SQLSERVER.sqlstring);
            int stationid = station.get_station_id(stationname);    
            StringWriter sw = new StringWriter();
            JsonWriter jsonWriter = new JsonTextWriter(sw);

            Card card = new Card(SQLSERVER.sqlstring);
            bool istrue;
            if (card.inorout_station(cardid, stationid,price))
            {
                istrue = true;
            }
            else
                istrue = false;
            jsonWriter.WriteValue(istrue);
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