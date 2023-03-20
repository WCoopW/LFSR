using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace StreamCipher
{
    
    public class Register
    {
        public int[] mass = new int[100];
        public byte[] Reg3 = new byte[3];
        public byte[] Reg7 = new byte[7];
        public byte[] Reg11 = new byte[11];
        public byte[] bytes = new byte[100];
        Random rnd = new Random();

        public byte[] Ror(byte[] reg, int step1, int step2)
        {

            for (int i = reg.Length - 1; i > 0; i--)
            {
                reg[i] = reg[i - 1];
            }
            reg[0] = (byte)(reg[step1] ^ reg[step2]);
            return reg;
        }
       
        public string Func(byte[] reg3, byte[] reg7, byte[] reg11)
        {
            byte x = (byte)(reg3[1] ^ reg3[2]);
            byte y = (byte)(reg7[6] ^ reg7[5]);
            byte z = (byte)(reg11[10] ^ reg11[8]);
            var CipherByte = x & y | x & z | y & z;
            return CipherByte.ToString();
        }
        public void Coding(byte[] reg3, byte[] reg7, byte[] reg11)
        {
            int j = 0;
            Reg3 = reg3;
            Reg7 = reg7;
            Reg11 = reg11;
            string cipher = "";
            for (int i = 0; i < 200; i++)
              
            {
                var k = Func(Reg3, Reg7, Reg11);
                if ((Reg3[1] ^ Reg3[2]) == Convert.ToByte(k))
                {
                    Reg3 = Ror(Reg3, 2, 1);
                }
                if ((Reg7[6] ^ Reg7[5]) == Convert.ToByte(k))
                {
                    Reg7 = Ror(Reg7, 6, 5);
                }
                if ((Reg11[10] ^ Reg11[8]) ==Convert.ToByte(k))
                {
                    Reg11 = Ror(Reg11, 10, 8);
                }
                if (i < 99)
                {
                    cipher += k;
                }
                if (i > 99)
                {
                    bytes[j] = Convert.ToByte(k);
                    j++;
                }
            }
            Console.WriteLine(cipher);
            var CharCip = cipher.ToCharArray();
            byte[] ByteCip = new byte[CharCip.Length];
            for (int i = 0; i < CharCip.Length; i++)
            {
                ByteCip[i] = (byte)(Char.GetNumericValue(CharCip[i]));
            }
            Console.WriteLine("Complexity: " + BerlekampMassey(ByteCip));
            for (int i = 0; i < bytes.Length; i++)
            {
                Console.WriteLine(bytes[i]);
            }
            Asses(ByteCip);
            NewComplexity(ByteCip);
         

        }
        public void NewComplexity(byte[] Cip)
        {
            
            
            var CipList = new List<byte>();
            for (int i = 0; i < Cip.Length; i++)
            {
                CipList.Add(Cip[i]);
            }
            for ( int i = 0; i < 100; i++)
            {

                CipList.Add((bytes[i]));
                mass[i] = BerlekampMassey(CipList.ToArray());
                Console.WriteLine("New Complexity: " + BerlekampMassey(CipList.ToArray()));
  
            }
           
            Application.EnableVisualStyles();
            Application.Run(new Form1(mass));


        }

        public static void Asses(byte[] Cip)
        {
            int zero = 0;
            int one = 0;
            foreach (char i in Cip)
            {
                if (i == 0)
                    zero++;
                else
                    one++;  
            }
            Console.WriteLine($"1: {one}, 0: {zero}");
            var temp = 0;
            var temp_0 = 0;
            var temp_1 = 0;
            for (int i = 1; i < Cip.Length; i++)
            {
                i--;
                if (Cip[i] == 0) {
                    while (Cip[i] == 0)
                    {
                        temp++;
                        if (i == Cip.Length - 1)
                        {
                            break;
                        };
                        i++;
                    }
                    temp_0 = temp > temp_0 ? temp : temp_0;
                    temp = 0;
                }
                else 
                {
                    while (Cip[i] == 1)
                    {
                        temp++;
                        if(i == Cip.Length - 1)
                        {
                            break;
                        };
                        i++;
                    }
                    temp_1 = temp > temp_1 ? temp : temp_1;
                    temp = 0;
                }
            }
            Console.WriteLine($"Dublicate 1: {temp_1 }, Dublicate 0: {temp_0}");
        }
        public static int BerlekampMassey(byte[] s)
        {
            int L, N, m, d;
            int n = s.Length;
            byte[] c = new byte[n];
            byte[] b = new byte[n];
            byte[] t = new byte[n];

            //Initialization
            b[0] = c[0] = 1;
            N = L = 0;
            m = -1;

            //Algorithm core
            while (N < n)
            {
                d = s[N];
                for (int i = 1; i <= L; i++)
                    d ^= c[i] & s[N - i];            //(d+=c[i]*s[N-i] mod 2)
                if (d == 1)
                {
                    Array.Copy(c, t, n);    //T(D)<-C(D)
                    for (int i = 0; (i + N - m) < n; i++)
                        c[i + N - m] ^= b[i];
                    if (L <= (N >> 1))
                    {
                        L = N + 1 - L;
                        m = N;
                        Array.Copy(t, b, n);    //B(D)<-T(D)
                    }
                }
                N++;
            }
            return L;
        }

    }
}