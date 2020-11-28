using System;
using Common.Cache;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using System.Data.SqlClient;
using System.Drawing;

namespace Sistema_Incidencias
{
    public partial class FormEvaluarIncidencias : Form
    {
        string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
        public FormEvaluarIncidencias()
        {
            InitializeComponent();
        }

        private void FormEvaluarIncidencias_Load(object sender, EventArgs e)
        {
            var select = "Select incidencia.id as 'id incidencia', departamento.nombre, persona.apellidoPaterno, incidencia.titulo, incidencia.descripcion, tipos_elementoTI.nombre as 'Tipo de Elemento', incidencia.prioridad, incidencia.fechaLevantamiento, estados_incidencia.nombre as 'Estado de Incidencia', incidencia.calificacion, incidencia_detalle.elementoTI From incidencia JOIN incidencia_detalle on incidencia_detalle.fk_incidencia = incidencia.id Join estados_incidencia on estados_incidencia.id = incidencia.estado Join tipos_elementoTI on tipos_elementoTI.id = incidencia_detalle.tipo_elementoTI Join persona on persona.id = incidencia.persona Join departamento on departamento.id = incidencia_detalle.departamento Where incidencia.calificacion is null and incidencia.persona = " + UserLoginCache.id;

            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            DataTable dt = ObtenerIdIncidencia();
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "id";
        }

        public DataTable ObtenerIdIncidencia()
        {

            using (var cn = new SqlConnection(connString))
            {
                using (var da = new SqlDataAdapter())
                {
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT id, titulo,calificacion From incidencia where calificacion is null";
                        da.SelectCommand = cmd;
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Insertar();
        }

        public void Insertar()
        {
            string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connString))
            {
                String query = "UPDATE incidencia SET calificacion =" + comboBox2.SelectedItem + " WHERE id = " + comboBox1.SelectedValue;

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                   
                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                    else
                        MessageBox.Show("Insertado!");

                }
            }
        }

    }
}
