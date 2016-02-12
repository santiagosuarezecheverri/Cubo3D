using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Cube3DConsole
{
    class Program
    {
        static int[,,] matrix;
        static int x;
        static int y;
        static int z;
        static int W;

        //static char[] array;
        static void Main(string[] args)
        {
            String linea;

            //linea = LeerArchivo();

            matrix = new int[3, 3, 3];
            
            //InicializarMatrix(matrix);
            //AsignarValorMatrix(1, 1, 1, 99);
            //AsignarValorMatrix(1, 1, 2, 1);
            //AsignarValorMatrix(1, 1, 3, 88);
            //MostrarMatrix(matrix);
            //Buscar(matrix, 1, 1 ,1 ,1, 1, 3);
            Console.ReadLine();

        }


        static string LeerArchivo()
        {
            //cambiar la ruta del archivo
            StreamReader st = new StreamReader("C:/Users/Santiago/Documents/Visual Studio 2015/Projects/Cube3DConsole/Cube3DConsole/cubo3d.txt");
            String line = "";
            int N, T, M, x1, y1, z1, val, x2, y2, z2;
            char[] array;
            
            line = st.ReadLine();//lee primera linea: test case
            T = Convert.ToInt32(line);
            if (T <= 50 && T >= 1)
            {
                for (int i = 0; i < T; i++)
                {
                    line = st.ReadLine();//lee la linea N M

                    array = line.ToCharArray();//convienrte a vector de char

                    //conversion de tipos
                    N = (int)Char.GetNumericValue(array[0]);
                    M = (int)Char.GetNumericValue(array[2]);
                    

                    if (N >= 1 && N <= 100)
                    {
                        matrix = new int[N, N, N]; //matriz 3d

                        if (M >= 1 && M <= 1000)
                        {
                            
                            for (int j = 0; j < M; j++)
                            {
                                line = st.ReadLine();
                                array = line.ToCharArray();//copnvienrte a vector de char
                                switch (array[0])
                                {
                                    case 'U':

                                        //errores cuando hay 2 digitos o mas
                                        Console.WriteLine("case UPDATE");
                                        array = line.ToCharArray();//copnvienrte a vector de char                                                                 

                                        Separar(array, line.Length);

                                        break;

                                    case 'Q':

                                        //errores cuando hay 2 digitos o mas
                                        Console.WriteLine("case QUERY");
                                        array = line.ToCharArray();//convienrte a vector de char

                                        //conversion de tipos
                                        x1 = (int)Char.GetNumericValue(array[6]);
                                        y1 = (int)Char.GetNumericValue(array[8]);
                                        z1 = (int)Char.GetNumericValue(array[10]);

                                        x2 = (int)Char.GetNumericValue(array[12]);
                                        y2 = (int)Char.GetNumericValue(array[14]);
                                        z2 = (int)Char.GetNumericValue(array[16]);

                                        //exploracion entre esas coordenadas


                                        break;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ingrese un tamaño de matriz válido entre 1 y 1000");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ingrese un tamaño de matriz válido entre 1 y 100");
                    }


                }
            }
            else
            {
                Console.WriteLine("Ingrese un número de casos válido entre 1 y 50");
            }

            
            return line;
            st.Close();
        }

      
        static void Buscar(int[,,] matrix, int x1, int y1, int z1, int x2, int y2, int z2)
        {
            int suma = 0;

            x1--;
            y1--;
            z1--;
            x2--;
            y2--;
            z2--;            
           
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        //Console.WriteLine("matrix:" + (i+1) + " " + (j+1) + " " + (k+1));
                        if ((i>= x1 && i<=x2)&& (j >= y1 && j <= y2)&& (k >= z1 && k <= z2))
                        {
                            suma += matrix[i, j, k];
                        }
                       
                    }
                }
            }
            Console.WriteLine("la suma es: " + suma);
        }

        //Llena con ceros la matriz, ojo limitante hasta 3
        static void InicializarMatrix(int[,,] matrix)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        matrix[i, j, k]=0;
                    }
                }
            }
        }

        static void MostrarMatrix(int[,,] matrix)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    for (int k = 0; k < 3; k++)
                    {
                        Console.WriteLine("matrix: [" + (i+1) + "] [" + (j+1) + "] [" + (k+1)+ "] = "+matrix[i, j, k]);
                      
                    }
                }
            }
        }

        static void AsignarValorMatrix(int x, int y, int z, int val)
        {
            matrix[x-1, y-1, z-1] = val;
        }

        static void Separar(char[] cadena, int tam)
        {
            //contadior que me dice cuando se acaba una instruiccion o numero
            int c=0;
            string instruccion="";
            string numero = "";
            int []num=new int[3];
            for (int i = 0; i < tam; i++)
            {
                if (Char.IsNumber(cadena[i]))
                {
                    Console.WriteLine("numero=" + cadena[i]);
                    numero += cadena[i].ToString();

                }
                else
                {
                    if (Char.IsWhiteSpace(cadena[i]))
                    {
                        Console.WriteLine("espacio");
                        c++;

                    }
                    else
                    {
                        if (Char.IsLetter(cadena[i]))
                        {
                            Console.WriteLine("letra= " + cadena[i]);
                            instruccion += cadena[i].ToString();
                        }
                    }
                }
            }
            Console.WriteLine(instruccion + numero);
        }
    }
}
