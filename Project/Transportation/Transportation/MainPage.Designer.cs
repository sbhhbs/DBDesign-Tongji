namespace Transportation
{
    partial class MainPage
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            this.railSystemButton = new System.Windows.Forms.Button();
            this.transportSystemButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // railSystemButton
            // 
            this.railSystemButton.BackColor = System.Drawing.Color.White;
            this.railSystemButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.railSystemButton.FlatAppearance.BorderSize = 0;
            this.railSystemButton.Image = ((System.Drawing.Image)(resources.GetObject("railSystemButton.Image")));
            this.railSystemButton.Location = new System.Drawing.Point(277, 200);
            this.railSystemButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.railSystemButton.Name = "railSystemButton";
            this.railSystemButton.Size = new System.Drawing.Size(258, 42);
            this.railSystemButton.TabIndex = 0;
            this.railSystemButton.UseVisualStyleBackColor = false;
            this.railSystemButton.Click += new System.EventHandler(this.railSystemButton_Click);
            // 
            // transportSystemButton
            // 
            this.transportSystemButton.BackColor = System.Drawing.Color.White;
            this.transportSystemButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.transportSystemButton.FlatAppearance.BorderSize = 0;
            this.transportSystemButton.Image = ((System.Drawing.Image)(resources.GetObject("transportSystemButton.Image")));
            this.transportSystemButton.Location = new System.Drawing.Point(277, 271);
            this.transportSystemButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.transportSystemButton.Name = "transportSystemButton";
            this.transportSystemButton.Size = new System.Drawing.Size(258, 42);
            this.transportSystemButton.TabIndex = 1;
            this.transportSystemButton.UseVisualStyleBackColor = false;
            this.transportSystemButton.Click += new System.EventHandler(this.transportSystemButton_Click);
            // 
            // MainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(782, 595);
            this.Controls.Add(this.transportSystemButton);
            this.Controls.Add(this.railSystemButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainPage";
            this.Text = "公交系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button railSystemButton;
        private System.Windows.Forms.Button transportSystemButton;

    }
}

