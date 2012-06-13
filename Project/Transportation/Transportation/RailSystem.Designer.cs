namespace Transportation
{
    partial class RailSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RailSystem));
            this.map = new System.Windows.Forms.PictureBox();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Return = new System.Windows.Forms.Button();
            this.startPos = new System.Windows.Forms.Label();
            this.endPos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.map)).BeginInit();
            this.SuspendLayout();
            // 
            // map
            // 
            this.map.Image = ((System.Drawing.Image)(resources.GetObject("map.Image")));
            this.map.InitialImage = null;
            this.map.Location = new System.Drawing.Point(46, 47);
            this.map.Name = "map";
            this.map.Size = new System.Drawing.Size(505, 511);
            this.map.TabIndex = 0;
            this.map.TabStop = false;
            this.map.Paint += new System.Windows.Forms.PaintEventHandler(this.map_Paint);
            this.map.MouseDown += new System.Windows.Forms.MouseEventHandler(this.map_MouseDown);
            this.map.MouseMove += new System.Windows.Forms.MouseEventHandler(this.map_MouseMove);
            this.map.MouseUp += new System.Windows.Forms.MouseEventHandler(this.map_MouseUp);
            // 
            // button_OK
            // 
            this.button_OK.Image = ((System.Drawing.Image)(resources.GetObject("button_OK.Image")));
            this.button_OK.Location = new System.Drawing.Point(685, 276);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(73, 29);
            this.button_OK.TabIndex = 1;
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Return
            // 
            this.button_Return.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_Return.BackgroundImage")));
            this.button_Return.Location = new System.Drawing.Point(685, 322);
            this.button_Return.Margin = new System.Windows.Forms.Padding(2);
            this.button_Return.Name = "button_Return";
            this.button_Return.Size = new System.Drawing.Size(73, 29);
            this.button_Return.TabIndex = 2;
            this.button_Return.UseVisualStyleBackColor = true;
            this.button_Return.Click += new System.EventHandler(this.button_Return_Click);
            // 
            // startPos
            // 
            this.startPos.AutoSize = true;
            this.startPos.BackColor = System.Drawing.Color.Transparent;
            this.startPos.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.startPos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.startPos.Location = new System.Drawing.Point(669, 151);
            this.startPos.MaximumSize = new System.Drawing.Size(86, 22);
            this.startPos.Name = "startPos";
            this.startPos.Size = new System.Drawing.Size(0, 22);
            this.startPos.TabIndex = 3;
            // 
            // endPos
            // 
            this.endPos.AutoSize = true;
            this.endPos.BackColor = System.Drawing.Color.Transparent;
            this.endPos.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.endPos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.endPos.Location = new System.Drawing.Point(669, 239);
            this.endPos.MaximumSize = new System.Drawing.Size(86, 22);
            this.endPos.Name = "endPos";
            this.endPos.Size = new System.Drawing.Size(0, 22);
            this.endPos.TabIndex = 4;
            // 
            // RailSystem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.endPos);
            this.Controls.Add(this.startPos);
            this.Controls.Add(this.button_Return);
            this.Controls.Add(this.button_OK);
            this.Controls.Add(this.map);
            this.Name = "RailSystem";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "地铁出行查询";
            this.Load += new System.EventHandler(this.RailSystem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.map)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox map;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Return;
        private System.Windows.Forms.Label startPos;
        private System.Windows.Forms.Label endPos;
    }
}