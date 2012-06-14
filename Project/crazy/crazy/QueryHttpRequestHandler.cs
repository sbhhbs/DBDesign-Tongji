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
    public class QueryHttpRequestHandler : HttpRequestHandler
    {
        public const string NAME = "/FindRoute";

        public void Handle(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            response.StatusCode = (int)HttpStatusCode.OK;
            // Get name from query string
            //byte[] startByte = HttpUtility.UrlDecodeToBytes((context.Request.QueryString["startStationName"]));
            //byte[] endByte = HttpUtility.UrlDecodeToBytes((context.Request.QueryString["endStationName"]));

            string start = HttpUtility.UrlDecode((context.Request.QueryString["startStationName"]), Encoding.Unicode);
            string end = HttpUtility.UrlDecode((context.Request.QueryString["endStationName"]), Encoding.Unicode);

            StringWriter sw = new StringWriter();
            JsonWriter jsonWriter = new JsonTextWriter(sw);

            RouteQuery query = new RouteQuery();
            query.InitData();
          
            List<string> list = query.Query(start, end);

            new JsonSerializer().Serialize(jsonWriter, list);

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

}