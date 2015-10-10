using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Perlin_Noise;
using System.Windows.Forms.DataVisualization.Charting;
namespace Graph
{
    public partial class Form1 : Form
    {
        Series seriesOne;
        PerlinNoise p = new PerlinNoise();
        public Form1()
        {
            InitializeComponent();
            chartParlin.Series.Clear();
            seriesOne = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Series1",
                Color = System.Drawing.Color.Blue,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Line,

            };

            this.chartParlin.Series.Add(seriesOne);
        }

        private void chartParlin_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                var val = p.PerlinNoiseGeneration(p.noise(i, 0.5f), 0.5f, 4, PerlinNoise.InterpolationType.CosineInterp);;
                seriesOne.Points.AddXY(i, val);
            }
        }
    }
}
