using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FTPUtil
{
    public class FTP
    {

        //控制端口的socket用于传输命令，数据端口的socket用于数据传输
        internal Socket controlSocket;
        internal Socket dataSocket;

        private String serverHost;

        //线程锁
        private Object sendLock = new Object();
        private Object controlPortLock = new Object();
        private Object dataPortLock = new Object();

        private bool dataPortOpen = false;

        /// <summary>
        /// 建立ftp链接
        /// </summary>
        /// <param name="serverHost">服务器ip地址</param>
        /// <param name="portInt">服务器控制端口号</param>
        /// <param name="user">用户名</param>
        /// <param name="password">用户密码</param>
        public FTP(String serverHost, int portInt, String user, String password)
        {
            this.serverHost = serverHost;
            Connect(ref controlSocket, serverHost, portInt);
            ReadControlPort();
            Send("USER "+user);
            ReadControlPort();
            Send("PASS "+password);
            String reply = ReadControlPort();
            reply = reply.Split(' ')[0];
            if (!reply.Equals("230"))
            {
                throw new Exception("登录失败！\n请检查用户名和密码");
            }
            KeepConnect();
        }

        /// <summary>
        /// 匿名建立ftp链接
        /// </summary>
        public FTP(String serverHost, int portInt):this(serverHost, portInt, "anonymous", "anonymous"){}

        /// <summary>
        /// 向服务器的控制端口发送消息
        /// </summary>
        internal void Send(String order)
        {
            lock (sendLock)
            {
                Console.WriteLine(order);
                byte[] bytes = Encoding.UTF8.GetBytes((order + "\r\n").ToCharArray());
                controlSocket.Send(bytes, bytes.Length, 0);
            }
        }

        /// <summary>
        /// 从客户端的控制端口读消息
        /// </summary>
        internal String ReadControlPort()
        {
            String reply = String.Empty;
            lock (controlPortLock)
            {
                byte[] buffer = new byte[1024];
                int count;
                do
                {
                    count = controlSocket.Receive(buffer, buffer.Length, 0);
                    reply += Encoding.UTF8.GetString(buffer, 0, count);
                } while (count >= buffer.Length);
            }
            Console.Write(reply);
            return reply;
        }

        /// <summary>
        /// 通过被动模式建立数据端口连接
        /// </summary>
        internal void ConnectDataPortByPASV()
        {
            lock (sendLock)
            {
                Send("PASV");  //被动模式
                String dataSocketMessage = ReadControlPort();
                Console.WriteLine("connect by pasv:" + dataSocketMessage);
                String[] datas = dataSocketMessage.Split('(')[1].Split(')')[0].Split(',');
                int dataPort = int.Parse(datas[4]) * 256 + int.Parse(datas[5]);

                Connect(ref dataSocket, serverHost, dataPort);
                SetUTF8();
                dataPortOpen = true;
            }
        }

        /// <summary>
        /// 设置UTF8，防止乱码
        /// </summary>
        internal void SetUTF8()
        {
            string cmd = "OPTS UTF8 ON";
            Send(cmd);
            string reply = ReadControlPort();
        }

        /// <summary>
        /// 关数据端口
        /// </summary>
        internal void CloseDataPort()
        {
            if (!dataPortOpen) return;
            dataSocket.Close();
            dataPortOpen = false;
        }

        /// <summary>
        /// 从客户端的数据端口读消息，并返回字符串
        /// </summary>
        internal String ReadDataPortAsString()
        {
            if (!dataPortOpen) return null;
            String reply = String.Empty;
            byte[] buffer = new byte[1024];
            int count;
            lock (dataPortLock)
            {

                do
                {
                    count =  dataSocket.Receive(buffer, buffer.Length, 0);
                    reply += Encoding.UTF8.GetString(buffer, 0, count);
                } while (count >= buffer.Length);
            }
            return reply;
        }

        /// <summary>
        /// 从客户端的数据端口读消息，并返回字节流
        /// </summary>
        internal byte[] ReadDataPort(ref int count,int size)
        {
            if (!dataPortOpen) return null;
            byte[] buffer = new byte[size];  
            count = dataSocket.Receive(buffer, buffer.Length, 0);
            return buffer;
        }

        /// <summary>
        /// 写数据端口
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="count"></param>
        internal void WriteDataPort(byte[] buffer, ref int count)
        {
            if (!dataPortOpen) throw new Exception("Data port isn't open");
            try
            {
               count =  dataSocket.Send(buffer, 0); //count=已发送到的字节数。
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// 建立socket连接
        /// </summary>
        /// <param name="socket">socket的引用</param>
        /// <param name="serverHost">服务器ip</param>
        /// <param name="port">端口号</param>
        internal void Connect(ref Socket socket,String serverHost,int port)
        {
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(serverHost), port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(endpoint);
        }

        /// <summary>
        /// 保持链接，每隔10s发送一个空指令
        /// </summary>
        private void KeepConnect()
        {
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(10000);
                    SendNoop();
                }
            });
            thread.Start();
        }

        /// <summary>
        /// 发送空指令
        /// </summary>
        private void SendNoop()
        {
            lock (sendLock)
            {
                Send("NOOP");
                ReadControlPort();
            }
        }

        public static void Main()
        {
            FTP ftp = new FTP("192.168.18.29", 21);
            //TransferCommand cmd = new DownloadCommand(ftp,"\\HW1.pdf","D:\\");
            //Thread thread = new Thread(new ThreadStart(cmd.Execute));
            //cmd.Execute();
            //thread.Start();
            Command ic = new ListCommand(ftp, "");
            ic.Execute();
            Thread.Sleep(100);
            //cmd.Abort();
            Thread.Sleep(100000);
        }
    }
}
