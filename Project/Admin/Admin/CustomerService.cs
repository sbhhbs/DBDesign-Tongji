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
    public partial class CustomerService : Form
    {
        public void setUserCardID(string text)
        {
            textCardID.Text = text;
        }
        public CustomerService()
        {
            InitializeComponent();
            ListViewSet();
            CreateViewItemMethodOne();
            initialization();
        }

        private void initialization()
        {
            textBoxBalance.Text = ResourceClass.cardInfo.Balance;
            userNameLabel.Text = ResourceClass.userInfo.UserName;
            userEmergencyTEL.Text = ResourceClass.userInfo.EmergencyTel;
            userBirthdayLabel.Text = ResourceClass.userInfo.Birthday;
            userGender.Text = ResourceClass.userInfo.Gender;
            userTELLabel.Text = ResourceClass.userInfo.Telephone;
            userWorkingLabel.Text = ResourceClass.userInfo.StaffId + ResourceClass.userInfo.Department;
            userWorkingTime.Text = ResourceClass.userInfo.WorkStartTime;

            this.panelUserInfo.Visible = true;
        }

        private void ListViewSet()
        {
            listViewHistoryQuery.View = View.Details;
        }
        private void CreateViewItemMethodOne()
        {
            //ActionListView.OwnerDraw = true;
            listViewHistoryQuery.BeginUpdate();
            #region
            //创建列表标题
            listViewHistoryQuery.Columns.Add("StartTime", "进站时间", -1);
            listViewHistoryQuery.Columns.Add("StartStation", "起点", -1);
            listViewHistoryQuery.Columns.Add("EndTime", "出站时间", -1);
            listViewHistoryQuery.Columns.Add("EndStation", "终点", -1);
            listViewHistoryQuery.Columns.Add("Fare", "车费", -1);
            #endregion

            #region 手動填加ListView方法

            //2、增加第一個Item，在View.Details模式下，有點像第一列中一個值


            #endregion
            listViewHistoryQuery.EndUpdate();
        }
        private void ServiceHistory_Load(object sender, EventArgs e)
        {
        }

        private void charge_Click(object sender, EventArgs e)
        {
            this.listViewHistoryQuery.Visible = false;
            this.panelChangeType.Visible = false;
            this.panelHistory.Visible = false;
            this.panelUnlock.Visible = false;
            this.panelUserInfo.Visible = false;
            this.panelRecharge.Visible = true;
        }

        private void change_Click(object sender, EventArgs e)
        {
            this.listViewHistoryQuery.Visible = false;
            this.panelHistory.Visible = false;
            this.panelUnlock.Visible = false;
            this.panelRecharge.Visible = false;
            this.panelUserInfo.Visible = false;
            this.panelChangeType.Visible = true;
        }

        private void lost_Click(object sender, EventArgs e)
        {
            this.listViewHistoryQuery.Visible = false;
            this.panelChangeType.Visible = false;
            this.panelHistory.Visible = false;
            this.panelRecharge.Visible = false;
            this.panelUserInfo.Visible = false;

            if (ResourceClass.cardInfo.Missing.Equals("0"))
            {
                if (lostCardService())
                {
                    ResourceClass.cardInfo.Missing = "1";
                    MessageBox.Show("成功挂失", "提醒", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("挂失失败", "提醒", MessageBoxButtons.OK);
                }

                this.panelUnlock.Visible = false;
                this.panelUserInfo.Visible = true;
            }
            else 
            {            
                this.panelUnlock.Visible = true;
            }


        }

        private bool lostCardService()
        {
            HttpWebRequest requestToServer = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ReportLoss?managerId=" + ResourceClass.managerId + "&&cardId=" + ResourceClass.cardId);
            requestToServer.AllowWriteStreamBuffering = false;
            requestToServer.KeepAlive = false;

            WebResponse response = requestToServer.GetResponse();
            StreamReader responseReader = new StreamReader(response.GetResponseStream());
            string replyFromServer = responseReader.ReadToEnd();

            JsonReader jsonReader = new JsonTextReader(new StringReader(replyFromServer));

            jsonReader.Read();

            return (bool)jsonReader.Value;
        }

        private void exit_Click(object sender, EventArgs e)
        {

            new Thread(new ThreadStart(goToServiceInfo)).Start();
            Close();
        }

        private void goToServiceInfo()
        {
            new ServiceInfo().ShowDialog();
        }

        private void buttonOkChangeType_Click(object sender, EventArgs e)
        {
            String cardType = "";

            if (radioButtonOldman.Checked)
            {
                cardType = "oldman_card";
            }
            else if (radioButtonRegular.Checked)
            {
                cardType = "normal_card";
            }
            else if (radioButtonStaff.Checked)
            {
                cardType = "staff_card";
            }
            else if (radioButtonStudent.Checked)
            {
                cardType = "student_card";
            }
            else
            {
                this.panelChangeType.Visible = false;
                return;
            }

            if (changeType(cardType))
            {
                MessageBox.Show("改变成功", "提醒", MessageBoxButtons.OK);
                ResourceClass.cardInfo.CardType = cardType;
            }
            else
            {
                MessageBox.Show("改变失败", "提醒", MessageBoxButtons.OK);
            }


            this.panelChangeType.Visible = false;
            this.panelUserInfo.Visible = true;
        }

        private bool changeType(string cardType)
        {
            HttpWebRequest requestToServer = (HttpWebRequest)WebRequest.Create("http://localhost:8080/ChangeCardType?cardType=" + cardType + "&&managerId=" + ResourceClass.managerId + "&&cardId=" + ResourceClass.cardId);
            requestToServer.AllowWriteStreamBuffering = false;
            requestToServer.KeepAlive = false;

            WebResponse response = requestToServer.GetResponse();
            StreamReader responseReader = new StreamReader(response.GetResponseStream());
            string replyFromServer = responseReader.ReadToEnd();

            JsonReader jsonReader = new JsonTextReader(new StringReader(replyFromServer));

            jsonReader.Read();

            return (bool)jsonReader.Value;
        }

        private void buttonOkLost_Click(object sender, EventArgs e)
        {
            this.panelUnlock.Visible = false;
            this.panelUserInfo.Visible = true;
        }

        private void buttonOkRecharge_Click(object sender, EventArgs e)
        {
            if (textBoxChargeAmount.Text == null || textBoxChargeAmount.Text.Length == 0)
            {
                MessageBox.Show("请输入金额", "提醒", MessageBoxButtons.OK);
                return;
            }
            if (recharge())
            {
                MessageBox.Show("充值成功", "提醒", MessageBoxButtons.OK);
                ResourceClass.cardInfo.Balance = (int.Parse(ResourceClass.cardInfo.Balance) + int.Parse(textBoxChargeAmount.Text)).ToString();
                textBoxBalance.Text = ResourceClass.cardInfo.Balance;
            }
            else
                MessageBox.Show("充值失败", "提醒", MessageBoxButtons.OK);

            this.panelRecharge.Visible = false;
            this.panelUserInfo.Visible = true;
        }

        private bool recharge()
        {
            HttpWebRequest requestToServer = (HttpWebRequest)WebRequest.Create("http://localhost:8080/AddMoney?money=" + textBoxChargeAmount.Text + "&&managerId=" + ResourceClass.managerId + "&&cardId=" + ResourceClass.cardId);
            requestToServer.AllowWriteStreamBuffering = false;
            requestToServer.KeepAlive = false;

            WebResponse response = requestToServer.GetResponse();
            StreamReader responseReader = new StreamReader(response.GetResponseStream());
            string replyFromServer = responseReader.ReadToEnd();

            JsonReader jsonReader = new JsonTextReader(new StringReader(replyFromServer));

            jsonReader.Read();

            return (bool)jsonReader.Value;
        }

        private void buttonOkUnlock_Click(object sender, EventArgs e)
        {
            // TODO : Add The Service Part
            MessageBox.Show("解除挂失成功！", "Success", MessageBoxButtons.OK);
            this.panelUnlock.Visible = false;
        }

        private void historyQuery_Click(object sender, EventArgs e)
        {
            List<TripRecord1> tripRecord = historyQueryService();

            for (int i = 0; i != tripRecord.Count; i++)
            {
                string lineName = "Line" + i;

                TripRecord1 temp = tripRecord.ElementAt(i);

                listViewHistoryQuery.Items.Add(lineName, temp.Start_time.ToString(), 0);
                listViewHistoryQuery.Items[lineName].SubItems.Add(temp.Start_station_name);
                listViewHistoryQuery.Items[lineName].SubItems.Add(temp.End_time.ToString());
                listViewHistoryQuery.Items[lineName].SubItems.Add(temp.End_startion_name.ToString());
                listViewHistoryQuery.Items[lineName].SubItems.Add(temp.Price.ToString());
            }

            this.panelChangeType.Visible = false;
            this.panelHistory.Visible = false;
            this.panelRecharge.Visible = false;
            this.panelUnlock.Visible = false;
            this.panelUserInfo.Visible = false;
            this.listViewHistoryQuery.Visible = true;

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

        private List<TripRecord1> historyQueryService()
        {
            HttpWebRequest requestToServer = (HttpWebRequest)WebRequest.Create("http://localhost:8080/GetTripRecords?managerId=" + ResourceClass.managerId + "&&cardId=" + ResourceClass.cardId);
            requestToServer.AllowWriteStreamBuffering = false;
            requestToServer.KeepAlive = false;

            WebResponse response = requestToServer.GetResponse();
            StreamReader responseReader = new StreamReader(response.GetResponseStream(), Encoding.Unicode);
            string replyFromServer = responseReader.ReadToEnd();

            List<TripRecord1> tripRecords = JsonConvert.DeserializeObject<List<TripRecord1>>(replyFromServer);

            return tripRecords;
        
        }

        private void radioButtonStudent_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonStaff_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonRegular_CheckedChanged(object sender, EventArgs e)
        {

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

        private void buttonShopping_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(goToShoopingView)).Start();
            Close();
        }

        private void goToShoopingView()
        {
            new ShoppingView().ShowDialog();
        }

        private void userWorkingLabel_Click(object sender, EventArgs e)
        {

        }


    }
}
