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

            var reg3 = new byte[3] { 1, 1, 1 };
            var reg7 = new byte[7] { 1, 0, 1, 1, 1, 0, 0 };
            var NewReg = new byte[7];
            for (int i = 0; i< NewReg.Length; i++)
            {
                
              NewReg[i] = i < reg3.Length ? (byte)(reg3[i] ^ reg7[i]) : reg7[i];
                Console.WriteLine(NewReg[i]);
            }


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
