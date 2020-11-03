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
    public partial class AltaElementoTI : Form
    {

        string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
        public AltaElementoTI()
        {
            InitializeComponent();
        }

        private void AltaElementoTI_Load(object sender, EventArgs e)
        {
            DataTable dt = CategoryAll();
            CmbTipoElemento.DataSource = dt;
            CmbTipoElemento.ValueMember = "id";
            CmbTipoElemento.DisplayMember = "nombre";
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panelContenedorForm_Paint(object sender, PaintEventArgs e)
        {

        }

        public DataTable CategoryAll()
        {

            using (var cn = new SqlConnection(connString))
            {
                using (var da = new SqlDataAdapter())
                {
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "SELECT id, nombre From tipos_ElementoTI";
                        da.SelectCommand = cmd;
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

       


    }
}
