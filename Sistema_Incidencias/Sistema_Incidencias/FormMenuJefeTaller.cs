using Common.Cache;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_Incidencias
{
    public partial class FormMenuJefeTaller : Form
    {
        public FormMenuJefeTaller()
        {
            InitializeComponent();
        }

        private void FormMenuJefeTaller_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }

        private void LoadUserData()
        {
            label3.Text = UserLoginCache.Nombres;
            label4.Text = UserLoginCache.ApellidoPaterno;
            label5.Text = UserLoginCache.Cargo;
        }

        private void tmFechaHora_Tick(object sender, EventArgs e)
        {

        }

        private void tmContraerMenu_Tick(object sender, EventArgs e)
        {

        }

        private void tmExpandirMenu_Tick(object sender, EventArgs e)
        {
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToString("HH:mm:ssss");
        }

        private void btnIncidencia_Click(object sender, EventArgs e)
        {
            //FormIncidenciasJefeTaller incidencias = new FormIncidenciasJefeTaller();
            //incidencias.Show();

            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FormIncidenciasJefeTaller);

            if (frm != null)
            {
                //si la instancia existe la pongo en primer plano
                frm.BringToFront();
                return;
            }

            //sino existe la instancia se crea una nueva
            frm = new FormIncidenciasJefeTaller();
            frm.Show();
        }

        private void btnTecnicos_Click(object sender, EventArgs e)
        {
            //FormTecnicosJefeTaller tecnicos = new FormTecnicosJefeTaller();
            //tecnicos.Show();

            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FormTecnicosJefeTaller);

            if (frm != null)
            {
                //si la instancia existe la pongo en primer plano
                frm.BringToFront();
                return;
            }

            //sino existe la instancia se crea una nueva
            frm = new FormTecnicosJefeTaller();
            frm.Show();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FormHistorialDeIncidencias);

            if (frm != null)
            {
                //si la instancia existe la pongo en primer plano
                frm.BringToFront();
                return;
            }

            //sino existe la instancia se crea una nueva
            frm = new FormHistorialDeIncidencias();
            frm.Show();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //FormAsignarTecnico AbrirAsignar = new FormAsignarTecnico();
            //AbrirAsignar.Show();

            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FormAsignarTecnico);

            if (frm != null)
            {
                //si la instancia existe la pongo en primer plano
                frm.BringToFront();
                return;
            }

            //sino existe la instancia se crea una nueva
            frm = new FormAsignarTecnico();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin login = new FormLogin();
            login.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar?", "Alerta¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
