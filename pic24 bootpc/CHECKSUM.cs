using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class CHECKSUM : Form
    {
        public CHECKSUM()
        {
            InitializeComponent();
        }

        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            hexString = hexString.Replace("\r\n", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }
      
        public static ushort checksum( byte[] arr,int len)
        {
            ushort checksum = 0;

            for (int i = 0; i < arr.Length; i++)
                checksum += arr[i];

            return checksum;
        }
        public static UInt32 CRC32_MPEG_2(UInt32 crc32, byte[] data, int length)
        {
            uint i;
            UInt32 crc = 0xffffffff, j = 0;
            crc = crc32;
            while ((length--) != 0)
            {
                crc ^= (UInt32)data[j] << 24;
                j++;
                for (i = 0; i < 8; ++i)
                {
                    if ((crc & 0x80000000) != 0)
                        crc = (crc << 1) ^ 0x04C11DB7;
                    else
                        crc <<= 1;
                }
            }
            return crc;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int len;
            byte[] arr = new byte[5000000];
            ushort res=0;
            UInt32 res32 = 0;
            UInt32 crc32=0xffffffff;
            if (radioButton_CRC32.Checked == true)
            { 
            arr = strToToHexByte(textBox_input.Text);
            len = arr.Length;
            res32 = CRC32_MPEG_2(crc32, arr, len);
       

            textBox_OUTput.Text = res32.ToString("x8");
            }
            else if (radioButton_ADD16.Checked == true)
            {
                arr = strToToHexByte(textBox_input.Text);
                len = textBox_input.TextLength;
                res = checksum(arr,  arr.Length);
                //for (int i = 0; i < arr.Length; i++)
                //     checksum+=arr[i];

                textBox_OUTput.Text = res.ToString("x4");
            }
    
        }
    }
}
