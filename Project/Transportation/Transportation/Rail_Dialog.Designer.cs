﻿namespace Transportation
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
            this.button_In.Location = new System.Drawing.Point(26, 111);
            this.button_In.Name = "button_In";
            this.button_In.Size = new System.Drawing.Size(97, 33);
            this.button_In.TabIndex = 0;
            this.button_In.Text = "进站";
            this.button_In.UseVisualStyleBackColor = true;
            // 
            // button_Out
            // 
            this.button_Out.Location = new System.Drawing.Point(171, 111);
            this.button_Out.Name = "button_Out";
            this.button_Out.Size = new System.Drawing.Size(99, 33);
            this.button_Out.TabIndex = 1;
            this.button_Out.Text = "出站";
            this.button_Out.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(70, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "设为进站还是出站呢？";
            // 
            // Rail_Dialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 180);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Out);
            this.Controls.Add(this.button_In);
            this.Name = "Rail_Dialog";
            this.Text = "Rail_Dialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_In;
        private System.Windows.Forms.Button button_Out;
        private System.Windows.Forms.Label label1;
    }
}