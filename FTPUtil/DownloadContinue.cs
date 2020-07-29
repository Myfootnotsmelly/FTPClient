﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPUtil
{
    public class DownloadContinue : DownloadCommand
    {

        public DownloadContinue(FTP ftp, String source, String destination, int Point) : base(ftp, source, destination)
        {
            this.Point = Point;
        }
        public override Command Abort()
        {
            base.Abort();
            return new DownloadContinue(ftp, Source, Destination, Point);
        }

        public override void Execute()
        {
            lock (this)
            {
                ftp.ConnectDataPortByPASV();
                ftp.Send("REST" + Point);//重新指定文件传送的偏移量
                reply = ftp.ReadControlPort();
                ftp.Send("RETR " + Source);

                reply = ftp.ReadControlPort();
            }
            FileStream fs = new FileStream(Destination + FileName, FileMode.Append) ;
            int count = 0;
            byte[] data;
            do
            {
                data = ftp.ReadDataPort(ref count,Size);
                fs.Write(data,0, data.Length);
                Point += data.Length;
            } while (count >= data.Length);
            reply = ftp.ReadControlPort();
            ftp.CloseDataPort();
            fs.Flush();
            fs.Close();
        }

        public override string GetReply()
        {
            return this.reply;
        }
    }
}
