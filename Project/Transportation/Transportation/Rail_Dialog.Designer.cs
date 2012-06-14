namespace Transportation
{
    partial class Rail_Dialog
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
            this.button_In = new System.Windows.Forms.Button();
            this.button_Out = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_In
            // 
            this.button_In.Location = new System.Drawing.Point(20, 89);
            this.button_In.Margin = new System.Windows.Forms.Padding(2);
            this.button_In.Name = "button_In";
            this.button_In.Size = new System.Drawing.Size(73, 26);
            this.button_In.TabIndex = 0;
            this.button_In.Text = "进站";
            this.button_In.UseVisualStyleBackColor = true;
            this.button_In.Click += new System.EventHandler(this.button_In_Click);
            // 
            // button_Out
            // 
            this.button_Out.Location = new System.Drawing.Point(128, 89);
            this.button_Out.Margin = new System.Windows.Forms.Padding(2);
            this.button_Out.Name = "button_Out";
            this.button_Out.Size = new System.Drawing.Size(74, 26);
            this.button_Out.TabIndex = 1;
            this.button_Out.Text = "出站";
            this.button_Out.UseVisualStyleBackColor = true;
            this.button_Out.Click += new System.EventHandler(this.button_Out_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "设为进站还是出站呢？";
            // 
            // Rail_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 144);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Out);
            this.Controls.Add(this.button_In);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Rail_Dialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rail_Dialog";
            this.Load += new System.EventHandler(this.Rail_Dialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_In;
        private System.Windows.Forms.Button button_Out;
        private System.Windows.Forms.Label label1;
    }
}