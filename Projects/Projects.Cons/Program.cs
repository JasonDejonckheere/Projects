using Projects.Core;
using Projects.Core.Exercises.Numbers;
using Projects.Core.Interfaces;

namespace Projects.Cons
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IExercise exercise = new FindEToTheNthDigit();
            exercise.Run();
        }
    }
}
