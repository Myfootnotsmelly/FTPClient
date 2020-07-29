﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPUtil
{
    /// <summary>
    /// 文件传输类，派生出上传、下载和对应的两个断点续传类
    /// </summary>
    public abstract class TransferCommand : Command
    {
        //需要绝对路径（含文件名）
        public String Source { get; set; }

        //需要绝对路径
        public String Destination { get; set; }

        //传输文件名
        public String FileName { get; protected set; }

        //文件大小，单位字节
        public int Size { get; protected set; }

        //当前进度（已完成传送的字节数，下次续传应从+1处开始）
        public int Point { get; protected set; }



        protected FTP ftp;
        protected String reply;

        protected bool started = false;

        public abstract void Execute();
        public abstract string GetReply();

        /// <summary>
        /// 暂停，返回断点重续对象
        /// </summary>
        /// <returns>该传输命令对应的断点传输命令对象</returns>
        public abstract Command Abort(); 
    }
}
