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
    public partial class FormIncidenciasJefeDepto : Form
    {
        public FormIncidenciasJefeDepto()
        {
            InitializeComponent();
        }

        private void FormIncidenciasJefeDepto_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        public void Mostrar()
        {
            var select = "select i.titulo, i.descripcion,  estados_incidencia.nombre, i.fechaLevantamiento,  incidencia_detalle.tiempo_estimado_Solucion from incidencia i " +
                "join incidencia_detalle on incidencia_detalle.fk_incidencia = i.id " +
                "join estados_incidencia on i.estado = estados_incidencia.id where i.persona = " + UserLoginCache.id;


            


            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }


    }
}
