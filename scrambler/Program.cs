using System;

namespace scrambler
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3) {
                Console.WriteLine("usage: dotnet run [task] [filename] [key]\n task:\n -s to scramble a file\n -u to unscramble");
                return;
            }
            
            String input = System.IO.File.ReadAllText(args[0]);
            Console.WriteLine(input);

        }
    }
}
