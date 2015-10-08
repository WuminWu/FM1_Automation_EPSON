using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Sockets;    //use this namespace for sockets
using System.Net;            //for ip addressing
using System.IO;             //for streaming io
using System.Threading;      //for running threads
using System.Reflection;
using System.Globalization;
using System.Security.Cryptography;

//Harris ++
using System.Runtime.InteropServices;
//Harris --

using IACT_RobotLibrary;

namespace IACT_RobotDemo
{
    public partial class Form_Main : Form
    {
        private bool InitControllerResult = false, InitControllerResult2 = false, InitRobotResult, InitMessagePort;
        private string pwd = "1234";

        private string callCameraAngle = "TakePictureForAngle\r\n";
        private string callCameraPosition = "TakePictureForPosituon\r\n";
        private double offsetAngle, offsetX, offsetY;

        NetworkStream networkStream;
        TcpClient tcpClient = new TcpClient();

        private Thread MsgThread, MsgThread2, MsgThread3;

        public IACT_RobotLibrary.IACT_RobotLibrary robot = new IACT_RobotLibrary.IACT_RobotLibrary();
        public IACT_RobotLibrary.IACT_RobotLibrary robot2 = new IACT_RobotLibrary.IACT_RobotLibrary();

        public Form_Main()
        {
            InitializeComponent();
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Form_Main_Closing);
        }

        // Form is opened 
        private void Form_Main_Load(object sender, EventArgs e)
        {
            Console.Write("Status = Form_Main_Load\n");
        }

        // Form is closed
        private void Form_Main_Closing(object sender, EventArgs e)
        {
            Console.Write("Status = Form_MainClosing\n");
            robot.DeinitRobot();                              //  Close TCP 
        }
        
        // Receive Message, As a Server
        private void communicateMessageLoop()
        {
            IPAddress ip = IPAddress.Parse("192.168.0.2");

            TcpListener tcpListener = new TcpListener(ip, 36000);
            tcpListener.Start();
            Console.WriteLine("communicateMessageLoop Server Waiting.............");

            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();
                Console.WriteLine("AcceptTcpClient()");
                try
                {
                    if (tcpClient.Connected)
                    {
                        Console.WriteLine("communicateMessageLoop Success !!");
                        string receiveMsg = string.Empty;
                        byte[] receiveBytes = new byte[tcpClient.ReceiveBufferSize];
                        int numberOfBytesRead = 0;
                        networkStream = tcpClient.GetStream();

                        if (networkStream.CanRead)
                        {
                            do
                            {
                                // Read Data
                                numberOfBytesRead = networkStream.Read(receiveBytes, 0, tcpClient.ReceiveBufferSize);
                                receiveMsg = Encoding.Default.GetString(receiveBytes, 0, numberOfBytesRead);
                                if(receiveMsg != "")
                                    Console.WriteLine("Get receiveMsg = " + receiveMsg);

                                if (receiveMsg.Equals(callCameraAngle))
                                {
                                    Console.WriteLine("Activate Camera for Angle");

                                    // generate random angle and send it to Robot
                                    double angle = ActionCameraAngle(-10, 10);

                                    // Send Angle to Robot Controller
                                    if (InitControllerResult == false)
                                    {
                                        Console.WriteLine("Connect with angleService");
                                        InitControllerResult = robot.InitControllerPort("192.168.0.3", 2000);
                                    }
                                    if (InitControllerResult)
                                    {
                                        robot.SendInput(angle.ToString());
                                        Console.WriteLine("ActionCameraAngle = " + angle);
                                    }
                                    else
                                        MessageBox.Show("Client2 connect fail : Angle");
                                }
                                    
                                if (receiveMsg.Equals(callCameraPosition))
                                {
                                    Console.WriteLine("Activate Camera for Position");

                                    //generate random position and send it to Robot
                                    double[] position = ActionCameraPosition(-0.05, 0.05);

                                    // Send Position to Robot Controller
                                    if (InitControllerResult2 == false)
                                    {
                                        Console.WriteLine("Connect with positionService");
                                        InitControllerResult2 = robot2.InitControllerPort("192.168.0.3", 2001);
                                    }

                                    if (InitControllerResult2)
                                    {
                                        robot2.SendInput(position[0].ToString());
                                        robot2.SendInput(position[1].ToString());
                                        Console.WriteLine("position[X] = " + position[0]);
                                        Console.WriteLine("position[Y] = " + position[1]);
                                    }
                                    else
                                        MessageBox.Show("Client2 connect fail : Position");
                                }

                                /*
                                // Write Data and return it to Client
                                String strTest = "Send Msg from Server";
                                Byte[] myBytes = Encoding.ASCII.GetBytes(strTest);
                                networkStream = tcpClient.GetStream();
                                networkStream.Write(myBytes, 0, myBytes.Length);
                                */
                            }
                            while (networkStream.DataAvailable);                  // return to AcceptTcpClient() if false
                            // while(true)                                        // keep receive
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Catch Exception = " + e);
                    tcpClient.Close();
                    Console.WriteLine("Server communicateMessageLoop Close");
                    Console.Read();
                }
            }
        }

        private double ActionCameraAngle(double minValue, double maxValue)
        {
            Random random = new Random();
            double angle = random.NextDouble()*(maxValue-minValue)+minValue;
            angle = Math.Round(angle,3);
            return angle;
        }

        private double[] ActionCameraPosition(double minValue, double maxValue)
        {
            Random random = new Random();
            double positionX = random.NextDouble() * (maxValue - minValue) + minValue;
            positionX = Math.Round(positionX, 3);
            double positionY = random.NextDouble() * (maxValue - minValue) + minValue;
            positionY = Math.Round(positionY, 3);

            double[] position = new double[]{positionX,positionY};
            return position;
        }

        private void MessageLoop()
        {
            string message;
            do
            {
                if (robot != null && robot.IsRobotConnected() == true)
                {
                    message = robot.GetMessage();

                    if (message != null)
                    {
                        Console.WriteLine("MessageLoop GetMessage = " + message);
                    }
                }
            } while (true);
        }

        private void MessageLoop2()
        {
            string message2;
            do
            {
                if (robot != null && robot.IsRobotConnected() == true)
                {
                    message2 = robot2.GetMessage();

                    if (message2 != null)
                    {
                        Console.WriteLine("MessageLoop GetMessage2 = " + message2);
                    }
                }
            } while (true);
        }

        private void button_Connect(object sender, EventArgs e)
        {
            // Connect with Robot Controller
            InitRobotResult = robot.InitRobotOnly("192.168.0.3",5000);

            if (InitRobotResult == true)
            {
                MessageBox.Show("Robot Connect Successfully");

                // GetMessage While Form_Main activate
                MsgThread = new Thread(new ThreadStart(communicateMessageLoop));
                MsgThread.Start();

                // getMessage from object robot
                MsgThread2 = new Thread(new ThreadStart(MessageLoop));
                MsgThread2.Start();

                // getMessage from object robot2
                MsgThread3 = new Thread(new ThreadStart(MessageLoop2));
                MsgThread3.Start();
            }
            else
                MessageBox.Show("Robot Connect Fail");

        }

        private void button_EmergencyStop(object sender, EventArgs e)
        {
            string response = robot.StopRunRobot();
            if(response==null)
                MessageBox.Show("Stop Robot Fail");
        }

        private void button_Login(object sender, EventArgs e)
        {
            string response = robot.EpsonLoginRobot(pwd);
            if (response == null)
                MessageBox.Show("Login Fail");
            if (response.Equals("#Login,0"))
                MessageBox.Show("Login Success");
        }

        private void button_Logout(object sender, EventArgs e)
        {
            string response = robot.EpsonLogoutRobot();
            if (response == null)
                MessageBox.Show("Logout Fail");
        }

        private void button_ExecuteRobot1(object sender, EventArgs e)
        {
            if (robot != null && robot.IsRobotConnected() == true)
            {
                string response;
                //Select Function Num
                response = robot.SendCommand("$Start,2");               
                Thread.Sleep(100);
                if (response == null)
                {
                    MessageBox.Show("No Programing File");
                    return;
                }
            }
            else
                MessageBox.Show("Robot Connect Fail");
        }

        private void button_ExecuteRobot2(object sender, EventArgs e)
        {
            if (robot != null && robot.IsRobotConnected() == true)
            {
                string response;
                // Select Function Num
                response = robot.SendCommand("$Start,0");
                Thread.Sleep(100);
                if (response == null)
                {
                    MessageBox.Show("No Programing File");
                    return;
                }
            }
            else
                MessageBox.Show("Robot Connect Fail");
        }

        private void button_ServerOn(object sender, EventArgs e)
        {
            string response = robot.ServerOn(true);
            if (response == null)
                MessageBox.Show("ServerOn Fail");
        }

        private void button_ServerOff(object sender, EventArgs e)
        {
            string response = robot.ServerOn(false);
            if (response == null)
                MessageBox.Show("ServerOn Fail");
        }

        private void button_Reset(object sender, EventArgs e)
        {
            string response = robot.ResetRobot();
            if (response == null)
                MessageBox.Show("Reset Fail");
        }

        private void button_canTakePicture(object sender, EventArgs e)
        {
            // Call OpenCV and get angle
        }

        private void button_OpenControllerPort(object sender, EventArgs e)
        {
            string response = robot.SendCommand("$Start,5");
            Console.WriteLine("Open Controller port, and reponse = " + response);

            //InitMessagePort = robot.InitMessagePort("192.168.0.3", 2015);

            if (response.Equals("#Start,0"))
                MessageBox.Show("Controller Connection Success");
            else
                MessageBox.Show("Controller Connection Fail");
        }

        private void button_SendString(object sender, EventArgs e)
        {
            if (InitControllerResult == false)
            {
                InitControllerResult = robot.InitControllerPort("192.168.0.3", 2002);
                Console.WriteLine("InitControllerResult = " + InitControllerResult);
            }

            if (InitControllerResult)
                robot.SendInput("HelloWorld");
            else
                MessageBox.Show("Client2 connect fail : String");
        }

        private void button_SendAngle(object sender, EventArgs e)
        {
            if (InitControllerResult == false)
            {
                InitControllerResult = robot.InitControllerPort("192.168.0.3", 2000);
                Console.WriteLine("InitControllerResult = " + InitControllerResult);
            }
            if (InitControllerResult)
                robot.SendInput("9.527");
            else
                MessageBox.Show("Client2 connect fail : Angle");
        }

        private void button_SendPosition(object sender, EventArgs e)
        {
            if (InitControllerResult == false)
            {
                InitControllerResult = robot.InitControllerPort("192.168.0.3", 2001);
                Console.WriteLine("InitControllerResult = " + InitControllerResult);
            }
            if (InitControllerResult)
            {
                robot.SendInput("1.45678");
                robot.SendInput("1.234");
            }
            else
                MessageBox.Show("Client2 connect fail : Position");
        }

        private void button_canTakePic(object sender, EventArgs e)
        {
            double angle = ActionCameraAngle(-10,10);

            // Send Angle to Robot Controller
            if (InitControllerResult == false)
            {
                Console.WriteLine("Connect with angleService");
                InitControllerResult = robot.InitControllerPort("192.168.0.3", 2000);
            }
            if (InitControllerResult)
            {
                robot.SendInput(angle.ToString());
                Console.WriteLine("ActionCameraAngle = " + angle);
            }
            else
                MessageBox.Show("Client2 connect fail : Angle");
        }

        private void button_canTakeSecPic(object sender, EventArgs e)
        {
            double[] position = ActionCameraPosition(-0.05, 0.05);

            // Send Position to Robot Controller
            if (InitControllerResult2 == false)
            {
                Console.WriteLine("Connect with positionService");
                InitControllerResult2 = robot2.InitControllerPort("192.168.0.3", 2001);
            }

            if (InitControllerResult2)
            {
                robot2.SendInput(position[0].ToString());
                robot2.SendInput(position[1].ToString());
                Console.WriteLine("position[X] = " + position[0]);
                Console.WriteLine("position[Y] = " + position[1]);
            }
            else
                MessageBox.Show("Client2 connect fail : Position");
        }

        private void button_getAngle(object sender, EventArgs e)
        {
            //float[] Angle = new float[1];
            //Antenna_Stick_OpenCV.IAC_find_antenna_angle(Angle);
            //IAC_find_antenna_angle(Angle);
            //find_antenna_angle_adaptation(Angle);
           
            //AngleText.Text = Angle[0].ToString();
            //AngleText.Show();
        }

        private void button_getOffset(object sender, EventArgs e)
        {
            //float[] X = new float[1];
            //float[] Y = new float[1];
            //float[] width = new float[1];
            //float[] height = new float[1];
            //Antenna_Stick_OpenCV.IAC_find_antenna_offset(X,Y);
            //IAC_find_antenna_offset(X, Y);
            //find_antenna_offset_adaptation(X, Y, width, height);
            //OffsetX.Text = X[0].ToString();
            //OffsetY.Text = Y[0].ToString();
            //antennaLength.Text = width[0].ToString();
            //antennaHeight.Text = height[0].ToString();
            //OffsetX.Show();
            //OffsetY.Show();
            //antennawidth.Show();
            //antennaheight.Show();
        }

        private void button_OpenCamera1(object sender, EventArgs e)
        {
            //bool camera_state;
            //camera_state = open_basler_camera1_adaptation();
            //if (!camera_state)
                //MessageBox.Show("Camera not ready! Please Try again!");
            //else
                //MessageBox.Show("Camera already standby");
        }

        private void button_CameraInfo(object sender, EventArgs e)
        {
            //StringBuilder build_number = new StringBuilder(20);
            //get_camera1_info(build_number);
            //cameraInfoText.Text = build_number.ToString();
        }

        private void AngleText_TextChanged(object sender, EventArgs e)
        {

        }

        private void check_left_x_TextChanged(object sender, EventArgs e)
        {

        }

        private void OffsetY_TextChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

    }
}
