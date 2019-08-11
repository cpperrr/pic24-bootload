using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            foreach (string com in System.IO.Ports.SerialPort.GetPortNames())
            {
                comboBox_serial.Items.Add(com);
            }
            comboBox_serial.DropDownStyle = ComboBoxStyle.DropDownList;
           // comboBox_serial.SelectedIndex = 1;
            _readThread = new Thread(run);
            _readThread.Start();
            updateStep = 2;

        }
        public static int updateStep = 0;	//更新程序的步骤

        public static int gLoadingSection = 0;
        public static int Cycletimer = 300;
        public static byte[] firmdata = new byte[17];
        public static byte[] txCmdData = new byte[50];
        public static UserFileData downflashdata;
        UserExplainFile testUser = new UserExplainFile();
        UInt32 gCrc32;
        string gRcvCrc32;

        public void OpenCanLoaderFile()
        {
         //   UInt32 crc32 = 0xffffffff;
            totalsize=0;
            String Pathname = null;
            String[] filter = { "*.s19;*.glo;*.hex" };
            //if (openhexFileDialog.ShowDialog() == null)
            //{
            //    return;
            //}
            openFileDialog_HEXFILE.ShowDialog();
            if (openFileDialog_HEXFILE.FileName.EndsWith(".s19")
               || openFileDialog_HEXFILE.FileName.EndsWith(".glo")
               || openFileDialog_HEXFILE.FileName.EndsWith(".hex"))
            {
              
                //Pathname = openhexFileDialog.getFilterPath() + "\\" + openhexFileDialog.getFileName();
                Pathname = openFileDialog_HEXFILE.FileName;

                if (testUser.ReadFile(Pathname) == 0)//文件解析成功
                {
                    textBox_totalframe.Text = (UserExplainFile.Flash_SectionNum).ToString();
                    for(int i=0;i<UserExplainFile.CurSecNum;i++)
                        totalsize += UserExplainFile.flash_Data[i].SectionDataNum ;
                    totalsize += UserExplainFile.flash_Data[UserExplainFile.CurSecNum ].SectionDataNum;
                    textBox_totalsize.Text = totalsize.ToString();
                    gCrc32 = 0xffffffff;
                      for (int i = 0; i < UserExplainFile.CurSecNum; i++)
                          gCrc32 = CHECKSUM.CRC32_MPEG_2(gCrc32, UserExplainFile.GetSectionData(i).data, (ushort)UserExplainFile.flash_Data[i].SectionDataNum);

                      gCrc32 = CHECKSUM.CRC32_MPEG_2(gCrc32,UserExplainFile.GetSectionData(UserExplainFile.CurSecNum).data, (ushort)UserExplainFile.flash_Data[UserExplainFile.CurSecNum].SectionDataNum);
                   //   gCrc32 = crc32;
                      文件CRC32.Text = gCrc32.ToString("X8");
                }
                else
                {
                    MessageBox.Show("文件解析失败");
                    textBox_totalframe.Text = ("0");
                }
            }
            else
            {
                MessageBox.Show("文件类型错误");
            }

        }
	
        private void 烧录文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenCanLoaderFile();
           
        }

        private void 计算校验和ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CHECKSUM checkdialog = new CHECKSUM();
            checkdialog.ShowDialog();

        }

        private void aDD16ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cRC32ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void button_enterboot_Click(object sender, EventArgs e)
        {

            txCmdData[0] = 0xf1;
            //JMK-BMS-BL00
           // 4A 4D 4B 2D 42 4D 53 2D 42 4C 30 30 00 
            txCmdData[1] = 0x4A;
            txCmdData[2] = 0x4D;
            txCmdData[3] = 0x4B;
            txCmdData[4] = 0x2D;
            txCmdData[5] = 0x42;
            txCmdData[6] = 0x4D;
            txCmdData[7] = 0x53;
            txCmdData[8] = 0x2D;
            txCmdData[9] = 0x42;
            txCmdData[10] = 0x4C;
            txCmdData[11] = 0x30;
            txCmdData[12] = 0x30;

            WriteflashCommandAPI(14, txCmdData);
            Cycletimer = 100;
            updateStep = 5;
        }
        Thread _readThread;
        private void button_startdownload_Click(object sender, EventArgs e)
        {
            //timer_download.Enabled = true
            downflashdata = UserExplainFile.GetSectionData(gLoadingSection);
            if (downflashdata == null)
            {
                MessageBox.Show("文件未打开");
                return;
            }
          
            updateStep = 0;
            gLoadingSection = 0;
        }

        private void button_openserial_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                serialPort1.Close();
            }
            else
            {
                try
                {
                    serialPort1.PortName = comboBox_serial.Text;
                    serialPort1.BaudRate = 115200;
                    serialPort1.Open();
                }            
                catch
                {
                    serialPort1.Dispose();
                    MessageBox.Show("打开失败");
                 
                }
            }
         
            button_openserial.Text = serialPort1.IsOpen ? "关闭串口" : "打开串口";
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox_curframe.Text = gLoadingSection.ToString();
            toolStripStatusLabel_serialstatus.Text=serialPort1.IsOpen?"串口状态：打开":"串口状态：关闭";
            接受CRC32.Text = gRcvCrc32;
        }
        public  int SendRS485DataApi(byte[] data, int length)
        {
            // if (length == 0 || data == null || outputStream == null)

            if (length == 0 || data == null)
            {
                return (-1);
            }
            try
            {
                if (serialPort1.IsOpen)
                    serialPort1.Write(data, 0, length);
                // outputStream.flush();
            }
            catch (IOException e)
            {
                // TODO Auto-generated catch block
                // e.printStackTrace();
                return (-1);
            }

            return (0);
        }
        public   int WriteflashCommandAPI(int datalen, byte[] dat)
        {
            byte[] txdata = new byte[50];
            byte[] checkdata = new byte[50];
            int dataCRC = 0;
            int result = 0;

            txdata[0] = 0x3a;
            txdata[1] = 0x16;
            txdata[2] = 0xf0;          
            txdata[3] = (byte)datalen;
            

            for (int i = 0; i < datalen; i++)
            {
                txdata[4 + i] = dat[i];
            }
            for (int i = 0; i < datalen + 8 - 5; i++)
                checkdata[i] = txdata[i + 1];


            dataCRC = CHECKSUM.checksum(checkdata, (ushort)(datalen + 8 - 5));

            txdata[datalen + 8 - 3] = (byte)dataCRC;
            txdata[datalen + 8 - 4] = (byte)(dataCRC>>8);

           // txdata[datalen + 8 - 2] = 0x0d;
           // txdata[datalen + 8 - 1] = 0x0a;


            result = SendRS485DataApi(txdata, 6 + datalen);

            return (result);


        }
        public  int WriteflashDataAPI(byte cmd, int datalen, int CursectionNum , byte[] flashdata)
        {
            byte[] txdata = new byte[200];
            byte[] checkdata = new byte[200];
            int dataCRC = 0;
            int regedistNum = 0;
            int result;
 

            if (datalen <= 0 || datalen > 200)
            {
                return (-1);
            }

            txdata[0] = 0x3a;		
            txdata[1] = 0x16;							
            txdata[2] = 0xf0;
            txdata[3] = (byte)datalen;

            txdata[4] = cmd;
            txdata[5] = (byte)(CursectionNum & 0x00ff);
            txdata[6] = (byte)((CursectionNum >> 8) & 0x00ff);


            for (int i = 0; i < flashdata.Length; i++)
            {
                txdata[7 + i] = flashdata[i];
            }

            for (int i = 0; i < datalen + 8 - 5; i++)
                checkdata[i] = txdata[i + 1];

            dataCRC = CHECKSUM.checksum(checkdata, (ushort)(datalen + 8 - 5));

            txdata[datalen + 8 - 3] = (byte)dataCRC;
            txdata[datalen + 8 - 4] = (byte)(dataCRC >> 8);

          //  txdata[datalen + 8 - 2] = 0x0d;
          //  txdata[datalen + 8 - 1] = 0x0a;

           
            result = SendRS485DataApi(txdata, 6 + datalen);

            return (result);


        }
        static int readlength = 0;
        static int rcvlen = 0;
        static byte cmdF1reply = 0xff;
        static byte cmdF6reply = 0xff;
        static byte cmdF7reply = 0xff;
        static byte cmdF4reply = 0xff;
        static byte cmdF5reply = 0xff;
      
        public   Boolean ReadReceiveRS485Data()
        {
         
            byte[] readbuf = new byte[1024];
            Boolean Result = true;

            byte[] splitdata = new byte[23];
            int splitlength = 0;
            int splitStart = 0;

          

            try
            {
                if (serialPort1.IsOpen == false) return false;
                readlength = serialPort1.BytesToRead;
                if (serialPort1.Read(readbuf, 0, readlength) != 0)//璇诲彇鍙戦€佺殑淇℃伅
                {
                    rcvlen = readbuf[3];
                   
                 //   { return false; }
                    if ((readbuf[0] == 0x3a) && (readbuf[1] == 0x16) || (rcvlen + 8 == readlength))
                    {
                        switch (readbuf[4])
                        {
                            case 0xf1:
                                cmdF1reply = 0x00;
                                break;
                            case 0xf6:
                                cmdF6reply = 0x00;
                                break;
                            case 0xf7:
                                cmdF7reply = 0x00;
                                break;
                            case 0xf4:
                                cmdF4reply = 0x00;
                                break;
                            case 0xf5:
                                cmdF5reply = 0X00;
                            //    gRcvCrc32 = (UInt32)(readbuf[12] + (readbuf[13] << 8) + (readbuf[14] << 16) + (readbuf[15] << 24));
                                gRcvCrc32 = readbuf[15].ToString("X2") + readbuf[14].ToString("X2") + readbuf[13].ToString("X2") + readbuf[12].ToString("X2");
                                break;
                        }
                    }
                      
                    return true;
                }
            }
            catch (IOException e)
            {
                MessageBox.Show("璇诲彇澶辫触");
                return false;
            }

            return false;
        }
        int totalsize = 0;
        int gTimeOut = 0;
        public void run()
        {  //在任务里进行下载

            while (true)
            {
                switch (updateStep)
                {
                    case 0:     //发送F6 固件信息
                    
                        firmdata[0] = 0xf6;
                        firmdata[1] = 0;             //默认值
                        firmdata[2] = 0;            //默认值
                        firmdata[3] = (byte)(totalsize);      //totalsize
                        firmdata[4] = (byte)(totalsize>>8);  //totalsize
                        firmdata[5] = (byte)(totalsize>>16);    //totalsize
                        firmdata[6] = (byte)(UserExplainFile.Flash_SectionNum&0x00ff); //totalframe
                        firmdata[7] = (byte)(UserExplainFile.Flash_SectionNum>>8); //totalframe
                        firmdata[8] = (byte)gCrc32;     //crc32
                        firmdata[9] = (byte)(gCrc32>>8);     //crc32
                        firmdata[10] = (byte)(gCrc32>>16);      //crc32
                        firmdata[11] = (byte)(gCrc32>>24);     //crc32
                        firmdata[12] = 0x00;        //默认值
                        firmdata[13] = 0x00;        //默认值
                        firmdata[14] = 0x00;        //默认值
                        firmdata[15] = 0x00;        //默认值
                        firmdata[16] = 0x00;        //默认值
                        WriteflashCommandAPI(0x11, firmdata);
                        updateStep = 4;
                        Cycletimer = 300;
                        break;
                    case 1:                          
                        downflashdata = UserExplainFile.GetSectionData(gLoadingSection);
                      //  WriteflashDataAPI(0xf7, UserExplainFile.flash_Data[gLoadingSection].SectionDataNum+3, (int)gLoadingSection, downflashdata.data);
                        WriteflashDataAPI(0xf7, 0x80 + 3, (int)gLoadingSection, downflashdata.data);
                        updateStep = 4;
                         Cycletimer = 300;
                        break;
                    case 2:
                 
                        break;
                    case 3:
                         ReadReceiveRS485Data();     //发完进行读取
                         txCmdData[0] = 0xf4;
                         txCmdData[1] = 0x00;
                         WriteflashCommandAPI(2, txCmdData);
                         if (cmdF4reply == 0x00)
                         {                    
                             cmdF4reply = 0xff;
                             updateStep = 2;
                         }
                        break;
                    case 4:
                         ReadReceiveRS485Data();     //发完进行读取
                         if (cmdF6reply == 0x00)
                         { 
                             cmdF6reply = 0xff;
                             updateStep = 1; 
                         }
                       
                         if (cmdF7reply == 0x00)
                         {
                             gTimeOut = 0;
                             cmdF7reply = 0xff;
                             updateStep = 1;
                             gLoadingSection += 1;
                             if (gLoadingSection >= UserExplainFile.Flash_SectionNum)
                             {
                                 updateStep = 2;
                             }
                         }
                         else if (gTimeOut++ > 60)
                         { gTimeOut = 0; updateStep = 1; }
                         Cycletimer = 50;
                        break;
                    case 5:
                         ReadReceiveRS485Data();     //发完进行读取
                         if (cmdF1reply == 0x00)
                         {
                             cmdF1reply = 0xff;
                             MessageBox.Show("enter boot success");
                             updateStep = 2;
                         }
                 
                        break;
                    case 6:
                        ReadReceiveRS485Data();     //发完进行读取
                        if (cmdF5reply == 0x00)
                        {
                            cmdF5reply = 0xff;                          
                            updateStep = 2;
                        }

                        break;
                    case 7: 
                        ReadReceiveRS485Data();     //发完进行读取
                        if (cmdF4reply == 0x00)
                        {
                            cmdF4reply = 0xff;
                            updateStep = 2;
                        }
                           
                        break;
                }
                Thread.Sleep(Cycletimer);
            }
        }
     
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0); 
        }

        private void 跳转到APP_Click(object sender, EventArgs e)
        {
            txCmdData[0] = 0xf5;
            txCmdData[1] = 0x00;
            WriteflashCommandAPI( 2, txCmdData);
            updateStep = 7;
            Cycletimer = 50;
        }

        private void 读取当前固件信息_Click(object sender, EventArgs e)
        {
            txCmdData[0] = 0xf5;
            txCmdData[1] = 0x00;
            WriteflashCommandAPI(2, txCmdData);
            updateStep = 6;
            Cycletimer = 4000;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txCmdData[0] = 0xf2;
            txCmdData[1] = 0x00;
            WriteflashCommandAPI(2, txCmdData);
            updateStep = 2;
            Cycletimer = 100;
        }
    }
}
