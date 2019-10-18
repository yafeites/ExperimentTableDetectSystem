namespace ExperimentTableDetectSystem.Windows
{
    partial class MainWin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnUserSet = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExperiment = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSinglePoint = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExperimentdata = new System.Windows.Forms.ToolStripMenuItem();
            this.btnByDate = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCurrentData = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox2 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.txtTempNow = new System.Windows.Forms.ToolStripTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(93)))), ((int)(((byte)(152)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnUserSet,
            this.btnSetParameter,
            this.btnExperiment,
            this.btnSinglePoint,
            this.btnExperimentdata,
            this.btnExit,
            this.toolStripTextBox2,
            this.toolStripTextBox1,
            this.txtTempNow});
            this.menuStrip1.Location = new System.Drawing.Point(22, 72);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1108, 48);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnUserSet
            // 
            this.btnUserSet.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUserSet.ForeColor = System.Drawing.Color.White;
            this.btnUserSet.Name = "btnUserSet";
            this.btnUserSet.Size = new System.Drawing.Size(101, 44);
            this.btnUserSet.Text = "系统设置";
            this.btnUserSet.Click += new System.EventHandler(this.btnUserSet_Click);
            // 
            // btnSetParameter
            // 
            this.btnSetParameter.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSetParameter.ForeColor = System.Drawing.Color.White;
            this.btnSetParameter.Name = "btnSetParameter";
            this.btnSetParameter.Size = new System.Drawing.Size(101, 44);
            this.btnSetParameter.Text = "参数设置";
            this.btnSetParameter.Click += new System.EventHandler(this.btnSetParameter_Click);
            // 
            // btnExperiment
            // 
            this.btnExperiment.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExperiment.ForeColor = System.Drawing.Color.White;
            this.btnExperiment.Name = "btnExperiment";
            this.btnExperiment.Size = new System.Drawing.Size(101, 44);
            this.btnExperiment.Text = "实验项目";
            this.btnExperiment.Click += new System.EventHandler(this.btnExperiment_Click);
            // 
            // btnSinglePoint
            // 
            this.btnSinglePoint.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSinglePoint.ForeColor = System.Drawing.Color.White;
            this.btnSinglePoint.Name = "btnSinglePoint";
            this.btnSinglePoint.Size = new System.Drawing.Size(101, 44);
            this.btnSinglePoint.Text = "单点调试";
            this.btnSinglePoint.Click += new System.EventHandler(this.btnSinglePoint_Click);
            // 
            // btnExperimentdata
            // 
            this.btnExperimentdata.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnByDate,
            this.btnCurrentData});
            this.btnExperimentdata.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExperimentdata.ForeColor = System.Drawing.Color.White;
            this.btnExperimentdata.Name = "btnExperimentdata";
            this.btnExperimentdata.Size = new System.Drawing.Size(101, 44);
            this.btnExperimentdata.Text = "实验数据";
            // 
            // btnByDate
            // 
            this.btnByDate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnByDate.ForeColor = System.Drawing.Color.White;
            this.btnByDate.Name = "btnByDate";
            this.btnByDate.Size = new System.Drawing.Size(184, 26);
            this.btnByDate.Text = "按日期查询";
            this.btnByDate.Click += new System.EventHandler(this.btnByDate_Click);
            // 
            // btnCurrentData
            // 
            this.btnCurrentData.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCurrentData.ForeColor = System.Drawing.Color.White;
            this.btnCurrentData.Name = "btnCurrentData";
            this.btnCurrentData.Size = new System.Drawing.Size(184, 26);
            this.btnCurrentData.Text = "精确查询";
            this.btnCurrentData.Click += new System.EventHandler(this.btnCurrentData_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(61, 44);
            this.btnExit.Text = "退出";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // toolStripTextBox2
            // 
            this.toolStripTextBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(93)))), ((int)(((byte)(152)))));
            this.toolStripTextBox2.Name = "toolStripTextBox2";
            this.toolStripTextBox2.Size = new System.Drawing.Size(100, 44);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(93)))), ((int)(((byte)(152)))));
            this.toolStripTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStripTextBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 44);
            this.toolStripTextBox1.Text = "当前油温：";
            this.toolStripTextBox1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTempNow
            // 
            this.txtTempNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(93)))), ((int)(((byte)(152)))));
            this.txtTempNow.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtTempNow.ForeColor = System.Drawing.SystemColors.Window;
            this.txtTempNow.Name = "txtTempNow";
            this.txtTempNow.Size = new System.Drawing.Size(100, 44);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(22, 120);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1108, 778);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 5000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 922);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "MainWin";
            this.Padding = new System.Windows.Forms.Padding(22, 72, 22, 24);
            this.Resizable = false;
            this.Text = "欢迎使用叉车液压多路阀自动检测系统";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainWin_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnUserSet;
        private System.Windows.Forms.ToolStripMenuItem btnSetParameter;
        private System.Windows.Forms.ToolStripMenuItem btnExperimentdata;
        private System.Windows.Forms.ToolStripMenuItem btnCurrentData;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem btnExperiment;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem btnByDate;
        private System.Windows.Forms.ToolStripMenuItem btnSinglePoint;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripTextBox txtTempNow;
        private System.Windows.Forms.Timer timer1;
    }
}