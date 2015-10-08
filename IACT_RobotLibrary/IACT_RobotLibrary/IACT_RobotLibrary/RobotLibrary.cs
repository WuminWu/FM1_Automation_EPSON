using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.IO;
using System.Runtime.InteropServices;

namespace IACT_RobotLibrary
{
    // For EPSON Robot
    public class IACT_RobotLibrary
    {
        private int RobotPort, MessagePort;                              // robot controller TCP/IP Port
        private string ip;                                 // robot controller IP Address
        private TcpClient Client1, Client2, Client3;
        Thread  checkStateThread, checkStateThread2;                                         // Check Network Status
        private StreamReader MessageReader1, MessageReader2, MessageReader3;
        private NetworkStream DataStream1, DataStream2, DataStream3;
        private Byte[] SFData = new Byte[250];
        private string MainFunctionName = "";


        public bool InitRobotOnly(string IPAddr, int Port)
        {
            ip = IPAddr;
            RobotPort = Port;
            Client1 = new TcpClient();

            try
            {
                Client1.Connect(IPAddress.Parse(ip), RobotPort);
                Console.WriteLine("Client1.Connect = {0} ", Client1.Connected);
                if (Client1.Connected)
                {
                    DataStream1 = Client1.GetStream();
                    MessageReader1 = new StreamReader(DataStream1);
                }
                else
                    return false;
            }
            catch (SocketException ex2)
            {
                Console.WriteLine("SocketException = " + ex2);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception = " + e);
                return false;
            }

            if (Client1.Connected)
            {
                checkStateThread = new Thread(new ThreadStart(checkStateRobot));
                checkStateThread.IsBackground = true;
                checkStateThread.Start();
                return true;
            }
            return false;
        }

        public bool InitControllerPort(string IPAddr, int Port)
        {
            ip = IPAddr;
            MessagePort = Port;
            Client2 = new TcpClient();
            try
            {
                Client2.Connect(IPAddress.Parse(ip), MessagePort);
                Console.WriteLine("Client2.Connect = {0} ", Client2.Connected);
                if (Client2.Connected)
                {
                    DataStream2 = Client2.GetStream();
                    MessageReader2 = new StreamReader(DataStream2);
                }
            }
            catch (SocketException ex2)
            {
                Console.WriteLine("SocketException = " + ex2);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception = " + e);
                return false;
            }

            if (Client2.Connected)
            {
                checkStateThread2 = new Thread(new ThreadStart(checkStateController));
                checkStateThread2.IsBackground = true;
                checkStateThread2.Start();
                return true;
            }
            return false;
        }


        public bool InitMessagePort(string IPAddr, int Port)
        {
            ip = IPAddr;
            MessagePort = Port;
            Client3 = new TcpClient();
            try
            {
                Client3.Connect(IPAddress.Parse(ip), MessagePort);
                Console.WriteLine("Client3.Connect = {0} ", Client3.Connected);
                if (Client3.Connected)
                {
                    DataStream3 = Client3.GetStream();
                    MessageReader3 = new StreamReader(DataStream3);
                    return true;
                }
                else
                    return false;
            }
            catch (SocketException ex2)
            {
                Console.WriteLine("SocketException = " + ex2);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception = " + e);
                return false;
            }
        }

        // Destruct all connections.
        public void DeinitRobot()
        {
            if (checkStateThread != null)
                checkStateThread.Abort();
            if (checkStateThread2 != null)
                checkStateThread2.Abort();
            if (MessageReader1 != null)
                MessageReader1.Close();
            if (MessageReader2 != null)
                MessageReader2.Close();
            if (DataStream1 != null)
                DataStream1.Close();
            if (DataStream2 != null)
                DataStream2.Close();
            if (Client1 != null)
                Client1.Close();
            if (Client2 != null)
                Client2.Close();
        }

        public bool IsRobotConnected()
        {
            try
            {
                if (Client1 != null && Client1.Connected)
                    return true;
            }
            catch (System.NullReferenceException)
            {
            }
            return false;
        }

        public string SendCommand(string msg)
        {
            try
            {
                if (Client1 != null && Client1.Connected)
                {
                    msg += System.Environment.NewLine;                   // there is a newline between command and command

                    ASCIIEncoding code = new ASCIIEncoding();
                    if(DataStream1.CanWrite){
                        Byte[] bbb = code.GetBytes(msg);
                        DataStream1.Write(bbb, 0, bbb.Length);          // Write to transmit
                    }
                    else
                        Console.WriteLine(" DataStream1 can not Write");

                    // Wait for response
                    Thread.Sleep(100);
                    int result = 0;
                    string data = null;
                    do
                    {
                        data = EpsonReadResponse();                                         // MessageReader1.ReadLine();

                        if (data != null)
                        {
                            if (!data.Equals(""))
                                Console.WriteLine("EpsonReadResponse() = "+data);

                            result = string.Compare(msg, data);
                        }
                    } while (result == 0);
                    return data;
                }
            }
            catch (ArgumentNullException ex1)
            {
                Console.WriteLine("ArgumentNullException = " + ex1);
            }
            catch (IOException ex2)
            {
                Console.WriteLine("IOException = " + ex2);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception = " + e);
            }
            return null;
        }

        public void SendInput(string msg)                       //send messages to controller
        {
            try
            {
                if (Client2 != null && Client2.Connected)
                {
                    msg += System.Environment.NewLine;          // Add a NewLine
                    int len = msg.Length;
                    if (len != 0)
                    {
                        ASCIIEncoding code = new ASCIIEncoding();
                        Byte[] bbb = code.GetBytes(msg);

                        Byte[] aaa = new Byte[1024];
                        for (int i = 0; i < len; i++)
                            aaa[i] = bbb[i];
                        aaa[len] = 0x0D;                        // 0x0D means Enter
                        aaa[len + 1] = 0;
                        DataStream2.Write(aaa, 0, len);

                        //DataStream2.Write(bbb, 0, msg.Length);
                        Thread.Sleep(100);
                    }
                }
            }
            catch (ArgumentNullException ex1)
            {
                Console.WriteLine("ArgumentNullException = "+ex1);
            }
            catch (IOException ex2)
            {
                Console.WriteLine("IOException = " + ex2);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception = " + e);
            }
        }

        public string GetMessage()
        {
            char[] data = new char[1000];
            string message;
            int ret, i;

            try
            {
                if (Client2 != null && Client2.Connected == true)
                {
                    ret = MessageReader2.Read(data, 0, 500);                       //read message  char[], int index, int count
                    if (ret == -1)
                        return null;

                    for (i = 0; data[i] != Convert.ToChar(0); )
                    {
                        if (data[i] == 0x0d)
                            data[i] = Convert.ToChar(0);                          // int(0) to char(null)
                        else
                            i++;
                    } 

                    message = CharArrayToString(data, i);
                    return message;
                }
            }
            catch (ArgumentException ex1)
            {
                Console.WriteLine("ArgumentException = " + ex1);
            }
            catch (IOException ex3)
            {
                Console.WriteLine("IOException = " + ex3);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception = " + e);
            }
            return null;
        }

        public string GetPositionMessage()
        {
            char[] data = new char[1000];
            string message;
            int ret, i;

            try
            {
                if (Client3 != null && Client3.Connected == true)
                {
                    ret = MessageReader3.Read(data, 0, 500);                       //read message  char[], int index, int count
                    Console.WriteLine("readerString isn't null, and ret = " + ret);
                    if (ret == -1)
                        return null;

                    for (i = 0; data[i] != Convert.ToChar(0); )
                    {
                        Console.WriteLine("data[{0}] = {1}", i, data[i]);
                        if (data[i] == 0x0d)
                            data[i] = Convert.ToChar(0);                          // int(0) to char(null)
                        else
                            i++;
                    }

                    message = CharArrayToString(data, i);
                    return message;
                }
            }
            catch (ArgumentException ex1)
            {
                Console.WriteLine("ArgumentException = " + ex1);
            }
            catch (IOException ex3)
            {
                Console.WriteLine("IOException = " + ex3);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception = " + e);
            }
            return null;
        }
 

        public string EpsonLoginRobot(string pw)
        {
            string response;

            response = SendCommand("$Login," + pw);     // Login Robot
            return response;

        }

        public string EpsonLogoutRobot()
        {
            string response;

            response = SendCommand("$Logout");     // Logout Robot
            return response;
        }

        public string EpsonGetControllerStatus()
        {
                string response;

                response = SendCommand("$GetStatus");     // Get Status
                return response;
        }

        public string EpsonPauseAllTask()
        {
                string response;

                response = SendCommand("$Pause");         // Pause All Tasks
                return response;
        }

        public string EpsonContinuePauseTask()
        {
                string response;

                response = SendCommand("$Continue");      // Continue Tasks been paused
                return response;
        }

        private void checkStateRobot()
        {
            while (true)
            {
                Thread.Sleep(1000);
                
                if (Client1.Connected == false)
                {
                    try
                    {
                        if (MessageReader1 != null)
                            MessageReader1.Close();
                        if (DataStream1 != null)
                            DataStream1.Close();
                        if (Client1 != null)
                            Client1.Close();

                        Client1 = new TcpClient();
                        Client1.Connect(IPAddress.Parse(ip), RobotPort);              // connect to given ip on port 1000 for robot controll
                        if (Client1.Connected)
                        {
                            DataStream1 = Client1.GetStream();
                            MessageReader1 = new StreamReader(DataStream1);            //Message for remote controll
                        }
                    }
                    catch (ArgumentNullException ex1)
                    {
                        Console.WriteLine("ArgumentNullException = " + ex1);
                    }
                    catch (SocketException ex2)
                    {
                        Console.WriteLine("SocketException = " + ex2);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception = " + e);
                    }
                }
            }
        }

        private void checkStateController()
        {
            while (true)
            {
                Thread.Sleep(1000);

                if (Client2.Connected == false)
                {
                    try
                    {
                        if (MessageReader2 != null)
                            MessageReader2.Close();
                        if (DataStream2 != null)
                            DataStream2.Close();
                        if (Client2 != null)
                            Client2.Close();

                        Client2 = new TcpClient();
                        Client2.NoDelay = true;
                        Client2.Connect(IPAddress.Parse(ip), MessagePort);

                        if (Client2.Connected)
                        {
                            DataStream2 = Client1.GetStream();
                            MessageReader2 = new StreamReader(DataStream2);            
                        }
                    }
                    catch (ArgumentNullException ex1)
                    {
                        Console.WriteLine("ArgumentNullException = " + ex1);
                    }
                    catch (SocketException ex2)
                    {
                        Console.WriteLine("SocketException = " + ex2);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception = " + e);
                    }
                }
            }
        }

        private string EpsonReadResponse()
        {
            string message;

            try
            {
                if (Client1 != null && Client1.Connected == true && DataStream1.DataAvailable == true)
                {
                    message = MessageReader1.ReadLine();   //read message
                    return message;
                }
            }
            catch (IOException ex1)
            {
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception = " + e);
            }
            return null;
        }

        public string ServerOn(bool OnOff)
        {
            string response;

            if (OnOff == true)
                response = SendCommand("$SetMotorsOn, 1");         // ServerOn, 0 means all robots
            else
                response = SendCommand("$SetMotorsOff, 1");        // ServerOff, 0 means all robots
            return response;
        }

        public string StartRunRobot()
        {
            string response;

            response = SendCommand("$Start," + MainFunctionName);        // Choose main function
            return response;
        }

        public string StopRunRobot()
        {
            string response;

            response = SendCommand("$Stop");         // 停止所有程序
            return response;
        }


        public string ResetRobot()
        {
            string response;
            response = SendCommand("$Reset");        // 程序复位
            return response;
        }

        private string CharArrayToString(char[] data, int len)
        {
            StringBuilder sb = new StringBuilder(len + 1);
            for (int i = 0; i < len; i++)
                sb.Append(Convert.ToString(data[i]));
            return sb.ToString();
        }

        private string GetTextFromFile(string FilePath)
        {
            StreamReader r = null;
            try
            {
                r = new StreamReader(FilePath);
                StringBuilder s = new StringBuilder();
                string str = null;
                while ((str = r.ReadLine()) != null)
                {
                    s.Append(str);
                }
                return s.ToString();
            }
            catch
            {
                return "";
            }
            finally
            {
                try
                {
                    r.Close();
                }
                catch { }
            }
        }


    }
}
