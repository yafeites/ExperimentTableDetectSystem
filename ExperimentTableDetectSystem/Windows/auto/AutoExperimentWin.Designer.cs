namespace ExperimentTableDetectSystem.Windows
{
    partial class AutoExperimentWin
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grpPressureLoss = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.chkMediumPressureLoss = new System.Windows.Forms.CheckBox();
            this.chkSteerValveQ = new System.Windows.Forms.CheckBox();
            this.chkLeakageHoldPresssure = new System.Windows.Forms.CheckBox();
            this.chkSmallSelfLock = new System.Windows.Forms.CheckBox();
            this.chkBigSelfLock = new System.Windows.Forms.CheckBox();
            this.grpGate = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.chkSmallMenjiaUp = new System.Windows.Forms.CheckBox();
            this.chkSmallMenjiaDown = new System.Windows.Forms.CheckBox();
            this.chkBigMenjiaUp = new System.Windows.Forms.CheckBox();
            this.chkBigMenjiaDown = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.chkSmallMenjiaForward = new System.Windows.Forms.CheckBox();
            this.chkSmallMenjiaBack = new System.Windows.Forms.CheckBox();
            this.chkBigMenjiaForward = new System.Windows.Forms.CheckBox();
            this.chkBigMenjiaBack = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpPressureLoss.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.grpGate.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(22, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1108, 826);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "试验项目选择";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.grpPressureLoss, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.grpGate, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.22641F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.22641F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.547171F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1102, 799);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grpPressureLoss
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grpPressureLoss, 2);
            this.grpPressureLoss.Controls.Add(this.tableLayoutPanel3);
            this.grpPressureLoss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpPressureLoss.Location = new System.Drawing.Point(554, 3);
            this.grpPressureLoss.Name = "grpPressureLoss";
            this.tableLayoutPanel1.SetRowSpan(this.grpPressureLoss, 2);
            this.grpPressureLoss.Size = new System.Drawing.Size(545, 732);
            this.grpPressureLoss.TabIndex = 1;
            this.grpPressureLoss.TabStop = false;
            this.grpPressureLoss.Text = "2.其他类型试验";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel3.Controls.Add(this.chkMediumPressureLoss, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.chkSteerValveQ, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.chkLeakageHoldPresssure, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.chkSmallSelfLock, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.chkBigSelfLock, 1, 8);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 24);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 16;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.249217F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25172F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.249217F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25172F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.249217F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25172F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.249217F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25172F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.249217F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.25172F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.249217F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.249217F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.249217F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.249217F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.249217F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.249217F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(539, 705);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // chkMediumPressureLoss
            // 
            this.chkMediumPressureLoss.AutoSize = true;
            this.chkMediumPressureLoss.Checked = true;
            this.chkMediumPressureLoss.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkMediumPressureLoss.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkMediumPressureLoss.Location = new System.Drawing.Point(83, 3);
            this.chkMediumPressureLoss.Name = "chkMediumPressureLoss";
            this.chkMediumPressureLoss.Size = new System.Drawing.Size(453, 38);
            this.chkMediumPressureLoss.TabIndex = 0;
            this.chkMediumPressureLoss.Text = "中位压力损失测试";
            this.chkMediumPressureLoss.UseVisualStyleBackColor = true;
            // 
            // chkSteerValveQ
            // 
            this.chkSteerValveQ.AutoSize = true;
            this.chkSteerValveQ.Checked = true;
            this.chkSteerValveQ.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSteerValveQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSteerValveQ.Location = new System.Drawing.Point(83, 91);
            this.chkSteerValveQ.Name = "chkSteerValveQ";
            this.chkSteerValveQ.Size = new System.Drawing.Size(453, 38);
            this.chkSteerValveQ.TabIndex = 1;
            this.chkSteerValveQ.Text = "转向优先阀流量测试";
            this.chkSteerValveQ.UseVisualStyleBackColor = true;
            // 
            // chkLeakageHoldPresssure
            // 
            this.chkLeakageHoldPresssure.AutoSize = true;
            this.chkLeakageHoldPresssure.Checked = true;
            this.chkLeakageHoldPresssure.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkLeakageHoldPresssure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLeakageHoldPresssure.Location = new System.Drawing.Point(83, 179);
            this.chkLeakageHoldPresssure.Name = "chkLeakageHoldPresssure";
            this.chkLeakageHoldPresssure.Size = new System.Drawing.Size(453, 38);
            this.chkLeakageHoldPresssure.TabIndex = 2;
            this.chkLeakageHoldPresssure.Text = "内泄漏保压测试";
            this.chkLeakageHoldPresssure.UseVisualStyleBackColor = true;
            // 
            // chkSmallSelfLock
            // 
            this.chkSmallSelfLock.AutoSize = true;
            this.chkSmallSelfLock.Checked = true;
            this.chkSmallSelfLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSmallSelfLock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSmallSelfLock.Location = new System.Drawing.Point(83, 267);
            this.chkSmallSelfLock.Name = "chkSmallSelfLock";
            this.chkSmallSelfLock.Size = new System.Drawing.Size(453, 38);
            this.chkSmallSelfLock.TabIndex = 3;
            this.chkSmallSelfLock.Text = "小门架前倾自锁测试";
            this.chkSmallSelfLock.UseVisualStyleBackColor = true;
            // 
            // chkBigSelfLock
            // 
            this.chkBigSelfLock.AutoSize = true;
            this.chkBigSelfLock.Checked = true;
            this.chkBigSelfLock.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBigSelfLock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBigSelfLock.Location = new System.Drawing.Point(83, 355);
            this.chkBigSelfLock.Name = "chkBigSelfLock";
            this.chkBigSelfLock.Size = new System.Drawing.Size(453, 38);
            this.chkBigSelfLock.TabIndex = 4;
            this.chkBigSelfLock.Text = "大门架前倾自锁测试";
            this.chkBigSelfLock.UseVisualStyleBackColor = true;
            // 
            // grpGate
            // 
            this.grpGate.Controls.Add(this.tableLayoutPanel2);
            this.grpGate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpGate.Location = new System.Drawing.Point(3, 3);
            this.grpGate.Name = "grpGate";
            this.tableLayoutPanel1.SetRowSpan(this.grpGate, 2);
            this.grpGate.Size = new System.Drawing.Size(545, 732);
            this.grpGate.TabIndex = 0;
            this.grpGate.TabStop = false;
            this.grpGate.Text = "1.门架动作";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel2.Controls.Add(this.chkBigMenjiaBack, 1, 14);
            this.tableLayoutPanel2.Controls.Add(this.chkBigMenjiaForward, 1, 12);
            this.tableLayoutPanel2.Controls.Add(this.chkSmallMenjiaBack, 1, 10);
            this.tableLayoutPanel2.Controls.Add(this.chkSmallMenjiaForward, 1, 8);
            this.tableLayoutPanel2.Controls.Add(this.chkSmallMenjiaUp, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.chkSmallMenjiaDown, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.chkBigMenjiaUp, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.chkBigMenjiaDown, 1, 6);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 24);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 16;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.247182F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.247182F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.247182F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.247182F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.247182F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.247182F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.247182F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.247182F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.29716F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.246485F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.246485F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.246485F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.246485F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.246485F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.246485F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.246485F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(539, 705);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // chkSmallMenjiaUp
            // 
            this.chkSmallMenjiaUp.AutoSize = true;
            this.chkSmallMenjiaUp.Checked = true;
            this.chkSmallMenjiaUp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSmallMenjiaUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSmallMenjiaUp.Location = new System.Drawing.Point(83, 3);
            this.chkSmallMenjiaUp.Name = "chkSmallMenjiaUp";
            this.chkSmallMenjiaUp.Size = new System.Drawing.Size(453, 38);
            this.chkSmallMenjiaUp.TabIndex = 0;
            this.chkSmallMenjiaUp.Text = "小门架上升、压力损失、推动滑阀力与时间测试";
            this.chkSmallMenjiaUp.UseVisualStyleBackColor = true;
            // 
            // chkSmallMenjiaDown
            // 
            this.chkSmallMenjiaDown.AutoSize = true;
            this.chkSmallMenjiaDown.Checked = true;
            this.chkSmallMenjiaDown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSmallMenjiaDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSmallMenjiaDown.Location = new System.Drawing.Point(83, 91);
            this.chkSmallMenjiaDown.Name = "chkSmallMenjiaDown";
            this.chkSmallMenjiaDown.Size = new System.Drawing.Size(453, 38);
            this.chkSmallMenjiaDown.TabIndex = 1;
            this.chkSmallMenjiaDown.Text = "小门架下降、压力损失、推动滑阀力与时间测试";
            this.chkSmallMenjiaDown.UseVisualStyleBackColor = true;
            // 
            // chkBigMenjiaUp
            // 
            this.chkBigMenjiaUp.AutoSize = true;
            this.chkBigMenjiaUp.Checked = true;
            this.chkBigMenjiaUp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBigMenjiaUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBigMenjiaUp.Location = new System.Drawing.Point(83, 179);
            this.chkBigMenjiaUp.Name = "chkBigMenjiaUp";
            this.chkBigMenjiaUp.Size = new System.Drawing.Size(453, 38);
            this.chkBigMenjiaUp.TabIndex = 2;
            this.chkBigMenjiaUp.Text = "大门架上升、压力损失、推动滑阀力与时间测试";
            this.chkBigMenjiaUp.UseVisualStyleBackColor = true;
            // 
            // chkBigMenjiaDown
            // 
            this.chkBigMenjiaDown.AutoSize = true;
            this.chkBigMenjiaDown.Checked = true;
            this.chkBigMenjiaDown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBigMenjiaDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBigMenjiaDown.Location = new System.Drawing.Point(83, 267);
            this.chkBigMenjiaDown.Name = "chkBigMenjiaDown";
            this.chkBigMenjiaDown.Size = new System.Drawing.Size(453, 38);
            this.chkBigMenjiaDown.TabIndex = 3;
            this.chkBigMenjiaDown.Text = "大门架下降、压力损失、推动滑阀力与时间测试";
            this.chkBigMenjiaDown.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel8);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(554, 741);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 55);
            this.panel1.TabIndex = 6;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 3;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel8.Controls.Add(this.btnStartTest, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(269, 55);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // btnStartTest
            // 
            this.tableLayoutPanel8.SetColumnSpan(this.btnStartTest, 2);
            this.btnStartTest.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnStartTest.Location = new System.Drawing.Point(3, 3);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(172, 49);
            this.btnStartTest.TabIndex = 0;
            this.btnStartTest.Text = "开始自动试验";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // chkSmallMenjiaForward
            // 
            this.chkSmallMenjiaForward.AutoSize = true;
            this.chkSmallMenjiaForward.Checked = true;
            this.chkSmallMenjiaForward.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSmallMenjiaForward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSmallMenjiaForward.Location = new System.Drawing.Point(83, 355);
            this.chkSmallMenjiaForward.Name = "chkSmallMenjiaForward";
            this.chkSmallMenjiaForward.Size = new System.Drawing.Size(453, 38);
            this.chkSmallMenjiaForward.TabIndex = 4;
            this.chkSmallMenjiaForward.Text = "小门架前倾、压力损失、推动滑阀力与时间测试";
            this.chkSmallMenjiaForward.UseVisualStyleBackColor = true;
            // 
            // chkSmallMenjiaBack
            // 
            this.chkSmallMenjiaBack.AutoSize = true;
            this.chkSmallMenjiaBack.Checked = true;
            this.chkSmallMenjiaBack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSmallMenjiaBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkSmallMenjiaBack.Location = new System.Drawing.Point(83, 443);
            this.chkSmallMenjiaBack.Name = "chkSmallMenjiaBack";
            this.chkSmallMenjiaBack.Size = new System.Drawing.Size(453, 38);
            this.chkSmallMenjiaBack.TabIndex = 5;
            this.chkSmallMenjiaBack.Text = "小门架后倾、压力损失、推动滑阀力与时间测试";
            this.chkSmallMenjiaBack.UseVisualStyleBackColor = true;
            // 
            // chkBigMenjiaForward
            // 
            this.chkBigMenjiaForward.AutoSize = true;
            this.chkBigMenjiaForward.Checked = true;
            this.chkBigMenjiaForward.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBigMenjiaForward.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBigMenjiaForward.Location = new System.Drawing.Point(83, 531);
            this.chkBigMenjiaForward.Name = "chkBigMenjiaForward";
            this.chkBigMenjiaForward.Size = new System.Drawing.Size(453, 38);
            this.chkBigMenjiaForward.TabIndex = 6;
            this.chkBigMenjiaForward.Text = "大门架前倾、压力损失、推动滑阀力与时间测试";
            this.chkBigMenjiaForward.UseVisualStyleBackColor = true;
            // 
            // chkBigMenjiaBack
            // 
            this.chkBigMenjiaBack.AutoSize = true;
            this.chkBigMenjiaBack.Checked = true;
            this.chkBigMenjiaBack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkBigMenjiaBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkBigMenjiaBack.Location = new System.Drawing.Point(83, 619);
            this.chkBigMenjiaBack.Name = "chkBigMenjiaBack";
            this.chkBigMenjiaBack.Size = new System.Drawing.Size(453, 38);
            this.chkBigMenjiaBack.TabIndex = 7;
            this.chkBigMenjiaBack.Text = "大门架后倾、压力损失、推动滑阀力与时间测试";
            this.chkBigMenjiaBack.UseVisualStyleBackColor = true;
            // 
            // AutoExperimentWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 922);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "AutoExperimentWin";
            this.Padding = new System.Windows.Forms.Padding(22, 72, 22, 24);
            this.Resizable = false;
            this.Text = "自动试验(试验项目选择)";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AutoExperimentWin_Load);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grpPressureLoss.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.grpGate.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grpGate;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox chkSmallMenjiaUp;
        private System.Windows.Forms.CheckBox chkSmallMenjiaDown;
        private System.Windows.Forms.CheckBox chkBigMenjiaUp;
        private System.Windows.Forms.CheckBox chkBigMenjiaDown;
        private System.Windows.Forms.GroupBox grpPressureLoss;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.CheckBox chkMediumPressureLoss;
        private System.Windows.Forms.CheckBox chkSteerValveQ;
        private System.Windows.Forms.CheckBox chkLeakageHoldPresssure;
        private System.Windows.Forms.CheckBox chkSmallSelfLock;
        private System.Windows.Forms.CheckBox chkBigSelfLock;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.CheckBox chkBigMenjiaBack;
        private System.Windows.Forms.CheckBox chkBigMenjiaForward;
        private System.Windows.Forms.CheckBox chkSmallMenjiaBack;
        private System.Windows.Forms.CheckBox chkSmallMenjiaForward;
    }
}