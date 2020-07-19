using System;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            var process = new SortLettersProcess();
            var result = process.Perform("Contrary to popular belief, the pink unicorn flies east.");
            
            if (result == "aaabcceeeeeffhiiiiklllnnnnooooppprrrrssttttuuy")
                Console.WriteLine("Yeah!");
            Console.WriteLine(result);

            Console.ReadKey();
        }
    }
}
