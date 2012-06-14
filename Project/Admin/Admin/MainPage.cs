using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Web;

namespace Admin
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void go_Click(object sender, EventArgs e)
        {
            this.Hide();
            CustomerService service = new CustomerService();
            service.Show();
        }

        private void MainPage_Load(object sender, EventArgs e)
        {

        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            if ((textBoxUserName.Text == null) || (textBoxPassword.Text == null))
            {
                MessageBox.Show("用户名或密码不可为空哦！", "出错", MessageBoxButtons.OK);
            }
            else if ((textBoxUserName.Text.Length == 0) || (textBoxPassword.Text.Length == 0))
            {
                MessageBox.Show("用户名或密码不可为空哦！", "出错", MessageBoxButtons.OK);
            }
            else
            {
                if (logInService())
                {
                    ResourceClass.managerId = textBoxUserName.Text;
                    new Thread(new ThreadStart(logIn)).Start();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("账号或密码错误！", "出错", MessageBoxButtons.OK);
                }
            }
        }

        private void logIn()
        {
            ServiceInfo serviceInfo = new ServiceInfo();
            serviceInfo.ShowDialog();
        }

        private bool logInService()
        {

            HttpWebRequest requestToServer = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ManagerRegister?managerId=" + textBoxUserName.Text + "&&password=" + textBoxPassword.Text);
            requestToServer.AllowWriteStreamBuffering = false;
            requestToServer.KeepAlive = false;

            WebResponse response = requestToServer.GetResponse();
            StreamReader responseReader = new StreamReader(response.GetResponseStream());
            string replyFromServer = responseReader.ReadToEnd();

            JsonReader jsonReader = new JsonTextReader(new StringReader(replyFromServer));

            jsonReader.Read();

            return (bool)jsonReader.Value;
        }
    }
}
