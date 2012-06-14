namespace Admin
{
    partial class ServiceRecharge
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceRecharge));
            this.historyQuery = new System.Windows.Forms.Button();
            this.lost = new System.Windows.Forms.Button();
            this.change = new System.Windows.Forms.Button();
            this.charge = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.panelRecharge = new System.Windows.Forms.Panel();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // historyQuery
            // 
            this.historyQuery.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.historyQuery.Image = ((System.Drawing.Image)(resources.GetObject("historyQuery.Image")));
            this.historyQuery.Location = new System.Drawing.Point(266, 449);
            this.historyQuery.Name = "historyQuery";
            this.historyQuery.Size = new System.Drawing.Size(72, 28);
            this.historyQuery.TabIndex = 9;
            this.historyQuery.UseVisualStyleBackColor = true;
            this.historyQuery.Click += new System.EventHandler(this.historyQuery_Click);
            // 
            // lost
            // 
            this.lost.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.lost.Image = ((System.Drawing.Image)(resources.GetObject("lost.Image")));
            this.lost.Location = new System.Drawing.Point(147, 318);
            this.lost.Name = "lost";
            this.lost.Size = new System.Drawing.Size(72, 28);
            this.lost.TabIndex = 8;
            this.lost.UseVisualStyleBackColor = true;
            this.lost.Click += new System.EventHandler(this.lost_Click);
            // 
            // change
            // 
            this.change.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.change.Image = ((System.Drawing.Image)(resources.GetObject("change.Image")));
            this.change.Location = new System.Drawing.Point(266, 318);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(72, 28);
            this.change.TabIndex = 7;
            this.change.UseVisualStyleBackColor = true;
            this.change.Click += new System.EventHandler(this.change_Click);
            // 
            // charge
            // 
            this.charge.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.charge.Image = ((System.Drawing.Image)(resources.GetObject("charge.Image")));
            this.charge.Location = new System.Drawing.Point(266, 254);
            this.charge.Name = "charge";
            this.charge.Size = new System.Drawing.Size(72, 28);
            this.charge.TabIndex = 6;
            this.charge.UseVisualStyleBackColor = true;
            this.charge.Click += new System.EventHandler(this.charge_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.MenuText;
            this.textBox1.Enabled = false;
            this.textBox1.Font = new System.Drawing.Font("宋体", 13F);
            this.textBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.textBox1.Location = new System.Drawing.Point(66, 55);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(272, 27);
            this.textBox1.TabIndex = 10;
            // 
            // button2
            // 
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.Location = new System.Drawing.Point(246, 379);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(92, 27);
            this.button2.TabIndex = 12;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // panelRecharge
            // 
            this.panelRecharge.BackColor = System.Drawing.Color.Transparent;
            this.panelRecharge.BackgroundImage = global::Admin.Properties.Resources.Right_Recharge;
            this.panelRecharge.Location = new System.Drawing.Point(442, 27);
            this.panelRecharge.Name = "panelRecharge";
            this.panelRecharge.Size = new System.Drawing.Size(335, 532);
            this.panelRecharge.TabIndex = 13;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Black;
            this.textBox2.Enabled = false;
            this.textBox2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.ForeColor = System.Drawing.Color.White;
            this.textBox2.Location = new System.Drawing.Point(107, 195);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(231, 29);
            this.textBox2.TabIndex = 14;
            // 
            // Exit
            // 
            this.Exit.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Exit.Image = global::Admin.Properties.Resources.Exit;
            this.Exit.Location = new System.Drawing.Point(266, 510);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(72, 28);
            this.Exit.TabIndex = 15;
            this.Exit.UseVisualStyleBackColor = true;
            // 
            // ServiceRecharge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(804, 602);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.panelRecharge);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.historyQuery);
            this.Controls.Add(this.lost);
            this.Controls.Add(this.change);
            this.Controls.Add(this.charge);
            this.Name = "ServiceRecharge";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServiceRecharge";
            this.Load += new System.EventHandler(this.ServiceRecharge_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button historyQuery;
        private System.Windows.Forms.Button lost;
        private System.Windows.Forms.Button change;
        private System.Windows.Forms.Button charge;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelRecharge;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button Exit;
    }
}