using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class UserFileData
    {
        public int StartAddress = 0;
        public byte[] data = new byte[UserConfig.FLASH_DATA_BUF_SIZE];
        public int SectionDataNum = 0;
        public int CRC = 0;
    }
}
