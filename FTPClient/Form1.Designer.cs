namespace FTPClient
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("计算机");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbo_ifAnonymous = new System.Windows.Forms.CheckBox();
            this.button_Connect = new System.Windows.Forms.Button();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.txt_hostip = new System.Windows.Forms.TextBox();
            this.txt_password = new System.Windows.Forms.TextBox();
            this.txt_username = new System.Windows.Forms.TextBox();
            this.label_port = new System.Windows.Forms.Label();
            this.label_hostip = new System.Windows.Forms.Label();
            this.label_password = new System.Windows.Forms.Label();
            this.label_UserName = new System.Windows.Forms.Label();
            this.treeLocal = new System.Windows.Forms.TreeView();
            this.menuLocal = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_upLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.treeServer = new System.Windows.Forms.TreeView();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.menuServer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menu_download = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.panel1.SuspendLayout();
            this.menuLocal.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuServer.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.cbo_ifAnonymous);
            this.panel1.Controls.Add(this.button_Connect);
            this.panel1.Controls.Add(this.txt_port);
            this.panel1.Controls.Add(this.txt_hostip);
            this.panel1.Controls.Add(this.txt_password);
            this.panel1.Controls.Add(this.txt_username);
            this.panel1.Controls.Add(this.label_port);
            this.panel1.Controls.Add(this.label_hostip);
            this.panel1.Controls.Add(this.label_password);
            this.panel1.Controls.Add(this.label_UserName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(947, 100);
            this.panel1.TabIndex = 0;
            // 
            // cbo_ifAnonymous
            // 
            this.cbo_ifAnonymous.AutoSize = true;
            this.cbo_ifAnonymous.Location = new System.Drawing.Point(803, 75);
            this.cbo_ifAnonymous.Name = "cbo_ifAnonymous";
            this.cbo_ifAnonymous.Size = new System.Drawing.Size(89, 19);
            this.cbo_ifAnonymous.TabIndex = 9;
            this.cbo_ifAnonymous.Text = "匿名登陆";
            this.cbo_ifAnonymous.UseVisualStyleBackColor = true;
            this.cbo_ifAnonymous.CheckedChanged += new System.EventHandler(this.cbo_ifAnonymous_CheckedChanged);
            // 
            // button_Connect
            // 
            this.button_Connect.Location = new System.Drawing.Point(803, 37);
            this.button_Connect.Name = "button_Connect";
            this.button_Connect.Size = new System.Drawing.Size(100, 25);
            this.button_Connect.TabIndex = 8;
            this.button_Connect.Text = "连接";
            this.button_Connect.UseVisualStyleBackColor = true;
            this.button_Connect.Click += new System.EventHandler(this.button_Connect_Click);
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(654, 37);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(100, 25);
            this.txt_port.TabIndex = 7;
            // 
            // txt_hostip
            // 
            this.txt_hostip.Location = new System.Drawing.Point(445, 37);
            this.txt_hostip.Name = "txt_hostip";
            this.txt_hostip.Size = new System.Drawing.Size(143, 25);
            this.txt_hostip.TabIndex = 6;
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(247, 37);
            this.txt_password.Name = "txt_password";
            this.txt_password.Size = new System.Drawing.Size(100, 25);
            this.txt_password.TabIndex = 5;
            this.txt_password.UseSystemPasswordChar = true;
            // 
            // txt_username
            // 
            this.txt_username.Location = new System.Drawing.Point(73, 37);
            this.txt_username.Name = "txt_username";
            this.txt_username.Size = new System.Drawing.Size(100, 25);
            this.txt_username.TabIndex = 4;
            // 
            // label_port
            // 
            this.label_port.AutoSize = true;
            this.label_port.Location = new System.Drawing.Point(611, 40);
            this.label_port.Name = "label_port";
            this.label_port.Size = new System.Drawing.Size(37, 15);
            this.label_port.TabIndex = 3;
            this.label_port.Text = "端口";
            // 
            // label_hostip
            // 
            this.label_hostip.AutoSize = true;
            this.label_hostip.Location = new System.Drawing.Point(384, 40);
            this.label_hostip.Name = "label_hostip";
            this.label_hostip.Size = new System.Drawing.Size(52, 15);
            this.label_hostip.TabIndex = 2;
            this.label_hostip.Text = "主机号";
            // 
            // label_password
            // 
            this.label_password.AutoSize = true;
            this.label_password.Location = new System.Drawing.Point(204, 40);
            this.label_password.Name = "label_password";
            this.label_password.Size = new System.Drawing.Size(37, 15);
            this.label_password.TabIndex = 1;
            this.label_password.Text = "密码";
            // 
            // label_UserName
            // 
            this.label_UserName.AutoSize = true;
            this.label_UserName.Location = new System.Drawing.Point(12, 40);
            this.label_UserName.Name = "label_UserName";
            this.label_UserName.Size = new System.Drawing.Size(52, 15);
            this.label_UserName.TabIndex = 0;
            this.label_UserName.Text = "用户名";
            // 
            // treeLocal
            // 
            this.treeLocal.ContextMenuStrip = this.menuLocal;
            this.treeLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeLocal.ImageIndex = 0;
            this.treeLocal.ImageList = this.imageList1;
            this.treeLocal.Location = new System.Drawing.Point(0, 0);
            this.treeLocal.Name = "treeLocal";
            treeNode2.Name = "节点0";
            treeNode2.Text = "计算机";
            this.treeLocal.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode2});
            this.treeLocal.SelectedImageIndex = 0;
            this.treeLocal.Size = new System.Drawing.Size(457, 408);
            this.treeLocal.TabIndex = 0;
            this.treeLocal.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeLocal_BeforeExpand);
            this.treeLocal.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeLocal_AfterSelect);
            // 
            // menuLocal
            // 
            this.menuLocal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuLocal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_upLoad});
            this.menuLocal.Name = "menuLocal";
            this.menuLocal.Size = new System.Drawing.Size(109, 28);
            // 
            // menu_upLoad
            // 
            this.menu_upLoad.Name = "menu_upLoad";
            this.menu_upLoad.Size = new System.Drawing.Size(108, 24);
            this.menu_upLoad.Text = "上传";
            this.menu_upLoad.Click += new System.EventHandler(this.menu_upLoad_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "computer.gif");
            this.imageList1.Images.SetKeyName(1, "drive.gif");
            this.imageList1.Images.SetKeyName(2, "folder.ico");
            this.imageList1.Images.SetKeyName(3, "file.ico");
            this.imageList1.Images.SetKeyName(4, "up.gif");
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 100);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(947, 443);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel3);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(939, 414);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "文件列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.treeServer);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(473, 408);
            this.panel3.TabIndex = 2;
            // 
            // treeServer
            // 
            this.treeServer.ContextMenuStrip = this.menuServer;
            this.treeServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeServer.ImageIndex = 0;
            this.treeServer.ImageList = this.imageList1;
            this.treeServer.Location = new System.Drawing.Point(0, 0);
            this.treeServer.Name = "treeServer";
            this.treeServer.SelectedImageIndex = 0;
            this.treeServer.Size = new System.Drawing.Size(473, 408);
            this.treeServer.TabIndex = 0;
            this.treeServer.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeServer_BeforeExpand);
            this.treeServer.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeServer_AfterSelect);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.treeLocal);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(479, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(457, 408);
            this.panel2.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(939, 414);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "传输列表";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // menuServer
            // 
            this.menuServer.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuServer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_download});
            this.menuServer.Name = "menuServer";
            this.menuServer.Size = new System.Drawing.Size(109, 28);
            // 
            // menu_download
            // 
            this.menu_download.Name = "menu_download";
            this.menu_download.Size = new System.Drawing.Size(210, 24);
            this.menu_download.Text = "下载";
            this.menu_download.Click += new System.EventHandler(this.menu_download_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 543);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "FTPClient";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuLocal.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.menuServer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbo_ifAnonymous;
        private System.Windows.Forms.Button button_Connect;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.TextBox txt_hostip;
        private System.Windows.Forms.TextBox txt_password;
        private System.Windows.Forms.TextBox txt_username;
        private System.Windows.Forms.Label label_port;
        private System.Windows.Forms.Label label_hostip;
        private System.Windows.Forms.Label label_password;
        private System.Windows.Forms.Label label_UserName;
        private System.Windows.Forms.TreeView treeLocal;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip menuLocal;
        private System.Windows.Forms.ToolStripMenuItem menu_upLoad;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeServer;
        private System.Windows.Forms.ContextMenuStrip menuServer;
        private System.Windows.Forms.ToolStripMenuItem menu_download;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}

