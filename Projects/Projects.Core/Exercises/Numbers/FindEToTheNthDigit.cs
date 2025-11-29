using Projects.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.Core.Exercises.Numbers
{
    public class FindEToTheNthDigit : IExercise
    {
        /// <summary>
        /// Find e to the Nth Digit - Just like the previous problem,
        /// but with e instead of PI. Enter a number and have the program generate e up to that many decimal places. 
        /// Keep a limit to how far the program will go.
        /// </summary>

        public void Run()
        {
            try
            {
                Console.WriteLine("Enter a decimal number:");
                double number = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter rounding (limit 12)");
                int roundingLimit = int.Parse(Console.ReadLine());

                double roundedNumber = GetRoundedNumber(number, roundingLimit);
                Console.WriteLine(roundedNumber);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Run();
            }
        }

        private double GetRoundedNumber(double value, int roundingLimit)
        {
            const int MAXROUNDINGLIMIT = 12;

            if (roundingLimit >= MAXROUNDINGLIMIT)
            {
                return Math.Round(value, MAXROUNDINGLIMIT);
            }
            return Math.Round(value, roundingLimit);
        }

    }
}
