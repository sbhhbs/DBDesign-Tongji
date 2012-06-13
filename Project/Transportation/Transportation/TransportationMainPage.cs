using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Transportation
{
    public partial class TransportationMainPage : Form
    {
        public TransportationMainPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (connectToServer())
            {
                new Thread(new ThreadStart(logIn)).Start();
                Close();
            }
        }

        private void logIn()
        {
            new MainPage().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool connectToServer()
        {

<<<<<<< HEAD
            if (CardID.Text.Length == 0 || CardID.Text == null)
            {
                MessageBox.Show("请输入卡号", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            HttpWebRequest requestToServer = (HttpWebRequest)WebRequest.Create("http://localhost:8080/UserIn?userId=" + CardID.Text);
            requestToServer.AllowWriteStreamBuffering = false;
            requestToServer.KeepAlive = false;

            WebResponse response = requestToServer.GetResponse();
            StreamReader responseReader = new StreamReader(response.GetResponseStream());
            string replyFromServer = responseReader.ReadToEnd();

            JsonReader jsonReader = new JsonTextReader(new StringReader(replyFromServer));

            jsonReader.Read();
            
            return (bool)jsonReader.Value;
            
        }

        private void TransportationMainPage_Load(object sender, EventArgs e)
        {

        }

        private void CardID_TextChanged(object sender, EventArgs e)
=======
            HttpWebRequest requestToServer = (HttpWebRequest)WebRequest.Create("http://127.0.0.1:8080/UserIn?userId=" + CardID.Text);
            requestToServer.AllowWriteStreamBuffering = false;
            requestToServer.KeepAlive = false;

            try
            {

                WebResponse response = requestToServer.GetResponse();
                StreamReader responseReader = new StreamReader(response.GetResponseStream());
                string replyFromServer = responseReader.ReadToEnd();

                JsonReader jsonReader = new JsonTextReader(new StringReader(replyFromServer));

                jsonReader.Read();

                return (bool)jsonReader.Value;
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e.StackTrace);
                System.Console.WriteLine(e.ToString());
            }

            return false;
            
        }

        private void TransportationMainPage_Load(object sender, EventArgs e)
>>>>>>> 3dede48173b97823b4add529b8d2a73ab8286c26
        {

        }
    }

}
