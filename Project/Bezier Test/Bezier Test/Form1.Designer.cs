namespace Bezier_Test
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BezierContainer = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.BezierContainer)).BeginInit();
            this.SuspendLayout();
            // 
            // BezierContainer
            // 
            this.BezierContainer.Image = ((System.Drawing.Image)(resources.GetObject("BezierContainer.Image")));
            this.BezierContainer.Location = new System.Drawing.Point(169, 12);
            this.BezierContainer.Name = "BezierContainer";
            this.BezierContainer.Size = new System.Drawing.Size(544, 391);
            this.BezierContainer.TabIndex = 0;
            this.BezierContainer.TabStop = false;
            this.BezierContainer.Click += new System.EventHandler(this.BezierContainer_Click);
            this.BezierContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BezierContainer_MouseDown);
            this.BezierContainer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BezierContainer_MouseMove);
            this.BezierContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BezierContainer_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 224);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 27);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(718, 407);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.BezierContainer);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BezierContainer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox BezierContainer;
        private System.Windows.Forms.Button button1;
    }
}

