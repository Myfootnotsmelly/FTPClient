using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FTPUtil
{
    public class ListCommand : Command
    {
        public List<List<String>> Files { get; private set; }
        public List<List<String>> Directories { get; private set; }
        private FTP ftp;
        private String fullpath;
        private String reply = null;

        /// <summary>
        /// 获取文件列表
        /// </summary>
        /// <param name="ftp"></param>
        /// <param name="fullpath">目标文件夹的绝对路径</param>
        public ListCommand(FTP ftp, string fullpath)
        {
            this.ftp = ftp;
            this.fullpath = fullpath;
            this.Files = null;
            this.Directories = null;
        }

        public void Execute()
        {
            //从服务器获取文件目录信息
            Files = null;
            Directories = null;
            ftp.ConnectDataPortByPASV();
            ftp.Send("LIST " + fullpath);
            reply = ftp.ReadControlPort();
            String res = ftp.ReadDataPortAsString();
            ftp.CloseDataPort();


            String[] list = Regex.Split(res, "\r\n", RegexOptions.IgnoreCase);         // /r/n-->换行
            int count = list.Length - 1;
            Files = new List<List<String>>();
            Directories = new List<List<String>>();
            for(int i = 0;i<count;i++)
            {
                String file = list[i];
                List<String> item = new List<string>(Regex.Split(file, "\\s+", RegexOptions.IgnoreCase));
                if (item[2].Equals("<DIR>"))                                            //支持了名字带有空格的文件夹
                {
                    string raw_fileNameofDIR = file.Substring(file.IndexOf("DIR") + 4); //+4使index指向了文件夹名前一个空格的位置
                    string format_fileNameofDIR = raw_fileNameofDIR.Trim();             //去除了文件夹名前的空格
                    item[3] = format_fileNameofDIR;                                     //将文件夹名放在item[3]
                    Directories.Add(item);
                }
                else
                {
                    item[3] = GetFormatFileNameIncludingSpace(file);                    //支持了名字带有空格的文件
                    Files.Add(item);
                }
            }
            reply = ftp.ReadControlPort();
        }

        private string GetFormatFileNameIncludingSpace(string name)//获取名字中带有空格的文件名
        {
            string temp = name; 
            for (int i=0;i<3;i++)
            {
                temp = temp.Substring(temp.IndexOf(" ")+1).Trim();
            }
            return temp;
        }

        public string GetReply()
        {
            return reply;
        }
        
    }
}
