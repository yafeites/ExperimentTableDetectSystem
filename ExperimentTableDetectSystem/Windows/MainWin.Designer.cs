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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnUserSet = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSetParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExperiment = new System.Windows.Forms.ToolStripMenuItem();
            this.btnManualExperiment = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAutoExperiment = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExperimentdata = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCurrentData = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHistoryData = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDataAnalysis = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAnalysisResult = new System.Windows.Forms.ToolStripMenuItem();
            this.btnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
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
            this.btnExperimentdata,
            this.btnDataAnalysis,
            this.btnAnalysisResult,
            this.btnExit});
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
            this.btnExperiment.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnManualExperiment,
            this.btnAutoExperiment});
            this.btnExperiment.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExperiment.ForeColor = System.Drawing.Color.White;
            this.btnExperiment.Name = "btnExperiment";
            this.btnExperiment.Size = new System.Drawing.Size(101, 44);
            this.btnExperiment.Text = "实验项目";
            // 
            // btnManualExperiment
            // 
            this.btnManualExperiment.BackColor = System.Drawing.Color.SteelBlue;
            this.btnManualExperiment.ForeColor = System.Drawing.Color.White;
            this.btnManualExperiment.Name = "btnManualExperiment";
            this.btnManualExperiment.Size = new System.Drawing.Size(164, 26);
            this.btnManualExperiment.Text = "手动实验";
            this.btnManualExperiment.Click += new System.EventHandler(this.btnManualExperiment_Click);
            // 
            // btnAutoExperiment
            // 
            this.btnAutoExperiment.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAutoExperiment.ForeColor = System.Drawing.Color.White;
            this.btnAutoExperiment.Name = "btnAutoExperiment";
            this.btnAutoExperiment.Size = new System.Drawing.Size(164, 26);
            this.btnAutoExperiment.Text = "自动实验";
            this.btnAutoExperiment.Click += new System.EventHandler(this.btnAutoExperiment_Click);
            // 
            // btnExperimentdata
            // 
            this.btnExperimentdata.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCurrentData,
            this.btnHistoryData});
            this.btnExperimentdata.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnExperimentdata.ForeColor = System.Drawing.Color.White;
            this.btnExperimentdata.Name = "btnExperimentdata";
            this.btnExperimentdata.Size = new System.Drawing.Size(101, 44);
            this.btnExperimentdata.Text = "实验数据";
            // 
            // btnCurrentData
            // 
            this.btnCurrentData.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCurrentData.ForeColor = System.Drawing.Color.White;
            this.btnCurrentData.Name = "btnCurrentData";
            this.btnCurrentData.Size = new System.Drawing.Size(164, 26);
            this.btnCurrentData.Text = "当前数据";
            // 
            // btnHistoryData
            // 
            this.btnHistoryData.BackColor = System.Drawing.Color.SteelBlue;
            this.btnHistoryData.ForeColor = System.Drawing.Color.White;
            this.btnHistoryData.Name = "btnHistoryData";
            this.btnHistoryData.Size = new System.Drawing.Size(164, 26);
            this.btnHistoryData.Text = "历史数据";
            // 
            // btnDataAnalysis
            // 
            this.btnDataAnalysis.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnDataAnalysis.ForeColor = System.Drawing.Color.White;
            this.btnDataAnalysis.Name = "btnDataAnalysis";
            this.btnDataAnalysis.Size = new System.Drawing.Size(101, 44);
            this.btnDataAnalysis.Text = "数据分析";
            // 
            // btnAnalysisResult
            // 
            this.btnAnalysisResult.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAnalysisResult.ForeColor = System.Drawing.Color.White;
            this.btnAnalysisResult.Name = "btnAnalysisResult";
            this.btnAnalysisResult.Size = new System.Drawing.Size(101, 44);
            this.btnAnalysisResult.Text = "分析结果";
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
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 922);
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
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnUserSet;
        private System.Windows.Forms.ToolStripMenuItem btnSetParameter;
        private System.Windows.Forms.ToolStripMenuItem btnExperimentdata;
        private System.Windows.Forms.ToolStripMenuItem btnCurrentData;
        private System.Windows.Forms.ToolStripMenuItem btnHistoryData;
        private System.Windows.Forms.ToolStripMenuItem btnExit;
        private System.Windows.Forms.ToolStripMenuItem btnExperiment;
        private System.Windows.Forms.ToolStripMenuItem btnDataAnalysis;
        private System.Windows.Forms.ToolStripMenuItem btnAnalysisResult;
        private System.Windows.Forms.ToolStripMenuItem btnManualExperiment;
        private System.Windows.Forms.ToolStripMenuItem btnAutoExperiment;
    }
}