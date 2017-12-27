namespace ExperimentTableDetectSystem.Windows.auto
{
    partial class TestFinishedWin
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
            this.lblCon = new MetroFramework.Controls.MetroLabel();
            this.btnNxet = new System.Windows.Forms.Button();
            this.btnRetest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblCon
            // 
            this.lblCon.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCon.AutoSize = true;
            this.lblCon.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lblCon.ForeColor = System.Drawing.Color.Red;
            this.lblCon.Location = new System.Drawing.Point(295, 175);
            this.lblCon.Margin = new System.Windows.Forms.Padding(3);
            this.lblCon.Name = "lblCon";
            this.lblCon.Size = new System.Drawing.Size(107, 25);
            this.lblCon.TabIndex = 7;
            this.lblCon.Text = "已完成测试";
            this.lblCon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNxet
            // 
            this.btnNxet.BackColor = System.Drawing.Color.SteelBlue;
            this.btnNxet.ForeColor = System.Drawing.Color.White;
            this.btnNxet.Location = new System.Drawing.Point(181, 308);
            this.btnNxet.Name = "btnNxet";
            this.btnNxet.Size = new System.Drawing.Size(117, 41);
            this.btnNxet.TabIndex = 8;
            this.btnNxet.Text = "测下一个阀";
            this.btnNxet.UseVisualStyleBackColor = false;
            // 
            // btnRetest
            // 
            this.btnRetest.BackColor = System.Drawing.Color.SteelBlue;
            this.btnRetest.ForeColor = System.Drawing.Color.White;
            this.btnRetest.Location = new System.Drawing.Point(384, 308);
            this.btnRetest.Name = "btnRetest";
            this.btnRetest.Size = new System.Drawing.Size(114, 41);
            this.btnRetest.TabIndex = 9;
            this.btnRetest.Text = "重新测试";
            this.btnRetest.UseVisualStyleBackColor = false;
            this.btnRetest.Click += new System.EventHandler(this.btnRetest_Click);
            // 
            // TestFinishedWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Drawing.MetroBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(694, 582);
            this.Controls.Add(this.btnRetest);
            this.Controls.Add(this.btnNxet);
            this.Controls.Add(this.lblCon);
            this.Font = new System.Drawing.Font("宋体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Movable = false;
            this.Name = "TestFinishedWin";
            this.Padding = new System.Windows.Forms.Padding(22, 72, 22, 24);
            this.Resizable = false;
            this.Text = "测试完成";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TestFinishedWin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblCon;
        private System.Windows.Forms.Button btnNxet;
        private System.Windows.Forms.Button btnRetest;
    }
}