namespace CSThread08
{
    partial class frmTest
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTest));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.cmdStart = new System.Windows.Forms.ToolStripButton();
            this.cmdStop = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdStart,
            this.cmdStop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // lstLog
            // 
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 12;
            this.lstLog.Location = new System.Drawing.Point(0, 25);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(800, 425);
            this.lstLog.TabIndex = 2;
            // 
            // cmdStart
            // 
            this.cmdStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdStart.Image = ((System.Drawing.Image)(resources.GetObject("cmdStart.Image")));
            this.cmdStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdStart.Name = "cmdStart";
            this.cmdStart.Size = new System.Drawing.Size(39, 22);
            this.cmdStart.Text = "Start";
            this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cmdStop.Image = ((System.Drawing.Image)(resources.GetObject("cmdStop.Image")));
            this.cmdStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(39, 22);
            this.cmdStop.Text = "Stop";
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lstLog);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmTest";
            this.Text = "Thread Demo";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton cmdStart;
        private System.Windows.Forms.ToolStripButton cmdStop;
        private System.Windows.Forms.ListBox lstLog;
    }
}

