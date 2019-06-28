namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.log = new System.Windows.Forms.ListView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RebootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.autoScroll = new System.Windows.Forms.CheckBox();
            this.svrAddress = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(674, 446);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Clear Log";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClearLog_Click);
            // 
            // log
            // 
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.log.AutoArrange = false;
            this.log.ContextMenuStrip = this.contextMenuStrip1;
            this.log.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.log.Location = new System.Drawing.Point(12, 12);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(737, 424);
            this.log.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.log.TabIndex = 3;
            this.log.UseCompatibleStateImageBehavior = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RebootToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(113, 26);
            // 
            // RebootToolStripMenuItem
            // 
            this.RebootToolStripMenuItem.Name = "RebootToolStripMenuItem";
            this.RebootToolStripMenuItem.Size = new System.Drawing.Size(112, 22);
            this.RebootToolStripMenuItem.Text = "Reboot";
            this.RebootToolStripMenuItem.Click += new System.EventHandler(this.RebootToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 451);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Error: 0 Warn: 0 Info: 0 Success: 0";
            // 
            // autoScroll
            // 
            this.autoScroll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.autoScroll.AutoSize = true;
            this.autoScroll.Location = new System.Drawing.Point(596, 450);
            this.autoScroll.Name = "autoScroll";
            this.autoScroll.Size = new System.Drawing.Size(72, 17);
            this.autoScroll.TabIndex = 6;
            this.autoScroll.Text = "Autoscroll";
            this.autoScroll.UseVisualStyleBackColor = true;
            this.autoScroll.CheckedChanged += new System.EventHandler(this.AutoScroll_CheckedChanged);
            // 
            // svrAddress
            // 
            this.svrAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.svrAddress.AutoSize = true;
            this.svrAddress.Cursor = System.Windows.Forms.Cursors.Hand;
            this.svrAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.svrAddress.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.svrAddress.Location = new System.Drawing.Point(513, 451);
            this.svrAddress.Name = "svrAddress";
            this.svrAddress.Size = new System.Drawing.Size(77, 13);
            this.svrAddress.TabIndex = 7;
            this.svrAddress.Text = "configuration.h";
            this.svrAddress.Click += new System.EventHandler(this.SvrAddress_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 477);
            this.Controls.Add(this.svrAddress);
            this.Controls.Add(this.autoScroll);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.log);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Remote Debugger";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView log;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem RebootToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox autoScroll;
        private System.Windows.Forms.Label svrAddress;
    }
}

