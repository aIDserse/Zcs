using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZPE
{
    public partial class Form2 : Form
    {
        public int[] AR = new int[256];
        public int[] AG = new int[256];
        public int[] AB = new int[256];
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            chartRed.Series[0].Points.Clear();
            chartRed.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartRed.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chartRed.Series[0].IsVisibleInLegend = false;
            chartGreen.Series[0].Points.Clear();
            chartGreen.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartGreen.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chartGreen.Series[0].IsVisibleInLegend = false;
            chartBlue.Series[0].Points.Clear();
            chartBlue.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
            chartBlue.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;
            chartBlue.Series[0].IsVisibleInLegend = false;
            for (int i = 0; i < AR.Length; i++)
            {
                chartRed.Series[0].Points.AddXY(Convert.ToString(i), AR[i]);
                chartRed.Series[0].Points[i].Color = Color.Red;
            }
            for (int i = 0; i < AG.Length; i++)
            {
                chartGreen.Series[0].Points.AddXY(Convert.ToString(i), AG[i]);
                chartGreen.Series[0].Points[i].Color = Color.Green;
            }
            for (int i = 0; i < AB.Length; i++)
            {
                chartBlue.Series[0].Points.AddXY(Convert.ToString(i), AB[i]);
                chartBlue.Series[0].Points[i].Color = Color.Blue;
            }
        }
    }
}
