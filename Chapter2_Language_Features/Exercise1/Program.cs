using System.Diagnostics;

namespace Exercise1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WriteDelegate writeDelegate = null;
            BalloonProgram balloon = new BalloonProgram(writeDelegate);
            balloon.Run();
            //TODO: instantiate a delegate that writes to console and debug

            Console.WriteLine();
            Console.WriteLine("Press enter to close...");
            Console.Read();
        }
    }
}