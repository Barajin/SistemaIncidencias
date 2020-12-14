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
    public partial class FormTecnicosJefeTaller : Form
    {
        public FormTecnicosJefeTaller()
        {
            InitializeComponent();
        }

        private void FormTecnicosJefeTaller_Load(object sender, EventArgs e)
        {
            lblId.Text = UserLoginCache.departamento.ToString();
            llenarTabla();
            InformacionPersona();
        }

        public void llenarTabla()
        {
            var select = "";
            if(UserLoginCache.Cargo == "Jefe de Taller de Hardware")
            {
                select = "Select p.nombre + ' ' + p.apellidoPaterno as 'Nombre completo',  count(p.id) as 'Incidencias asignadas' from persona p " +
                    "join cargo_persona cp on p.id = cp.fk_persona left join incidencia_detalle on incidencia_detalle.tecnico = p.id  " +
                    "join incidencia on incidencia.id = incidencia_detalle.fk_incidencia  " +
                    "where cp.cargo like 'Técnico en Hardware%' and estado < 6 " +
                    "group by p.id, p.apellidoPaterno, p.nombre " +
                    "order by p.id desc";
            }
            else if (UserLoginCache.Cargo == "Jefe de Taller de Software")
            {
                select = "select p.id, p.nombre + ' ' + p.apellidoPaterno as 'Nombre completo',  count(p.id) as 'Incidencias asignadas' from persona p " +
                  "join cargo_persona cp on p.id = cp.fk_persona left join incidencia_detalle on incidencia_detalle.tecnico = p.id  " +
                  "join incidencia on incidencia.id = incidencia_detalle.fk_incidencia  " +
                  "where cp.cargo like 'Técnico en Software%' and estado < 6 " +
                  "group by p.id, p.apellidoPaterno, p.nombre " +
                  "order by p.id desc";
            }

            else if(UserLoginCache.Cargo == "Jefe de Taller de Redes")
            {
                select = "select p.id, p.nombre + ' ' + p.apellidoPaterno as 'Nombre completo',  count(p.id) as 'Incidencias asignadas' from persona p " +
                  "join cargo_persona cp on p.id = cp.fk_persona left join incidencia_detalle on incidencia_detalle.tecnico = p.id  " +
                  "join incidencia on incidencia.id = incidencia_detalle.fk_incidencia  " +
                  "where cp.cargo like 'Técnico en Redes%' and estado < 6 " +
                  "group by p.id, p.apellidoPaterno, p.nombre " +
                  "order by p.id desc";
            }
            

            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dgvTecnicos.DataSource = ds.Tables[0];
        }

        private void btnRegresar_Click(object sender, EventArgs e)
        {
            //FormMenuJefeTaller menu = new FormMenuJefeTaller();
            //menu.Show();
            // this.Close();
            this.Close();
        }

        public void InformacionPersona()
        {
            var select = "";
            if (UserLoginCache.Cargo == "Jefe de Taller de Hardware")
            {
                select = "Select p.id, p.nombre + ' ' + p.apellidoPaterno as 'Nombre completo', cp.cargo From persona p " +
                    "inner join cargo_persona cp on p.id = cp.fk_persona where cp.cargo like 'Técnico en Hardware%'";
            }
            else if (UserLoginCache.Cargo == "Jefe de Taller de Software")
            {
                select = "Select p.id, p.nombre + ' ' + p.apellidoPaterno as 'Nombre completo', cp.cargo From persona p " +
                    "inner join cargo_persona cp on p.id = cp.fk_persona where cp.cargo like 'Técnico en Software%'";
            }

            else if (UserLoginCache.Cargo == "Jefe de Taller de Redes")
            {
                select = "Select p.id, p.nombre + ' ' + p.apellidoPaterno as 'Nombre completo', cp.cargo From persona p " +
                    "inner join cargo_persona cp on p.id = cp.fk_persona where cp.cargo like 'Técnico en Redes%'";
            }


            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds1 = new DataSet();
            dataAdapter.Fill(ds1);
            dataGridView1.DataSource = ds1.Tables[0];
        }


    }
}
