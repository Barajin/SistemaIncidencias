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
    public partial class AsignarSolucion : Form
    {
        int idServicio = 0;
        int idIncidencia = 0;
        int idElemento = 0;
        string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";

        public AsignarSolucion()
        {
            InitializeComponent();
        }

        private void AsignarSolucion_Load(object sender, EventArgs e)
        {
            MostrarSoluciones();
        }

        public void MostrarSoluciones()
        {
            var select = "Select * From servicios";
            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idServicio = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());

        }

        public void ActualizarIncidencia()
        {
            var connetionString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
            var sql = "UPDATE incidencia SET estado = 5 where incidencia.id = @id";// repeat for all variables

            using (var connection = new SqlConnection(connetionString))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", idIncidencia);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                    else
                    {
                        MessageBox.Show("Incidencia finalizada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    connection.Close();
                }
            }

            
        }

        public void ActualizarIncidenciaDetalle()
        {
            var connetionString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
            var sql = "UPDATE incidencia_detalle SET fechaTerminacion = GETDATE() where incidencia.id = @id";// repeat for all variables

            using (var connection = new SqlConnection(connetionString))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add("@id", idIncidencia);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                    else
                    {
                        MessageBox.Show("Incidencia finalizada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    connection.Close();
                }
            }
        }

        public void InsertarSolucion()
        {
            using (SqlConnection connection = new SqlConnection(connString))
            {
                String query = "INSERT INTO incidencia_soluciones(fk_incidencia,fk_elemento,fk_servicio) " +
                    "VALUES (@fk_incidencia,@fk_elemento,@fk_servicio)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fk_incidencia", idIncidencia);
                    command.Parameters.AddWithValue("@fk_elemento", idElemento);
                    command.Parameters.AddWithValue("@fk_servicio", idServicio);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                    else
                        MessageBox.Show(("Cargo asignado"), "Cargo asignado correctamente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                }
            }
        }

        private void btnAsignar_Click(object sender, EventArgs e)
        {
            InsertarSolucion();
            ActualizarIncidencia();
            ActualizarIncidenciaDetalle();
        }



    }
}
