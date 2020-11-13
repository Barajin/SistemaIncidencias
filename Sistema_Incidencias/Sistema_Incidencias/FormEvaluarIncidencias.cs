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

namespace Sistema_Incidencias
{
    public partial class FormEvaluarIncidencias : Form
    {
        public FormEvaluarIncidencias()
        {
            InitializeComponent();
        }

        private void FormEvaluarIncidencias_Load(object sender, EventArgs e)
        {
            var select = "Select incidencia.id, departamento.nombre, persona.apellidoPaterno, incidencia.titulo, incidencia.descripcion, tipos_elementoTI.nombre as 'Tipo de Elemento', incidencia.prioridad, incidencia.fechaLevantamiento, estados_incidencia.nombre as 'Estado de Incidencia', incidencia.calificacion, incidencia_detalle.elementoTI From incidencia JOIN incidencia_detalle on incidencia_detalle.fk_incidencia = incidencia.id Join estados_incidencia on estados_incidencia.id = incidencia.estado Join tipos_elementoTI on tipos_elementoTI.id = incidencia_detalle.tipo_elementoTI Join persona on persona.id = incidencia.persona Join departamento on departamento.id = incidencia_detalle.departamento Where incidencia.persona = " + UserLoginCache.id;

            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
    }
}
