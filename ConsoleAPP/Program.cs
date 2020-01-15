using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMACGen
{
    class Program
    {
        public static int iCount; //we need this for the loops
        public static int iCu; //we need this for max loop
        public static string MyBigMAC = string.Empty; //store genned mac temporarily.

        static void Main(string[] args)
        {
            MACGen MyGen = new MACGen();// -- call our new class!
            List<string> GenMACs = new List<string>(); //This is our list.

            int ABC = 100; //we need to count.
            string DFG, HIJ, KLM, NOP, TUV;
            bool QRS = false;

            Console.Title = "MAC Address Generator v0.2";
            Console.WriteLine("Welcome. Please enter how many MAC Addresses you want:");
            TUV = Console.ReadLine();
            if (TUV == ""|| TUV == null)
            {
                Console.WriteLine("[ERROR] Please enter a valid number:");
                TUV = Console.ReadLine();
             
                if (TUV == "" || TUV == null)
                {
                    Console.WriteLine("Since you didn't put a valid number\nWe've set default to 100.");
                    ABC = 100;
                } else
                {
                    ABC = Convert.ToInt32(TUV);
                    Console.WriteLine("You've entered" + ABC);
                }
            }
            Console.WriteLine("Do you want seperators: y/n?");
            NOP = Console.ReadLine();
            if (NOP == "y")
            {
                QRS = true;
            }
            else
            {
                QRS = false;
            }
       
            Console.WriteLine($"Thank you. Generating #: {ABC}");
            iCu = ABC; //set our count.
            if (QRS)
            {
                GenMACs.Clear(); // clear list just incase.
                for (iCount = 0; iCount < iCu; iCount++)
                {
                    GenMACs.Add(MyGen.Options(0, ""));
                }
            }
            else
            {
                GenMACs.Clear(); // clear list just incase.
                for (iCount = 0; iCount < iCu; iCount++)
                {
                    GenMACs.Add(MyGen.Options(2, ""));
                }
            }
            Console.WriteLine("Do you want us to see generated results? y/n");
            DFG = Console.ReadLine();
            if (DFG == "y")
            {
                Print(GenMACs);
            }
            Console.WriteLine("Do you wish to save to a text file? y/n");
            HIJ = Console.ReadLine();
            if (HIJ == "y")
            {
                Console.WriteLine("Please enter a filename:");
                KLM = Console.ReadLine();
                if (KLM == "")
                {
                    Console.WriteLine("[ERROR] Please enter a filename:");
                    KLM = Console.ReadLine();
                }
                System.IO.File.WriteAllLines(KLM + ".txt", GenMACs);
                Console.WriteLine($"Saved to: {KLM}.txt");
            }
            Console.WriteLine("Thank you for using MAC Generator v0.2\nPlease press any key to exit");
            Console.ReadLine();

        }

        static void Print(IList<string> list)
        {
            Console.WriteLine("Count: {0}", list.Count);
            foreach (string value in list)
            {
                Console.WriteLine(value);
            }
        }
    }

}
