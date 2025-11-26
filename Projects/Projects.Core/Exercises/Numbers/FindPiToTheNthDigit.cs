using Projects.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.Core.Exercises.Numbers
{
    public class FindPiToTheNthDigit : IExercise
    {
        /// <summary>
        /// Find PI to the Nth Digit - Enter a number and have the program generate PI up to that many decimal places. Keep a limit to how far the program will go.
        /// </summary>
        
        public void Run()
        {
            try
            {
                Console.WriteLine("Enter a rounding number:");
                int roundingLimit = int.Parse(Console.ReadLine());
                double pi = Math.PI;
                double roundedNumber = GetRoundedNumber(pi, roundingLimit);
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

            if(roundingLimit >= MAXROUNDINGLIMIT)
            {
                return Math.Round(value, MAXROUNDINGLIMIT);
            }
            return Math.Round(value, roundingLimit);
        }

    }
}
