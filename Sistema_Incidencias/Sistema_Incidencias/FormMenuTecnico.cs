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
    public partial class FormMenuTecnico : Form
    {
        public FormMenuTecnico()
        {
            InitializeComponent();
        }

        private void FormMenuTecnico_Load(object sender, EventArgs e)
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
            lbFecha.Text = DateTime.Now.ToLongDateString();
            lblHora.Text = DateTime.Now.ToString("HH:mm:ssss");
        }

        private void btnMembresia_Click(object sender, EventArgs e)
        {
            //FormIncidenciasAsignadasTecnico incidencias = new FormIncidenciasAsignadasTecnico();
            //incidencias.Show();

            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FormIncidenciasAsignadasTecnico);

            if (frm != null)
            {
                //si la instancia existe la pongo en primer plano
                frm.BringToFront();
                return;
            }

            //sino existe la instancia se crea una nueva
            frm = new FormIncidenciasAsignadasTecnico();
            frm.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnMiPerfil_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FormVerSoluciones);

            if (frm != null)
            {
                //si la instancia existe la pongo en primer plano
                frm.BringToFront();
                return;
            }

            //sino existe la instancia se crea una nueva
            frm = new FormVerSoluciones();
            frm.Show();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de cerrar?", "Alerta¡¡", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            FormLogin login = new FormLogin();
            login.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FormSolucionesAsignadasHistorial);

            if (frm != null)
            {
                //si la instancia existe la pongo en primer plano
                frm.BringToFront();
                return;
            }

            //sino existe la instancia se crea una nueva
            frm = new FormSolucionesAsignadasHistorial();
            frm.Show();
        }



    }
}
