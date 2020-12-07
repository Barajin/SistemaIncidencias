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
    public partial class FormSolucionesAsignadasHistorial : Form
    {
        public FormSolucionesAsignadasHistorial()
        {
            InitializeComponent();
        }

        private void FormSolucionesAsignadasHistorial_Load(object sender, EventArgs e)
        {
            MostrarSolucionesHistorial();
        }

        public void MostrarSolucionesHistorial()
        {
            var select = "Select incidencia_soluciones.fk_incidencia as 'Código de incidencia', incidencia_detalle.tecnico as 'Técnico asignado', incidencia.descripcion as 'Incidencia', servicios.nombre as 'Solución empleada' From incidencia_soluciones " +
            "inner join incidencia_detalle on incidencia_detalle.fk_incidencia = incidencia_soluciones.fk_incidencia " +
            "inner join servicios on servicios.id = incidencia_soluciones.fk_servicio " + 
            "inner join incidencia on incidencia.id = incidencia_soluciones.fk_incidencia";
            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }


    }
}
