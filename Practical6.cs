using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ChartLab
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupChart();
        }

        private void SetupChart()
        {
            chart1.Series.Clear();

            Series s1 = new Series("y1(x)");
            s1.ChartType = SeriesChartType.Spline;
            s1.BorderWidth = 3;
            s1.Color = System.Drawing.Color.Blue;
            chart1.Series.Add(s1);

            Series s2 = new Series("y2(x)");
            s2.ChartType = SeriesChartType.Spline;
            s2.BorderWidth = 3;
            s2.Color = System.Drawing.Color.Orange;
            chart1.Series.Add(s2);
        }

        private void buttonCalc_Click(object sender, EventArgs e)
        {
            double Xmin = double.Parse(textBoxXmin.Text);
            double Xmax = double.Parse(textBoxXmax.Text);
            double Step = double.Parse(textBoxStep.Text);

            int count = (int)Math.Ceiling((Xmax - Xmin) / Step) + 1;

            double[] x = new double[count];
            double[] y1 = new double[count];
            double[] y2 = new double[count];

            double a = -1.25;
            double b = -1.5;
            double c = 0.75;

            for (int i = 0; i < count; i++)
            {
                x[i] = Xmin + Step * i;

                y1[i] = Math.Pow(10, 2) * b * c / x[i] + Math.Cos(Math.Sqrt(Math.Pow(a, 3) * x[i]));

                y2[i] = Math.Pow(x[i], 2);
            }

            chart1.ChartAreas[0].AxisX.Minimum = Xmin;
            chart1.ChartAreas[0].AxisX.Maximum = Xmax;
            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = Step;

            chart1.Series[0].Points.DataBindXY(x, y1);
            chart1.Series[1].Points.DataBindXY(x, y2);
        }
    }
}