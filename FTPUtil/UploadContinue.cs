using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FTPUtil
{
    public class UploadContinue : UploadCommand
    {
        public UploadContinue(FTP ftp, String source, String des, int point) : base(ftp, source, des) { this.Point = point; } 
        public override Command Abort()
        {
            base.Abort();
            return new UploadContinue(this.ftp, this.FileName, this.Destination,this.Point);
        }

        public override void Execute()
        {
            ftp.ConnectDataPortByPASV();
            ftp.Send("CWD " + Destination + "\r\n");
            reply = ftp.ReadControlPort();
            Console.WriteLine(reply);
            ftp.Send("APPE" + FileName + "\r\n");           //追加上传，用于断点续传
            reply = ftp.ReadControlPort();
            //ftp.Send("STOR " + fileName + "\r\n");
            //reply = ftp.ReadControlPort();
            Console.WriteLine(reply);
            FileStream fs = new FileStream(Source, FileMode.Open, FileAccess.Read);
            try
            {
                int count = 0;
                byte[] buffer = new byte[fs.Length - Point]; //可能有bug，此处也可能是Len - Point，后面再改 ----已修改
                fs.Position = Point+1; //也可能是Point + 1 ----已修改
                fs.Read(buffer, 0, (int)fs.Length/*+1?*/);
                ftp.WriteDataPort(buffer, ref count);
                this.Point = Point +  count;

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
                ftp.CloseDataPort();
            }
        }

        public override string GetReply()
        {
            return base.GetReply();
        }
    }
}
