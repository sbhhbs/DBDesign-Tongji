﻿namespace Admin
{
    partial class CustomerService
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerService));
            this.historyQuery = new System.Windows.Forms.Button();
            this.lost = new System.Windows.Forms.Button();
            this.change = new System.Windows.Forms.Button();
            this.charge = new System.Windows.Forms.Button();
            this.textCardID = new System.Windows.Forms.TextBox();
            this.panelHistory = new System.Windows.Forms.Panel();
            this.textBoxBalance = new System.Windows.Forms.TextBox();
            this.panelChangeType = new System.Windows.Forms.Panel();
            this.buttonOkChangeType = new System.Windows.Forms.Button();
            this.radioButtonRegular = new System.Windows.Forms.RadioButton();
            this.radioButtonStaff = new System.Windows.Forms.RadioButton();
            this.radioButtonStudent = new System.Windows.Forms.RadioButton();
            this.radioButtonOldman = new System.Windows.Forms.RadioButton();
            this.panelRecharge = new System.Windows.Forms.Panel();
            this.textBoxChargeAmount = new System.Windows.Forms.TextBox();
            this.buttonOkRecharge = new System.Windows.Forms.Button();
            this.panelUnlock = new System.Windows.Forms.Panel();
            this.buttonOkUnlock = new System.Windows.Forms.Button();
            this.buttonOkLost = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.listViewHistoryQuery = new System.Windows.Forms.ListView();
            this.StartTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StartStation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EndTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EndStation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fare = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonShopping = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.panelUserInfo = new System.Windows.Forms.Panel();
            this.userEmergencyTEL = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.userWorkingTime = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.userWorkingLabel = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.userGender = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.userTELLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.userBirthdayLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelChangeType.SuspendLayout();
            this.panelRecharge.SuspendLayout();
            this.panelUnlock.SuspendLayout();
            this.panelUserInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // historyQuery
            // 
            this.historyQuery.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.historyQuery.Image = ((System.Drawing.Image)(resources.GetObject("historyQuery.Image")));
            this.historyQuery.Location = new System.Drawing.Point(264, 446);
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
            this.lost.Location = new System.Drawing.Point(264, 386);
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
            this.change.Location = new System.Drawing.Point(264, 319);
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
            this.charge.Location = new System.Drawing.Point(264, 250);
            this.charge.Name = "charge";
            this.charge.Size = new System.Drawing.Size(72, 28);
            this.charge.TabIndex = 6;
            this.charge.UseVisualStyleBackColor = true;
            this.charge.Click += new System.EventHandler(this.charge_Click);
            // 
            // textCardID
            // 
            this.textCardID.BackColor = System.Drawing.SystemColors.MenuText;
            this.textCardID.Enabled = false;
            this.textCardID.Font = new System.Drawing.Font("SimSun", 12F);
            this.textCardID.ForeColor = System.Drawing.SystemColors.Window;
            this.textCardID.Location = new System.Drawing.Point(57, 53);
            this.textCardID.Name = "textCardID";
            this.textCardID.Size = new System.Drawing.Size(274, 26);
            this.textCardID.TabIndex = 10;
            this.textCardID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panelHistory
            // 
            this.panelHistory.BackColor = System.Drawing.Color.Transparent;
            this.panelHistory.BackgroundImage = global::Admin.Properties.Resources.Right_History;
            this.panelHistory.Location = new System.Drawing.Point(440, 25);
            this.panelHistory.Name = "panelHistory";
            this.panelHistory.Size = new System.Drawing.Size(335, 532);
            this.panelHistory.TabIndex = 14;
            this.panelHistory.Visible = false;
            // 
            // textBoxBalance
            // 
            this.textBoxBalance.BackColor = System.Drawing.Color.Black;
            this.textBoxBalance.Enabled = false;
            this.textBoxBalance.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxBalance.ForeColor = System.Drawing.Color.White;
            this.textBoxBalance.Location = new System.Drawing.Point(107, 195);
            this.textBoxBalance.Name = "textBoxBalance";
            this.textBoxBalance.Size = new System.Drawing.Size(230, 29);
            this.textBoxBalance.TabIndex = 15;
            this.textBoxBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panelChangeType
            // 
            this.panelChangeType.BackColor = System.Drawing.Color.Transparent;
            this.panelChangeType.BackgroundImage = global::Admin.Properties.Resources.Right_ChangeType;
            this.panelChangeType.Controls.Add(this.buttonOkChangeType);
            this.panelChangeType.Controls.Add(this.radioButtonRegular);
            this.panelChangeType.Controls.Add(this.radioButtonStaff);
            this.panelChangeType.Controls.Add(this.radioButtonStudent);
            this.panelChangeType.Controls.Add(this.radioButtonOldman);
            this.panelChangeType.Location = new System.Drawing.Point(440, 25);
            this.panelChangeType.Name = "panelChangeType";
            this.panelChangeType.Size = new System.Drawing.Size(335, 532);
            this.panelChangeType.TabIndex = 16;
            this.panelChangeType.Visible = false;
            // 
            // buttonOkChangeType
            // 
            this.buttonOkChangeType.Image = global::Admin.Properties.Resources.CommandOK;
            this.buttonOkChangeType.Location = new System.Drawing.Point(152, 393);
            this.buttonOkChangeType.Name = "buttonOkChangeType";
            this.buttonOkChangeType.Size = new System.Drawing.Size(75, 29);
            this.buttonOkChangeType.TabIndex = 4;
            this.buttonOkChangeType.UseVisualStyleBackColor = true;
            this.buttonOkChangeType.Click += new System.EventHandler(this.buttonOkChangeType_Click);
            // 
            // radioButtonRegular
            // 
            this.radioButtonRegular.AutoSize = true;
            this.radioButtonRegular.Location = new System.Drawing.Point(114, 318);
            this.radioButtonRegular.Name = "radioButtonRegular";
            this.radioButtonRegular.Size = new System.Drawing.Size(14, 13);
            this.radioButtonRegular.TabIndex = 3;
            this.radioButtonRegular.TabStop = true;
            this.radioButtonRegular.UseVisualStyleBackColor = true;
            this.radioButtonRegular.CheckedChanged += new System.EventHandler(this.radioButtonRegular_CheckedChanged);
            // 
            // radioButtonStaff
            // 
            this.radioButtonStaff.AutoSize = true;
            this.radioButtonStaff.Location = new System.Drawing.Point(113, 240);
            this.radioButtonStaff.Name = "radioButtonStaff";
            this.radioButtonStaff.Size = new System.Drawing.Size(14, 13);
            this.radioButtonStaff.TabIndex = 2;
            this.radioButtonStaff.TabStop = true;
            this.radioButtonStaff.UseVisualStyleBackColor = true;
            this.radioButtonStaff.CheckedChanged += new System.EventHandler(this.radioButtonStaff_CheckedChanged);
            // 
            // radioButtonStudent
            // 
            this.radioButtonStudent.AutoSize = true;
            this.radioButtonStudent.Location = new System.Drawing.Point(113, 171);
            this.radioButtonStudent.Name = "radioButtonStudent";
            this.radioButtonStudent.Size = new System.Drawing.Size(14, 13);
            this.radioButtonStudent.TabIndex = 1;
            this.radioButtonStudent.TabStop = true;
            this.radioButtonStudent.UseVisualStyleBackColor = true;
            this.radioButtonStudent.CheckedChanged += new System.EventHandler(this.radioButtonStudent_CheckedChanged);
            // 
            // radioButtonOldman
            // 
            this.radioButtonOldman.AutoSize = true;
            this.radioButtonOldman.Location = new System.Drawing.Point(112, 98);
            this.radioButtonOldman.Name = "radioButtonOldman";
            this.radioButtonOldman.Size = new System.Drawing.Size(14, 13);
            this.radioButtonOldman.TabIndex = 0;
            this.radioButtonOldman.TabStop = true;
            this.radioButtonOldman.UseVisualStyleBackColor = true;
            // 
            // panelRecharge
            // 
            this.panelRecharge.BackColor = System.Drawing.Color.Transparent;
            this.panelRecharge.BackgroundImage = global::Admin.Properties.Resources.Right_Recharge;
            this.panelRecharge.Controls.Add(this.textBoxChargeAmount);
            this.panelRecharge.Controls.Add(this.buttonOkRecharge);
            this.panelRecharge.Location = new System.Drawing.Point(440, 25);
            this.panelRecharge.Name = "panelRecharge";
            this.panelRecharge.Size = new System.Drawing.Size(335, 532);
            this.panelRecharge.TabIndex = 17;
            this.panelRecharge.Visible = false;
            // 
            // textBoxChargeAmount
            // 
            this.textBoxChargeAmount.BackColor = System.Drawing.Color.Black;
            this.textBoxChargeAmount.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBoxChargeAmount.ForeColor = System.Drawing.Color.White;
            this.textBoxChargeAmount.Location = new System.Drawing.Point(100, 120);
            this.textBoxChargeAmount.Name = "textBoxChargeAmount";
            this.textBoxChargeAmount.Size = new System.Drawing.Size(148, 26);
            this.textBoxChargeAmount.TabIndex = 1;
            this.textBoxChargeAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBoxChargeAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.userCardID_KeyPress);
            // 
            // buttonOkRecharge
            // 
            this.buttonOkRecharge.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonOkRecharge.BackgroundImage")));
            this.buttonOkRecharge.Location = new System.Drawing.Point(136, 183);
            this.buttonOkRecharge.Name = "buttonOkRecharge";
            this.buttonOkRecharge.Size = new System.Drawing.Size(73, 29);
            this.buttonOkRecharge.TabIndex = 0;
            this.buttonOkRecharge.UseVisualStyleBackColor = true;
            this.buttonOkRecharge.Click += new System.EventHandler(this.buttonOkRecharge_Click);
            // 
            // panelUnlock
            // 
            this.panelUnlock.BackColor = System.Drawing.Color.Transparent;
            this.panelUnlock.BackgroundImage = global::Admin.Properties.Resources.Right_CardLost;
            this.panelUnlock.Controls.Add(this.buttonOkUnlock);
            this.panelUnlock.Controls.Add(this.buttonOkLost);
            this.panelUnlock.Location = new System.Drawing.Point(440, 25);
            this.panelUnlock.Name = "panelUnlock";
            this.panelUnlock.Size = new System.Drawing.Size(335, 532);
            this.panelUnlock.TabIndex = 18;
            this.panelUnlock.Visible = false;
            // 
            // buttonOkUnlock
            // 
            this.buttonOkUnlock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonOkUnlock.BackgroundImage")));
            this.buttonOkUnlock.Location = new System.Drawing.Point(189, 245);
            this.buttonOkUnlock.Name = "buttonOkUnlock";
            this.buttonOkUnlock.Size = new System.Drawing.Size(76, 29);
            this.buttonOkUnlock.TabIndex = 1;
            this.buttonOkUnlock.UseVisualStyleBackColor = true;
            this.buttonOkUnlock.Click += new System.EventHandler(this.buttonOkUnlock_Click);
            // 
            // buttonOkLost
            // 
            this.buttonOkLost.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonOkLost.BackgroundImage")));
            this.buttonOkLost.Location = new System.Drawing.Point(79, 245);
            this.buttonOkLost.Name = "buttonOkLost";
            this.buttonOkLost.Size = new System.Drawing.Size(75, 29);
            this.buttonOkLost.TabIndex = 0;
            this.buttonOkLost.UseVisualStyleBackColor = true;
            this.buttonOkLost.Click += new System.EventHandler(this.buttonOkLost_Click);
            // 
            // exit
            // 
            this.exit.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.exit.Image = global::Admin.Properties.Resources.Exit;
            this.exit.Location = new System.Drawing.Point(264, 509);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(72, 28);
            this.exit.TabIndex = 19;
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // listViewHistoryQuery
            // 
            this.listViewHistoryQuery.BackColor = System.Drawing.Color.Black;
            this.listViewHistoryQuery.ForeColor = System.Drawing.Color.White;
            this.listViewHistoryQuery.Location = new System.Drawing.Point(440, 25);
            this.listViewHistoryQuery.Name = "listViewHistoryQuery";
            this.listViewHistoryQuery.Size = new System.Drawing.Size(334, 530);
            this.listViewHistoryQuery.TabIndex = 2;
            this.listViewHistoryQuery.UseCompatibleStateImageBehavior = false;
            this.listViewHistoryQuery.Visible = false;
            // 
            // buttonShopping
            // 
            this.buttonShopping.BackgroundImage = global::Admin.Properties.Resources.shopping;
            this.buttonShopping.Location = new System.Drawing.Point(57, 507);
            this.buttonShopping.Name = "buttonShopping";
            this.buttonShopping.Size = new System.Drawing.Size(92, 30);
            this.buttonShopping.TabIndex = 20;
            this.buttonShopping.UseVisualStyleBackColor = true;
            this.buttonShopping.Click += new System.EventHandler(this.buttonShopping_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(14, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "姓名:";
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userNameLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.userNameLabel.Location = new System.Drawing.Point(191, 58);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(50, 25);
            this.userNameLabel.TabIndex = 1;
            this.userNameLabel.Text = "张三";
            // 
            // panelUserInfo
            // 
            this.panelUserInfo.BackColor = System.Drawing.Color.Transparent;
            this.panelUserInfo.Controls.Add(this.userEmergencyTEL);
            this.panelUserInfo.Controls.Add(this.label13);
            this.panelUserInfo.Controls.Add(this.userWorkingTime);
            this.panelUserInfo.Controls.Add(this.label11);
            this.panelUserInfo.Controls.Add(this.userWorkingLabel);
            this.panelUserInfo.Controls.Add(this.label9);
            this.panelUserInfo.Controls.Add(this.userGender);
            this.panelUserInfo.Controls.Add(this.label7);
            this.panelUserInfo.Controls.Add(this.userTELLabel);
            this.panelUserInfo.Controls.Add(this.label5);
            this.panelUserInfo.Controls.Add(this.userBirthdayLabel);
            this.panelUserInfo.Controls.Add(this.label3);
            this.panelUserInfo.Controls.Add(this.userNameLabel);
            this.panelUserInfo.Controls.Add(this.label1);
            this.panelUserInfo.Location = new System.Drawing.Point(440, 25);
            this.panelUserInfo.Name = "panelUserInfo";
            this.panelUserInfo.Size = new System.Drawing.Size(335, 532);
            this.panelUserInfo.TabIndex = 21;
            this.panelUserInfo.Visible = false;
            // 
            // userEmergencyTEL
            // 
            this.userEmergencyTEL.AutoSize = true;
            this.userEmergencyTEL.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userEmergencyTEL.ForeColor = System.Drawing.SystemColors.Control;
            this.userEmergencyTEL.Location = new System.Drawing.Point(192, 440);
            this.userEmergencyTEL.Name = "userEmergencyTEL";
            this.userEmergencyTEL.Size = new System.Drawing.Size(144, 28);
            this.userEmergencyTEL.TabIndex = 13;
            this.userEmergencyTEL.Text = "10987654321";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.ForeColor = System.Drawing.SystemColors.Control;
            this.label13.Location = new System.Drawing.Point(14, 440);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(117, 28);
            this.label13.TabIndex = 12;
            this.label13.Text = "紧急电话：";
            // 
            // userWorkingTime
            // 
            this.userWorkingTime.AutoSize = true;
            this.userWorkingTime.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userWorkingTime.ForeColor = System.Drawing.SystemColors.Control;
            this.userWorkingTime.Location = new System.Drawing.Point(192, 381);
            this.userWorkingTime.Name = "userWorkingTime";
            this.userWorkingTime.Size = new System.Drawing.Size(65, 28);
            this.userWorkingTime.TabIndex = 11;
            this.userWorkingTime.Text = "12:09";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.ForeColor = System.Drawing.SystemColors.Control;
            this.label11.Location = new System.Drawing.Point(14, 381);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(143, 28);
            this.label11.TabIndex = 10;
            this.label11.Text = "开始工作时间:";
            // 
            // userWorkingLabel
            // 
            this.userWorkingLabel.AutoSize = true;
            this.userWorkingLabel.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userWorkingLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.userWorkingLabel.Location = new System.Drawing.Point(193, 319);
            this.userWorkingLabel.Name = "userWorkingLabel";
            this.userWorkingLabel.Size = new System.Drawing.Size(96, 28);
            this.userWorkingLabel.TabIndex = 9;
            this.userWorkingLabel.Text = "同济大学";
            this.userWorkingLabel.Click += new System.EventHandler(this.userWorkingLabel_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.ForeColor = System.Drawing.SystemColors.Control;
            this.label9.Location = new System.Drawing.Point(14, 319);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(182, 28);
            this.label9.TabIndex = 8;
            this.label9.Text = "学校/职工号/部门:";
            // 
            // userGender
            // 
            this.userGender.AutoSize = true;
            this.userGender.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userGender.ForeColor = System.Drawing.SystemColors.Control;
            this.userGender.Location = new System.Drawing.Point(195, 259);
            this.userGender.Name = "userGender";
            this.userGender.Size = new System.Drawing.Size(33, 28);
            this.userGender.TabIndex = 7;
            this.userGender.Text = "男";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.SystemColors.Control;
            this.label7.Location = new System.Drawing.Point(14, 259);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 28);
            this.label7.TabIndex = 6;
            this.label7.Text = "性别:";
            // 
            // userTELLabel
            // 
            this.userTELLabel.AutoSize = true;
            this.userTELLabel.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userTELLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.userTELLabel.Location = new System.Drawing.Point(192, 192);
            this.userTELLabel.Name = "userTELLabel";
            this.userTELLabel.Size = new System.Drawing.Size(133, 25);
            this.userTELLabel.TabIndex = 5;
            this.userTELLabel.Text = "12345678901";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.SystemColors.Control;
            this.label5.Location = new System.Drawing.Point(14, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 28);
            this.label5.TabIndex = 4;
            this.label5.Text = "联系电话:";
            // 
            // userBirthdayLabel
            // 
            this.userBirthdayLabel.AutoSize = true;
            this.userBirthdayLabel.Font = new System.Drawing.Font("Microsoft YaHei", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.userBirthdayLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.userBirthdayLabel.Location = new System.Drawing.Point(190, 123);
            this.userBirthdayLabel.Name = "userBirthdayLabel";
            this.userBirthdayLabel.Size = new System.Drawing.Size(105, 25);
            this.userBirthdayLabel.TabIndex = 3;
            this.userBirthdayLabel.Text = "1992-9-22";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(14, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 28);
            this.label3.TabIndex = 2;
            this.label3.Text = "生日:";
            // 
            // CustomerService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(804, 582);
            this.Controls.Add(this.panelUserInfo);
            this.Controls.Add(this.buttonShopping);
            this.Controls.Add(this.listViewHistoryQuery);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.panelRecharge);
            this.Controls.Add(this.panelUnlock);
            this.Controls.Add(this.panelChangeType);
            this.Controls.Add(this.textBoxBalance);
            this.Controls.Add(this.panelHistory);
            this.Controls.Add(this.textCardID);
            this.Controls.Add(this.historyQuery);
            this.Controls.Add(this.lost);
            this.Controls.Add(this.change);
            this.Controls.Add(this.charge);
            this.Name = "CustomerService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ServiceHistory";
            this.Load += new System.EventHandler(this.ServiceHistory_Load);
            this.panelChangeType.ResumeLayout(false);
            this.panelChangeType.PerformLayout();
            this.panelRecharge.ResumeLayout(false);
            this.panelRecharge.PerformLayout();
            this.panelUnlock.ResumeLayout(false);
            this.panelUserInfo.ResumeLayout(false);
            this.panelUserInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button historyQuery;
        private System.Windows.Forms.Button lost;
        private System.Windows.Forms.Button change;
        private System.Windows.Forms.Button charge;
        private System.Windows.Forms.TextBox textCardID;
        private System.Windows.Forms.Panel panelHistory;
        private System.Windows.Forms.TextBox textBoxBalance;
        private System.Windows.Forms.Panel panelChangeType;
        private System.Windows.Forms.RadioButton radioButtonOldman;
        private System.Windows.Forms.RadioButton radioButtonRegular;
        private System.Windows.Forms.RadioButton radioButtonStaff;
        private System.Windows.Forms.RadioButton radioButtonStudent;
        private System.Windows.Forms.Panel panelRecharge;
        private System.Windows.Forms.Button buttonOkRecharge;
        private System.Windows.Forms.Panel panelUnlock;
        private System.Windows.Forms.Button buttonOkUnlock;
        private System.Windows.Forms.Button buttonOkLost;
        private System.Windows.Forms.Button exit;
        private System.Windows.Forms.Button buttonOkChangeType;
        private System.Windows.Forms.ListView listViewHistoryQuery;
        private System.Windows.Forms.ColumnHeader StartTime;
        private System.Windows.Forms.ColumnHeader StartStation;
        private System.Windows.Forms.ColumnHeader EndTime;
        private System.Windows.Forms.ColumnHeader EndStation;
        private System.Windows.Forms.ColumnHeader Fare;
        private System.Windows.Forms.TextBox textBoxChargeAmount;
        private System.Windows.Forms.Button buttonShopping;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Panel panelUserInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label userTELLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label userBirthdayLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label userEmergencyTEL;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label userWorkingTime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label userWorkingLabel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label userGender;
    }
}