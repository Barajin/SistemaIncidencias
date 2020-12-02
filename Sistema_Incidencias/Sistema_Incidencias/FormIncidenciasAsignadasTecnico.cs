using Common.Cache;
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
    public partial class FormIncidenciasAsignadasTecnico : Form
    {
        public FormIncidenciasAsignadasTecnico()
        {
            InitializeComponent();
        }

        public void llenarTablaPendientes()
        {
            
          int id =  UserLoginCache.id;
           

            var select = "select i.id,  i.titulo, i.descripcion, d.elementoTI, e.modelo as ElementoTI,ti.nombre as Tipo,i.prioridad, p.nombre + p.apellidoPaterno as Solicitante,dpto.nombre as Departamento,i.fechaLevantamiento from incidencia i" +
                " inner join incidencia_detalle d on i.id = d.fk_incidencia inner join persona p on i.persona = p.id inner join departamento dpto on dpto.id = d.departamento inner join tipos_incidencia ti on ti.id = i.tipo inner join elementoTI e on d.elementoTI = e.id inner join estados_incidencia ei on ei.id = i.estado where d.tecnico =" + id + " and ei.nombre = 'Aprobada'  or ei.nombre = 'En curso' ";

            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dgvIncidencias.DataSource = ds.Tables[0];

            DataGridViewButtonColumn solucionarButtonColumn = new DataGridViewButtonColumn();
            solucionarButtonColumn.Name = "Solucionar";
            solucionarButtonColumn.Text = "Solucionar";
            solucionarButtonColumn.UseColumnTextForButtonValue = true;
            int columnIndex1 = dgvIncidencias.ColumnCount;
            if (dgvIncidencias.Columns["Solucionar"] == null)
            {
                dgvIncidencias.Columns.Insert(columnIndex1, solucionarButtonColumn);
            }

            DataGridViewButtonColumn finalizarButtonColumn = new DataGridViewButtonColumn();
            finalizarButtonColumn.Name = "Finalizar";
            finalizarButtonColumn.Text = "finalizar";
            finalizarButtonColumn.UseColumnTextForButtonValue = true;
            int columnIndex = dgvIncidencias.ColumnCount;
            if (dgvIncidencias.Columns["Finalizar"] == null)
            {
                dgvIncidencias.Columns.Insert(columnIndex, finalizarButtonColumn);
            }


        }

        private void dgvIncidencias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvIncidencias.Columns["Solucionar"].Index)
            {
                int idIncidenciaEnviar = Convert.ToInt32(dgvIncidencias.Rows[e.RowIndex].Cells[0].Value.ToString());

                AsignarSolucion soluciones = new AsignarSolucion(idIncidenciaEnviar);
                soluciones.ShowDialog();
            }


                if (e.ColumnIndex == dgvIncidencias.Columns["Finalizar"].Index)
            {
                string id = dgvIncidencias.Rows[e.RowIndex].Cells[0].Value.ToString();

                var connetionString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
                
                var sql = "UPDATE incidencia SET estado = 5 where incidencia.id = @id";// repeat for all variables

                using (var connection = new SqlConnection(connetionString))
                {
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.Add("@id", id);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result < 0)
                            Console.WriteLine("Error inserting data into Database!");
                        else
                        {
                            MessageBox.Show("Incidencia finalizada.", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                llenarTablaPendientes();
                llenarTablaTerminados();
            }
           
        }

        public void llenarTablaTerminados()
        {

            int id = UserLoginCache.id;


            var select = "select i.titulo, i.descripcion,e.modelo as ElementoTI,ti.nombre as Tipo,i.prioridad, p.nombre + p.apellidoPaterno as Solicitante,dpto.nombre as Departamento,i.fechaLevantamiento from incidencia i" +
                " inner join incidencia_detalle d on i.id = d.fk_incidencia inner join persona p on i.persona = p.id inner join departamento dpto on dpto.id = d.departamento inner join tipos_incidencia ti on ti.id = i.tipo inner join elementoTI e on d.elementoTI = e.id inner join estados_incidencia ei on ei.id = i.estado where d.tecnico =" + id + " and ei.nombre = 'Finalizada' ";

            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dgvIncidenciasTerminadas.DataSource = ds.Tables[0];




        }
        private void btnRegresar_Click(object sender, EventArgs e)
        {
            FormMenuTecnico menu = new FormMenuTecnico();
            menu.Show();
            this.Close();
        }

        private void FormIncidenciasAsignadasTecnico_Load(object sender, EventArgs e)
        {
            dgvIncidencias.CellClick += dgvIncidencias_CellClick;
            llenarTablaPendientes();
            llenarTablaTerminados();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
