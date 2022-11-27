using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StreamCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var reg3 = new byte[3] { 1, 0, 1 };
            var reg7 = new byte[7] { 1, 0, 1, 1, 1, 0, 0 };
            var reg11 = new byte[11] { 1, 0, 1, 1, 1, 0, 1, 0, 0, 0, 1 };
            Console.WriteLine("LFSR 1: 101");
            Console.WriteLine("LFSR 2: 1011100");
            Console.WriteLine("LFSR 1: 10111010001");
            var p = new Register();

            p.Coding(reg3, reg7, reg11);


            Console.ReadLine();
        }
    }
}
