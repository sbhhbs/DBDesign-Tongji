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
    class GetUserInformationHttpRequestHandler : HttpRequestHandler
    {
        public const string NAME = "/UserInformation";

        public void Handle(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            response.StatusCode = (int)HttpStatusCode.OK;

            string idString = context.Request.QueryString["userId"];
            int id = int.Parse(idString);

            StringWriter sw = new StringWriter();

            JsonWriter jsonWriter = new JsonTextWriter(sw);

            User user = new User(SQLSERVER.sqlstring);
            SqlDataReader myreader = user.get_user_information(id);

            UserInfo userInfo = new UserInfo();

            while(myreader.Read())
            {
                userInfo.UserId = myreader["user_id"].ToString();
                userInfo.UserName = myreader["user_name"].ToString();
                userInfo.Birthday = myreader["birthday"].ToString();
                userInfo.Telephone = myreader["telephone"].ToString();
                userInfo.Gender = myreader["gender"].ToString();
                userInfo.StaffId = myreader["staff_id"].ToString();
                userInfo.Department = myreader["department"].ToString();
                userInfo.WorkStartTime = myreader["work_start_time"].ToString();
                userInfo.EmergencyTel = myreader["emergency_tel"].ToString();

            }

            new JsonSerializer().Serialize(jsonWriter, userInfo);

            myreader.Close();
            string jsonText = sw.GetStringBuilder().ToString();
            byte[] messageBytes = Encoding.Unicode.GetBytes(jsonText);
            response.OutputStream.Write(messageBytes, 0, messageBytes.Length);
            response.Close();
        }

        public string GetName()
        {
            return NAME;
        }
    }
}
