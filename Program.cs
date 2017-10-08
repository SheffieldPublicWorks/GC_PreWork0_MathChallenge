using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/***********************************************************/
/*             Code by Stephen Scobie                      */
/***********************************************************/

namespace GC_Deliverable0_PreWorkMathChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            long num1 = 0, num2 = 0;

            Console.WriteLine("Welcome! You will be asked to enter two integers.");
            Console.WriteLine("Integers MUST be the same length, e.g., 123 and 231, not 1 and 34. No zeroes.\r\n");

            ReadInts(ref num1, ref num2);                                                                                           //ReadInts() will read in user input, check it's integrity, and perform the digit summation test.

            Console.WriteLine("Press any key to contune...");
            Console.ReadKey();
        }

        private static void ReadInts(ref long a, ref long b)
        {
            Console.WriteLine("Enter the first number (no decimals):");
            a = CheckIntFormats(Console.ReadLine());

            if (a != 0)
            {
                Console.WriteLine("Enter the second number (no decimals):");
                b = CheckIntFormats(Console.ReadLine());

                if (b == 0)
                {
                    Console.WriteLine("The program finished with errors.");
                    return;
                }
            }
            else
            {
                Console.WriteLine("The program finished with errors.");
                return;
            }

            if (CheckIntLen(ref a, ref b))
            {
                DigitTest(ref a, ref b);
            }
            else
            {
                Console.WriteLine("The two numbers provided were NOT the same length!\r\nPress any key to exit.");
            }
        }

        private static long CheckIntFormats(string str1)
        {
            long numUser = 0;

            try
            {
                numUser = Convert.ToInt64(str1);
            }
            catch (FormatException e)
            {

                Console.WriteLine("Oops! Looks like you didn't enter a valid integer. | ERROR: {0}", e.Message);
                return 0;
            }

            return numUser;
        }

        private static bool CheckIntLen(ref long a, ref long b)
        {
            double c = Convert.ToDouble(a) / Convert.ToDouble(b);

            if (c < 10.0 && c > 0.1)
            {
                return true;
            }
            else return false;
        }

        private static void DigitTest(ref long a, ref long b)
        {
            string strA = Convert.ToString(a);
            string strB = Convert.ToString(b);

            int tempPrev = 999;                                                                                                     //initialize previous to be some value a single digit couldn't possibly be
            for (int i = 0; i < strA.Length; i++)
            {
                int tempCurrent = Convert.ToInt32(Char.GetNumericValue(strA[i])) + Convert.ToInt32(Char.GetNumericValue(strB[i]));  //The string array element is returned as char!
                
                if (tempPrev != 999 && tempPrev != tempCurrent)
                {
                    Console.WriteLine("False");
                    return;
                }

                tempPrev = tempCurrent;
            }

            Console.WriteLine("True");
        }
    }
}
