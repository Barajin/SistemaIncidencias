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
    public partial class FormIncidenciaDetalle : Form
    {
        public FormIncidenciaDetalle()
        {
            InitializeComponent();
        }

        private void FormIncidenciaDetalle_Load(object sender, EventArgs e)
        {
            llenarTabla();
        }


        public void llenarTabla()
        {
            var select = "select i.titulo, i.descripcion, i.prioridad, " +
                   "i.calificacion, ti.nombre as Tipo,  inc.tecnico, inc.departamento, " +
                   "cargo_persona.cargo, persona.apellidoPaterno + ' ' + persona.apellidoMaterno " +
                   "as 'Nombre de Jefe de Departamento', inc.fechaInicio, inc.fechaTerminacion from incidencia i " +
                   "join tipos_incidencia ti on i.tipo = ti.id join incidencia_detalle inc on inc.fk_incidencia = i.id " +
                   "join cargo_persona on cargo_persona.fk_departamento = inc.departamento join persona on persona.id = cargo_persona.fk_persona";


            if (UserLoginCache.Cargo == "Jefe de Taller de Hardware" || UserLoginCache.Cargo == "Técnico en Hardware")
            {
                select = "select i.titulo, i.descripcion, i.prioridad," +
                         "i.calificacion, ti.nombre as Tipo,  inc.tecnico, inc.departamento, cargo_persona.cargo, persona.apellidoPaterno + ' ' + persona.apellidoMaterno as 'Nombre de Jefe de Departamento', " +
                         "inc.fechaInicio, inc.fechaTerminacion from incidencia i " +
                         "join tipos_incidencia ti on i.tipo = ti.id " +
                         "join incidencia_detalle inc on inc.fk_incidencia = i.id " +
                         "join cargo_persona on cargo_persona.fk_departamento = inc.departamento " +
                         "join persona on persona.id = cargo_persona.fk_persona " +
                         "where ti.nombre = 'Hardware'";
            }

            else if (UserLoginCache.Cargo == "Jefe de Taller de Software" || UserLoginCache.Cargo == "Técnico en Software")
            {
                select = "select i.titulo, i.descripcion, i.prioridad," +
                      "i.calificacion, ti.nombre as Tipo,  inc.tecnico, inc.departamento, cargo_persona.cargo, persona.apellidoPaterno + ' ' + persona.apellidoMaterno as 'Nombre de Jefe de Departamento', " +
                      "inc.fechaInicio, inc.fechaTerminacion from incidencia i " +
                      "join tipos_incidencia ti on i.tipo = ti.id " +
                      "join incidencia_detalle inc on inc.fk_incidencia = i.id " +
                      "join cargo_persona on cargo_persona.fk_departamento = inc.departamento " +
                      "join persona on persona.id = cargo_persona.fk_persona " +
                      "where ti.nombre = 'Software'";
            }

            else if (UserLoginCache.Cargo == "Jefe de Taller de Redes" || UserLoginCache.Cargo == "Técnico en Redes")
            {
                select = "select i.titulo, i.descripcion, i.prioridad," +
                      "i.calificacion, ti.nombre as Tipo,  inc.tecnico, inc.departamento, cargo_persona.cargo, persona.apellidoPaterno + ' ' + persona.apellidoMaterno as 'Nombre de Jefe de Departamento', " +
                      "inc.fechaInicio, inc.fechaTerminacion from incidencia i " +
                      "join tipos_incidencia ti on i.tipo = ti.id " +
                      "join incidencia_detalle inc on inc.fk_incidencia = i.id " +
                      "join cargo_persona on cargo_persona.fk_departamento = inc.departamento " +
                      "join persona on persona.id = cargo_persona.fk_persona " +
                      "where ti.nombre = 'Redes'";
            }



            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dgvIncidencias.DataSource = ds.Tables[0];
        }

        private void dgvIncidencias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }



}
