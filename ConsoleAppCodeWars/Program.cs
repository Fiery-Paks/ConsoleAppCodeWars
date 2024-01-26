using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCodeWars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SnailOutput snailOutput = new SnailOutput(5);
            int[] z = snailOutput.Select();
            Console.ReadKey();
        }
    }
}
