using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MODELOS_DISCRETOS_CONTINUOS
{
    public partial class Form4 : Form
    {
        private int N;
        private decimal P;
        private int X1;
        private int X2;
        private int Mayor;
        private int Menor;
        public double[] resultados;
        public Form4()
        {
            InitializeComponent();
            dataGridView1.Columns.Add("X", "X");
            dataGridView1.Columns.Add("px", "P(X)");
            dataGridView1.Columns.Add("por", "%");
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            int auxiliar = 0;
            N = 0;
            P = 0;
            X1 = 0;
            X2 = 0;
            ValidarDatos();

            if ((double)P > 0.10)
            {
                auxiliar++;
            }
            if (P * N > 10)
            {
                auxiliar++;
            }
            if (auxiliar!=0)
            {
                MessageBox.Show("Resolver por medio de distribucion Binomial");
            }
            Operacion();


        }
        public void ValidarDatos()
        {
            int cont = 0;
            if (textN.Text.Trim() == "")
            {
                errorN.SetError(textN, "Introduce N");
                cont++;
            }
            if (textX1.Text.Trim() == "")
            {
                errorN.SetError(textX1, "Introduce X");
                cont++;
            }
            if (textP.Text.Trim() == "")
            {
                errorN.SetError(textP, "Introduce P");
                cont++;
            }

            if (cont!=0)
            {
                MessageBox.Show("Ingrese los datos");
            }
            else
            {
                Datos();
                MessageBox.Show(N + " - " + P + " - " + X1 + " - " + X2);
            }

        }

        public void Datos()
        {
            CultureInfo culture = new CultureInfo("en-US");
            try
            {
                P = Convert.ToDecimal(textP.Text.Trim(), culture);
                N = Convert.ToInt32(textN.Text.Trim(), culture);
                if (textX1.Text.Trim()!="")
                {
                    X1 = Convert.ToInt32(textX1.Text.Trim(), culture);
                    Mayor = X1;
                   
                }
                if (textX2.Text.Trim() != "")
                {
                    X2 = Convert.ToInt32(textX2.Text.Trim(), culture);
                    Mayor = X2;
                }

                if (X1 != 0 && X2 != 0)
                {
                    if (X1>X2)
                    {
                        Mayor = X1;
                        Menor = X2;
                    }
                    else
                    {
                        Mayor = X2;
                        Menor = X1;
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        public void Operacion()
        {
            int contador = 0;
            chart1.Palette = ChartColorPalette.Pastel;
            chart1.Titles.Add("Representacion Grafica");
            Calculo calculo = new Calculo();
            resultados = calculo.DistribucionPoisson(N, Mayor, Menor, P);

            for (int i=0; i<resultados.Length;i++)
            {

                dataGridView1.Rows.Add(contador, resultados[i], resultados[i]*100);

                Series serie = chart1.Series.Add(i + " . " + resultados[i].ToString());
                chart1.Series[0].Points.AddXY(contador, resultados[i]);
                contador++;
            }

           
            



            listRespuesta.Items.Add("Media = "+calculo.Media(N,P));
            listRespuesta.Items.Add("Desviacion Estandar = " + calculo.DesviacionEstandar(N, P));
            listRespuesta.Items.Add("Sesgo = " + calculo.Sesgo(N,P));
            listRespuesta.Items.Add("Curtosis = " + calculo.Curtosis(N, P));


        }

    }
}
