using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Common.Cache;

namespace Sistema_Incidencias
{
    public partial class FormAsignarTecnico : Form
    {
        string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
        int idIncidencia = 0;
        int idTecnico = 0;
        public FormAsignarTecnico()
        {
            InitializeComponent();
        }

        private void FormAsignarTecnico_Load(object sender, EventArgs e)
        {
            cargarincidencias();
            DataTable dt = cargarTennicos();
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "nombre";
        }

        public void cargarincidencias()
        {
            var select = "";
            if (UserLoginCache.Cargo.Contains("Hardware"))
            {
                select = "Select incidencia.id as 'ID', incidencia.titulo as 'Titulo' , incidencia.descripcion as 'Descripcion', incidencia.prioridad as 'Prioridad', " +
                "incidencia.fechaLevantamiento as 'FechaLevantamiento', estados_incidencia.nombre as 'Nombre', incidencia.calificacion as 'Calificacion', incidencia_detalle.elementoTI as 'Detalle' From incidencia " +
                "JOIN incidencia_detalle " +
                "on incidencia_detalle.fk_incidencia = incidencia.id " +
                "Join estados_incidencia on estados_incidencia.id = incidencia.estado Where incidencia.estado = 2 and incidencia.tipo = 1";
            }

            else if (UserLoginCache.Cargo.Contains("Software"))
            {
                select = "Select incidencia.id as 'ID', incidencia.titulo as 'Titulo' , incidencia.descripcion as 'Descripcion', incidencia.prioridad as 'Prioridad', " +
               "incidencia.fechaLevantamiento as 'FechaLevantamiento', estados_incidencia.nombre as 'Nombre', incidencia.calificacion as 'Calificacion', incidencia_detalle.elementoTI as 'Detalle' From incidencia " +
               "JOIN incidencia_detalle " +
               "on incidencia_detalle.fk_incidencia = incidencia.id " +
               "Join estados_incidencia on estados_incidencia.id = incidencia.estado Where incidencia.estado = 2 and incidencia.tipo = 2";
            }

            else if (UserLoginCache.Cargo.Contains("Redes"))
            {
                select = "Select incidencia.id as 'ID', incidencia.titulo as 'Titulo' , incidencia.descripcion as 'Descripcion', incidencia.prioridad as 'Prioridad', " +
                 "incidencia.fechaLevantamiento as 'FechaLevantamiento', estados_incidencia.nombre as 'Nombre', incidencia.calificacion as 'Calificacion', incidencia_detalle.elementoTI as 'Detalle' From incidencia " +
                 "JOIN incidencia_detalle " +
                 "on incidencia_detalle.fk_incidencia = incidencia.id " +
                 "Join estados_incidencia on estados_incidencia.id = incidencia.estado Where incidencia.estado = 2 and incidencia.tipo = 3";
            }

            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            dataGridView1.ClearSelection();

        }

        public DataTable cargarTennicos()
        {

            using (var cn = new SqlConnection(connString))
            {
                using (var da = new SqlDataAdapter())
                {
                    using (var cmd = cn.CreateCommand())
                    {
                        if (UserLoginCache.Cargo.Contains("Hardware"))
                        {
                            cmd.CommandText = "Select * From Persona " +
                                            "Inner join cargo_persona " +
                                            "on cargo_persona.fk_persona = persona.id " +
                                            "Where cargo LIKE '%Técnico en Hardware%' or cargo LIKE '%Técnica en Hardware%'";
                        }

                        else if (UserLoginCache.Cargo.Contains("Software"))
                        {
                            cmd.CommandText = "Select * From Persona " +
                                            "Inner join cargo_persona " +
                                            "on cargo_persona.fk_persona = persona.id " +
                                            "Where cargo LIKE '%Técnico en Software%' or cargo LIKE '%Técnica en Software%'";
                        }

                        else if (UserLoginCache.Cargo.Contains("Redes"))
                        {
                            cmd.CommandText = "Select * From Persona " +
                                           "Inner join cargo_persona " +
                                           "on cargo_persona.fk_persona = persona.id " +
                                           "Where cargo LIKE '%Técnico en Redes%' or cargo LIKE '%Técnica en Redes%'";
                        }
                        
                        da.SelectCommand = cmd;
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            //String variable = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            idTecnico = Convert.ToInt32(comboBox1.SelectedValue.ToString());

            if (idIncidencia == 0 || idTecnico == 0)
            {
                MessageBox.Show("Seleccione una incidencia y un técnico para continuar.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            

            var connetionString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
            var sql = "UPDATE incidencia SET estado = 4 where incidencia.id = @id";// repeat for all variables

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
                        MessageBox.Show("Incidencia Asignada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    connection.Close();
                }
            }

            var sql1 = "UPDATE incidencia_detalle SET tecnico = @tecnico where incidencia_detalle.fk_incidencia = @id";// repeat for all variables

            using (var connection = new SqlConnection(connetionString))
            {
                using (var command = new SqlCommand(sql1, connection))
                {
                    command.Parameters.Add("@id", idIncidencia);
                    command.Parameters.Add("@tecnico", idTecnico);
                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                    else
                    {
                        MessageBox.Show("Incidencia Asignada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    connection.Close();
                }



            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.Rows[0].Selected = false;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idIncidencia = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox1.Text = idIncidencia.ToString();
        }
    }
}
