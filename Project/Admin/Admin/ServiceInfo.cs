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

namespace Admin
{
    public partial class ServiceInfo : Form
    {

        public ServiceInfo()
        {
            InitializeComponent();
            ListViewSet();
            CreateViewItemMethodOne();        
        }

        private void ListViewSet()
        {
            ActionListView.View = View.Details;
        }
        private void CreateViewItemMethodOne()
        {
            //ActionListView.OwnerDraw = true;
            ActionListView.BeginUpdate();
            #region 
            //创建列表标题
            ActionListView.Columns.Add("datetime","操作时间",-1);
            ActionListView.Columns.Add("cardID","卡号",-1);
            ActionListView.Columns.Add("type","操作类型",-2);
            ActionListView.Columns.Add("money","操作金额",-2);
            ActionListView.Columns.Add("description","备注",-1);
            #endregion

            //#region 手動填加ListView方法

            ////2、增加第一個Item，在View.Details模式下，有點像第一列中一個值
            //ActionListView.Items.Add("action1", "2012-6-13 15:27", 0);
            ////3、增加第一個Item的第一個SubItem，在View.Details模式下，有點像第一列中一個值
            //ActionListView.Items["action1"].SubItems.Add("10287373");
            ////增加第一個Item的第二個SubItem，在View.Details模式下，有點像第一列中一個值
            //ActionListView.Items["action1"].SubItems.Add("pay");
            //ActionListView.Items["action1"].SubItems.Add("8.00");
            //ActionListView.Items["action1"].SubItems.Add("助学金");

            

            //#endregion
            ActionListView.EndUpdate();
        }

        private void userCardID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

        private void ServiceInfo_Load(object sender, EventArgs e)
        {

        }

        private void returnMain()
        {
            MainPage mainPage = new MainPage();
            mainPage.ShowDialog();
        }

        private UserInfo getUserInfo()
        {
            HttpWebRequest requestToServer = (HttpWebRequest)WebRequest.Create("http://localhost:8080/UserInformation?userId=" + ResourceClass.cardInfo.UserID);
            requestToServer.AllowWriteStreamBuffering = false;
            requestToServer.KeepAlive = false;

            WebResponse response = requestToServer.GetResponse();
            StreamReader responseReader = new StreamReader(response.GetResponseStream(), Encoding.Unicode);
            string replyFromServer = responseReader.ReadToEnd();

            UserInfo userInfo = JsonConvert.DeserializeObject<UserInfo>(replyFromServer);

            return userInfo;
        }

        private void buttonCustomerService_Click(object sender, EventArgs e)
        {
            if (userCardID.Text.Length == 0 || userCardID.Text == null)
            {
                MessageBox.Show("请输入8位公交卡号", "警告", MessageBoxButtons.OK);
            }
            else if (userCardID.Text.Length != 8)
            {
                MessageBox.Show("8位公交卡号输入错误", "出错", MessageBoxButtons.OK);
            }
            else 
            {
                if (validateCard())
                {
                    ResourceClass.cardId = userCardID.Text;
                    getCardInfo();
                    ResourceClass.userInfo = getUserInfo();
                    new Thread(new ThreadStart(goToCustomerService)).Start();
                    Close();
                }
                else
                    MessageBox.Show("卡号错误", "出错", MessageBoxButtons.OK);
            }
        }

        private void getCardInfo()
        {
            HttpWebRequest requestToServer = (HttpWebRequest)WebRequest.Create("http://localhost:8080/CardInformation?cardId=" + ResourceClass.cardId + "&&managerId=" + ResourceClass.managerId);
            requestToServer.AllowWriteStreamBuffering = false;
            requestToServer.KeepAlive = false;

            WebResponse response = requestToServer.GetResponse();
            StreamReader responseReader = new StreamReader(response.GetResponseStream());
            string replyFromServer = responseReader.ReadToEnd();

            ResourceClass.cardInfo = JsonConvert.DeserializeObject<CardInfo>(replyFromServer);
        }

        private bool validateCard()
        {
            HttpWebRequest requestToServer = (HttpWebRequest)WebRequest.Create("http://localhost:8080/UserIn?userId=" + userCardID.Text);
            requestToServer.AllowWriteStreamBuffering = false;
            requestToServer.KeepAlive = false;

            WebResponse response = requestToServer.GetResponse();
            StreamReader responseReader = new StreamReader(response.GetResponseStream());
            string replyFromServer = responseReader.ReadToEnd();

            JsonReader jsonReader = new JsonTextReader(new StringReader(replyFromServer));

            jsonReader.Read();

            return (bool)jsonReader.Value;
        }

        private void goToCustomerService()
        {
            CustomerService customerService = new CustomerService();
            customerService.setUserCardID(userCardID.Text);
            customerService.ShowDialog();
        }

        private void ActionListView_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.White, e.Bounds);	//采用特定颜色绘制标题列
            e.DrawText();
        }

        private void ActionListView_DrawItem(object sender, DrawListViewItemEventArgs e)
        {
            e.DrawDefault = true;
        }

        private void ActionListView_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            e.DrawDefault = true;	//采用系统默认方式绘制子项
            e.DrawFocusRectangle(e.Bounds);
        }

        private void ActionListView_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void buttonServiceInfo_Click(object sender, EventArgs e)
        {
            List<ManagermentAction1> managementAction = getManagementActions();

            for (int i = 0; i != managementAction.Count; i++)
            {
                ManagermentAction1 temp = managementAction.ElementAt(i);

                string lineName = "Line" + i;
                ActionListView.Items.Add(lineName, temp.Action_time, i);
                ActionListView.Items[lineName].SubItems.Add((temp.Card_id).ToString());
                ActionListView.Items[lineName].SubItems.Add(Utility.actions[temp.Action - 1]);
                ActionListView.Items[lineName].SubItems.Add((temp.Money).ToString());
                ActionListView.Items[lineName].SubItems.Add(temp.Description);
            }

            ActionListView.Visible = true;

        }

        private List<ManagermentAction1> getManagementActions()
        {
            List<ManagermentAction1> actions = new List<ManagermentAction1>();

            HttpWebRequest requestToServer = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ManagermentAction?managerId=" + ResourceClass.managerId);
            requestToServer.AllowWriteStreamBuffering = false;
            requestToServer.KeepAlive = false;

            WebResponse response = requestToServer.GetResponse();
            StreamReader responseReader = new StreamReader(response.GetResponseStream(), Encoding.Unicode);
            string replyFromServer = responseReader.ReadToEnd();

            actions = JsonConvert.DeserializeObject<List<ManagermentAction1>>(replyFromServer);

            return actions;
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(returnMain)).Start();
            Close();
        }
    }
}
