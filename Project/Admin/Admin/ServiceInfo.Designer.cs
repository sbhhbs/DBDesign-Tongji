namespace Admin
{
    partial class ServiceInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceInfo));
            this.userCardID = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.ActionListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // userCardID
            // 
            this.userCardID.BackColor = System.Drawing.SystemColors.MenuText;
            this.userCardID.Font = new System.Drawing.Font("宋体", 12F);
            this.userCardID.ForeColor = System.Drawing.SystemColors.Window;
            this.userCardID.Location = new System.Drawing.Point(55, 54);
            this.userCardID.Name = "userCardID";
            this.userCardID.Size = new System.Drawing.Size(280, 26);
            this.userCardID.TabIndex = 0;
            this.userCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.userCardID_KeyPress);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.Location = new System.Drawing.Point(132, 271);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 32);
            this.button1.TabIndex = 1;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.Location = new System.Drawing.Point(132, 386);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(128, 27);
            this.button2.TabIndex = 2;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.Location = new System.Drawing.Point(157, 491);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 31);
            this.button3.TabIndex = 3;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ActionListView
            // 
            this.ActionListView.BackColor = System.Drawing.SystemColors.InfoText;
            this.ActionListView.Location = new System.Drawing.Point(445, 25);
            this.ActionListView.Name = "ActionListView";
            this.ActionListView.Size = new System.Drawing.Size(330, 530);
            this.ActionListView.TabIndex = 4;
            this.ActionListView.UseCompatibleStateImageBehavior = false;
            // 
            // ServiceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(804, 612);
            this.Controls.Add(this.ActionListView);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.userCardID);
            this.Name = "ServiceInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ServiceInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userCardID;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ListView ActionListView;
    }
}