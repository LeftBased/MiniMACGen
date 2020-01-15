using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading; //individual thread!
using System.Diagnostics; //for our stopwatch
using C5; //C5 Random [XorShift] by Niels Kokholm, Peter Sestoft, and Rasmus Lystrøm (https://github.com/sestoft/C5) under MIT License.

namespace MiniMACGen
{
    class MACGen
    {
        public static readonly C5Random getRandom2 = new C5Random();
        public static string aT = string.Empty;
        public static string myOptionsRet = string.Empty;
        public static string numOUI = string.Empty;

        public string Options(int Select, string inputOUI)
        {

            numOUI = inputOUI;

            switch (Select)
            {
                case 0:
                    myOptionsRet = GenerateHex(":", true, string.Empty);
                    break;
                case 1:
                    myOptionsRet = GenerateHex("-", false, numOUI);
                    break;
                case 2:
                    myOptionsRet = GenerateHex(string.Empty, true, string.Empty);
                    break;
                case 3:
                    myOptionsRet = GenerateHex(string.Empty, false, numOUI);
                    break;
                case 4:
                    myOptionsRet = GenerateHex(string.Empty, false, numOUI);
                    break;
                case 5:
                    myOptionsRet = GenerateHex(" ", false, numOUI);
                    break;
                case 6:
                    myOptionsRet = GenerateHex(" ", true, string.Empty);
                    break;
                case 7:
                    myOptionsRet = GenerateHex("-", false, numOUI);
                    break;
                case 8:
                    myOptionsRet = GenerateHex(" ", true, numOUI);
                    break;
            }
            return myOptionsRet;
        }
        public string RandomHexStr()
        {
            C5Random rdm = getRandom2;
            string hexValue = string.Empty;
            int num;
            num = rdm.Next(8, 101);
            hexValue = num.ToString("X2");
            return hexValue;
        }

        public string GenerateHex(string mySymbol, bool my00s, string myOUI)
        {
            string aT = string.Empty;

            if (my00s)
            {
                aT = "00" + mySymbol + RandomHexStr() + mySymbol + RandomHexStr() + mySymbol + RandomHexStr() + mySymbol + RandomHexStr() + mySymbol + RandomHexStr();
            }
            else
            {
                if (myOUI == "")
                {
                    aT = RandomHexStr() + mySymbol + RandomHexStr() + mySymbol + RandomHexStr() + mySymbol + RandomHexStr() + mySymbol + RandomHexStr() + mySymbol + RandomHexStr();
                }
                else
                {
                    string[] mySplitter = myOUI.Split(':');
                    aT = mySplitter[0].ToUpper() + mySymbol + mySplitter[1].ToUpper() + mySymbol + mySplitter[2].ToUpper() + mySymbol + RandomHexStr() + mySymbol + RandomHexStr() + mySymbol + RandomHexStr();
                }
            }
            return aT;
        }

    }
}