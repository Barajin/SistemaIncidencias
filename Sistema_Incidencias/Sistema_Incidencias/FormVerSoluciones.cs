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
    public partial class FormVerSoluciones : Form
    {
        public FormVerSoluciones()
        {
            InitializeComponent();
        }

        private void FormVerSoluciones_Load(object sender, EventArgs e)
        {
            MostrarSoluciones();
        }

        public void MostrarSoluciones()
        {
            var select = "Select * From servicios";
            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms.Cast<Form>().FirstOrDefault(x => x is FormAñadirNuevaSolucion);

            if (frm != null)
            {
                //si la instancia existe la pongo en primer plano
                frm.BringToFront();
                return;
            }

            //sino existe la instancia se crea una nueva
            frm = new FormAñadirNuevaSolucion();
            frm.Show();
        }
    }
}
