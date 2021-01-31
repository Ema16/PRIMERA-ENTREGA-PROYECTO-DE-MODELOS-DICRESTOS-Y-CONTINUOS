using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MODELOS_DISCRETOS_CONTINUOS
{
    class Calculo
    {
        public double Factorial(int numero)
        {
            if (numero == 0 || numero == 1)
                return 1;
            return (numero) * Factorial(numero - 1);
        }

        public double Combinatoria(int n, int x)
        {
            double resultado = 0;
            int restanx = n - x;

            double X = Factorial(x);
            double N = Factorial(n);
            double restaNX = Factorial(restanx);

            resultado = ((N) / ((X) * (restaNX)));

            return resultado;
        }

        //Aca nos quedamos
        //En el for podemos cambiar n a x
        public double[] DistribucionBinomial(decimal p, int n, int x)
        {

            double[] resultados = new double[n + 1];
            for (int i = 0; i <= n; i++)
            {
                resultados[i] = ((Combinatoria(n, i)) * (Potencia((double)p, i)) * (Potencia((double)(1 - p), (n - i))));
            }
            return resultados;
        }

        //Elevar numero
        public double Potencia(double numero, int potencia)
        {
            double resultado;
            resultado = Math.Pow((double)numero, potencia);
            return resultado;
        }


        public double Resultado2(double[] resultados, int x1, int x2, string opcion)
        {
            double result = 0;
            switch (opcion)
            {
                case "entre":
                    if (x1 > x2)
                    {
                        for (int i = x2; i <= resultados.Length; i++)
                        {
                            if (i <= x1)
                            {
                                result = result + resultados[i];
                            }
                            // result = result + resultados[j];
                        }
                        
                    }
                    else
                    {
                        for (int i = x1; i <= resultados.Length; i++)
                        {
                            if (i <= x2)
                            {
                                result = result + resultados[i];
                            }
                            // result = result + resultados[j];
                        }
                    }
                    break;

                case "menorigualsinigual":
                    if (x1 > x2)
                    {
                        for (int i = x2+1; i <= resultados.Length; i++)
                        {
                            if (i < x1)
                            {
                                result = result + resultados[i];
                            }
                            // result = result + resultados[j];
                        }
                    }
                    else
                    {
                        for (int i = x1+1; i <= resultados.Length; i++)
                        {
                            if (i < x2)
                            {
                                result = result + resultados[i];
                            }
                            // result = result + resultados[j];
                        }
                    }
                    break;
            }

            
            return result;

        }
        public double DesviacionEstandar(int n, decimal p)
        {
            double result = 0;

            result = Math.Sqrt((double)(n*p*(1-p)));
            return result;
        }

        public double Media(int n, decimal p)
        {
            int resul = 0;
            resul = (int)(n * p);
            return resul;

        }

        public double Varianza(int n, decimal p)
        {
            double result = 0;
            result = (double)(n * p * (1 - p));
            return result;
        }
        public double resultados(double[] resultados, string opcionRes,int X )
        {
            double result = 0;
            switch (opcionRes)
            {
                case "igual":
                    for(int i=0; i < resultados.Length; i++)
                    {
                        if (i==X)
                        {
                            return resultados[i];
                        }
                        
                    }
                    break;

                case "mayor":
                        for (int j = X + 1; j < resultados.Length; j++)
                        {
                            result = result + resultados[j];
                        }
                    return result;

                case "menor":
                    for (int j = 0; j < X; j++)
                    {
                        result = result + resultados[j];
                    }
                    return result;

                case "mayorigual":
                    for (int j = X; j < resultados.Length; j++)
                    {
                        result = result + resultados[j];
                    }
                    return result;

                case "menorigual":
                    for (int j = 0; j <= X; j++)
                    {
                        result = result + resultados[j];
                    }
                    return result;

                default:
                    MessageBox.Show("UPS ALGO SALIO MAL");
                    break;


            }

            return resultados[0];
        }
    }
}
