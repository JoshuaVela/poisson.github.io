using System;

namespace Trabajo
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] num_random = Generador_ConMix(4, 5, 7, 8);
            // promedio(num_random);
            if (Pmts_Gene(num_random) && promedio(num_random) && frecuencias(num_random) && series(num_random))
            {
                Console.WriteLine("No se rechaza la hipotesis");
            }
            else
            {
                Console.WriteLine("Se rechaza la hipotesis");
            }
            // SET != lista entonces habia repetidos
            // la serie es completa si no hay numeros repetidos
            // for lista numeros primos a,c, m=1001, X_0= nuemro de la suerte
            // las series que pasasn las guardan en archivo.
            for (int i = 0; i < num_random.Length; i++)
            {
                Console.WriteLine(num_random[i]);
            }

            Console.WriteLine("Distribución de Bernoulli");

            String[] bernoulli = Bernoulli(num_random);

            for (int j = 0; j < bernoulli.Length; j++)
            {
                Console.WriteLine(bernoulli[j]);
            }

            Console.WriteLine("Distribución Exponencial");

            double[] Euler = Exponencial(num_random);

            for (int k = 0; k < Euler.Length; k++)
            {
                Console.WriteLine(Euler[k]);
            }

            Console.WriteLine("Distribución Uniforme");

            double[] uniformidad = Uniforme(num_random);

            for (int f = 0; f < uniformidad.Length; f++)
            {
                Console.WriteLine(uniformidad[f]);
            }

            Console.WriteLine("Estimación Pi");

            Double pi = Pi(num_random);

            Console.WriteLine(pi);

            Console.WriteLine("Distribución Poisson");

            int poisson = Poisson(5, 0.85);

            Console.WriteLine(poisson);



        }
        public static double[] Generador_ConMix(int x0, int a, int c, int mod)    //Generador Congruencial mixto ------> ya esta 
        {
            int Xn;
            int Xsig = 0;
            Xn = x0;
            double[] num_random = new double[mod];
            //mod porcentaje division que da el residuo 
            for (int i = 0; i < mod; i++)
            {
                Xsig = ((a * Xn) + c) % (mod);
                // Console.WriteLine(Xsig);
                Xn = Xsig;
                num_random[i] = (Xsig * 1.0) / mod;
            }
            return num_random;
        }

        static bool Pmts_Gene(double[] num_random)       //prueba parametros generados
        {
            double formula;
            double promedio;
            double suma = 0;
            for (int i = 0; i < num_random.Length; i++)
            {
                suma = num_random[i] + suma;
            }
            promedio = suma / num_random.Length;
            formula = Math.Abs(((0.5 - Math.Abs(promedio)) * 4.4721) / 0.28867513);
            // Console.WriteLine(formula);
            // Console.WriteLine(promedio);
            if (formula < 1.96)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // 1,2,3,4

        static bool promedio(double[] num_random)    //Prueba Promedio-----> ya se entrego
        {
            double formula;
            double promedio;
            double suma = 0;
            for (int i = 0; i < num_random.Length; i++)
            {
                suma = num_random[i] + suma;
            }
            promedio = suma / num_random.Length;
            formula = Math.Abs(((0.5 - Math.Abs(promedio)) * 4.4721) / 0.28867513);
            // Console.WriteLine(formula);
            // Console.WriteLine(promedio);
            if (formula < 1.96)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool frecuencias(double[] num_random)        //prueba frecuencias -------> ya esta
        {
            double formuC1;
            double formuC2;
            double formuC3;
            double formuC4;
            double formutot;
            double fe0 = 0;
            double valor1 = 0;
            int foc1 = 0, foc2 = 0, foc3 = 0, foc4 = 0;

            for (int i = 0; i < num_random.Length - 1; i++)
            {
                valor1 = num_random[i];
                if (valor1 < 0.25)
                {
                    foc1++;
                }
                else if (valor1 > 0.25 && valor1 < 0.5)
                {
                    foc2++;
                }
                else if (valor1 > 0.5 && valor1 < 0.75)
                {
                    foc3++;
                }
                else if (valor1 > 0.75 && valor1 < 1)
                {
                    foc4++;
                }
            }
            fe0 = Math.Abs(((num_random.Length) / 4));
            formuC1 = Math.Pow(fe0 - foc1, 2);
            formuC2 = Math.Pow(fe0 - foc2, 2);
            formuC3 = Math.Pow(fe0 - foc3, 2);
            formuC4 = Math.Pow(fe0 - foc4, 2);
            formutot = ((formuC1 + formuC2 + formuC3 + formuC4)) / (num_random.Length);
            if (formutot < 7.81)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static Boolean series(double[] num_random)             //prueba series ---------> ya se entrego
        {
            double formulac1;
            double formulac2;
            double formulac3;
            double formulac4;
            double formut;
            double fe = 0;
            double valor1 = 0, valor2 = 0;
            int foc1 = 0, foc2 = 0, foc3 = 0, foc4 = 0;
            for (int i = 0; i < num_random.Length - 1; i++)
            {
                valor1 = num_random[i];
                valor2 = num_random[i + 1];
                if (valor1 < 0.5 && valor2 < 0.5)
                {
                    foc1++;
                }
                else if (valor1 > 0.5 && valor2 < 0.5)
                {
                    foc2++;
                }
                else if (valor1 < 0.5 && valor2 > 0.5)
                {
                    foc3++;
                }
                else if (valor1 > 0.5 && valor2 > 0.5)
                {
                    foc4++;
                }
            }
            fe = Math.Abs(((num_random.Length - 1) / 4));
            formulac1 = Math.Pow(foc1 - fe, 2);
            formulac2 = Math.Pow(foc2 - fe, 2);
            formulac3 = Math.Pow(foc3 - fe, 2);
            formulac4 = Math.Pow(foc4 - fe, 2);
            formut = ((formulac1 + formulac2 + formulac3 + formulac4) * 4) / (num_random.Length - 1);
            if (formut < 7.81)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string[] Bernoulli(double[] num_random)       //Distribución Bernoulli------------->Ya se entrego
        {
            string[] bernoulli = new string[8];
            double pfalla = 0.8;
            double ri;
            for (int i = 0; i < num_random.Length; i++)
            {
                ri = num_random[i];

                if (ri > 0 && ri < pfalla)
                {
                    bernoulli[i] = ("No se detecta falla");
                }
                else if (ri > 0.8 && ri < 1)
                {
                    bernoulli[i] = ("Se detecto una falla");
                }
            }
            return bernoulli;
        }

        public static double[] Exponencial(double[] num_random)                 //Distribución exponencial--------------> Ya se entrego
        {
            double[] ex = new double[8];
            double ri;
            double media = 3;
            for (int i = 0; i < num_random.Length; i++)
            {
                ri = num_random[i];
                ex[i] = -(media) * Math.Log10(1 - ri);
            }
            return ex;
        }

        public static double[] Uniforme(double[] num_random)            //Distribución uniforme-------------------->Ya se entrgo
        {
            double[] du = new double[8];
            double ri;
            double LI = 4, LS = 9;

            for (int i = 0; i < num_random.Length; i++)
            {
                ri = num_random[i];
                du[i] = LI + ((LS - LI) * ri);
            }
            return du;
        }

        public static double Pi(double[] num_random)                    //Estimación Pi------------------> Ya se entrego
        {
            double pi;
            double caudx, cuady;
            double cirx, ciry;
            int cuadrado = 0;
            int circulo = 0;
            int circuloact = 0;
            double rcc;

            for (int i = 0; i < num_random.Length - 1; i++)
            {
                caudx = 1 - 2 * num_random[i];
                cuady = 1 - 2 * num_random[i + 1];

                if (Math.Pow(caudx, 2) + Math.Pow(cuady, 2) < 1)
                {
                    cirx = caudx;
                    ciry = cuady;
                    cuadrado++;
                    circulo++;
                    circuloact = circulo;
                }
                else
                {
                    cirx = 0;
                    ciry = 0;
                    cuadrado++;
                    circuloact = circulo;
                }
            }

            rcc = circuloact / cuadrado;
            pi = rcc * 4;

            return pi;
        }

        public static int Poisson(int lambda, double r)         //Distrubución Poisson--------------->
        {
            int x = 0;
            double p, P = 0;
            int fact = 0;
            int[] encontrada = new int[41];

            for (int i = 0; i < encontrada.Length; i++)
            {
                while (x < i)
                {
                    fact = fact * x;
                    x = x + 1;
                }

                if(fact == 0 && i == 0)
                {
                    p = Math.Pow(lambda, x) * Math.Pow(Math.Exp(1), -(lambda / 1));                    
                }
                else
                {
                    p = Math.Pow(lambda, x) * Math.Pow(Math.Exp(1), -(lambda / fact));          //Tuvimos problemas para obtener el resultado
                }
                P = P + p;

                if (r > 0)
                {
                    if (r < P)
                    {
                        encontrada[i] = x;
                    }
                    else
                    {
                        encontrada[i] = 0;
                    }
                }
                else
                {
                    encontrada[i] = 0;
                }
            }

            float mayor;
            int poisson = 0;
            mayor = encontrada[0];

            for (int j = 0; j < encontrada.Length; j++)
            {
                if (encontrada[j] > mayor)
                {
                    mayor = encontrada[j];
                    poisson = j;
                }
            }
            return poisson;
        }
    }
}
