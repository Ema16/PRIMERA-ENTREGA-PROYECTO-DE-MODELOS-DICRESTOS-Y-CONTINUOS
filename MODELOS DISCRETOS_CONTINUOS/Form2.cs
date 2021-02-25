using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MODELOS_DISCRETOS_CONTINUOS
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }

/*
        private void button1_Click(object sender, EventArgs e)
        {
            // Arreglos del Grafico
            string[] seriesArray = { "Categoria 1", "Categoria 2", "Categoria 3" };
            int[] pointsArray = { Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(textBox3.Text) };
            // Se modifica la Paleta de Colores a utilizar por el control.
            this.chart1.Palette = ChartColorPalette.SeaGreen;
            // Se agrega un titulo al Grafico.
            this.chart1.Titles.Add("Categorias");
            // Agregar las Series al Grafico.
            for (int i = 0; i < seriesArray.Length; i++)
            {
                // Aqui se agregan las series o Categorias.
                Series series = this.chart1.Series.Add(seriesArray[i]);
                // Aqui se agregan los Valores.
                series.Points.Add(pointsArray[i]);
            }
        }
*/

        public void Mostrar(double[] resultados, string opcion)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            chart1.Titles.Clear();
            chart1.Series.Clear();
            Series serie;

            int contador = 0;
            double PA = 0;
            ChartArea CA = chart1.ChartAreas[0];
            CA.AxisX.ScaleView.Zoomable = true;
            CA.CursorX.AutoScroll = true;
            CA.CursorX.IsUserSelectionEnabled = true;

            CA.AxisY.ScaleView.Zoomable = true;
            CA.CursorY.AutoScroll = true;
            CA.CursorY.IsUserSelectionEnabled = true;

            if (opcion.Equals("normal"))
            {
                chart1.Palette = ChartColorPalette.Pastel;
                chart1.Titles.Add("Representacion Grafica");
                chart1.Series.Add("x" + "       " + "f(x)");

                for (int i = 0; i < resultados.Length; i++)
                {
                    //Titulos
                    serie = chart1.Series.Add(i + " . " + resultados[i].ToString());

                    //Cantidades
                    // serie.Label = resultados[i].ToString();
                    chart1.Series[0].Points.AddXY(contador,resultados[i]);
                   // chart1.Palette = ChartColorPalette.Bright;
                    //chart1.Series[0]["PointWidth"] = "0.8";
                    // serie.Points.AddXY(contador, resultados[i]);
                    contador++;


                }

            }
            else if (opcion.Equals("%"))
            {
                chart1.Palette = ChartColorPalette.Pastel;
                chart1.Titles.Add("Representacion Grafica");
                chart1.Series.Add("x" + "       " + "%");

                for (int i = 0; i < resultados.Length; i++)
                {
                    //Titulos
                    serie = chart1.Series.Add(i + " . " + (resultados[i] * 100).ToString());

                    //Cantidades
                    // serie.Label = resultados[i].ToString();

                    chart1.Series[0].Points.AddXY(contador, resultados[i]*100);
                    contador++;


                }
            }
            else if (opcion.Equals("%Acumulado"))
            {
                chart1.Palette = ChartColorPalette.Pastel;
                chart1.Titles.Add("Representacion Grafica");
                chart1.Series.Add("x" + "       " + "% Acumulado");

                for (int i = 0; i < resultados.Length; i++)
                {

                    if (contador == 0)
                    {
                        PA = resultados[i];
                        serie = chart1.Series.Add(i + " . " + (PA * 100).ToString());
                    }
                    else
                    {
                        PA = resultados[i] + PA;
                        serie = chart1.Series.Add(i + " . " + (PA * 100).ToString());
                    }
                    //Cantidades
                    // serie.Label = resultados[i].ToString();

                    chart1.Series[0].Points.AddXY(contador, PA * 100);
                    contador++;


                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JPeg Imagen|*.jpg|Bitmap Imagen|*.bmp|PNG Imagen|*.png";
            saveFileDialog1.Title = "Guardar Grafico en Imagen";
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs =
                (System.IO.FileStream)saveFileDialog1.OpenFile();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        this.chart1.SaveImage(fs, ChartImageFormat.Jpeg);
                        break;
                    case 2:
                        this.chart1.SaveImage(fs, ChartImageFormat.Bmp);
                        break;
                    case 3:
                        this.chart1.SaveImage(fs, ChartImageFormat.Png);
                        break;
                }
                fs.Close();
            }
        }
    }
}
