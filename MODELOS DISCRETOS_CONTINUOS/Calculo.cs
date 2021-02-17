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
        //Factorial
        public double Factorial(int numero)
        {
            if (numero == 0 || numero == 1)
                return 1;
            return (numero) * Factorial(numero - 1);

        }

        public double Factorial1(int numero)
        {
            int i = 2;
            double fac = 1;
            while (i<=numero)
            {
                fac *= i;
                i++;
            }
            return fac;
        }

        //Combinatoria
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
        //Distribucion Binomial
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

        //Desviacion Estandar
        public double DesviacionEstandar(int n, decimal p)
        {
            double result = 0;

            result = Math.Sqrt((double)(n*p*(1-p)));
            return result;
        }


        //Media
        public double Media(int n, decimal p)
        {
            double resul;
            resul = (double)(n * p);
            return resul;

        }


        //Varianza
        public double Varianza(int n, decimal p)
        {
            double result;
            result = (double)(n * p * (1 - p));
            return result;
        }

        //------MEDIA Y DEVIACION ESTANDAR DE LA DISTRIBUCION
        //------BINOMIAL PARA POBLACION FINITA---------------

        //Factor de Correccion para poblaciones finitas
        public double FactorCorreccion(int N, int n)
        {
            double resultado;
            resultado = Math.Sqrt(((double)(N-n)/(double)(N-1)));
            return resultado;
        }
           
        //Deviacion para la pobalcion Finita
        public double DesviacionPFinita(int N, int n, decimal p)
        {
            double resultado;
            double FC;
            FC = FactorCorreccion(N,n);
            resultado = FC*(Math.Sqrt((double)(n*p*(1-p))));
            return resultado;
        }

        //----------------------------------------------------
        //----------------------------------------------------


        //Sesgo
        public double Sesgo(int n, decimal p)
        {
            double resultado;
            resultado = (((double)((1 - p)))/(Math.Sqrt((double)(n*p*(1-p)))));
            return resultado;
        }
        //Curtosis
        public double Curtosis(int n, decimal p)
        {
            double resultado;
            resultado = (double)3+((double)(1-(6*p*(1-p))) / (Math.Sqrt((double)(n*p*(1-p)))));
            return resultado;
        }


        //Resultados sin rangos
        public Resultados resultados(double[] resultados, string opcionRes,int X )
        {
            List<int> datos = new List<int>();
            Resultados resultados1 = new Resultados();
            double result = 0;
            double mediana = 0;
            switch (opcionRes)
            {
                case "igual":
                    for(int i=0; i < resultados.Length; i++)
                    {
                        if (i==X)
                        {
                            datos.Add(i);
                           // mediana = Mediana(datos);
                            resultados1.result = resultados[i];
                            resultados1.mediana = i;
                            return resultados1;
                        }
                        
                    }
                    break;

                case "mayor":
                        for (int j = X + 1; j < resultados.Length; j++)
                        {
                            result = result + resultados[j];
                        datos.Add(j);
                        }
                    mediana = Mediana(datos);
                    resultados1.result = result;
                    resultados1.mediana = mediana;
                   // return resultados1;
                    //return result;
                    break;

                case "menor":
                    for (int j = 0; j < X; j++)
                    {
                        result = result + resultados[j];
                        datos.Add(j);
                    }
                    mediana = Mediana(datos);
                    resultados1.result = result;
                    resultados1.mediana = mediana;
                 //   return resultados1;
                    //return result;
                    break;
                case "mayorigual":
                    for (int j = X; j < resultados.Length; j++)
                    {
                        result = result + resultados[j];
                        datos.Add(j);
                    }
                    mediana = Mediana(datos);
                    resultados1.result = result;
                    resultados1.mediana = mediana;
                    //return resultados1;
                    //return result;
                    break;
                case "menorigual":
                    for (int j = 0; j <= X; j++)
                    {
                        result = result + resultados[j];
                        datos.Add(j);
                    }
                    mediana = Mediana(datos);
                    resultados1.result = result;
                    resultados1.mediana = mediana;
                    //return resultados1;
                    break;
                // return result;

                default:
                    MessageBox.Show("UPS ALGO SALIO MAL");
                    break;


            }

            return resultados1;
        }

        //Resultado para los rangos
        public Resultados Resultado2(double[] resultados, int x1, int x2, string opcion)
        {
            List<int> datos = new List<int>();
            Resultados resultados1 = new Resultados();
            double result = 0;
            double mediana = 0;
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
                                datos.Add(i);
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
                                datos.Add(i);
                            }
                            // result = result + resultados[j];
                        }
                    }
                    break;

                case "menorigualsinigual":
                    if (x1 > x2)
                    {
                        for (int i = x2 + 1; i <= resultados.Length; i++)
                        {
                            if (i < x1)
                            {
                                result = result + resultados[i];
                                datos.Add(i);
                            }
                            // result = result + resultados[j];
                        }
                    }
                    else
                    {
                        for (int i = x1 + 1; i <= resultados.Length; i++)
                        {
                            if (i < x2)
                            {
                                result = result + resultados[i];
                                datos.Add(i);
                            }
                            // result = result + resultados[j];
                        }
                    }
                    break;
            }

            mediana = Mediana(datos);
            resultados1.result = result;
            resultados1.mediana = mediana;
            return resultados1;
          //  return result;

        }

        
        public double Mediana(List<int> datos)
        {
            double resultado;
            //resultado = datos.Count;
            if ((datos.Count%2)==0)
            {
                resultado = Par(datos);
              //  MessageBox.Show("La mediana es: "+resultado);
            }
            else
            {
                resultado = Impar(datos);
              //  MessageBox.Show("La mediana es: " + resultado);
            }

            return resultado;
        }

        //Encontrar la mitad de una lista
        public double Par(List<int> datos)
        {
            double resultado;
            int mitad = 0;
            mitad = ((datos.Count)/2);
            resultado = ((double)(datos[mitad]+datos[mitad-1]) / (2));
            return resultado;
        }

        public double Impar(List<int> datos)
        {
            double resultado;
            int mitad = 0;
            mitad = ((datos.Count-1)/2);
            resultado = (double)datos[mitad];
            return resultado;
        }


        //Respuestas del Sesgo
        public string TipoSesgo(double media, double mediana)
        {
            string respuesta="";
            if (media<mediana)
            {
                respuesta = "Sesgo Negativo";
            }else if (media==mediana)
            {
                respuesta = "Sesgo Nulo";
            }
            else if(media>mediana)
            {
                respuesta = "Sesgo Positivo";
            }

            return respuesta;

        }


        //DISTRIBUCIONHIPERGEOMETRICA
        //La que x esta por si acaso
        public double[] DistribucionHipergeometrica(int n, int K, int N, int x)
        {
            double dividendo = 0;
            double divisor = 0;
            double[] resultados = new double[n + 1];
            for (int i = 0; i <= n; i++)
            {
                dividendo = ((double)(Factorial1(N-K))*(Factorial1(K))*(Factorial1(n))*(Factorial1(N-n)));
                divisor = ((double)(Factorial1(n-i))*(Factorial1(N-K-n+i))*Factorial1(i)*(Factorial1(K-i))*Factorial1(N));
                resultados[i] = ((double)(dividendo/divisor));
                // resultados[i] = ((Combinatoria(n, i)) * (Potencia((double)p, i)) * (Potencia((double)(1 - p), (n - i))));
            }
            return resultados;
        }


        //Media 
        public double MediaHipergeometrica(int n, int K, int N)
        {
            double resultado = 0;
            resultado = (double)((n*K)/(N));
            return resultado;
        }

        //Devuelve la Probabilidad de exito
        public double ProbabilidadExito(int K, int N)
        {
            double resultado = 0;
            resultado = ((double)(K/N));
            return resultado;
        }

        public double DEHconP(int n, int p, int N)
        {
            double resultado = 0;
            resultado = ((double)(Math.Sqrt(n*p*(1-p)))*(double)(Math.Sqrt((N-n)/(N-1))));
            return resultado;
        }

        public double DEHsinP(int n, int K, int N)
        {
            double resultado = 0;
            resultado = ((Math.Sqrt((double)(n*K)/(N)))*((1-((double)K / (double)N)))*(Math.Sqrt((double)(N-n)/(N-1))));
            return resultado;
        }


    }
}
