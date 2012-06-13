using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

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
            listViewHistoryQuery.Items.Add("action1", "2012-6-13 15:27", 0);
            listViewHistoryQuery.Items["action1"].SubItems.Add("上海汽车城");
            listViewHistoryQuery.Items["action1"].SubItems.Add("2012-6-14 1:32");
            listViewHistoryQuery.Items["action1"].SubItems.Add("同济大学");
            listViewHistoryQuery.Items["action1"].SubItems.Add("6.00");

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
            this.panelRecharge.Visible = true;
        }

        private void change_Click(object sender, EventArgs e)
        {
            this.listViewHistoryQuery.Visible = false;
            this.panelHistory.Visible = false;
            this.panelUnlock.Visible = false;
            this.panelRecharge.Visible = false;
            this.panelChangeType.Visible = true;
        }

        private void lost_Click(object sender, EventArgs e)
        {
            this.listViewHistoryQuery.Visible = false;
            this.panelChangeType.Visible = false;
            this.panelHistory.Visible = false;
            this.panelRecharge.Visible = false;
            this.panelUnlock.Visible = true;
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
            this.panelChangeType.Visible = false;
        }

        private void buttonOkLost_Click(object sender, EventArgs e)
        {
            this.panelUnlock.Visible = false;
        }

        private void buttonOkRecharge_Click(object sender, EventArgs e)
        {
            this.panelRecharge.Visible = false;
        }

        private void buttonOkUnlock_Click(object sender, EventArgs e)
        {
            MessageBox.Show("解除挂失成功！", "Success", MessageBoxButtons.OK);
        }

        private void historyQuery_Click(object sender, EventArgs e)
        {
            this.panelChangeType.Visible = false;
            this.panelHistory.Visible = false;
            this.panelRecharge.Visible = false;
            this.panelUnlock.Visible = false;
            this.listViewHistoryQuery.Visible = true;
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
            if (e.KeyChar > '0' && e.KeyChar < '9' || e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            else
                e.Handled = true;
        }

    }
}
