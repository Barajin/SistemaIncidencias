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
    public partial class FormAltaDepartamento : Form
    {
        public FormAltaDepartamento()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            FormDepartamentos departamentos = new FormDepartamentos();
            departamentos.Show();
            this.Close();
        }

        private void btnAgregarDepartamento_Click(object sender, EventArgs e)
        {
            string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
            string nombre = "";
        
            nombre = textBox1.Text;
         

            using (SqlConnection connection = new SqlConnection(connString))
            {
                String query = "INSERT INTO Departamento (nombre) " +
                    "VALUES (@nombre)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@nombre", nombre);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                    else
                        MessageBox.Show("Departamento Insertado!");

                }
            }
        }







    }
}