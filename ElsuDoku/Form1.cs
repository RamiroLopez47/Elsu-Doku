

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ElsuDoku
{
    public partial class Form1 : Form
    {
        private Sudoku juego = new Sudoku();
        private Random aleatorio = new Random();

        public Form1()
        {
            iniciarComponentes();
            Load += cargarVista;
            botonNuevo.Click += clickBotonNuevo;
            botonSolucion.Click += clickBotonSolucion;            
            botonComparar.Click += clickBotonComparar;
            vista.Paint += pinturaVista;
            juego.mostrarCeldas += juego_mostrarCeldas;
            juego.mostrarSolucion += juego_mostrarSolucion;
            juego.mostrarComparar += juego_mostrarComparar;
        }

        private void cargarVista(System.Object sender, System.EventArgs e) //Inicia la vista, Por ejemplo, si se descomenta botonSolucion, se verán casillas grises y azules.
        {
            vista.Rows.Add(9);
            botonNuevo.PerformClick();
           // botonSolucion.PerformClick();
            
        }

        private void clickBotonNuevo(System.Object sender, System.EventArgs e)
        {
            juego.NuevoJuego(aleatorio);
        }

        private void clickBotonComparar(System.Object sender, System.EventArgs e)
        {
            juego.mostrarComparacion();
        }

        private void clickBotonSolucion(System.Object sender, System.EventArgs e)
        {
            juego.mostrarSolucionGrilla();
        }

        private void cargaVista(object sender, EventArgs e)
        {

        }



        // LINEAS AZULES  Traza una linea entre dos puntos (x,y)
        private void pinturaVista(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.DrawLine(new Pen(Color.Blue, 3), 1, 0, 1, 200);

            e.Graphics.DrawLine(new Pen(Color.Blue, 3), 450, 1, 450, 202);

            e.Graphics.DrawLine(new Pen(Color.Blue, 3), 0, 2, 450, 2);

            e.Graphics.DrawLine(new Pen(Color.Blue, 3), 0, 200, 450, 200);

            e.Graphics.DrawLine(new Pen(Color.Blue, 3), 150, 0, 150, 200);

            e.Graphics.DrawLine(new Pen(Color.Blue, 3), 300, 0, 300, 200);

            e.Graphics.DrawLine(new Pen(Color.Blue, 3), 0, 66, 450, 66);

            e.Graphics.DrawLine(new Pen(Color.Blue, 3), 0, 132, 450, 132);
        }

        public void juego_mostrarCeldas(int[][] grilla) // MUESTRA las celdas fijas y variables, Tambien regula dificultad.
        {
            
            for (int i = 0; i <= 8; i++)
            {
                List<int> celdas = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
                for (int c = 1; c <= 9 - (9 - 4); c++)
                    //                       ↑   regula la dificultad.   
                    //                   9 --> Celdas totales por fila.
                    //                   Sustraendo --> Celdas a ocultar por fila.

                {
                    int numeroAleatorio = celdas[aleatorio.Next(0, celdas.Count())]; //Asigna un valor aleatorio desde 1 hasta el máximo almacenado.
                    celdas.Remove(numeroAleatorio);                                  //Remueve el valor asignado.
                }
                for (int j = 0; j <= 8; j++)
                {
                    if (celdas.Contains(j + 1))  //Si la lista contiene el elemento (no fue eliminado en el bucle anterior), lo agrega a la fila, le da color y establece modo solo lectura.
                    {
                        vista.Rows[i].Cells[j].Value = grilla[i][j];
                        vista.Rows[i].Cells[j].Style.ForeColor = Color.DarkSlateGray; //Color FIJAS
                        vista.Rows[i].Cells[j].ReadOnly = true;
                    }
                    else                         //Si el elemento fue eliminado en el primer bucle, deja la casilla en blanco, determina el color y da permiso de edición.
                    {
                        vista.Rows[i].Cells[j].Value = "";  
                        vista.Rows[i].Cells[j].Style.ForeColor = Color.Black; //Color INGRESADAS. NO CAMBIAR COLOR, SINO NO FUNCIONA SOLUCION 
                        vista.Rows[i].Cells[j].ReadOnly = false;
                    }
                }
            }
        }
        
        public void juego_mostrarSolucion(int[][] grilla)
        {
           
            for (int i = 0; i <= 8; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    //Si las celdas son Negras,Rojas o Verdes ingresa.
                    if ((vista.Rows[i].Cells[j].Style.ForeColor == Color.Black)||(vista.Rows[i].Cells[j].Style.ForeColor == Color.Red) ||(vista.Rows[i].Cells[j].Style.ForeColor == Color.Green))
                    {
                        //Si la celda esta vacía o es nula (VER else de juego_mostrarCeldas), le asigna en AZUL el valor original de la grilla.
                        if (string.IsNullOrEmpty(vista.Rows[i].Cells[j].Value.ToString()))
                        {
                            vista.Rows[i].Cells[j].Style.ForeColor = Color.Blue;
                            vista.Rows[i].Cells[j].Value = grilla[i][j];
                            vista.Rows[i].Cells[j].ReadOnly = true;
                        }
                        else
                        {
                            //Si el valor no corresponde con el de la grilla original, le asigna el valor correcto en AZUL.
                            if (grilla[i][j].ToString() != vista.Rows[i].Cells[j].Value.ToString())
                            {
                                vista.Rows[i].Cells[j].Style.ForeColor = Color.Blue;
                                vista.Rows[i].Cells[j].Value = grilla[i][j];
                                vista.Rows[i].Cells[j].ReadOnly = true;
                            }
                        }
                    }
                }
            }
        }

        public void juego_mostrarComparar(int[][] grilla)
        {
            for (int i = 0; i <= 8; i++)
            {
                for (int j = 0; j <= 8; j++)
                {
                    //Si el valor ingresado corresponde con el valor original de la grilla, cambia su color a verde.
                   if (grilla[i][j].ToString() == vista.Rows[i].Cells[j].Value.ToString())
                    {
                        vista.Rows[i].Cells[j].Style.ForeColor = Color.Green;
                    }
                    else    //Si el valor ingresado no es correcto, su color cambia a rojo.
                    {
                      vista.Rows[i].Cells[j].Style.ForeColor = Color.Red;     

                    }

                }

            }
        }

        private void InitializeComponent() //Inicia la ventana
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SuspendLayout();
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(453, 255);
            this.Font = new System.Drawing.Font("Humnst777 Blk BT", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(453, 255);
            this.MinimumSize = new System.Drawing.Size(453, 255);
            this.Name = "Form1";
            this.ResumeLayout(false);

        }
    }
}

