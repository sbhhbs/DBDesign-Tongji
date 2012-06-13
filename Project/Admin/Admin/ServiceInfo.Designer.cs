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
            this.buttonServiceCustomer = new System.Windows.Forms.Button();
            this.buttonServiceInfo = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
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
            this.userCardID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.userCardID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.userCardID_KeyPress);
            // 
            // buttonServiceCustomer
            // 
            this.buttonServiceCustomer.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonServiceCustomer.BackgroundImage")));
            this.buttonServiceCustomer.Location = new System.Drawing.Point(132, 271);
            this.buttonServiceCustomer.Name = "buttonServiceCustomer";
            this.buttonServiceCustomer.Size = new System.Drawing.Size(129, 32);
            this.buttonServiceCustomer.TabIndex = 1;
            this.buttonServiceCustomer.UseVisualStyleBackColor = true;
            this.buttonServiceCustomer.Click += new System.EventHandler(this.buttonCustomerService_Click);
            // 
            // buttonServiceInfo
            // 
            this.buttonServiceInfo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonServiceInfo.BackgroundImage")));
            this.buttonServiceInfo.Location = new System.Drawing.Point(132, 386);
            this.buttonServiceInfo.Name = "buttonServiceInfo";
            this.buttonServiceInfo.Size = new System.Drawing.Size(128, 27);
            this.buttonServiceInfo.TabIndex = 2;
            this.buttonServiceInfo.UseVisualStyleBackColor = true;
            this.buttonServiceInfo.Click += new System.EventHandler(this.buttonServiceInfo_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonExit.BackgroundImage")));
            this.buttonExit.Location = new System.Drawing.Point(157, 491);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(78, 31);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // ActionListView
            // 
            this.ActionListView.BackColor = System.Drawing.SystemColors.InfoText;
            this.ActionListView.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ActionListView.Location = new System.Drawing.Point(439, 24);
            this.ActionListView.Name = "ActionListView";
            this.ActionListView.Size = new System.Drawing.Size(338, 535);
            this.ActionListView.TabIndex = 4;
            this.ActionListView.UseCompatibleStateImageBehavior = false;
            this.ActionListView.Visible = false;
            this.ActionListView.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.ActionListView_DrawColumnHeader);
            this.ActionListView.DrawItem += new System.Windows.Forms.DrawListViewItemEventHandler(this.ActionListView_DrawItem);
            this.ActionListView.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.ActionListView_DrawSubItem);
            this.ActionListView.SelectedIndexChanged += new System.EventHandler(this.ActionListView_SelectedIndexChanged);
            // 
            // ServiceInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(804, 612);
            this.Controls.Add(this.ActionListView);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.buttonServiceInfo);
            this.Controls.Add(this.buttonServiceCustomer);
            this.Controls.Add(this.userCardID);
            this.Name = "ServiceInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ServiceInfo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userCardID;
        private System.Windows.Forms.Button buttonServiceCustomer;
        private System.Windows.Forms.Button buttonServiceInfo;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ListView ActionListView;
    }
}