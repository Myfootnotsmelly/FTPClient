using System;
using FTPUtil;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            FTP myftp = new FTP("192.168.18.29", 21);
            DownloadCommand cmd = new DownloadCommand(myftp, "Game.dll", "G:\\");
            cmd.Execute();
            Thread.Sleep(10);
            DownloadContinue cmd2 = (DownloadContinue)cmd.Abort();
            cmd2.Execute();
        }
    }
}
