using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElsuDoku
{
    class Sudoku
    {
        public event mostrarCeldasEventHandler mostrarCeldas;
        public delegate void mostrarCeldasEventHandler(int[][] grilla);
        public event mostrarSolucionEventHandler mostrarSolucion;
        public delegate void mostrarSolucionEventHandler(int[][] grilla);
        public event mostrarCompararEventHandler mostrarComparar;
        public delegate void mostrarCompararEventHandler(int[][] grilla);

        private List<int>[] filas = new List<int>[9];
        private List<int>[] columnas = new List<int>[9];
        private List<int>[] cuadradoInterno = new List<int>[9];

        private int[][] grilla = new int[9][];

        private Random random;
        public void NuevoJuego(Random random)
        {
            this.random = random;
            iniciarNuevoJuego();
        }

        private void iniciarListas() //Carga los elementos de cada List
        {
            for (int i = 0; i <= 8; i++)
            {
                filas[i] = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                columnas[i] = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                cuadradoInterno[i] = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                int[] row = new int[9];
                grilla[i] = row;
            }
        }

        private void iniciarNuevoJuego()
        {
            while (true) 
            {
            break1:
                iniciarListas();
                for (int i = 0; i <= 8; i++)
                {
                    for (int j = 0; j <= 8; j++)
                    {
                        int si = (i / 3) * 3 + (j / 3);
                        int[] listaAux = filas[i].Intersect(columnas[j]).Intersect(cuadradoInterno[si]).ToArray();

                        if (listaAux.Count() == 0) //Si la lista esta vacia, reinicia
                        {
                            goto break1;
                        }

                        int casillaAux = listaAux[this.random.Next(0, listaAux.Count())]; //Asigna un valor entre 1 y el máximo de la lista.
                        filas[i].Remove(casillaAux);               //Elimina el valor en la fila.
                        columnas[j].Remove(casillaAux);            //Elimina el valor en la columna.
                        cuadradoInterno[si].Remove(casillaAux);    //Elimina el valor en el cuadrado 3x3.
                        grilla[i][j] = casillaAux;                 //Asigna el valor a la casilla actual.


                        if (i == 8 & j == 8) 
                        {
                            goto break2;
                        }
                    }
                }
            };
        break2:

            if (mostrarCeldas != null)
            {
                mostrarCeldas(grilla); //Hace visibles las casillas.
            }

        }

        public void mostrarComparacion() {
            mostrarComparar(grilla);
        }

        public void mostrarSolucionGrilla()
        {
            if (mostrarSolucion != null)
            {
                mostrarSolucion(grilla);
            }

        }

    }
}

