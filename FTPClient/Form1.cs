using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using FTPUtil;

namespace FTPClient
{
    public partial class Form1 : Form
    {
        private FTP myFTP;

        #region 初始化加载事件

        /// <summary>
        /// 初始化界面
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            InitLocalTreeView();
        }

        /// <summary>
        /// 初始化本地文件列表
        /// </summary>
        private void InitLocalTreeView()
        {
            string[] drives = Environment.GetLogicalDrives();
            int i = 0;
            foreach (string drive in drives)
            {
                DriveInfo d = new DriveInfo(drive);
                if ((d.DriveType & DriveType.Fixed) == DriveType.Fixed)
                {
                    string drive1 = drive.Substring(0, drive.Length - 1);
                    treeLocal.Nodes[0].Nodes.Add(drive1);
                    treeLocal.Nodes[0].Nodes[i].ImageIndex = 1;
                    treeLocal.Nodes[0].Nodes[i].SelectedImageIndex = 1;
                    treeLocal.Nodes[0].Nodes[i].Tag = drive1;
                    treeLocal.Nodes[0].Nodes[i].Nodes.Add("");//增加一个空白节点，看起来是加号
                    i++;
                }
            }
        }

        
        /// <summary>
        /// 初始化服务器端文件列表
        /// </summary>
        private void InitServerTreeView()
        {
            ListCommand cmd = new ListCommand(myFTP, "/");
            cmd.Execute();
            treeServer.Nodes.Clear();

            int i = 0;
            foreach (List<String> dir in cmd.Directories)
            {
                int imageIndex = 2;
                TreeNode node = new TreeNode(dir[3])
                {
                    Tag = dir[3],
                    ImageIndex = imageIndex,
                    SelectedImageIndex = imageIndex,
                };
                treeServer.Nodes.Add(node);
                treeServer.Nodes[i].Nodes.Add("");//增加一个空白节点，看起来是加号.为文件夹可展开之必要
                i++;
            };

            foreach (List<String> file in cmd.Files)
            {
                int imageIndex = 3;
                TreeNode node = new TreeNode(file[3])
                {
                    Tag = file[3],
                    ImageIndex = imageIndex,
                    SelectedImageIndex = imageIndex,
                };
                treeServer.Nodes.Add(node);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbo_ifAnonymous.Checked = true;//默认使用匿名登陆
            txt_username.Enabled = false;  //匿名登陆用户名默认置为anonymous
            txt_password.Enabled = false;
        }

        private void cbo_ifAnonymous_CheckedChanged(object sender, EventArgs e)
        {
            txt_username.Enabled = txt_password.Enabled = !cbo_ifAnonymous.Checked;
        }
        #endregion

        #region 文件树列表

        /// <summary>
        /// 本地文件列表展开之前填充结点
        /// </summary>
        private void treeLocal_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Level > 0)
            {
                //点击之前，先填充节点：
                string path = e.Node.FullPath.Substring(e.Node.FullPath.IndexOf("\\") + 1) + "\\";
                e.Node.Nodes.Clear();
                string[] files = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly);     //GetFiles返回包含路径的文件名，下处Tag同
                int i = 0;
                foreach (string file in files)
                {
                    FileInfo f = new FileInfo(file);
                    if ((f.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden && (f.Attributes & FileAttributes.System) != FileAttributes.System)
                    {
                        e.Node.Nodes.Add(Path.GetFileName(file));
                        e.Node.Nodes[i].ImageIndex = 3;
                        e.Node.Nodes[i].SelectedImageIndex = 3;
                        e.Node.Nodes[i].Tag = file;
                        i++;
                    }
                }
                string[] dirs = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly);
                foreach (string dir in dirs)
                {
                    DirectoryInfo d = new DirectoryInfo(dir);
                    if ((d.Attributes & FileAttributes.Hidden) != FileAttributes.Hidden && (d.Attributes & FileAttributes.System) != FileAttributes.System)
                    {
                        e.Node.Nodes.Add(Path.GetFileName(dir));
                        e.Node.Nodes[i].ImageIndex = 2;
                        e.Node.Nodes[i].SelectedImageIndex = 2;
                        e.Node.Nodes[i].Tag = dir;
                        e.Node.Nodes[i].Nodes.Add("");
                        i++;
                    }
                }
            }
        }

        /// <summary>
        /// 服务器端文件列表展开前填充子节点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeServer_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            TreeNode parent = e.Node;
            parent.Nodes.Clear();
            //currentServerFolder = parent.ToString();

            String fullPath = parent.FullPath;

            //TODO:先试试同步的加载文件夹效果如何，不行再换多线程
            ListCommand cmd = new ListCommand(myFTP, fullPath);
            cmd.Execute();


            foreach (List<String> dir in cmd.Directories)
            {
                int imageIndex = 2;
                TreeNode node = new TreeNode(dir[3])
                {
                    ImageIndex = imageIndex,
                    SelectedImageIndex = imageIndex,             
                };
                node.Nodes.Add("");            
                parent.Nodes.Add(node);
                node.Tag = node.Parent.Tag + "//" + dir[3];

            }
            foreach (List<String> file in cmd.Files)
            {
                int imageIndex = 3;
                TreeNode node = new TreeNode(file[3])
                {
                    ImageIndex = imageIndex,
                    SelectedImageIndex = imageIndex,
                };
                parent.Nodes.Add(node);
                node.Tag = node.Parent.Tag + "//" + file[3];
            }

        }

        /// <summary>
        /// 本地文件列表右键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeLocal_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Level > 1 )
            {
                this.menuLocal.Enabled = true;
                string path = e.Node.FullPath.Substring(e.Node.FullPath.IndexOf("\\") + 1);
                this.menu_upLoad.Tag = path;
            }
            else
            {
                this.menuLocal.Enabled = false;
            }
        }

        /// <summary>
        /// 服务器端文件列表右键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void treeServer_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string path = e.Node.Tag.ToString();
            menu_download.Tag = path;
            if (e.Node.ImageIndex == 3)
            {
                menuServer.Enabled = true;
            }
            else menuServer.Enabled = false;
        }
        #endregion

        #region FTP操作
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Connect_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbo_ifAnonymous.Checked)
                {
                    myFTP = new FTP(txt_hostip.Text, Int32.Parse(txt_port.Text)); //匿名登陆

                }
                else
                {
                    myFTP = new FTP(txt_hostip.Text, Int32.Parse(txt_port.Text),txt_username.Text,txt_password.Text); //用户名登陆
                }
                InitServerTreeView();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_upLoad_Click(object sender, EventArgs e)
        {
            try
            {
                ToolStripMenuItem load = (ToolStripMenuItem)sender;
                string path = load.Tag.ToString();
                if (File.Exists(path)||(Directory.Exists(path)))
                {
                    TransferCommand transfer = new UploadCommand(myFTP, path, "");
                    transfer.Execute();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("请先与服务器建立连接！", "提示");
            }
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menu_download_Click(object sender, EventArgs e)
        {
            try  
             {             
                ToolStripMenuItem load = (ToolStripMenuItem)sender;
                string path = load.Tag.ToString();
                string destination ;
                FolderBrowserDialog Fbd = new FolderBrowserDialog();
                if(Fbd.ShowDialog()==DialogResult.OK)
                {
                    destination = Fbd.SelectedPath+"\\";
                    TransferCommand transfer = new DownloadCommand(myFTP, path, destination);
                    transfer.Execute();
                }
                 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion


    }
}
