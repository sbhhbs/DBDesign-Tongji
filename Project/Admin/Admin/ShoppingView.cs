using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

namespace Admin
{
    public partial class ShoppingView : Form
    {
        private int goodsId = -1;

        public ShoppingView()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            goodsId = 9;
            goodsPrice.Text = "5";
        }

        private void ShoppingView_Load(object sender, EventArgs e)
        {

        }

        private void organgeJuice_Click(object sender, EventArgs e)
        {
            goodsId = 1;
            goodsPrice.Text = "4";
        }

        private void yogurt_Click(object sender, EventArgs e)
        {
            goodsId = 2;
            goodsPrice.Text = "4";
        }

        private void coke_Click(object sender, EventArgs e)
        {
            goodsId = 3;
            goodsPrice.Text = "3";
        }

        private void coca_Click(object sender, EventArgs e)
        {
            goodsId = 4;
            goodsPrice.Text = "3";
        }

        private void coffee_Click(object sender, EventArgs e)
        {
            goodsId = 5;
            goodsPrice.Text = "5";
        }

        private void molitea_Click(object sender, EventArgs e)
        {
            goodsId = 6;
            goodsPrice.Text = "4";
        }

        private void molihuatea_Click(object sender, EventArgs e)
        {
            goodsId = 7;
            goodsPrice.Text = "4";
        }

        private void pesiacoke_Click(object sender, EventArgs e)
        {
            goodsId = 8;
            goodsPrice.Text = "3";
        }

        private void buy_Click(object sender, EventArgs e)
        {
            if (goodsId != -1)
            {
                if (buyGoods())
                {
                    MessageBox.Show("购买成功", "提醒", MessageBoxButtons.OK);
                    goodsId = -1;
                }
                else
                {
                    MessageBox.Show("购买失败", "提醒", MessageBoxButtons.OK);
                    goodsId = -1;
                }
            }
            else 
            {
                MessageBox.Show("请先选择商品", "提醒", MessageBoxButtons.OK);
            }
        }

        private bool buyGoods()
        {

            HttpWebRequest requestToServer = (HttpWebRequest)WebRequest.Create("http://localhost:8080/Purchase?goodsId=" + goodsId + "&&cardId=" + ResourceClass.cardId);
            requestToServer.AllowWriteStreamBuffering = false;
            requestToServer.KeepAlive = false;

            WebResponse response = requestToServer.GetResponse();
            StreamReader responseReader = new StreamReader(response.GetResponseStream());
            string replyFromServer = responseReader.ReadToEnd();

            JsonReader jsonReader = new JsonTextReader(new StringReader(replyFromServer));

            jsonReader.Read();

            return (bool)jsonReader.Value;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(back)).Start();
            Close();
        }

        private void back()
        {
            new CustomerService().ShowDialog();
        }
    }
}
