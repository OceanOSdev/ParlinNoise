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
        float octaves = 8.0f;
        float persistance = 0.5f;
        PerlinNoise.InterpolationType interpType;
        ChartArea area;
        public Form1()
        {
            InitializeComponent();

            // Initialize the chart
            chartParlin.Series.Clear();
            seriesOne = new System.Windows.Forms.DataVisualization.Charting.Series
            {
                Name = "Series1",
                Color = System.Drawing.Color.Blue,
                IsVisibleInLegend = false,
                IsXValueIndexed = true,
                ChartType = SeriesChartType.Spline,

            };

            this.chartParlin.Series.Add(seriesOne);

            //PerlinNoise.InterpolationType[] pArray = {PerlinNoise.InterpolationType.LinearInterp, PerlinNoise.InterpolationType.CosineInterp, PerlinNoise.InterpolationType.CubicInterp};
            comboInterpType.Items.Clear();
            comboInterpType.Items.AddRange(new string[] { "Linear Interpolation", "Cosine Interpolation", "Cubic Interpolation" });
            //comboInterpType.SelectedValue = comboInterpType.ValueMember[0];
            txtOctaves.Text = "8";
            txtPersistence.Text = "0.5";
            

            for (float i = 0; i < octaves - 1; i+= 0.1f)
            {
                var val = p.PerlinNoiseGeneration(p.noise((int)(i* 10), octaves), persistance, octaves, PerlinNoise.InterpolationType.CosineInterp);
                seriesOne.Points.AddXY(i, val);
            }

            chartParlin.Update();
            area = chartParlin.ChartAreas[seriesOne.ChartArea];
            applyArea();
        }

        private void chartParlin_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                var val = p.PerlinNoiseGeneration(p.noise(i, 0.5f), 0.5f, 8, PerlinNoise.InterpolationType.CosineInterp);;
                seriesOne.Points.AddXY(i, val);
            }
        }

        private void txtPersistence_KeyDown(object sender, KeyEventArgs e)
        {
            if (!char.IsControl((char)e.KeyCode) && !char.IsDigit((char)e.KeyCode) && ((char)e.KeyCode != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if (((char)e.KeyCode == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtOctaves_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                e.Handled = true;


            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                e.Handled = true;

            
        }

        private void txtPersistence_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void btnApplyAndGraph_Click(object sender, EventArgs e)
        {
            seriesOne.Points.Clear();
            float.TryParse(txtOctaves.Text, out octaves);
            float.TryParse(txtPersistence.Text, out persistance);
            for (float i = 0; i < octaves - 1; i+= 0.1f)
            {
                var val = p.PerlinNoiseGeneration(p.noise((int)(i*10), octaves), persistance, octaves, interpType);
                p.SmoothNoiseOneDimensional(i, i * 10);
                seriesOne.Points.AddXY(i, val);
            }

            chartParlin.Update();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboInterpType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (comboInterpType.SelectedText)
            {
                case "Linear Interpolation":
                    interpType = PerlinNoise.InterpolationType.LinearInterp;
                    break;
                case "Cosine Interpolation":
                    interpType = PerlinNoise.InterpolationType.CosineInterp;
                    break;
                case "Cubic Interpolation":
                    interpType = PerlinNoise.InterpolationType.CubicInterp;
                    break;
                default:
                    //MessageBox.Show("Test");
                    
                    break;
            }
            
        }

        private void applyArea()
        {
            area.AxisX.Minimum = 0;
            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 1;
            area.AxisX.ScaleView.Zoom(0, 8);
            area.AxisY.ScaleView.Zoom(0, 1);
            area.CursorX.AutoScroll = true;

            //area.AxisX.Interval = 0.1;
            area.AxisX.MajorTickMark.Enabled = true;
            area.AxisX.MajorTickMark.Interval = 1;
            area.AxisX.MinorTickMark.Enabled = true;
            area.AxisX.MinorTickMark.Interval = 0.1;

            //area.AxisX.

            area.AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.SmallScroll;
            area.AxisX.ScaleView.SmallScrollSize = 8;
        }
    }
}
