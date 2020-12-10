using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Incidencias
{
    public partial class FormAñadirNuevaSolucion : Form
    {

        int tiempoEstimado = 0;
        string nombreSolucion = "";
        string descripcionSolucion = "";
        public FormAñadirNuevaSolucion()
        {
            InitializeComponent();
        }

        private void txtTiempo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            Añadir();
            this.Close();
        }

        public void Añadir()
        {
            string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";

            nombreSolucion = txtNombre.Text;
            descripcionSolucion = txtDescripcion.Text;
            tiempoEstimado = Convert.ToInt32(txtTiempo.Text);

            using (SqlConnection connection = new SqlConnection(connString))
            {
                String query = "INSERT INTO servicios(descripcion,nombre,tiempo_estimado) " +
                    "VALUES (@descripcion,@nombre,@tiempo_estimado)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@descripcion", descripcionSolucion);
                    command.Parameters.AddWithValue("@nombre", nombreSolucion);
                    command.Parameters.AddWithValue("@tiempo_estimado", tiempoEstimado);
              


                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                    else
                        MessageBox.Show("Solución añadida");
                    connection.Close();
                }
            }
        }


    }
}
