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
    public class ManagermentActionHttpRequestHandler : HttpRequestHandler
    {
        public const string NAME = "/ManagermentAction";

        public void Handle(HttpListenerContext context)
        {
            HttpListenerResponse response = context.Response;
            response.StatusCode = (int)HttpStatusCode.OK;

            // Get name from query string
            int managerid = int.Parse(context.Request.QueryString["managerId"]);
            StringWriter sw = new StringWriter();
            JsonWriter jsonWriter = new JsonTextWriter(sw);


            ManagermentAction managermentaction = new ManagermentAction(SQLSERVER.sqlstring);
            SqlDataReader myreader = managermentaction.manageroperation(managerid);
            List<ManagermentAction1> actions = new List<ManagermentAction1>();
            while (myreader.Read())
            {
                   int manager_id = int.Parse(myreader["manager_id"].ToString());
                   int card_id = int.Parse(myreader["card_id"].ToString());
                   int action = int.Parse(myreader["action"].ToString());
                   string action_time = myreader["action_time"].ToString();
                   string description = myreader["description"].ToString();
                   float money = float.Parse(myreader["money"].ToString());
                   ManagermentAction1 temp = new ManagermentAction1(manager_id,
                       card_id, action, action_time, description, money);
                   actions.Add(temp);
            }
            myreader.Close();

            new JsonSerializer().Serialize(jsonWriter, actions);

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


    class ManagermentAction1
    {
        int manager_id;

        public int Manager_id
        {
            get { return manager_id; }
            set { manager_id = value; }
        }


        private int card_id;

        public int Card_id
        {
            get { return card_id; }
            set { card_id = value; }
        }

        int action;

        public int Action
        {
            get { return action; }
            set { action = value; }
        }

        string action_time;

        public string Action_time
        {
            get { return action_time; }
            set { action_time = value; }
        }

        string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        float money;

        public float Money
        {
            get { return money; }
            set { money = value; }
        }

        public ManagermentAction1(int manager_id, int card_id, int action,
        string action_time,
        string description,
        float money)
        {
            this.manager_id = manager_id;
            this.card_id = card_id;
            this.action = action;
            this.action_time = action_time;
            this.description = description;
            this.money = money;
        }
    }
}