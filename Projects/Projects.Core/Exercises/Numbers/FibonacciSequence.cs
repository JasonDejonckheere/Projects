using Projects.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projects.Core.Exercises.Numbers
{
    public class FibonacciSequence : IExercise
    {
        public void Run()
        {
            try
            {
                Console.WriteLine("How many times to execute fibonacci sequence?");
                int amount = int.Parse(Console.ReadLine());
                Console.WriteLine("========================");
                FibonacciCalculation(amount);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Overlow of sum happened. Max displayable value reached. ({ulong.MaxValue})");
            }
            catch (Exception)
            {
                Console.WriteLine("Enter a valid number");
                Run();
            }
        }

        private void FibonacciCalculation(int limit)
        {
            ulong num1 = 0;
            ulong num2 = 1;

            for (int i = 0; i < limit; i++)
            {
                ulong sum = checked(num1 + num2);
                Console.WriteLine(sum);
                num1 = num2;
                num2 = sum;
            }

        }
    }
}
