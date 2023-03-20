using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StreamCipher
{
    public partial class Form1 : Form
    {
        public int[] array = new int[100];
        public Form1(int[] mass)
        {
            int[] array = new int[100];
            this.array = mass;
            InitializeComponent();
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            double y;
            this.chart1.Series[0].Points.Clear();
            this.chart1.ChartAreas[0].AxisY.Minimum = 50;
            
            for (int i = 0; i < array.Length; i++)
            {
                y = array[i];
                Console.WriteLine(y);
                this.chart1.Series[0].Points.AddXY(i, y);
            }
            
        }
    }
}
