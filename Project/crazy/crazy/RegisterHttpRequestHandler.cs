using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Web;

namespace crazy
{
    public class RegisterHttpRequestHandler : HttpRequestHandler
    {
        public const string NAME = "/ManagerRegister";

        public void Handle(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            response.StatusCode = (int)HttpStatusCode.OK;

            // Get name from query string
            string nameIndex = context.Request.QueryString["managerId"];
            int name = int.Parse(nameIndex);
            string str = (context.Request.QueryString["password"]);
            StringWriter sw = new StringWriter();
            JsonWriter jsonWriter = new JsonTextWriter(sw);

            string message;
            bool istrue;
            if (name == null)
            {
                istrue = false;
            }
            else
            {
                Manager manager = new Manager(SQLSERVER.sqlstring);
                if (manager.register(name, str))
                {
                    istrue = true;
                }
                else
                {
                    istrue = false;
                }

            } // end if

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
