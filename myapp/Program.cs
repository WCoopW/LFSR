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
            var reg7 = new byte[7] { 1, 0, 1, 1, 1, 0,0 };
            var reg11 = new byte[11] { 1, 0, 1, 1, 1, 0, 1,0,0,0,1 };
            //var p = new Register();

            // p.Coding(reg3, reg7, reg11);
            
            // var cipher = p.Ror(reg1, 3, 4);
            // for (int i = 0; i < 5; i++)
            //   Console.WriteLine(cipher[i]);

            Console.ReadLine();
        }
    }
}
