namespace ElsuDoku
{
    partial class Form1
    {

        #region

        private void iniciarComponentes()
        {
            this.botonSolucion = new System.Windows.Forms.Button();
            this.botonNuevo = new System.Windows.Forms.Button();
            this.botonComparar = new System.Windows.Forms.Button();
            this.vista = new System.Windows.Forms.DataGridView();
            this.col1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.vista)).BeginInit();
            this.SuspendLayout();

            // botonSolucion
            {
                this.botonSolucion.Location = new System.Drawing.Point(300, 215);
                this.botonSolucion.Name = "btnSolution";
                this.botonSolucion.Size = new System.Drawing.Size(130, 25);
                this.botonSolucion.Text = "Solucion";
                this.botonSolucion.UseVisualStyleBackColor = true;
                this.botonSolucion.Click += new System.EventHandler(this.clickBotonSolucion);
            }
           
            // botonNuevo
            {
                this.botonNuevo.Location = new System.Drawing.Point(15, 215);
                this.botonNuevo.Name = "botonNuevo";
                this.botonNuevo.Size = new System.Drawing.Size(130, 25);
                this.botonNuevo.Text = "Nuevo";
                this.botonNuevo.UseVisualStyleBackColor = true;
                this.botonNuevo.Click += new System.EventHandler(this.clickBotonNuevo);

            }

            //BotonComparar
            {
                this.botonComparar.Location = new System.Drawing.Point(157, 215);
                this.botonComparar.Name = "botonComparar";
                this.botonComparar.Size = new System.Drawing.Size(130, 25);             
                this.botonComparar.Text = "Comparar";
                this.botonComparar.UseVisualStyleBackColor = true;
                this.botonComparar.Click += new System.EventHandler(this.clickBotonComparar);
            }
            // vista
            {
                this.vista.AllowUserToAddRows = false;
                this.vista.AllowUserToDeleteRows = false;
                this.vista.AllowUserToResizeColumns = false;
                this.vista.AllowUserToResizeRows = false;
                this.vista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                this.vista.ColumnHeadersVisible = false;
                this.vista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col1,
            this.col2,
            this.col3,
            this.col4,
            this.col5,
            this.col6,
            this.col7,
            this.col8,
            this.col9});
                this.vista.Location = new System.Drawing.Point(0, 0);
                this.vista.Name = "vista";
                this.vista.RowHeadersVisible = false;
                this.vista.Size = new System.Drawing.Size(453, 255);

            }
            //Columnas (nombre y tamaño)
            {
                // col1

                this.col1.Name = "col1";
                this.col1.Width = 50;                
                
                // col2

                this.col2.Name = "col2";
                this.col2.Width = 50;
                
                // col3
                
                this.col3.Name = "col3";
                this.col3.Width = 50;
                
                
                // col4
                 
                this.col4.Name = "col4";
                this.col4.Width = 50;
                
                // col5
               
                this.col5.Name = "col5";
                this.col5.Width = 50;
                
                // col6
                
                this.col6.Name = "col6";
                this.col6.Width = 50;
               
                // col7
                
                this.col7.Name = "col7";
                this.col7.Width = 50;
                
                // col8
                
                this.col8.Name = "col8";
                this.col8.Width = 50;
               
                // col9
               
                this.col9.Name = "col9";
                this.col9.Width = 50;
            }

            // Ventana
            {
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(455, 255);
                this.Controls.Add(this.botonSolucion);
                this.Controls.Add(this.botonNuevo);
                this.Controls.Add(this.botonComparar);
                this.Controls.Add(this.vista);
                this.MaximizeBox = false;
                this.Name = "Ventana";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Elsu Doku";
                ((System.ComponentModel.ISupportInitialize)(this.vista)).EndInit();
                this.ResumeLayout(false);
            }
        }
        //EndRegion NO TOCAR
        #endregion

        internal System.Windows.Forms.Button botonSolucion;
        internal System.Windows.Forms.Button botonComparar;
        internal System.Windows.Forms.Button botonNuevo;
        internal System.Windows.Forms.DataGridView vista;
        internal System.Windows.Forms.DataGridViewTextBoxColumn col1;
        internal System.Windows.Forms.DataGridViewTextBoxColumn col2;
        internal System.Windows.Forms.DataGridViewTextBoxColumn col3;
        internal System.Windows.Forms.DataGridViewTextBoxColumn col4;
        internal System.Windows.Forms.DataGridViewTextBoxColumn col5;
        internal System.Windows.Forms.DataGridViewTextBoxColumn col6;
        internal System.Windows.Forms.DataGridViewTextBoxColumn col7;
        internal System.Windows.Forms.DataGridViewTextBoxColumn col8;
        internal System.Windows.Forms.DataGridViewTextBoxColumn col9;

    }
}