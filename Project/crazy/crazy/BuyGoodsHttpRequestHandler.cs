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
    public class BuyGoodsHttpRequestHandler : HttpRequestHandler
    {
        public const string NAME = "/Purchase";

        public void Handle(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            response.StatusCode = (int)HttpStatusCode.OK;
            // Get name from query string
            int cardid = int.Parse(context.Request.QueryString["cardId"]);
            int goodsid = int.Parse(context.Request.QueryString["goodsId"]);
            StringWriter sw = new StringWriter();
            JsonWriter jsonWriter = new JsonTextWriter(sw);

           
            bool istrue;
            PurchaseRecord puchaserecord = new PurchaseRecord(SQLSERVER.sqlstring);
            if (puchaserecord.buy_something(cardid, goodsid))
                istrue = true;
            else istrue = false;

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