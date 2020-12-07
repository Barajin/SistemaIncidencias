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
using Common.Cache;

namespace Sistema_Incidencias
{
    public partial class FormHistorialDeIncidencias : Form
    {
        public FormHistorialDeIncidencias()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormHistorialDeIncidencias_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        public void Mostrar()
        {
            var select = "";
            if (UserLoginCache.Cargo.Contains("Hardware"))
            {
                select = "Select incidencia_soluciones.fk_incidencia as 'Código de incidencia', tipos_incidencia.nombre as 'Tipo de incidencia' ,incidencia_detalle.tecnico as 'Técnico asignado', persona.nombre + ' ' + persona.apellidoPaterno + ' ' + persona.apellidoMaterno as 'Nombre de técnico', incidencia.descripcion as 'Incidencia', servicios.nombre as 'Solución empleada', incidencia.fechaLevantamiento, incidencia_detalle.fechaTerminacion, DATEDIFF( minute , incidencia.fechaLevantamiento , incidencia_detalle.fechaTerminacion ) as 'Tiempo de solución en minutos' From incidencia_soluciones " +
                         "inner join incidencia_detalle on incidencia_detalle.fk_incidencia = incidencia_soluciones.fk_incidencia " +
                         "inner join servicios on servicios.id = incidencia_soluciones.fk_servicio " +
                         "inner join incidencia on incidencia.id = incidencia_soluciones.fk_incidencia " +
                         "inner join tipos_incidencia on tipos_incidencia.id = incidencia.tipo " +
                         "inner join persona on incidencia_detalle.tecnico = persona.id " +
                         "where tipos_incidencia.id = 1 ";
            }

            if (UserLoginCache.Cargo.Contains("Software"))
            {
                select = "Select incidencia_soluciones.fk_incidencia as 'Código de incidencia', tipos_incidencia.nombre as 'Tipo de incidencia' ,incidencia_detalle.tecnico as 'Técnico asignado', persona.nombre + ' ' + persona.apellidoPaterno + ' ' + persona.apellidoMaterno as 'Nombre de técnico', incidencia.descripcion as 'Incidencia', servicios.nombre as 'Solución empleada', incidencia.fechaLevantamiento, incidencia_detalle.fechaTerminacion, DATEDIFF( minute , incidencia.fechaLevantamiento , incidencia_detalle.fechaTerminacion ) as 'Tiempo de solución en minutos' From incidencia_soluciones " +
                      "inner join incidencia_detalle on incidencia_detalle.fk_incidencia = incidencia_soluciones.fk_incidencia " +
                      "inner join servicios on servicios.id = incidencia_soluciones.fk_servicio " +
                      "inner join incidencia on incidencia.id = incidencia_soluciones.fk_incidencia " +
                      "inner join tipos_incidencia on tipos_incidencia.id = incidencia.tipo " +
                      "inner join persona on incidencia_detalle.tecnico = persona.id " +
                      "where tipos_incidencia.id = 2 ";
            }

            if (UserLoginCache.Cargo.Contains("Redes"))
            {
                select = "Select incidencia_soluciones.fk_incidencia as 'Código de incidencia', tipos_incidencia.nombre as 'Tipo de incidencia' ,incidencia_detalle.tecnico as 'Técnico asignado', persona.nombre + ' ' + persona.apellidoPaterno + ' ' + persona.apellidoMaterno as 'Nombre de técnico', incidencia.descripcion as 'Incidencia', servicios.nombre as 'Solución empleada', incidencia.fechaLevantamiento, incidencia_detalle.fechaTerminacion, DATEDIFF( minute , incidencia.fechaLevantamiento , incidencia_detalle.fechaTerminacion ) as 'Tiempo de solución en minutos' From incidencia_soluciones " +
                      "inner join incidencia_detalle on incidencia_detalle.fk_incidencia = incidencia_soluciones.fk_incidencia " +
                      "inner join servicios on servicios.id = incidencia_soluciones.fk_servicio " +
                      "inner join incidencia on incidencia.id = incidencia_soluciones.fk_incidencia " +
                      "inner join tipos_incidencia on tipos_incidencia.id = incidencia.tipo " +
                      "inner join persona on incidencia_detalle.tecnico = persona.id " +
                      "where tipos_incidencia.id = 3 ";
            }



            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }



    }
}
