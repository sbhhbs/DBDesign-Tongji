namespace Admin
{
    partial class ServiceChange
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServiceChange));
            this.historyQuery = new System.Windows.Forms.Button();
            this.lost = new System.Windows.Forms.Button();
            this.change = new System.Windows.Forms.Button();
            this.charge = new System.Windows.Forms.Button();
            this.balanceQuery = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // historyQuery
            // 
            this.historyQuery.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.historyQuery.Image = ((System.Drawing.Image)(resources.GetObject("historyQuery.Image")));
            this.historyQuery.Location = new System.Drawing.Point(282, 492);
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
            this.lost.Location = new System.Drawing.Point(157, 399);
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
            this.change.Location = new System.Drawing.Point(282, 320);
            this.change.Name = "change";
            this.change.Size = new System.Drawing.Size(72, 28);
            this.change.TabIndex = 7;
            this.change.UseVisualStyleBackColor = true;
            // 
            // charge
            // 
            this.charge.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.charge.Image = ((System.Drawing.Image)(resources.GetObject("charge.Image")));
            this.charge.Location = new System.Drawing.Point(282, 243);
            this.charge.Name = "charge";
            this.charge.Size = new System.Drawing.Size(72, 28);
            this.charge.TabIndex = 6;
            this.charge.UseVisualStyleBackColor = true;
            this.charge.Click += new System.EventHandler(this.charge_Click);
            // 
            // balanceQuery
            // 
            this.balanceQuery.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.balanceQuery.Image = ((System.Drawing.Image)(resources.GetObject("balanceQuery.Image")));
            this.balanceQuery.Location = new System.Drawing.Point(282, 180);
            this.balanceQuery.Name = "balanceQuery";
            this.balanceQuery.Size = new System.Drawing.Size(72, 28);
            this.balanceQuery.TabIndex = 5;
            this.balanceQuery.UseVisualStyleBackColor = true;
            this.balanceQuery.Click += new System.EventHandler(this.balanceQuery_Click);
            // 
            // ServiceChange
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(804, 602);
            this.Controls.Add(this.historyQuery);
            this.Controls.Add(this.lost);
            this.Controls.Add(this.change);
            this.Controls.Add(this.charge);
            this.Controls.Add(this.balanceQuery);
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Name = "ServiceChange";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServiceChange";
            this.Load += new System.EventHandler(this.ServiceChange_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button historyQuery;
        private System.Windows.Forms.Button lost;
        private System.Windows.Forms.Button change;
        private System.Windows.Forms.Button charge;
        private System.Windows.Forms.Button balanceQuery;
    }
}