using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;

namespace crazy
{
    class CardInActionHttpRequestHandler : HttpRequestHandler
    {
        public const string NAME = "/UserIn";

        public void Handle(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            response.StatusCode = (int)HttpStatusCode.OK;

            // Get name from query string
            int name = int.Parse(context.Request.QueryString["userId"]);
          
            StringWriter sw = new StringWriter();

            JsonWriter jsonWriter = new JsonTextWriter(sw);

            bool istrue;

                Card  card = new Card(SQLSERVER.sqlstring);
                if (!card.check_card_isexist(name))
                {
                    istrue = false;
                }
                else
                {
                    istrue = true;
                }

            jsonWriter.WriteValue(istrue);

            string jsonText = sw.GetStringBuilder().ToString();
            byte[] messageBytes = Encoding.Default.GetBytes(jsonText);
            response.OutputStream.Write(messageBytes, 0, messageBytes.Length);
            response.Close();
        } 

        public string GetName()
        {
            return NAME;
        }
    }
}
