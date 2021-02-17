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
        private int n;
        private int X;
        private int X1;
        private int X2;
        private decimal P;
        private decimal PHP;
        private int N = 0;
        private string opcion = "";
        private string opcionRes = "";
        private string opcionDisitribucion = "";
        private bool entero = true;
        //Respuestas
        private double Respuesta = 0;
        private double Media = 0;
        private double DesviacionEstandar = 0;
        private double Varianza = 0;
        private double FC = 0;
        private double Sesgo = 0;
        private double Curtosis = 0;
        private double Mediana = 0;
        private String TipoSesgo = "";


        private double[] resultados;
        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Distribucion Binomial");
            comboBox1.Items.Add("Distribucion Hipergeométrica");
            comboBox1.SelectedIndex=0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TipoSesgo = "";
            FC = 0;
            Sesgo = 0;
            Curtosis = 0;
            Mediana = 0;
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

            if (!X.Equals(""))
            {
                Operacion();
            }
            else if (!X1.Equals("") && !X2.Equals(""))
            {
                Operacion();
            }
            else{
               // MessageBox.Show("No tiene X");
            }


            if (opcionDisitribucion =="Binomial")
            {
                Binomial();   
            }
            else if (opcionDisitribucion == "Hipergeometrica")
            {
                if (n>=(N*0.20))
                {
                    DH();
                }
                else
                {
                    if (entero)
                    {
                        P = P / 100;
                    }
                    MessageBox.Show("Calculo con Distribucion Binomial");
                    Binomial();
                }

                
            }
            
            MostrarDatos();
        }

        public void Binomial()
        {
            if (n <= (0.05 * N))
            {
                Operacion1();
            }
            else if (N == 0)
            {
                Operacion1();
            }
            else
            {
                //MessageBox.Show("ES POBLACION FINITA");
                Operacion2();
            }
            // Operacion1();
            //AQUIE ME QUEDE
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
            if (Respuesta!=0)
            {
                listRespuestas.Items.Add("Probabilidad :            " + Respuesta);
            }
            else
            {
             //   listRespuestas.Items.Add("Probabilidad : ---- ");
            }
                
                listRespuestas.Items.Add("Media :                   " + Media);
            if (Varianza!=0)
            {
                listRespuestas.Items.Add("Varianza :                " + Varianza);
            }
            else
            {
              //  listRespuestas.Items.Add("Varianza : ----");
            }
                

            if (FC!=0)
            {
                listRespuestas.Items.Add("Factor de Correccion :    " + FC);
            }
            else
            {
              //  listRespuestas.Items.Add("Factor de Correccion : ----");
            }
               
                listRespuestas.Items.Add("Desviacion Estandar :     " + DesviacionEstandar);
                listRespuestas.Items.Add("Sesgo :                   " + Sesgo);
                listRespuestas.Items.Add("Curtosis :                " + Curtosis);
            if (Mediana!=0)
            {
                listRespuestas.Items.Add("Mediana :                 " + Mediana);
            }
            else
            {
              //  listRespuestas.Items.Add("Mediana : ----");
            }
            if (TipoSesgo!="")
            {
                listRespuestas.Items.Add("**************Tipo de Sesgo************");
                listRespuestas.Items.Add("**************" + TipoSesgo + "************");
            }
                
            try
            {
                pictureBox.Image = Image.FromFile(TipoSesgo+".PNG");
            }
            catch (Exception ex)
            {
                MessageBox.Show("El archivo seleccionado no es un tipo de imagen valido");
            }

        }

        //Metodo de desviacion, media, varianza en la poblacion Infinita
        public void Operacion1()
        {
            Media = metodos.Media(n,P);
            DesviacionEstandar = metodos.DesviacionEstandar(n,P);
            Varianza = metodos.Varianza(n,P);
            Sesgo = metodos.Sesgo(n,P);
            Curtosis = metodos.Curtosis(n,P);
        }

        //Metodo de deviacion, media, FC para la poblacion Finita
        public void Operacion2() {
            Media = metodos.Media(n,P);
            FC = metodos.FactorCorreccion(N,n);
            DesviacionEstandar = metodos.DesviacionPFinita(N,n,P);
            Sesgo = metodos.Sesgo(n, P);
            Curtosis = metodos.Curtosis(n, P);

        }

        public void DH()
        {
            if (entero)
            {
                Media = metodos.MediaHipergeometrica(n, (int)P, N);
                Sesgo = metodos.Sesgo(n, P/100);
                Curtosis = metodos.Curtosis(n, P/100);


            }
            else
            {
                Media = metodos.Media(n, PHP);
                Sesgo = metodos.Sesgo(n, P);
                Curtosis = metodos.Curtosis(n, P/100);
            }  
            DesviacionEstandar = metodos.DEHsinP(n,(int)P,N);
        }

        //Operacion para la Distribucion Binomial
        public void Operacion()
        {
            Resultados datos = new Resultados();
            int contador = 0;
            double UltimoResultado = 0;
            chart1.Palette = ChartColorPalette.Pastel;
            chart1.Titles.Add("Representacion Grafica");

            if (opcionDisitribucion=="Binomial")
            {
                resultados = metodos.DistribucionBinomial(P, n, X);
            }
            else
            {
                resultados = metodos.DistribucionHipergeometrica(n,(int)P,N,X);
            }
            

            if (X1 != 0 && X2 != 0)
            {
                datos = metodos.Resultado2(resultados, X1, X2, opcionRes);
                UltimoResultado = datos.result;
                Mediana = datos.mediana;
            }
            else
            {
                datos = metodos.resultados(resultados,opcionRes,X);
                UltimoResultado = datos.result;
                Mediana = datos.mediana;
               // UltimoResultado = metodos.resultados(resultados,opcionRes, X);
            }
            Media = metodos.Media(n, P);
            TipoSesgo = metodos.TipoSesgo(Media,Mediana);
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
       
        public void Datos()
        {
            entero = true;
            CultureInfo culture = new CultureInfo("en-US");
            try
            {
                if (opcionDisitribucion == "Binomial")
                {
                    P = Convert.ToDecimal(txtP.Text.Trim(), culture);
                }
                else if(opcionDisitribucion == "Hipergeometrica")
                {
                    char[] P0 = txtP.Text.Trim().ToCharArray();
                    for (int i = 0; i < P0.Length; i++)
                    {
                        if (P0[i] == '.')
                        {
                            entero = false;
                        }
                    }
                    if (entero)
                    {
                        P = Convert.ToInt32(txtP.Text.Trim(), culture);
                    }
                    else
                    {
                        PHP = Convert.ToDecimal(txtP.Text.Trim(), culture);
                    }

                }

                n = Int32.Parse(txtN.Text.Trim());
                if (txtPoblacion.Text.Trim()!="")
                {
                    N = Int32.Parse(txtPoblacion.Text.Trim());
                }
                else
                {
                    N = 0;
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

        private void radioSI_CheckedChanged(object sender, EventArgs e)
        {
            this.radioX.Enabled = true;
            this.radioX1.Enabled = true;
            this.radioX2.Enabled = true;
            this.radioX3.Enabled = true;
            this.radioX4.Enabled = true;
            this.radioX5.Enabled = true;
            this.radioX7.Enabled = true;
            this.txtX7.Enabled = true;
            this.txtX8.Enabled = true;
            this.txtX1.Enabled = true;
            this.txtX2.Enabled = true;
            this.txtX3.Enabled = true;
            this.txtX4.Enabled = true;
            this.txtX5.Enabled = true;
            this.txtX6.Enabled = true;
            this.txtX.Enabled = true;
        }

        private void radioNO_CheckedChanged(object sender, EventArgs e)
        {
            X = 0;
            X1 = 0;
            X2 = 0;
            opcion = "";
            opcionRes = "";
            this.radioX.Enabled = false;
            this.radioX1.Enabled = false;
            this.radioX2.Enabled = false;
            this.radioX3.Enabled = false;
            this.radioX4.Enabled = false;
            this.radioX5.Enabled = false;
            this.radioX7.Enabled = false;
            this.txtX7.Enabled = false;
            this.txtX8.Enabled = false;
            this.txtX1.Enabled = false;
            this.txtX2.Enabled = false;
            this.txtX3.Enabled = false;
            this.txtX4.Enabled = false;
            this.txtX5.Enabled = false;
            this.txtX6.Enabled = false;
            this.txtX.Enabled = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);
            if (item!=null)
            {
                if (item.Equals("Distribucion Binomial"))
                {
                    // MessageBox.Show("1 "+item);
                    label2.Text = "P (probabilidad de exito)";
                    label1.Text = "n (numero de eventos)";
                    this.Controls.Add(label2);
                    this.Controls.Add(label1);
                    opcionDisitribucion = "Binomial";
                }
                else
                {
                    // MessageBox.Show("2 " + item);
                    label2.Text = "K (Exitos en Poblacion)";
                    label1.Text = "n (Tamaño Muestra)";
                    this.Controls.Add(label2);
                    this.Controls.Add(label1);
                    opcionDisitribucion = "Hipergeometrica";
                }

            }
            else
            {
                MessageBox.Show("Elija una opcion");
            }
        }
    }
}
