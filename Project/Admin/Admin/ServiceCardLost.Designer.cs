namespace Admin
{
    partial class ServiceCardLost
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceCardLost));
            this.balanceQuery = new System.Windows.Forms.Button();
            this.charge = new System.Windows.Forms.Button();
            this.change = new System.Windows.Forms.Button();
            this.lost = new System.Windows.Forms.Button();
            this.historyQuery = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panelRecharge = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // balanceQuery
            // 
            this.balanceQuery.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.balanceQuery.Image = ((System.Drawing.Image)(resources.GetObject("balanceQuery.Image")));
            this.balanceQuery.Location = new System.Drawing.Point(282, 180);
            this.balanceQuery.Name = "balanceQuery";
            this.balanceQuery.Size = new System.Drawing.Size(72, 28);
            this.balanceQuery.TabIndex = 0;
            this.balanceQuery.UseVisualStyleBackColor = true;
            this.balanceQuery.Click += new System.EventHandler(this.balanceQuery_Click);
            // 
            // charge
            // 
            this.charge.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.charge.Image = ((System.Drawing.Image)(resources.GetObject("charge.Image")));
            this.charge.Location = new System.Drawing.Point(282, 243);
            this.charge.Name = "charge";
            this.charge.Size = new System.Drawing.Size(72, 28);
            this.charge.TabIndex = 1;
            this.charge.UseVisualStyleBackColor = true;
            this.charge.Click += new System.EventHandler(this.charge_Click);
            // 
            // change
            // 
            this.change.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.change.Image = ((System.Drawing.Image)(resources.GetObject("change.Image")));
            this.change.Location = new System.Drawing.Point(282, 320);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(72, 28);
            this.change.TabIndex = 2;
            this.change.UseVisualStyleBackColor = true;
            this.change.Click += new System.EventHandler(this.change_Click);
            // 
            // lost
            // 
            this.lost.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lost.Image = ((System.Drawing.Image)(resources.GetObject("lost.Image")));
            this.lost.Location = new System.Drawing.Point(157, 399);
            this.lost.Name = "lost";
            this.lost.Size = new System.Drawing.Size(72, 28);
            this.lost.TabIndex = 3;
            this.lost.UseVisualStyleBackColor = true;
            // 
            // historyQuery
            // 
            this.historyQuery.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.historyQuery.Image = ((System.Drawing.Image)(resources.GetObject("historyQuery.Image")));
            this.historyQuery.Location = new System.Drawing.Point(282, 492);
            this.historyQuery.Name = "historyQuery";
            this.historyQuery.Size = new System.Drawing.Size(72, 28);
            this.historyQuery.TabIndex = 4;
            this.historyQuery.UseVisualStyleBackColor = true;
            this.historyQuery.Click += new System.EventHandler(this.historyQuery_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuText;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("宋体", 12F);
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(66, 53);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(274, 26);
            this.textBox1.TabIndex = 5;
            // 
            // panelRecharge
            // 
            this.panelRecharge.BackColor = System.Drawing.Color.Transparent;
            this.panelRecharge.BackgroundImage = global::Admin.Properties.Resources.Right_CardLost;
            this.panelRecharge.Location = new System.Drawing.Point(440, 24);
            this.panelRecharge.Name = "panelRecharge";
            this.panelRecharge.Size = new System.Drawing.Size(335, 532);
            this.panelRecharge.TabIndex = 15;
            // 
            // ServiceCardLost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(804, 602);
            this.Controls.Add(this.panelRecharge);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.historyQuery);
            this.Controls.Add(this.lost);
            this.Controls.Add(this.change);
            this.Controls.Add(this.charge);
            this.Controls.Add(this.balanceQuery);
            this.Name = "ServiceCardLost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Services";
            this.Load += new System.EventHandler(this.ServiceCardLost_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button balanceQuery;
        private System.Windows.Forms.Button charge;
        private System.Windows.Forms.Button change;
        private System.Windows.Forms.Button lost;
        private System.Windows.Forms.Button historyQuery;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panelRecharge;
    }
}