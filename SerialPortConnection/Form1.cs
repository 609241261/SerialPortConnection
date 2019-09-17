using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using INIFILE;
using System.Text.RegularExpressions;
using System.Threading;

namespace SerialPortConnection
{
    public partial class Form1 : Form
    {
        SerialPort sp1 = new SerialPort();
        //sp1.ReceivedBytesThreshold = 1;//只要有1个字符送达端口时便触发DataReceived事件 
        //public static bool skgFlag;
        string txtReceiveAll = "";            //接收的所有字符拼接到一起，当收到一个完整密钥之后，清零重新开始累积
        int keySendFlag = 0;

        public Form1()
        {
            InitializeComponent();

        }

        //加载
        private void Form1_Load(object sender, EventArgs e)
        {
            INIFILE.Profile.LoadProfile();//加载所有

            // 预置波特率
            switch (Profile.G_BAUDRATE)
            {
                case "300":
                    cbBaudRate.SelectedIndex = 0;
                    break;
                case "600":
                    cbBaudRate.SelectedIndex = 1;
                    break;
                case "1200":
                    cbBaudRate.SelectedIndex = 2;
                    break;
                case "2400":
                    cbBaudRate.SelectedIndex = 3;
                    break;
                case "4800":
                    cbBaudRate.SelectedIndex = 4;
                    break;
                case "9600":
                    cbBaudRate.SelectedIndex = 5;
                    break;
                case "19200":
                    cbBaudRate.SelectedIndex = 6;
                    break;
                case "38400":
                    cbBaudRate.SelectedIndex = 7;
                    break;
                case "115200":
                    cbBaudRate.SelectedIndex = 8;
                    break;
                default:
                    {
                        MessageBox.Show("波特率预置参数错误。");
                        return;
                    }
            }

            //预置波特率
            switch (Profile.G_DATABITS)
            {
                case "5":
                    cbDataBits.SelectedIndex = 0;
                    break;
                case "6":
                    cbDataBits.SelectedIndex = 1;
                    break;
                case "7":
                    cbDataBits.SelectedIndex = 2;
                    break;
                case "8":
                    cbDataBits.SelectedIndex = 3;
                    break;
                default:
                    {
                        MessageBox.Show("数据位预置参数错误。");
                        return;
                    }

            }
            //预置停止位
            switch (Profile.G_STOP)
            {
                case "1":
                    cbStop.SelectedIndex = 0;
                    break;
                case "1.5":
                    cbStop.SelectedIndex = 1;
                    break;
                case "2":
                    cbStop.SelectedIndex = 2;
                    break;
                default:
                    {
                        MessageBox.Show("停止位预置参数错误。");
                        return;
                    }
            }

            //预置校验位
            switch (Profile.G_PARITY)
            {
                case "NONE":
                    cbParity.SelectedIndex = 0;
                    break;
                case "ODD":
                    cbParity.SelectedIndex = 1;
                    break;
                case "EVEN":
                    cbParity.SelectedIndex = 2;
                    break;
                default:
                    {
                        MessageBox.Show("校验位预置参数错误。");
                        return;
                    }
            }

            //检查是否含有串口
            string[] str = SerialPort.GetPortNames();
            if (str == null)
            {
                MessageBox.Show("本机没有串口！", "Error");
                return;
            }

            //添加串口项目
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {//获取有多少个COM口
                //System.Diagnostics.Debug.WriteLine(s);
                cbSerial.Items.Add(s);
            }

            //串口设置默认选择项
            cbSerial.SelectedIndex = 0;         //note：获得COM9口，但别忘修改
                                                //cbBaudRate.SelectedIndex = 5;
                                                // cbDataBits.SelectedIndex = 3;
                                                // cbStop.SelectedIndex = 0;
                                                //  cbParity.SelectedIndex = 0;
            sp1.BaudRate = 9600;

            //Thread.Sleep(600);
            Control.CheckForIllegalCrossThreadCalls = false;    //这个类中我们不检查跨线程的调用是否合法(因为.net 2.0以后加强了安全机制,，不允许在winform中直接跨线程访问控件的属性)
            //Thread.Sleep(220);
            sp1.DataReceived += new SerialDataReceivedEventHandler(sp1_DataReceived);
            //sp1.ReceivedBytesThreshold = 1;

            radio1.Checked = true;  //单选按钮默认是选中的
            rbRcvStr.Checked = true;

            //准备就绪              
            sp1.DtrEnable = true;
            sp1.RtsEnable = true;
            //设置数据读取超时为1秒
            sp1.ReadTimeout = 1000;

            sp1.Close();
        }
        #region 串口操作

        void sp1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (sp1.IsOpen)     //此处可能没有必要判断是否打开串口，但为了严谨性，我还是加上了
            {
                //输出当前时间
                //DateTime dt = DateTime.Now;
                //txtReceive.Text += dt.GetDateTimeFormats('f')[0].ToString() + "\r\n";
                //txtReceive.SelectAll();
                //txtReceive.SelectionColor = Color.Blue;         //改变字体的颜色
                // restrTimer.Enabled = false;
                //MessageBox.Show(restrTimer.Enabled.ToString());
                //if (skgFlag == true)
                //{
                //    restrTimer.Enabled = true;
                //MessageBox.Show(restrTimer.Enabled.ToString());
                // }
                // restrTimer.Enabled = true;


                Thread.Sleep(600);
                if (rbRcvStr.Checked)                          //'发送字符串'单选按钮
                {
                    string txtReceiveTemp;
                    byte[] byteRead = new byte[sp1.BytesToRead];    //BytesToRead:sp1接收的字符个数
                    sp1.Read(byteRead, 0, byteRead.Length);
                    txtReceiveTemp = System.Text.Encoding.Default.GetString(byteRead);
                    //txtReceiveTemp = sp1.ReadLine();
                    //MessageBox.Show(txtReceiveTemp);
                    //char dada = txtReceiveTemp[0];
                    //int dad = Convert.ToInt32(txtReceiveTemp[0]);
                    txtReceiveAll += txtReceiveTemp;//无论发送的是什么，接收之后都显示在txtSendView，用以判断发送是否成功；
                    txtSendView.Text += txtReceiveTemp;
                    keySendFlag = txtReceiveAll.IndexOf("!");

                    if (keySendFlag != -1)                    //找到！则判断总字符长度是否大于！位置加上130
                    {
                        //MessageBox.Show(keySendFlag.ToString());
                        if (txtReceiveAll.Length > (keySendFlag + 30))    //大于130 说明密钥已经接收完毕则显示密钥，并重置密钥发送标记和总字符
                        {
                            //txtReceive.Text = "";
                            //txtReceive.Text += txtReceiveAll.Substring((keySendFlag + 1), 29) + "\r\n";
                            txtReceive.Text = txtReceiveAll.Substring((keySendFlag + 1), 29);
                            keySendFlag = 0;
                            txtReceiveAll = "";

                            txtReceive.Focus();
                            txtReceive.Select(txtReceive.TextLength, 0);
                            txtReceive.ScrollToCaret();


                        }
                    }
                    /*if (Convert.ToInt32(txtReceiveTemp[0]) == 0x21)
                    {
                        txtReceive.Text += txtReceiveTemp+"\r\n" ; //注意：回车换行必须这样写，单独使用"\r"和"\n"都不会有效果
                        //MessageBox.Show(txtReceive.Text);
                    }
                    if (Convert.ToInt32(txtReceiveTemp[0]) == 0x22)
                    {
                        txtReceiveEnc.Text += txtReceiveTemp.Substring(1, 2)+"\r\n";
                        //MessageBox.Show(txtReceiveEnc.Text);
                    }*/

                    //txtReceive.Text = txtReceiveTemp;

                    //sp1.DiscardInBuffer();                      //清空SerialPort控件的Buffer 
                }
                else                                            //'发送16进制按钮'
                {
                    try
                    {
                        Byte[] receivedData = new Byte[sp1.BytesToRead];        //创建接收字节数组
                        sp1.Read(receivedData, 0, receivedData.Length);         //读取数据
                        //Thread.Sleep(220);
                        //string text = sp1.Read();   //Encoding.ASCII.GetString(receivedData);
                        sp1.DiscardInBuffer();                                  //清空SerialPort控件的Buffer
                        //这是用以显示字符串
                        //    string strRcv = null;
                        //    for (int i = 0; i < receivedData.Length; i++ )
                        //    {
                        //        strRcv += ((char)Convert.ToInt32(receivedData[i])) ;
                        //    }
                        //    txtReceive.Text += strRcv + "\r\n";             //显示信息
                        //}
                        string strRcv = null;
                        //int decNum = 0;//存储十进制
                        for (int i = 0; i < receivedData.Length; i++) //窗体显示
                        {

                            strRcv += receivedData[i].ToString("X2");  //16进制显示
                        }
                        txtSendView.Text += strRcv + "\r\n";//无论发送的是什么，接收之后都显示在txtSendView，用以判断发送是否成功；
                                                            /*if (receivedData[0] == 0x21)
                                                            {
                                                                txtReceive.Text += strRcv + "\r\n";
                                                            }
                                                            if (receivedData[0] == 0x22)
                                                            {
                                                                txtReceiveEnc.Text += strRcv.Substring(2, 2) + "\r\n";
                                                            }*/

                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show(ex.Message, "出错提示");
                        txtSend.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("请打开某个串口", "错误提示");
            }
        }

        //发送按钮
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            String strSend = txtSend.Text;
            //MessageBox.Show(txtSend.Text);
            if (radio1.Checked == true)	//“HEX发送” 按钮 
            {
                //处理数字转换
                string sendBuf = strSend;
                string sendnoNull = sendBuf.Trim();
                string sendNOComma = sendnoNull.Replace(',', ' ');    //去掉英文逗号
                string sendNOComma1 = sendNOComma.Replace('，', ' '); //去掉中文逗号
                string strSendNoComma2 = sendNOComma1.Replace("0x", "");   //去掉0x
                strSendNoComma2.Replace("0X", "");   //去掉0X
                string[] strArray = strSendNoComma2.Split(' ');

                int byteBufferLength = strArray.Length;
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] == "")
                    {
                        byteBufferLength--;
                    }
                }
                // int temp = 0;
                byte[] byteBuffer = new byte[byteBufferLength];
                int ii = 0;
                for (int i = 0; i < strArray.Length; i++)        //对获取的字符做相加运算
                {

                    Byte[] bytesOfStr = Encoding.Default.GetBytes(strArray[i]);

                    int decNum = 0;
                    if (strArray[i] == "")
                    {
                        //ii--;     //加上此句是错误的，下面的continue以延缓了一个ii，不与i同步
                        continue;
                    }
                    else
                    {
                        decNum = Convert.ToInt32(strArray[i], 16); //atrArray[i] == 12时，temp == 18 
                    }

                    try    //防止输错，使其只能输入一个字节的字符
                    {
                        byteBuffer[ii] = Convert.ToByte(decNum);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("字节越界，请逐个字节输入！", "Error");
                        tmSend.Enabled = false;
                        return;
                    }

                    ii++;
                }
                sp1.Write(byteBuffer, 0, byteBuffer.Length);
                //Thread.Sleep(220);
            }
            else		//以字符串形式发送时 
            {
                sp1.WriteLine(txtSend.Text);    //写入数据
            }
        }

        //开关按钮
        private void btnSwitch_Click(object sender, EventArgs e)
        {
            //serialPort1.IsOpen
            if (!sp1.IsOpen)
            {
                try
                {
                    //设置串口号
                    string serialName = cbSerial.SelectedItem.ToString();
                    sp1.PortName = serialName;

                    //设置各“串口设置”
                    string strBaudRate = cbBaudRate.Text;
                    string strDateBits = cbDataBits.Text;
                    string strStopBits = cbStop.Text;
                    Int32 iBaudRate = Convert.ToInt32(strBaudRate);
                    Int32 iDateBits = Convert.ToInt32(strDateBits);

                    sp1.BaudRate = iBaudRate;       //波特率
                    sp1.DataBits = iDateBits;       //数据位
                    switch (cbStop.Text)            //停止位
                    {
                        case "1":
                            sp1.StopBits = StopBits.One;
                            break;
                        case "1.5":
                            sp1.StopBits = StopBits.OnePointFive;
                            break;
                        case "2":
                            sp1.StopBits = StopBits.Two;
                            break;
                        default:
                            MessageBox.Show("Error：参数不正确!", "Error");
                            break;
                    }
                    switch (cbParity.Text)             //校验位
                    {
                        case "无":
                            sp1.Parity = Parity.None;
                            break;
                        case "奇校验":
                            sp1.Parity = Parity.Odd;
                            break;
                        case "偶校验":
                            sp1.Parity = Parity.Even;
                            break;
                        default:
                            MessageBox.Show("Error：参数不正确!", "Error");
                            break;
                    }

                    if (sp1.IsOpen == true)//如果打开状态，则先关闭一下
                    {
                        sp1.Close();
                    }
                    //状态栏设置
                    tsSpNum.Text = "串口号：" + sp1.PortName + "|";
                    tsBaudRate.Text = "波特率：" + sp1.BaudRate + "|";
                    tsDataBits.Text = "数据位：" + sp1.DataBits + "|";
                    tsStopBits.Text = "停止位：" + sp1.StopBits + "|";
                    tsParity.Text = "校验位：" + sp1.Parity + "|";

                    //设置必要控件不可用
                    //cbSerial.Enabled = false;
                    //cbBaudRate.Enabled = false;
                    //cbDataBits.Enabled = false;
                    //cbStop.Enabled = false;
                    //cbParity.Enabled = false;

                    sp1.Open();     //打开串口
                    btnSwitch.Text = "关闭串口";
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("Error:" + ex.Message, "Error");
                    tmSend.Enabled = false;
                    return;
                }
            }
            else
            {
                //状态栏设置
                tsSpNum.Text = "串口号：未指定|";
                tsBaudRate.Text = "波特率：未指定|";
                tsDataBits.Text = "数据位：未指定|";
                tsStopBits.Text = "停止位：未指定|";
                tsParity.Text = "校验位：未指定|";
                //恢复控件功能
                //设置必要控件不可用
                cbSerial.Enabled = true;
                cbBaudRate.Enabled = true;
                cbDataBits.Enabled = true;
                cbStop.Enabled = true;
                cbParity.Enabled = true;

                sp1.Close();                    //关闭串口
                btnSwitch.Text = "打开串口";
                tmSend.Enabled = false;         //关闭计时器
            }
        }

        //清空按钮
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtReceive.Text = "";       //清空文本
            txtSendView.Text = "";
            txtReceiveEnc.Text = "";

        }

        //退出按钮
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //关闭时事件
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            INIFILE.Profile.SaveProfile();
            sp1.Close();
        }

        private void txtSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (radio1.Checked == true)
            {
                //正则匹配
                string patten = "[0-9a-fA-F]|\b|0x|0X| "; //“\b”：退格键
                Regex r = new Regex(patten);
                Match m = r.Match(e.KeyChar.ToString());

                if (m.Success)//&&(txtSend.Text.LastIndexOf(" ") != txtSend.Text.Length-1))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }//end of radio1
            else
            {
                e.Handled = false;
            }
        }

        private void txtSend_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //设置各“串口设置”
            string strBaudRate = cbBaudRate.Text;
            string strDateBits = cbDataBits.Text;
            string strStopBits = cbStop.Text;
            Int32 iBaudRate = Convert.ToInt32(strBaudRate);
            Int32 iDateBits = Convert.ToInt32(strDateBits);

            Profile.G_BAUDRATE = iBaudRate + "";       //波特率
            Profile.G_DATABITS = iDateBits + "";       //数据位
            switch (cbStop.Text)            //停止位
            {
                case "1":
                    Profile.G_STOP = "1";
                    break;
                case "1.5":
                    Profile.G_STOP = "1.5";
                    break;
                case "2":
                    Profile.G_STOP = "2";
                    break;
                default:
                    MessageBox.Show("Error：参数不正确!", "Error");
                    break;
            }
            switch (cbParity.Text)             //校验位
            {
                case "无":
                    Profile.G_PARITY = "NONE";
                    break;
                case "奇校验":
                    Profile.G_PARITY = "ODD";
                    break;
                case "偶校验":
                    Profile.G_PARITY = "EVEN";
                    break;
                default:
                    MessageBox.Show("Error：参数不正确!", "Error");
                    break;
            }

            //保存设置
            // public static string G_BAUDRATE = "1200";//给ini文件赋新值，并且影响界面下拉框的显示
            //public static string G_DATABITS = "8";
            //public static string G_STOP = "1";
            //public static string G_PARITY = "NONE";
            Profile.SaveProfile();
        }

        //定时器
        private void tmSend_Tick(object sender, EventArgs e)
        {
            //转换时间间隔
            string strSecond = txtSecond.Text;
            try
            {
                int isecond = int.Parse(strSecond) * 1000;//Interval以微秒为单位
                tmSend.Interval = isecond;

                if (tmSend.Enabled == true)
                {
                    btnSend.PerformClick();
                }
            }
            catch (System.Exception ex)
            {
                tmSend.Enabled = false;
                MessageBox.Show("错误的定时输入！", "Error");
            }

        }

        private void txtSecond_KeyPress(object sender, KeyPressEventArgs e)
        {
            string patten = "[0-9]|\b"; //“\b”：退格键
            Regex r = new Regex(patten);
            Match m = r.Match(e.KeyChar.ToString());

            if (m.Success)
            {
                e.Handled = false;   //没操作“过”，系统会处理事件    
            }
            else
            {
                e.Handled = true;
            }
        }
        #endregion

        #region 无人机操作
        private void encSend_Click(object sender, EventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            /*switch (txtEnc.Text)
            {
                case "01":
                    txtSend.Text = "01%";
                    break;
                case "02":
                    txtSend.Text = "02%";
                    break;
                case "03":
                    txtSend.Text = "03%";
                    break;
                case "04":
                    txtSend.Text = "04%";
                    break;
                case "05":
                    txtSend.Text = "05%";
                    break;
                case "06":
                    txtSend.Text = "06%";
                    break;
                case "07":
                    txtSend.Text = "07%";
                    break;
                case "08":
                    txtSend.Text = "08%";
                    break;
                case "09":
                    txtSend.Text = "09%";
                    break;
                case "10":
                    txtSend.Text = "10%";
                    break;
                case "11":
                    txtSend.Text = "11%";
                    break;
                case "12":
                    txtSend.Text = "12%";
                    break;
                case "13":
                    txtSend.Text = "13%";
                    break;
                case "14":
                    txtSend.Text = "14%";
                    break;
                case "15":
                    txtSend.Text = "15%";
                    break;
                case "16":
                    txtSend.Text = "16%";
                    break;
                default:
                    MessageBox.Show("请输入正确的位置信息");
                    break;

            }*/
            txtSend.Text = textBox1.Text;
            String strSend = txtSend.Text;
            sp1.WriteLine(txtSend.Text);    //写入数据

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            //skgFlag = true;
            byte[] getSKGByteBuffer = new byte[4];
            getSKGByteBuffer[0] = 0xDA;
            getSKGByteBuffer[1] = 0xDB;
            getSKGByteBuffer[2] = 0x22;
            getSKGByteBuffer[3] = 0xDE;
            sp1.Write(getSKGByteBuffer, 0, getSKGByteBuffer.Length);    //写入数据

            restrTimer.Enabled = true;                                 //启动超时重启计时
            //MessageBox.Show(restrTimer.Enabled.ToString());
        }

        private void stopGenerate_Click(object sender, EventArgs e)
        {
            //skgFlag = false;
            //restrTimer.Enabled = false;
            //MessageBox.Show(restrTimer.Enabled.ToString());
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);    //写入数据
        }

        private void clrRestr_Click(object sender, EventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            //skgFlag = true;
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据


        }

        private void restrTimer_Tick(object sender, EventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            byte[] stopByteBuffer = new byte[2];    //停止之后重启
            stopByteBuffer[0] = 0x26;
            stopByteBuffer[1] = 0x26;
            byte[] restrByteBuffer = new byte[2];
            restrByteBuffer[0] = 0x27;
            restrByteBuffer[1] = 0x27;
            sp1.Write(restrByteBuffer, 0, restrByteBuffer.Length);    //写入停止
            Thread.Sleep(220);
            sp1.Write(restrByteBuffer, 0, restrByteBuffer.Length);    //写入重启
            restrTimer.Enabled = false;



        }

        private void getVersion_Click(object sender, EventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            /*byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);*/
            byte[] getVersionByteBuffer = new byte[7];    //获取版本的指令
            getVersionByteBuffer[0] = 0xDA;
            getVersionByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                getVersionByteBuffer[2] = 0x25;
                //getVersionByteBuffer[5] = 0x29;

            }
            else
            {
                getVersionByteBuffer[2] = 0x29;
                //getVersionByteBuffer[5] = 0x29;
            }
            getVersionByteBuffer[3] = 0xFA;
            getVersionByteBuffer[4] = 0xFB;
            getVersionByteBuffer[5] = 0x00;
            getVersionByteBuffer[6] = 0xDE;
            sp1.Write(getVersionByteBuffer, 0, getVersionByteBuffer.Length);    //写入获取版本
             /*Thread.Sleep(220);
            //generateSKG.PerformClick();                                //继续生成密钥
           byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据
            Thread.Sleep(600);*/
        }

        private void activate_Click(object sender, EventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            /*byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);*/
            byte[] activateByteBuffer = new byte[7];    //激活指令
            activateByteBuffer[0] = 0xDA;
            activateByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                activateByteBuffer[2] = 0x25;
                //activateByteBuffer[5] = 0x29;

            }
            else
            {
                activateByteBuffer[2] = 0x29;
                //activateByteBuffer[5] = 0x29;
            }
            activateByteBuffer[3] = 0xFA;
            activateByteBuffer[4] = 0xFB;
            activateByteBuffer[5] = 0x01;
            activateByteBuffer[6] = 0xDE;
            sp1.Write(activateByteBuffer, 0, activateByteBuffer.Length);    //写入激活指令 
            /*Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据*/
        }

        private void getControl_Click(object sender, EventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            /*byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);*/
            byte[] getControlByteBuffer = new byte[8];    //获取控制指令
            getControlByteBuffer[0] = 0xDA;
            getControlByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                getControlByteBuffer[2] = 0x25;
                //getControlByteBuffer[2] = 0x29;

            }
            else
            {
                getControlByteBuffer[2] = 0x29;
                //getControlByteBuffer[2] = 0x29;
            }
            getControlByteBuffer[3] = 0xFA;
            getControlByteBuffer[4] = 0xFB;
            getControlByteBuffer[5] = 0x02;
            getControlByteBuffer[6] = 0x01;
            getControlByteBuffer[7] = 0xDE;
            sp1.Write(getControlByteBuffer, 0, getControlByteBuffer.Length);    //写入获取控制指令 
            /*Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据*/
        }

        private void handOver_Click(object sender, EventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            /*byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);*/
            byte[] handOverByteBuffer = new byte[8];    //接管指令
            handOverByteBuffer[0] = 0xDA;
            handOverByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                handOverByteBuffer[2] = 0x25;
                //handOverByteBuffer[6] = 0x29;

            }
            else
            {
                handOverByteBuffer[2] = 0x29;
                //handOverByteBuffer[6] = 0x29;
            }
            handOverByteBuffer[3] = 0xFA;
            handOverByteBuffer[4] = 0xFB;
            handOverByteBuffer[5] = 0x05;
            handOverByteBuffer[6] = 0x02;
            handOverByteBuffer[7] = 0xDE;

            sp1.Write(handOverByteBuffer, 0, handOverByteBuffer.Length);    //写入接管指令 
            /*Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据*/
        }

        private void landing_Click(object sender, EventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            /*byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);*/
            byte[] landingByteBuffer = new byte[8];    //降落指令
            landingByteBuffer[0] = 0xDA;
            landingByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                landingByteBuffer[2] = 0x25;
                //landingByteBuffer[6] = 0x29;

            }
            else
            {
                landingByteBuffer[2] = 0x29;
                //landingByteBuffer[6] = 0x29;
            }
            landingByteBuffer[3] = 0xFA;
            landingByteBuffer[4] = 0xFB;
            landingByteBuffer[5] = 0x05;
            landingByteBuffer[6] = 0x03;
            landingByteBuffer[7] = 0xDE;

            sp1.Write(landingByteBuffer, 0, landingByteBuffer.Length);    //写入降落指令 
           /* Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据*/
        }

        private void freeControl_Click(object sender, EventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] freeControlByteBuffer = new byte[8];    //释放控制指令
            freeControlByteBuffer[0] = 0xDA;
            freeControlByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                freeControlByteBuffer[2] = 0x25;
                //freeControlByteBuffer[6] = 0x29;

            }
            else
            {
                freeControlByteBuffer[5] = 0x29;
                //freeControlByteBuffer[6] = 0x29;
            }
            freeControlByteBuffer[3] = 0xFA;
            freeControlByteBuffer[4] = 0xFB;
            freeControlByteBuffer[5] = 0x02;
            freeControlByteBuffer[6] = 0x00;
            freeControlByteBuffer[7] = 0xDE;
            sp1.Write(freeControlByteBuffer, 0, freeControlByteBuffer.Length);    //写入释放控制指令 
            Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据
        }

        private void selfReturn_Click(object sender, EventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] selfReturnByteBuffer = new byte[8];    //释放控制指令
            selfReturnByteBuffer[0] = 0xDA;
            selfReturnByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                selfReturnByteBuffer[2] = 0x25;
                //selfReturnByteBuffer[6] = 0x29;

            }
            else
            {
                selfReturnByteBuffer[2] = 0x29;
                //selfReturnByteBuffer[6] = 0x29;
            }
            selfReturnByteBuffer[3] = 0xFA;
            selfReturnByteBuffer[4] = 0xFB;
            selfReturnByteBuffer[5] = 0x05;
            selfReturnByteBuffer[6] = 0x01;
            selfReturnByteBuffer[7] = 0xDE;
            sp1.Write(selfReturnByteBuffer, 0, selfReturnByteBuffer.Length);    //写入释放控制指令 
            Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据
        }

        private void moveControl_Click(object sender, EventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            /*if (moveMode.Text == "移动模式")
            {
                moveMode.Text = "Speed";
            }*/
            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[14];    //移动指令
            moveParameterByteBuffer[0] = 0xDA;
            moveParameterByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[2] = 0x25;
                //moveParameterByteBuffer[13] = 0x29;

            }
            else
            {
                moveParameterByteBuffer[2] = 0x29;
                //moveParameterByteBuffer[13] = 0x29;
            }
            moveParameterByteBuffer[3] = 0xFA;
            moveParameterByteBuffer[4] = 0xFB;
            moveParameterByteBuffer[5] = 0x48;
            if (xAxis.Text == "")
            {
                moveParameterByteBuffer[6] = 0x00;
                moveParameterByteBuffer[7] = 0x00;
            }
            else
            {

                /*xAxisTexeTemp = xAxis.Text;
                xAxisTexeTemp = xAxisTexeTemp + "00";
                  Int16 xAxis16 = Convert.ToInt16(xAxisTexeTemp); 
                  moveParameterByteBuffer[3] = (byte)(xAxis16 >> 8);
                  moveParameterByteBuffer[4] = (byte)(xAxis16);*/
                string xAxisTexeTemp;
                double xAxisFlo;
                if (xAxis.Text.Substring(0, 1) == "-")
                {
                    xAxisTexeTemp = xAxis.Text.Replace("-", "");
                    xAxisFlo = double.Parse(xAxisTexeTemp) * 100;
                    moveParameterByteBuffer[6] = (byte)((int)(xAxisFlo) >> 8);
                    moveParameterByteBuffer[7] = (byte)((int)xAxisFlo);
                    moveParameterByteBuffer[6] |= 0x80;
                }
                else
                {
                    xAxisTexeTemp = xAxis.Text;
                    xAxisFlo = double.Parse(xAxisTexeTemp) * 100;
                    moveParameterByteBuffer[6] = (byte)((int)(xAxisFlo) >> 8);
                    moveParameterByteBuffer[7] = (byte)((int)xAxisFlo);
                }


            }
            if (yAxis.Text == "")
            {
                moveParameterByteBuffer[7] = 0x00;
                moveParameterByteBuffer[8] = 0x00;
            }
            else
            {
                /*string yAxisTexeTemp;
                yAxisTexeTemp = yAxis.Text;
                yAxisTexeTemp = yAxisTexeTemp + "00";
                Int16 yAxis16 = Convert.ToInt16(yAxisTexeTemp);
                moveParameterByteBuffer[5] = (byte)(yAxis16 >> 8);
                  moveParameterByteBuffer[6] = (byte)(yAxis16);*/
                string yAxisTexeTemp;
                double yAxisFlo;
                if (yAxis.Text.Substring(0, 1) == "-")
                {
                    yAxisTexeTemp = yAxis.Text.Replace("-", "");
                    yAxisFlo = double.Parse(yAxisTexeTemp) * 100;
                    moveParameterByteBuffer[7] = (byte)((int)(yAxisFlo) >> 8);
                    moveParameterByteBuffer[8] = (byte)((int)yAxisFlo);
                    moveParameterByteBuffer[7] |= 0x80;
                }
                else
                {
                    yAxisTexeTemp = yAxis.Text;
                    yAxisFlo = double.Parse(yAxisTexeTemp) * 100;
                    moveParameterByteBuffer[7] = (byte)((int)(yAxisFlo) >> 8);
                    moveParameterByteBuffer[8] = (byte)((int)yAxisFlo);
                }

            }

            if (zAxis.Text == "")
            {
                moveParameterByteBuffer[9] = 0x00;
                moveParameterByteBuffer[10] = 0x00;
            }
            else
            {
                /*string zAxisTexeTemp;
                zAxisTexeTemp = zAxis.Text;
                zAxisTexeTemp = zAxisTexeTemp + "00";
                Int16 zAxis16 = Convert.ToInt16(zAxisTexeTemp);
                moveParameterByteBuffer[7] = (byte)(zAxis16 >> 8);
                  moveParameterByteBuffer[8] = (byte)(zAxis16);*/
                string zAxisTexeTemp;
                double zAxisFlo;
                if (zAxis.Text.Substring(0, 1) == "-")
                {
                    zAxisTexeTemp = zAxis.Text.Replace("-", "");
                    zAxisFlo = double.Parse(zAxisTexeTemp) * 100;
                    moveParameterByteBuffer[9] = (byte)((int)(zAxisFlo) >> 8);
                    moveParameterByteBuffer[10] = (byte)((int)zAxisFlo);
                    moveParameterByteBuffer[9] |= 0x80;
                }
                else
                {
                    zAxisTexeTemp = zAxis.Text;
                    zAxisFlo = double.Parse(zAxisTexeTemp) * 100;
                    moveParameterByteBuffer[9] = (byte)((int)(zAxisFlo) >> 8);
                    moveParameterByteBuffer[10] = (byte)((int)zAxisFlo);
                }
            }
            if (yaw.Text == "")
            {
                moveParameterByteBuffer[11] = 0x00;
                moveParameterByteBuffer[12] = 0x00;
            }
            else
            {
                /*string yawTemp;
                yawTemp = yaw.Text;
                yawTemp = yawTemp + "00";
                  Int16 yaw16 = Convert.ToInt16(yawTemp);
                  moveParameterByteBuffer[9] = (byte)(yaw16 >> 8);
                  moveParameterByteBuffer[10] = (byte)(yaw16);*/
                string yawTexeTemp;
                double yawFlo;
                if (yaw.Text.Substring(0, 1) == "-")
                {
                    yawTexeTemp = yaw.Text.Replace("-", "");
                    yawFlo = double.Parse(yawTexeTemp) * 100;
                    moveParameterByteBuffer[11] = (byte)((int)(yawFlo) >> 8);
                    moveParameterByteBuffer[12] = (byte)((int)yawFlo);
                    moveParameterByteBuffer[11] |= 0x80;
                }
                else
                {
                    yawTexeTemp = yaw.Text;
                    yawFlo = double.Parse(yawTexeTemp) * 100;
                    moveParameterByteBuffer[11] = (byte)((int)(yawFlo) >> 8);
                    moveParameterByteBuffer[12] = (byte)((int)yawFlo);
                }


            }
            moveParameterByteBuffer[13] = 0xDE;


            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据
        }

        /* private void moveMode_SelectedIndexChanged(object sender, EventArgs e)
         {
             if (moveMode.Text == "Speed")
             {
                 label14.Text = "m/s";
                 label15.Text = "m/s";
                 label16.Text = "m/s";
                 label17.Text = "deg/s";
             }
             if (moveMode.Text == "Position")
             {
                 label14.Text = "m";
                 label15.Text = "m";
                 label16.Text = "m";
                 label17.Text = "deg";
             }
         }*/

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥*/
            Thread.Sleep(600);
            byte[] selfReturnByteBuffer = new byte[11];    //转圈指令
            selfReturnByteBuffer[0] = 0xDA;
            selfReturnByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                selfReturnByteBuffer[2] = 0x25;
                //selfReturnByteBuffer[9] = 0x29;

            }
            else
            {
                selfReturnByteBuffer[2] = 0x29;
                //selfReturnByteBuffer[9] = 0x29;
            }
            selfReturnByteBuffer[3] = 0xFA;
            selfReturnByteBuffer[4] = 0xFB;
            selfReturnByteBuffer[5] = 0x07;
            selfReturnByteBuffer[6] = 0x00;
            selfReturnByteBuffer[7] = 0x05;
            selfReturnByteBuffer[8] = 0x0F;
            selfReturnByteBuffer[9] = 0x05;
            selfReturnByteBuffer[10] = 0xDE;
            sp1.Write(selfReturnByteBuffer, 0, selfReturnByteBuffer.Length);    //写入转圈指令
            Thread.Sleep(200);
            sp1.Write(selfReturnByteBuffer, 0, selfReturnByteBuffer.Length);    //写入转圈指令
            Thread.Sleep(200);
            sp1.Write(selfReturnByteBuffer, 0, selfReturnByteBuffer.Length);    //写入转圈指令
            Thread.Sleep(200);
            sp1.Write(selfReturnByteBuffer, 0, selfReturnByteBuffer.Length);    //写入转圈指令
            Thread.Sleep(200);
            //generateSKG.PerformClick();                    //继续生成密钥
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据
        }

        private void movStop_Click(object sender, EventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[14];    //悬停指令
            moveParameterByteBuffer[0] = 0xDA;
            moveParameterByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[2] = 0x25;
                // moveParameterByteBuffer[13] = 0x29;

            }
            else
            {
                moveParameterByteBuffer[2] = 0x29;
                //moveParameterByteBuffer[13] = 0x29;
            }
            moveParameterByteBuffer[3] = 0xFA;
            moveParameterByteBuffer[4] = 0xFB;
            moveParameterByteBuffer[5] = 0x00;
            moveParameterByteBuffer[6] = 0x00;
            moveParameterByteBuffer[7] = 0x00;
            moveParameterByteBuffer[8] = 0x00;
            moveParameterByteBuffer[9] = 0x00;
            moveParameterByteBuffer[10] = 0x00;
            moveParameterByteBuffer[11] = 0x00;
            moveParameterByteBuffer[12] = 0x00;
            moveParameterByteBuffer[13] = 0xDE;



            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入悬停指令
            Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] selfReturnByteBuffer = new byte[8];    //转圈指令
            selfReturnByteBuffer[0] = 0xDA;
            selfReturnByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                selfReturnByteBuffer[2] = 0x25;
                //selfReturnByteBuffer[2] = 0x29;

            }
            else
            {
                selfReturnByteBuffer[2] = 0x29;
                //selfReturnByteBuffer[2] = 0x29;
            }
            selfReturnByteBuffer[3] = 0xFA;
            selfReturnByteBuffer[4] = 0xFB;
            selfReturnByteBuffer[5] = 0x07;
            selfReturnByteBuffer[6] = 0x01;
            selfReturnByteBuffer[7] = 0xDE;
            sp1.Write(selfReturnByteBuffer, 0, selfReturnByteBuffer.Length);    //写入转圈指令
            Thread.Sleep(200);
            sp1.Write(selfReturnByteBuffer, 0, selfReturnByteBuffer.Length);    //写入转圈指令
            Thread.Sleep(200);
            sp1.Write(selfReturnByteBuffer, 0, selfReturnByteBuffer.Length);    //写入转圈指令
            Thread.Sleep(200);
            sp1.Write(selfReturnByteBuffer, 0, selfReturnByteBuffer.Length);    //写入转圈指令
            Thread.Sleep(200);
            //generateSKG.PerformClick();                    //继续生成密钥
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据*/
        }

        private void button3_Click(object sender, EventArgs e)
        {
            restrTimer.Enabled = true;
        }
        //遥控器模拟按钮
        private void leftYaw_MouseEnter(object sender, EventArgs e)
        {
            //leftYaw.BackColor = System.Drawing.SystemColors.ActiveCaption;
            leftYaw.Image = Properties.Resources.左旋红;
        }

        private void leftYaw_MouseLeave(object sender, EventArgs e)
        {
            //leftYaw.BackColor = System.Drawing.SystemColors.ActiveBorder;
            leftYaw.Image = Properties.Resources.左旋蓝;
        }

        private void rightYaw_MouseEnter(object sender, EventArgs e)
        {
            //rightYaw.BackColor = System.Drawing.SystemColors.ActiveCaption;
            rightYaw.Image = Properties.Resources.右旋红;
        }

        private void rightYaw_MouseLeave(object sender, EventArgs e)
        {
            //rightYaw.BackColor = System.Drawing.SystemColors.ActiveBorder;
            rightYaw.Image = Properties.Resources.右旋蓝;
        }

        private void upMove_MouseEnter(object sender, EventArgs e)
        {
            //upMove.BackColor = System.Drawing.SystemColors.ActiveCaption;
            upMove.Image = Properties.Resources.上红;
        }

        private void upMove_MouseLeave(object sender, EventArgs e)
        {
            //upMove.BackColor = System.Drawing.SystemColors.ActiveBorder;
            upMove.Image = Properties.Resources.上蓝;
        }

        private void downMove_MouseEnter(object sender, EventArgs e)
        {
            //downMove.BackColor = System.Drawing.SystemColors.ActiveCaption;
            downMove.Image = Properties.Resources.下红;
        }

        private void downMove_MouseLeave(object sender, EventArgs e)
        {
            //downMove.BackColor = System.Drawing.SystemColors.ActiveBorder;
            downMove.Image = Properties.Resources.下蓝;
        }

        private void leftMove_MouseEnter(object sender, EventArgs e)
        {
            //leftMove.BackColor = System.Drawing.SystemColors.ActiveCaption;
            leftMove.Image = Properties.Resources.左红;
        }

        private void leftMove_MouseLeave(object sender, EventArgs e)
        {
            //leftMove.BackColor = System.Drawing.SystemColors.ActiveBorder;
            leftMove.Image = Properties.Resources.左蓝;
        }

        private void forwardMove_MouseEnter(object sender, EventArgs e)
        {
            //forwardMove.BackColor = System.Drawing.SystemColors.ActiveCaption;
            forwardMove.Image = Properties.Resources.前红;

        }

        private void forwardMove_MouseLeave(object sender, EventArgs e)
        {
            //forwardMove.BackColor = System.Drawing.SystemColors.ActiveBorder;
            forwardMove.Image = Properties.Resources.前蓝;
        }

        private void rightMove_MouseEnter(object sender, EventArgs e)
        {
            //rightMove.BackColor = System.Drawing.SystemColors.ActiveCaption;
            rightMove.Image = Properties.Resources.右红;
        }

        private void rightMove_MouseLeave(object sender, EventArgs e)
        {
            //rightMove.BackColor = System.Drawing.SystemColors.ActiveBorder;
            rightMove.Image = Properties.Resources.右蓝;
        }

        private void backMove_MouseEnter(object sender, EventArgs e)
        {
            //backMove.BackColor = System.Drawing.SystemColors.ActiveCaption;
            backMove.Image = Properties.Resources.后红;

        }

        private void backMove_MouseLeave(object sender, EventArgs e)
        {
            //backMove.BackColor = System.Drawing.SystemColors.ActiveBorder;
            backMove.Image = Properties.Resources.后蓝;
        }

        private void leftYaw_MouseDown(object sender, MouseEventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[15];    //移动指令
            moveParameterByteBuffer[0] = 0xDA;
            moveParameterByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[2] = 0x25;
                //moveParameterByteBuffer[13] = 0x29;

            }
            else
            {
                moveParameterByteBuffer[2] = 0x29;
                //moveParameterByteBuffer[13] = 0x29;
            }
            moveParameterByteBuffer[3] = 0xFA;
            moveParameterByteBuffer[4] = 0xFB;
            moveParameterByteBuffer[5] = 0x48;


            moveParameterByteBuffer[6] = 0x00;     //x轴
            moveParameterByteBuffer[7] = 0x00;


            moveParameterByteBuffer[8] = 0x00;    //y轴
            moveParameterByteBuffer[9] = 0x00;

            moveParameterByteBuffer[10] = 0x00;    //z轴
            moveParameterByteBuffer[11] = 0x00;

            moveParameterByteBuffer[12] = 0x07;    //旋转角速度
            moveParameterByteBuffer[13] = 0xD0;
            moveParameterByteBuffer[14] = 0xDE;



            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 连发四次
            Thread.Sleep(200);
            //Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            //clrRestr.PerformClick();
        }

        private void leftYaw_MouseUp(object sender, MouseEventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            //stopGenerate.PerformClick();                   //先停止生成密钥
            //Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[14];    //悬停指令
            moveParameterByteBuffer[0] = 0xDA;
            moveParameterByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[2] = 0x25;
                // moveParameterByteBuffer[13] = 0x29;

            }
            else
            {
                moveParameterByteBuffer[2] = 0x29;
                //moveParameterByteBuffer[13] = 0x29;
            }
            moveParameterByteBuffer[3] = 0xFA;
            moveParameterByteBuffer[4] = 0xFB;
            moveParameterByteBuffer[5] = 0x00;
            moveParameterByteBuffer[6] = 0x00;
            moveParameterByteBuffer[7] = 0x00;
            moveParameterByteBuffer[8] = 0x00;
            moveParameterByteBuffer[9] = 0x00;
            moveParameterByteBuffer[10] = 0x00;
            moveParameterByteBuffer[11] = 0x00;
            moveParameterByteBuffer[12] = 0x00;
            moveParameterByteBuffer[13] = 0xDE;



            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入悬停指令
            Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据
        }

        private void leftYaw_Click(object sender, EventArgs e)
        {
            /*if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            stopGenerate.PerformClick();                   //先停止生成密钥
            Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[13];    //移动指令
            moveParameterByteBuffer[0] = 0xFA;
            moveParameterByteBuffer[1] = 0xFB;
            moveParameterByteBuffer[2] = 0x48;              //速度模式


            moveParameterByteBuffer[3] = 0x00;           //X轴
            moveParameterByteBuffer[4] = 0x00;


            moveParameterByteBuffer[5] = 0x00;     //y轴
            moveParameterByteBuffer[6] = 0x00;


            moveParameterByteBuffer[7] = 0x00;    //z轴
            moveParameterByteBuffer[8] = 0x00;


            moveParameterByteBuffer[9] = 0x00;    //旋转角速度
            moveParameterByteBuffer[10] = 0x05;

            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[11] = 0x25;
                moveParameterByteBuffer[12] = 0x25;

            }
            else
            {
                moveParameterByteBuffer[11] = 0x29;
                moveParameterByteBuffer[12] = 0x29;
            }

            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(600);
            movStop.PerformClick();                       //停止移动
            Thread.Sleep(600);
            generateSKG.PerformClick();                    //继续生成密钥*/
        }

        private void rightYaw_MouseDown(object sender, MouseEventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[15];    //移动指令
            moveParameterByteBuffer[0] = 0xDA;
            moveParameterByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[2] = 0x25;
                //moveParameterByteBuffer[13] = 0x29;

            }
            else
            {
                moveParameterByteBuffer[2] = 0x29;
                //moveParameterByteBuffer[13] = 0x29;
            }
            moveParameterByteBuffer[3] = 0xFA;
            moveParameterByteBuffer[4] = 0xFB;
            moveParameterByteBuffer[5] = 0x48;


            moveParameterByteBuffer[6] = 0x00;     //x轴
            moveParameterByteBuffer[7] = 0x00;


            moveParameterByteBuffer[8] = 0x00;    //y轴
            moveParameterByteBuffer[9] = 0x00;

            moveParameterByteBuffer[10] = 0x00;    //z轴
            moveParameterByteBuffer[11] = 0x00;

            moveParameterByteBuffer[12] = 0x87;    //旋转角速度
            moveParameterByteBuffer[13] = 0xD0;
            moveParameterByteBuffer[14] = 0xDE;

            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            //Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            //clrRestr.PerformClick();
        }

        private void rightYaw_MouseUp(object sender, MouseEventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            //stopGenerate.PerformClick();                   //先停止生成密钥
            //Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[14];    //悬停指令
            moveParameterByteBuffer[0] = 0xDA;
            moveParameterByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[2] = 0x25;
                // moveParameterByteBuffer[13] = 0x29;

            }
            else
            {
                moveParameterByteBuffer[2] = 0x29;
                //moveParameterByteBuffer[13] = 0x29;
            }
            moveParameterByteBuffer[3] = 0xFA;
            moveParameterByteBuffer[4] = 0xFB;
            moveParameterByteBuffer[5] = 0x00;
            moveParameterByteBuffer[6] = 0x00;
            moveParameterByteBuffer[7] = 0x00;
            moveParameterByteBuffer[8] = 0x00;
            moveParameterByteBuffer[9] = 0x00;
            moveParameterByteBuffer[10] = 0x00;
            moveParameterByteBuffer[11] = 0x00;
            moveParameterByteBuffer[12] = 0x00;
            moveParameterByteBuffer[13] = 0xDE;



            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入悬停指令
            Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据
        }

        private void rightYaw_Click(object sender, EventArgs e)
        {
            /*if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[13];    //移动指令
            moveParameterByteBuffer[0] = 0xFA;
            moveParameterByteBuffer[1] = 0xFB;
            moveParameterByteBuffer[2] = 0x48;              //速度模式


            moveParameterByteBuffer[3] = 0x00;           //X轴
            moveParameterByteBuffer[4] = 0x00;


            moveParameterByteBuffer[5] = 0x00;     //y轴
            moveParameterByteBuffer[6] = 0x00;


            moveParameterByteBuffer[7] = 0x00;    //z轴
            moveParameterByteBuffer[8] = 0x00;


            moveParameterByteBuffer[9] = 0x80;    //旋转角速度
            moveParameterByteBuffer[10] = 0x05;

            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[11] = 0x25;
                moveParameterByteBuffer[12] = 0x25;

            }
            else
            {
                moveParameterByteBuffer[11] = 0x29;
                moveParameterByteBuffer[12] = 0x29;
            }

            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(600);
            movStop.PerformClick();                       //停止移动
            Thread.Sleep(600);
            generateSKG.PerformClick();                    //继续生成密钥*/
        }

        private void upMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[15];    //移动指令
            moveParameterByteBuffer[0] = 0xDA;
            moveParameterByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[2] = 0x25;
                //moveParameterByteBuffer[13] = 0x29;

            }
            else
            {
                moveParameterByteBuffer[2] = 0x29;
                //moveParameterByteBuffer[13] = 0x29;
            }
            moveParameterByteBuffer[3] = 0xFA;
            moveParameterByteBuffer[4] = 0xFB;
            moveParameterByteBuffer[5] = 0x48;


            moveParameterByteBuffer[6] = 0x00;     //x轴
            moveParameterByteBuffer[7] = 0x00;


            moveParameterByteBuffer[8] = 0x00;    //y轴
            moveParameterByteBuffer[9] = 0x00;

            moveParameterByteBuffer[10] = 0x00;    //z轴
            moveParameterByteBuffer[11] = 0x64;

            moveParameterByteBuffer[12] = 0x00;    //旋转角速度
            moveParameterByteBuffer[13] = 0x00;
            moveParameterByteBuffer[14] = 0xDE;

            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            //Thread.Sleep(220);
            //clrRestr.PerformClick();
            //generateSKG.PerformClick();                    //继续生成密钥
        }

        private void upMove_MouseUp(object sender, MouseEventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            //stopGenerate.PerformClick();                   //先停止生成密钥
            //Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[14];    //悬停指令
            moveParameterByteBuffer[0] = 0xDA;
            moveParameterByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[2] = 0x25;
                // moveParameterByteBuffer[13] = 0x29;

            }
            else
            {
                moveParameterByteBuffer[2] = 0x29;
                //moveParameterByteBuffer[13] = 0x29;
            }
            moveParameterByteBuffer[3] = 0xFA;
            moveParameterByteBuffer[4] = 0xFB;
            moveParameterByteBuffer[5] = 0x00;
            moveParameterByteBuffer[6] = 0x00;
            moveParameterByteBuffer[7] = 0x00;
            moveParameterByteBuffer[8] = 0x00;
            moveParameterByteBuffer[9] = 0x00;
            moveParameterByteBuffer[10] = 0x00;
            moveParameterByteBuffer[11] = 0x00;
            moveParameterByteBuffer[12] = 0x00;
            moveParameterByteBuffer[13] = 0xDE;



            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入悬停指令
            Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据
        }

        private void upMove_Click(object sender, EventArgs e)
        {
            /*if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[13];    //移动指令
            moveParameterByteBuffer[0] = 0xFA;
            moveParameterByteBuffer[1] = 0xFB;
            moveParameterByteBuffer[2] = 0x48;              //速度模式


            moveParameterByteBuffer[3] = 0x00;           //X轴
            moveParameterByteBuffer[4] = 0x00;


            moveParameterByteBuffer[5] = 0x00;     //y轴
            moveParameterByteBuffer[6] = 0x00;


            moveParameterByteBuffer[7] = 0x00;    //z轴
            moveParameterByteBuffer[8] = 0x64;


            moveParameterByteBuffer[9] = 0x00;    //旋转角速度
            moveParameterByteBuffer[10] = 0x00;

            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[11] = 0x25;
                moveParameterByteBuffer[12] = 0x25;

            }
            else
            {
                moveParameterByteBuffer[11] = 0x29;
                moveParameterByteBuffer[12] = 0x29;
            }

            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(600);
            movStop.PerformClick();                       //停止移动
            Thread.Sleep(600);
            generateSKG.PerformClick();                    //继续生成密钥*/
        }

        private void downMove_Click(object sender, EventArgs e)
        {
            /*if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[13];    //移动指令
            moveParameterByteBuffer[0] = 0xFA;
            moveParameterByteBuffer[1] = 0xFB;
            moveParameterByteBuffer[2] = 0x48;              //速度模式


            moveParameterByteBuffer[3] = 0x00;           //X轴
            moveParameterByteBuffer[4] = 0x00;


            moveParameterByteBuffer[5] = 0x00;     //y轴
            moveParameterByteBuffer[6] = 0x00;


            moveParameterByteBuffer[7] = 0x80;    //z轴
            moveParameterByteBuffer[8] = 0x64;


            moveParameterByteBuffer[9] = 0x00;    //旋转角速度
            moveParameterByteBuffer[10] = 0x00;

            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[11] = 0x25;
                moveParameterByteBuffer[12] = 0x25;

            }
            else
            {
                moveParameterByteBuffer[11] = 0x29;
                moveParameterByteBuffer[12] = 0x29;
            }

            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(600);
            movStop.PerformClick();                       //停止移动
            Thread.Sleep(600);
            generateSKG.PerformClick();                    //继续生成密钥*/
        }

        private void downMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[15];    //移动指令
            moveParameterByteBuffer[0] = 0xDA;
            moveParameterByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[2] = 0x25;
                //moveParameterByteBuffer[13] = 0x29;

            }
            else
            {
                moveParameterByteBuffer[2] = 0x29;
                //moveParameterByteBuffer[13] = 0x29;
            }
            moveParameterByteBuffer[3] = 0xFA;
            moveParameterByteBuffer[4] = 0xFB;
            moveParameterByteBuffer[5] = 0x48;


            moveParameterByteBuffer[6] = 0x00;     //x轴
            moveParameterByteBuffer[7] = 0x00;


            moveParameterByteBuffer[8] = 0x00;    //y轴
            moveParameterByteBuffer[9] = 0x00;

            moveParameterByteBuffer[10] = 0x80;    //z轴
            moveParameterByteBuffer[11] = 0x64;

            moveParameterByteBuffer[12] = 0x00;    //旋转角速度
            moveParameterByteBuffer[13] = 0x00;
            moveParameterByteBuffer[14] = 0xDE;

            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            //Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            //clrRestr.PerformClick();
        }

        private void downMove_MouseUp(object sender, MouseEventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            //stopGenerate.PerformClick();                   //先停止生成密钥
            //Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[14];    //悬停指令
            moveParameterByteBuffer[0] = 0xDA;
            moveParameterByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[2] = 0x25;
                // moveParameterByteBuffer[13] = 0x29;

            }
            else
            {
                moveParameterByteBuffer[2] = 0x29;
                //moveParameterByteBuffer[13] = 0x29;
            }
            moveParameterByteBuffer[3] = 0xFA;
            moveParameterByteBuffer[4] = 0xFB;
            moveParameterByteBuffer[5] = 0x00;
            moveParameterByteBuffer[6] = 0x00;
            moveParameterByteBuffer[7] = 0x00;
            moveParameterByteBuffer[8] = 0x00;
            moveParameterByteBuffer[9] = 0x00;
            moveParameterByteBuffer[10] = 0x00;
            moveParameterByteBuffer[11] = 0x00;
            moveParameterByteBuffer[12] = 0x00;
            moveParameterByteBuffer[13] = 0xDE;



            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入悬停指令
            Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据
        }

        private void leftMove_Click(object sender, EventArgs e)
        {
            /*if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[13];    //移动指令
            moveParameterByteBuffer[0] = 0xFA;
            moveParameterByteBuffer[1] = 0xFB;
            moveParameterByteBuffer[2] = 0x48;              //速度模式


            moveParameterByteBuffer[3] = 0x80;           //X轴
            moveParameterByteBuffer[4] = 0x64;


            moveParameterByteBuffer[5] = 0x00;     //y轴
            moveParameterByteBuffer[6] = 0x00;


            moveParameterByteBuffer[7] = 0x00;    //z轴
            moveParameterByteBuffer[8] = 0x00;


            moveParameterByteBuffer[9] = 0x00;    //旋转角速度
            moveParameterByteBuffer[10] = 0x00;

            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[11] = 0x25;
                moveParameterByteBuffer[12] = 0x25;

            }
            else
            {
                moveParameterByteBuffer[11] = 0x29;
                moveParameterByteBuffer[12] = 0x29;
            }

            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(600);
            movStop.PerformClick();                       //停止移动
            Thread.Sleep(600);
            generateSKG.PerformClick();                    //继续生成密钥*/
        }

        private void leftMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[15];    //移动指令
            moveParameterByteBuffer[0] = 0xDA;
            moveParameterByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[2] = 0x25;
                //moveParameterByteBuffer[13] = 0x29;

            }
            else
            {
                moveParameterByteBuffer[2] = 0x29;
                //moveParameterByteBuffer[13] = 0x29;
            }
            moveParameterByteBuffer[3] = 0xFA;
            moveParameterByteBuffer[4] = 0xFB;
            moveParameterByteBuffer[5] = 0x48;


            moveParameterByteBuffer[6] = 0x00;     //x轴
            moveParameterByteBuffer[7] = 0x64;


            moveParameterByteBuffer[8] = 0x00;    //y轴
            moveParameterByteBuffer[9] = 0x00;

            moveParameterByteBuffer[10] = 0x00;    //z轴
            moveParameterByteBuffer[11] = 0x00;

            moveParameterByteBuffer[12] = 0x00;    //旋转角速度
            moveParameterByteBuffer[13] = 0x00;
            moveParameterByteBuffer[14] = 0xDE;

            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            //Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            //clrRestr.PerformClick();
        }

        private void leftMove_MouseUp(object sender, MouseEventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            //stopGenerate.PerformClick();                   //先停止生成密钥
            //Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[14];    //悬停指令
            moveParameterByteBuffer[0] = 0xDA;
            moveParameterByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[2] = 0x25;
                // moveParameterByteBuffer[13] = 0x29;

            }
            else
            {
                moveParameterByteBuffer[2] = 0x29;
                //moveParameterByteBuffer[13] = 0x29;
            }
            moveParameterByteBuffer[3] = 0xFA;
            moveParameterByteBuffer[4] = 0xFB;
            moveParameterByteBuffer[5] = 0x00;
            moveParameterByteBuffer[6] = 0x00;
            moveParameterByteBuffer[7] = 0x00;
            moveParameterByteBuffer[8] = 0x00;
            moveParameterByteBuffer[9] = 0x00;
            moveParameterByteBuffer[10] = 0x00;
            moveParameterByteBuffer[11] = 0x00;
            moveParameterByteBuffer[12] = 0x00;
            moveParameterByteBuffer[13] = 0xDE;



            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入悬停指令
            Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据
        }

        private void rightMove_Click(object sender, EventArgs e)
        {
            /*if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[13];    //移动指令
            moveParameterByteBuffer[0] = 0xFA;
            moveParameterByteBuffer[1] = 0xFB;
            moveParameterByteBuffer[2] = 0x48;              //速度模式


            moveParameterByteBuffer[3] = 0x00;           //X轴
            moveParameterByteBuffer[4] = 0x64;


            moveParameterByteBuffer[5] = 0x00;     //y轴
            moveParameterByteBuffer[6] = 0x00;


            moveParameterByteBuffer[7] = 0x00;    //z轴
            moveParameterByteBuffer[8] = 0x00;


            moveParameterByteBuffer[9] = 0x00;    //旋转角速度
            moveParameterByteBuffer[10] = 0x00;

            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[11] = 0x25;
                moveParameterByteBuffer[12] = 0x25;

            }
            else
            {
                moveParameterByteBuffer[11] = 0x29;
                moveParameterByteBuffer[12] = 0x29;
            }

            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(600);
            movStop.PerformClick();                       //停止移动
            Thread.Sleep(600);
            generateSKG.PerformClick();                    //继续生成密钥*/
        }

        private void rightMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[15];    //移动指令
            moveParameterByteBuffer[0] = 0xDA;
            moveParameterByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[2] = 0x25;
                //moveParameterByteBuffer[13] = 0x29;

            }
            else
            {
                moveParameterByteBuffer[2] = 0x29;
                //moveParameterByteBuffer[13] = 0x29;
            }
            moveParameterByteBuffer[3] = 0xFA;
            moveParameterByteBuffer[4] = 0xFB;
            moveParameterByteBuffer[5] = 0x48;


            moveParameterByteBuffer[6] = 0x80;     //x轴
            moveParameterByteBuffer[7] = 0x64;


            moveParameterByteBuffer[8] = 0x00;    //y轴
            moveParameterByteBuffer[9] = 0x00;

            moveParameterByteBuffer[10] = 0x00;    //z轴
            moveParameterByteBuffer[11] = 0x00;

            moveParameterByteBuffer[12] = 0x00;    //旋转角速度
            moveParameterByteBuffer[13] = 0x00;
            moveParameterByteBuffer[14] = 0xDE;

            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            //Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            //clrRestr.PerformClick();
        }

        private void rightMove_MouseUp(object sender, MouseEventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            //stopGenerate.PerformClick();                   //先停止生成密钥
            //Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[14];    //悬停指令
            moveParameterByteBuffer[0] = 0xDA;
            moveParameterByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[2] = 0x25;
                // moveParameterByteBuffer[13] = 0x29;

            }
            else
            {
                moveParameterByteBuffer[2] = 0x29;
                //moveParameterByteBuffer[13] = 0x29;
            }
            moveParameterByteBuffer[3] = 0xFA;
            moveParameterByteBuffer[4] = 0xFB;
            moveParameterByteBuffer[5] = 0x00;
            moveParameterByteBuffer[6] = 0x00;
            moveParameterByteBuffer[7] = 0x00;
            moveParameterByteBuffer[8] = 0x00;
            moveParameterByteBuffer[9] = 0x00;
            moveParameterByteBuffer[10] = 0x00;
            moveParameterByteBuffer[11] = 0x00;
            moveParameterByteBuffer[12] = 0x00;
            moveParameterByteBuffer[13] = 0xDE;



            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入悬停指令
            Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据
        }

        private void forwardMove_Click(object sender, EventArgs e)
        {
            /*if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[13];    //移动指令
            moveParameterByteBuffer[0] = 0xFA;
            moveParameterByteBuffer[1] = 0xFB;
            moveParameterByteBuffer[2] = 0x48;              //速度模式


            moveParameterByteBuffer[3] = 0x00;           //X轴
            moveParameterByteBuffer[4] = 0x00;


            moveParameterByteBuffer[5] = 0x00;     //y轴
            moveParameterByteBuffer[6] = 0x64;


            moveParameterByteBuffer[7] = 0x00;    //z轴
            moveParameterByteBuffer[8] = 0x00;


            moveParameterByteBuffer[9] = 0x00;    //旋转角速度
            moveParameterByteBuffer[10] = 0x00;

            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[11] = 0x25;
                moveParameterByteBuffer[12] = 0x25;

            }
            else
            {
                moveParameterByteBuffer[11] = 0x29;
                moveParameterByteBuffer[12] = 0x29;
            }

            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(600);
            movStop.PerformClick();                       //停止移动
            Thread.Sleep(600);
            generateSKG.PerformClick();                    //继续生成密钥*/
        }

        private void forwardMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[15];    //移动指令
            moveParameterByteBuffer[0] = 0xDA;
            moveParameterByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[2] = 0x25;
                //moveParameterByteBuffer[13] = 0x29;

            }
            else
            {
                moveParameterByteBuffer[2] = 0x29;
                //moveParameterByteBuffer[13] = 0x29;
            }
            moveParameterByteBuffer[3] = 0xFA;
            moveParameterByteBuffer[4] = 0xFB;
            moveParameterByteBuffer[5] = 0x48;


            moveParameterByteBuffer[6] = 0x00;     //x轴
            moveParameterByteBuffer[7] = 0x00;


            moveParameterByteBuffer[8] = 0x00;    //y轴
            moveParameterByteBuffer[9] = 0x64;

            moveParameterByteBuffer[10] = 0x00;    //z轴
            moveParameterByteBuffer[11] = 0x00;

            moveParameterByteBuffer[12] = 0x00;    //旋转角速度
            moveParameterByteBuffer[13] = 0x00;
            moveParameterByteBuffer[14] = 0xDE;

            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            //Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            //clrRestr.PerformClick();
        }

        private void forwardMove_MouseUp(object sender, MouseEventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            //stopGenerate.PerformClick();                   //先停止生成密钥
            //Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[14];    //悬停指令
            moveParameterByteBuffer[0] = 0xDA;
            moveParameterByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[2] = 0x25;
                // moveParameterByteBuffer[13] = 0x29;

            }
            else
            {
                moveParameterByteBuffer[2] = 0x29;
                //moveParameterByteBuffer[13] = 0x29;
            }
            moveParameterByteBuffer[3] = 0xFA;
            moveParameterByteBuffer[4] = 0xFB;
            moveParameterByteBuffer[5] = 0x00;
            moveParameterByteBuffer[6] = 0x00;
            moveParameterByteBuffer[7] = 0x00;
            moveParameterByteBuffer[8] = 0x00;
            moveParameterByteBuffer[9] = 0x00;
            moveParameterByteBuffer[10] = 0x00;
            moveParameterByteBuffer[11] = 0x00;
            moveParameterByteBuffer[12] = 0x00;
            moveParameterByteBuffer[13] = 0xDE;



            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入悬停指令
            Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据
        }

        private void backMove_Click(object sender, EventArgs e)
        {
            /*if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[13];    //移动指令
            moveParameterByteBuffer[0] = 0xFA;
            moveParameterByteBuffer[1] = 0xFB;
            moveParameterByteBuffer[2] = 0x48;              //速度模式


            moveParameterByteBuffer[3] = 0x00;           //X轴
            moveParameterByteBuffer[4] = 0x00;


            moveParameterByteBuffer[5] = 0x80;     //y轴
            moveParameterByteBuffer[6] = 0x64;


            moveParameterByteBuffer[7] = 0x00;    //z轴
            moveParameterByteBuffer[8] = 0x00;


            moveParameterByteBuffer[9] = 0x00;    //旋转角速度
            moveParameterByteBuffer[10] = 0x00;

            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[11] = 0x25;
                moveParameterByteBuffer[12] = 0x25;

            }
            else
            {
                moveParameterByteBuffer[11] = 0x29;
                moveParameterByteBuffer[12] = 0x29;
            }

            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(600);
            movStop.PerformClick();                       //停止移动
            Thread.Sleep(600);
            generateSKG.PerformClick();                    //继续生成密钥*/
        }

        private void backMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            byte[] stopGenerateByteBuffer = new byte[4];
            stopGenerateByteBuffer[0] = 0xDA;
            stopGenerateByteBuffer[1] = 0xDB;
            stopGenerateByteBuffer[2] = 0x26;
            stopGenerateByteBuffer[3] = 0xDE;
            sp1.Write(stopGenerateByteBuffer, 0, stopGenerateByteBuffer.Length);                    //先停止生成密钥
            Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[15];    //移动指令
            moveParameterByteBuffer[0] = 0xDA;
            moveParameterByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[2] = 0x25;
                //moveParameterByteBuffer[13] = 0x29;

            }
            else
            {
                moveParameterByteBuffer[2] = 0x29;
                //moveParameterByteBuffer[13] = 0x29;
            }
            moveParameterByteBuffer[3] = 0xFA;
            moveParameterByteBuffer[4] = 0xFB;
            moveParameterByteBuffer[5] = 0x48;


            moveParameterByteBuffer[6] = 0x00;     //x轴
            moveParameterByteBuffer[7] = 0x00;


            moveParameterByteBuffer[8] = 0x80;    //y轴
            moveParameterByteBuffer[9] = 0x64;

            moveParameterByteBuffer[10] = 0x00;    //z轴
            moveParameterByteBuffer[11] = 0x00;

            moveParameterByteBuffer[12] = 0x00;    //旋转角速度
            moveParameterByteBuffer[13] = 0x00;
            moveParameterByteBuffer[14] = 0xDE;

            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入移动指令 
            Thread.Sleep(200);
            //Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            //clrRestr.PerformClick();
        }

        private void backMove_MouseUp(object sender, MouseEventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            //stopGenerate.PerformClick();                   //先停止生成密钥
            //Thread.Sleep(600);
            byte[] moveParameterByteBuffer = new byte[14];    //悬停指令
            moveParameterByteBuffer[0] = 0xDA;
            moveParameterByteBuffer[1] = 0xDB;
            if (encCtrl.Checked == true)
            {
                moveParameterByteBuffer[2] = 0x25;
                // moveParameterByteBuffer[13] = 0x29;

            }
            else
            {
                moveParameterByteBuffer[2] = 0x29;
                //moveParameterByteBuffer[13] = 0x29;
            }
            moveParameterByteBuffer[3] = 0xFA;
            moveParameterByteBuffer[4] = 0xFB;
            moveParameterByteBuffer[5] = 0x00;
            moveParameterByteBuffer[6] = 0x00;
            moveParameterByteBuffer[7] = 0x00;
            moveParameterByteBuffer[8] = 0x00;
            moveParameterByteBuffer[9] = 0x00;
            moveParameterByteBuffer[10] = 0x00;
            moveParameterByteBuffer[11] = 0x00;
            moveParameterByteBuffer[12] = 0x00;
            moveParameterByteBuffer[13] = 0xDE;



            sp1.Write(moveParameterByteBuffer, 0, moveParameterByteBuffer.Length);    //写入悬停指令
            Thread.Sleep(220);
            //generateSKG.PerformClick();                    //继续生成密钥
            byte[] clrRestrByteBuffer = new byte[4];
            clrRestrByteBuffer[0] = 0xDA;
            clrRestrByteBuffer[1] = 0xDB;
            clrRestrByteBuffer[2] = 0x27;
            //clrRestrByteBuffer[2] = 0x27;
            clrRestrByteBuffer[3] = 0xDE;
            sp1.Write(clrRestrByteBuffer, 0, clrRestrByteBuffer.Length);    //写入数据
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            String strSend = qTextSend.Text;
            //MessageBox.Show(txtSend.Text);
            if (radio1.Checked == true)	//“HEX发送” 按钮 
            {
                //处理数字转换
                string sendBuf = strSend;
                string sendnoNull = sendBuf.Trim();
                string sendNOComma = sendnoNull.Replace(',', ' ');    //去掉英文逗号
                string sendNOComma1 = sendNOComma.Replace('，', ' '); //去掉中文逗号
                string strSendNoComma2 = sendNOComma1.Replace("0x", "");   //去掉0x
                strSendNoComma2.Replace("0X", "");   //去掉0X

                //统一字符串格式
                string strSendNoComma3 = strSendNoComma2.Replace(" ", "");
                int length = strSendNoComma3.Length;
                string[] strArray = new string[length/2];
                for(int i =0 ; i < length/2; i++)
                {
                    strArray[i] = strSendNoComma3.Substring(i * 2, 2);
                }

                int byteBufferLength = strArray.Length;
                for (int i = 0; i < strArray.Length; i++)
                {
                    if (strArray[i] == "")
                    {
                        byteBufferLength--;
                    }
                }
                // int temp = 0;
                byte[] byteBuffer = new byte[byteBufferLength + 4];
                int ii = 0;
                for (int i = 0; i < strArray.Length; i++)        //对获取的字符做相加运算
                {

                    Byte[] bytesOfStr = Encoding.Default.GetBytes(strArray[i]);

                    int decNum = 0;
                    if (strArray[i] == "")
                    {
                        //ii--;     //加上此句是错误的，下面的continue以延缓了一个ii，不与i同步
                        continue;
                    }
                    else
                    {
                        decNum = Convert.ToInt32(strArray[i], 16); //atrArray[i] == 12时，temp == 18 
                    }

                    try    //防止输错，使其只能输入一个字节的字符
                    {
                        byteBuffer[ii + 3] = Convert.ToByte(decNum);
                    }
                    catch (System.Exception ex)
                    {
                        MessageBox.Show("字节越界，请逐个字节输入！", "Error");
                        tmSend.Enabled = false;
                        return;
                    }

                    ii++;
                }
                byteBuffer[0] = 0xDA;
                byteBuffer[1] = 0XDB;
                byteBuffer[2] = 0x23;
                byteBuffer[byteBufferLength + 3] = 0xDE;
                sp1.Write(byteBuffer, 0, byteBuffer.Length);
                //Thread.Sleep(220);
            }
            else		//以字符串形式发送时 
            {
                sp1.WriteLine(qTextSend.Text);    //写入数据
            }
        }
        #endregion
        private void platformTrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (platformTrans.Text)
            {
                case ("无人机"):
                    groupBox5.Visible = true;
                    groupBox9.Visible = false;                    
                    this.KeyPreview = false;
                    break;
                case ("小车"):
                    groupBox5.Visible = false;
                    groupBox9.Visible = true;                    
                    this.KeyPreview = true;
                    break;
                    
                                 
            }
            //btnExit.Focus();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }
            if (carEncCtrl.Checked)
            {
                carCtrl.carCtrlBuff[2] = 0x25;
            }
            else
            {
                carCtrl.carCtrlBuff[2] = 0x29;
            }
            switch (e.KeyCode)
            {

                case Keys.W:
                    if (!carCtrl.isFront)
                    {
                        carCtrlFront.Image = Properties.Resources.前红;
                        carCtrl.isFront = true;
                        carCtrl.carCtrlBuff[6] = 0x00;
                        carCtrl.carCtrlBuff[7] = 0x1f;
                        //carCtrl.carCtrlBuff[9] += 0x02;
                        carCtrl.carCtrlBuff[12] = Convert.ToByte(carCtrl.directionYFront & carCtrl.carCtrlBuff[12]);
                        sp1.Write(carCtrl.carCtrlBuff, 0, carCtrl.carCtrlBuff.Length);    //写入数据
                        //Thread.Sleep(1000);
                    }
                    break;
                case Keys.S:
                    if (!carCtrl.isBack)
                    {
                        carCtrlBack.Image = Properties.Resources.后红;
                        carCtrl.isBack = true;
                        carCtrl.carCtrlBuff[6] = 0x00;
                        carCtrl.carCtrlBuff[7] = 0x1f;
                        //carCtrl.carCtrlBuff[9] += 0x02;
                        carCtrl.carCtrlBuff[12] = Convert.ToByte(carCtrl.directionYBack | carCtrl.carCtrlBuff[12]);
                        sp1.Write(carCtrl.carCtrlBuff, 0, carCtrl.carCtrlBuff.Length);    //写入数据
                        //Thread.Sleep(1000);
                    }
                    break;
                case Keys.A:
                    if (!carCtrl.isLeft)
                    {
                        carCtrlLeft.Image = Properties.Resources.左红;
                        carCtrl.isLeft = true;
                        carCtrl.carCtrlBuff[6] = 0x00;
                        carCtrl.carCtrlBuff[7] = 0x1f;
                        carCtrl.carCtrlBuff[8] = 0x00;
                        carCtrl.carCtrlBuff[9] = 0x8f;
                        //carCtrl.carCtrlBuff[9] += 0x01;
                        carCtrl.carCtrlBuff[12] = Convert.ToByte(carCtrl.directionZLeft & carCtrl.carCtrlBuff[12]);
                        sp1.Write(carCtrl.carCtrlBuff, 0, carCtrl.carCtrlBuff.Length);    //写入数据
                        //Thread.Sleep(1000);
                    }
                    break;
                case Keys.D:
                    if (!carCtrl.isRight)
                    {
                        carCtrlRight.Image = Properties.Resources.右红;
                        carCtrl.isRight = true;
                        carCtrl.carCtrlBuff[6] = 0x00;
                        carCtrl.carCtrlBuff[7] = 0x1f;
                        carCtrl.carCtrlBuff[8] = 0x00;
                        carCtrl.carCtrlBuff[9] = 0x8f;
                        //carCtrl.carCtrlBuff[9] += 0x01;
                        carCtrl.carCtrlBuff[12] = Convert.ToByte(carCtrl.directionZRight | carCtrl.carCtrlBuff[12]);
                        sp1.Write(carCtrl.carCtrlBuff, 0, carCtrl.carCtrlBuff.Length);    //写入数据
                        //Thread.Sleep(1000);
                    }
                    break;
                case Keys.Space:
                    carCtrlStop.Image = Properties.Resources.红停止;
                    carCtrl.carCtrlBuff[6] = 0x00;
                    carCtrl.carCtrlBuff[7] = 0x00;
                    carCtrl.carCtrlBuff[8] = 0x00;
                    carCtrl.carCtrlBuff[9] = 0x00;
                    sp1.Write(carCtrl.carCtrlBuff, 0, carCtrl.carCtrlBuff.Length);    //写入数据
                    //carCtrl.carCtrlBuff[9] += 0x01;
                    //carCtrl.carCtrlBuff[9] = Convert.ToByte(carCtrl.directionZRight | carCtrl.carCtrlBuff[9]);
                    break;
                default:
                    break;

            }




        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    carCtrlFront.Image = Properties.Resources.前蓝;
                    carCtrl.isFront = false;
                    carCtrl.carCtrlBuff[6] = 0x00;
                    carCtrl.carCtrlBuff[7] = 0x00;
                    break;
                case Keys.S:
                    carCtrlBack.Image = Properties.Resources.后蓝;
                    carCtrl.isBack = false;
                    carCtrl.carCtrlBuff[6] = 0x00;
                    carCtrl.carCtrlBuff[7] = 0x00;
                    break;
                case Keys.A:
                    carCtrlLeft.Image = Properties.Resources.左蓝;
                    carCtrl.isLeft = false;
                    carCtrl.carCtrlBuff[8] = 0x00;
                    carCtrl.carCtrlBuff[9] = 0x00;
                    break;
                case Keys.D:
                    carCtrlRight.Image = Properties.Resources.右蓝;
                    carCtrl.isRight = false;
                    carCtrl.carCtrlBuff[8] = 0x00;
                    carCtrl.carCtrlBuff[9] = 0x00;
                    break;
                case Keys.Space:
                    carCtrlStop.Image = Properties.Resources.蓝停止;
                    break;
                default:
                    break;
                      

            }
            if (carEncCtrl.Checked)
            {
                carCtrl.carCtrlBuff[2] = 0x25;
            }
            else
            {
                carCtrl.carCtrlBuff[2] = 0x29;
            }
            if (cbTimeSend.Checked)
            {
                tmSend.Enabled = true;
            }
            else
            {
                tmSend.Enabled = false;
            }

            if (!sp1.IsOpen) //如果没打开
            {
                MessageBox.Show("请先打开串口！", "Error");
                return;
            }

            sp1.Write(carCtrl.carCtrlBuff, 0, carCtrl.carCtrlBuff.Length);    //写入数据

        }

        private void qTextSend_TextChanged(object sender, EventArgs e)
        {

        }


        //遥控器指令
    }
}
