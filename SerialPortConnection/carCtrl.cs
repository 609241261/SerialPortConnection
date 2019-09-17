using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SerialPortConnection
{
    class carCtrl
    {

        public static bool isFront;
        public static bool isBack;
        public static bool isLeft;
        public static bool isRight;
        public static byte[] carCtrlBuff = new byte[14] { 0xda,0xdb,0x29,0xff,0xfe,0x01,0x00,0x00,0x00,0x00, 0x00, 0x00, 0x00,0xde };
        //FF FE 02 00 1F 00 00 00 00 00                   加密，帧    头，模式，Y     轴，X      轴，预      留，YZ方向   
        //public static byte directionRstY = 0x01;
        //public static byte directionRstZ = 0x02;
        public static byte directionYFront = 0xFD;
        public static byte directionYBack = 0x02;
        public static byte directionZLeft = 0xFE;
        public static byte directionZRight = 0x01;


    }
}
