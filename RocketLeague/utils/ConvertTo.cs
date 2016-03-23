using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RocketLeague.utils
{
    class ConvertTo
    {
        static public int ConvertToInt(string hex)
        {
            int number = Convert.ToInt32(hex, 16);
            byte[] bytes = BitConverter.GetBytes(number);
            string retval = "";
            foreach (byte b in bytes)
                retval += b.ToString("X2");
            int res = Convert.ToInt32(retval, 16);
            return (res);
        }

        static public float ConvertToFloat(string hex)
        {
            float number = Convert.ToInt32(hex, 16);
            byte[] bytes = BitConverter.GetBytes(number);
            string retval = "";
            foreach (byte b in bytes)
                retval += b.ToString("X2");
            float res = Convert.ToInt32(retval, 16);
            return (res);
        }

        static public int GetIntFromStream(FileStream fs)
        {
            int hexIn;
            String hex = "";

            for (int i = 0; i < sizeof(int); i++)
            {
                hexIn = fs.ReadByte();
                hex += string.Format("{0:X2}", hexIn);
            }
            return (ConvertToInt(hex));
        }

        static public float GetFloatFromStream(FileStream fs)
        {
            int hexIn;
            String hex = "";

            for (int i = 0; i < sizeof(float); i++)
            {
                hexIn = fs.ReadByte();
                hex += string.Format("{0:X2}", hexIn);
            }
            return (ConvertToFloat(hex));
        }

        static public byte[][] GetBytesFromStream(FileStream fs, int len)
        {
            int hexIn;
            String hex = "";
            byte[][] bytes = new byte[len][];

            for (int i = 0; i < len; i++)
            {
                hexIn = fs.ReadByte();
                hex += string.Format("{0:X2}", hexIn);
                bytes[i] = BitConverter.GetBytes(hexIn);
            }
            return (bytes);
        }

        static public string GetStringFromStream(FileStream fs, int len)
        {
            int hexIn;
            String hex = "";

            for (int i = 0; i < len-1; i++)
            {
                hexIn = fs.ReadByte();
                hex += (char)hexIn;
            }
            return (hex);
        }

        static public bool GetBoolFromStream(FileStream fs)
        {
            int hexIn;

            hexIn = fs.ReadByte();
            if (hexIn == 0)
                return (false);
            return (true);
        }

        static public void SkipPadding(FileStream fs, int len)
        {
            int hexIn;
            for (int i = 0; i < len; i++)
                hexIn = fs.ReadByte();
        }
    }
}
