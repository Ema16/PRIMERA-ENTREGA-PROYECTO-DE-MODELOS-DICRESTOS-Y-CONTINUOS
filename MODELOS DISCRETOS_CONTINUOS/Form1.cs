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
    public partial class Form1 : Form
    {
        Calculo metodos = new Calculo();
        private int N;
        private int X;
        private int X1;
        private int X2;
        private string opcion = "";
        private string opcionRes = "";

        //Respuestas
        private double Respuesta = 0;
        private double Media = 0;
        private double DesviacionEstandar = 0;
        private double Varianza = 0;

        private decimal P;
        private int poblacion = 0;

        private double[] resultados;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resultados = null;
            Respuesta = 0;
            Media = 0;
            DesviacionEstandar = 0;
            Varianza = 0;
            listRespuestas.Items.Clear();
            X1 = 0;
            X1 = 0;
            X = 0;
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            chart1.Titles.Clear();
            chart1.Series.Clear();
            
            ValidarDatos();
            Datos();
            Operacion();
            if (N<=(0.05*poblacion))
            {
                Operacion1();
            }
            else if(poblacion==0)
            {
                Operacion1();
            }
            else{
                MessageBox.Show("ES POBLACION FINITA");
            }
           // Operacion1();
            //AQUIE ME QUEDE
            
               
           
            
            MostrarDatos();
        }

        public void ValidarDatos()
        {
            int cont = 0;
            if (txtN.Text.Trim() == "")
            {
                errorN.SetError(txtN, "Introduce N");
                cont++;
            }

            if (txtP.Text.Trim() == "")
            {
                errorP.SetError(txtP, "Introduce P");
                cont++;
            }
            /*
            if (txtX.Text.Trim() == "")
            {
                errorX.SetError(txtX, "Introduce X");
                cont++;
            }
            */
            if (cont != 0)
            {
                MessageBox.Show("LLene los campos requeridos", "Campos Vacios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                errorN.Clear();
                errorP.Clear();
                errorX.Clear();
                //Prosiga
            }
        }

        public void MostrarDatos() {
            listRespuestas.Items.Add("Probabilidad :"+Respuesta);
            listRespuestas.Items.Add("Media :" + Media);
            listRespuestas.Items.Add("Varianza :" + Varianza);
            listRespuestas.Items.Add("Desviacion Estandar :" + DesviacionEstandar);

        }

        public void Operacion1()
        {
            Media = metodos.Media(N,P);
            DesviacionEstandar = metodos.DesviacionEstandar(N,P);
            Varianza = metodos.Varianza(N,P);
        }

        public void Operacion()
        {
            int contador = 0;
            double UltimoResultado = 0;
            chart1.Palette = ChartColorPalette.Pastel;
            chart1.Titles.Add("Representacion Grafica");

            resultados = metodos.DistribucionBinomial(P, N, X);

            if (X1 != 0 && X2 != 0)
            {
                UltimoResultado = metodos.Resultado2(resultados, X1, X2, opcionRes);
            }
            else
            {
                UltimoResultado = metodos.resultados(resultados,opcionRes, X);
            }
            chart1.Series.Add("x"+"       "+"f(x)");
            Respuesta = UltimoResultado;
            bool res = Double.IsNaN(Respuesta);
            if (res)
            {
                
            }
            else{
                for (int i = 0; i < resultados.Length; i++)
                {
                    //Titulos

                    Series serie = chart1.Series.Add(i + " . " + resultados[i].ToString());

                    //Cantidades
                    // serie.Label = resultados[i].ToString();

                    serie.Points.AddXY(contador, resultados[i]);
                    contador++;

                }

            }
            
            

        }
       
        public void AsignarValores(string opcion)
        {
            switch (opcion)
            {
                case "X":
                    X = Int32.Parse(txtX.Text.Trim());
                    break;

                case "X1":
                    X = Int32.Parse(txtX1.Text.Trim());
                    break;

                case "X2":
                    X = Int32.Parse(txtX2.Text.Trim());
                    break;

                case "X3,4":
                    //Cambiar Aca
                    X1 = Int32.Parse(txtX3.Text.Trim());
                    X2 = Int32.Parse(txtX4.Text.Trim());
                    break;

                case "X5":
                    X = Int32.Parse(txtX5.Text.Trim());
                    break;

                case "X6":
                    X = Int32.Parse(txtX6.Text.Trim());
                    break;
                case "X7,8":
                    //Cambiar Aca
                    X1 = Int32.Parse(txtX7.Text.Trim());
                    X2 = Int32.Parse(txtX8.Text.Trim());
                    break;
            }
        }
        public void Datos()
        {
            try
            {
                CultureInfo culture = new CultureInfo("en-US");
                N = Int32.Parse(txtN.Text.Trim());
                P = Convert.ToDecimal(txtP.Text.Trim(), culture);
                if (txtPoblacion.Text.Trim()!="")
                {
                    poblacion = Int32.Parse(txtPoblacion.Text.Trim());
                }
                else
                {
                    poblacion = 0;
                }
                AsignarValores(opcion);
                //X con un solo dato
                
               
           /*     
                X5 = Int32.Parse(txtX5.Text.Trim());
                X6 = Int32.Parse(txtX6.Text.Trim());

                //X rango de 2
                X3 = Int32.Parse(txtX3.Text.Trim());
                X4 = Int32.Parse(txtX4.Text.Trim());
           */
               
            }
            catch (Exception ex)
            {

            }

        }
        private void textN_Validated(object sender, EventArgs e)
        {
            //int num = 0;
            if (txtN.Text.Trim() == "")
            {
                errorN.SetError(txtN, "Introduce N");
            }
            else
            {
                errorN.Clear();
            }
            /*  if (!int.TryParse(txtN.Text.Trim(), out num))
              {
                  errorN.SetError(txtN, "Solo Numeros");
              }
              */


        }

        private void textP_Validated(object sender, EventArgs e)
        {
            if (txtP.Text.Trim() == "")
            {
                errorP.SetError(txtP, "Introduce P");
            }
            else
            {
                errorP.Clear();
            }
        }

        private void textX_Validated(object sender, EventArgs e)
        {
            if (txtX.Text.Trim() == "")
            {
                errorX.SetError(txtX, "Introduce X");
            }
            else
            {
                errorX.Clear();
            }
        }

        private void txtN_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void txtP_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.NumerosDecimal(e);

        }

        private void txtX_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);

        }


        private void radioX_CheckedChanged(object sender, EventArgs e)
        {
            opcion = "X";
            opcionRes = "igual";
            this.txtX.Enabled = true;
            this.txtX1.Enabled = false;
            this.txtX2.Enabled = false;
            this.txtX3.Enabled = false;
            this.txtX4.Enabled = false;
            this.txtX5.Enabled = false;
            this.txtX6.Enabled = false;
            this.txtX7.Enabled = false;
            this.txtX8.Enabled = false;
        }

        private void radioX1_CheckedChanged(object sender, EventArgs e)
        {
            opcion = "X1";
            opcionRes = "mayor";
            this.txtX1.Enabled = true;
            this.txtX.Enabled = false;
            this.txtX2.Enabled = false;
            this.txtX3.Enabled = false;
            this.txtX4.Enabled = false;
            this.txtX5.Enabled = false;
            this.txtX6.Enabled = false;
            this.txtX7.Enabled = false;
            this.txtX8.Enabled = false;
        }

        private void radioX2_CheckedChanged(object sender, EventArgs e)
        {
            opcion = "X2";
            opcionRes = "menor";
            this.txtX2.Enabled = true;
            this.txtX1.Enabled = false;
            this.txtX.Enabled = false;
            this.txtX3.Enabled = false;
            this.txtX4.Enabled = false;
            this.txtX5.Enabled = false;
            this.txtX6.Enabled = false;
            this.txtX7.Enabled = false;
            this.txtX8.Enabled = false;
        }

        private void radioX3_CheckedChanged(object sender, EventArgs e)
        {
            opcion = "X3,4";
            opcionRes = "entre";
            this.txtX3.Enabled = true;
            this.txtX4.Enabled = true;
            this.txtX1.Enabled = false;
            this.txtX2.Enabled = false;
            this.txtX.Enabled = false;
            this.txtX5.Enabled = false;
            this.txtX6.Enabled = false;
            this.txtX7.Enabled = false;
            this.txtX8.Enabled = false;
        }

        private void radioX4_CheckedChanged(object sender, EventArgs e)
        {
            opcion = "X5";
            opcionRes = "mayorigual";
            this.txtX5.Enabled = true;
            this.txtX1.Enabled = false;
            this.txtX2.Enabled = false;
            this.txtX3.Enabled = false;
            this.txtX4.Enabled = false;
            this.txtX.Enabled = false;
            this.txtX6.Enabled = false;
            this.txtX7.Enabled = false;
            this.txtX8.Enabled = false;
        }

        private void radioX5_CheckedChanged(object sender, EventArgs e)
        {
            opcion = "X6";
            opcionRes = "menorigual";
            this.txtX6.Enabled = true;
            this.txtX1.Enabled = false;
            this.txtX2.Enabled = false;
            this.txtX3.Enabled = false;
            this.txtX4.Enabled = false;
            this.txtX5.Enabled = false;
            this.txtX.Enabled = false;
            this.txtX7.Enabled = false;
            this.txtX8.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            opcion = "X7,8";
            opcionRes = "menorigualsinigual";
            this.txtX7.Enabled = true;
            this.txtX8.Enabled = true;
            this.txtX1.Enabled = false;
            this.txtX2.Enabled = false;
            this.txtX3.Enabled = false;
            this.txtX4.Enabled = false;
            this.txtX5.Enabled = false;
            this.txtX6.Enabled = false;
            this.txtX.Enabled = false;

        }
    }
}
