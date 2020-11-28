using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlClient;
using System.Drawing;

namespace Sistema_Incidencias
{
    public partial class FormAñadirElementosDepartamentos : Form
    {
        string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
        public FormAñadirElementosDepartamentos()
        {
            InitializeComponent();
        }

        private void FormAñadirElementosDepartamentos_Load(object sender, EventArgs e)
        {
            DataTable dt = ObtenereElemento();
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "nombre";

            DataTable dt2 = ObtenereMarca();
            comboBox1.DataSource = dt;
            comboBox1.ValueMember = "marca";
            comboBox1.DisplayMember = "marca";
        }

        public DataTable ObtenereElemento()
        {

            using (var cn = new SqlConnection(connString))
            {
                using (var da = new SqlDataAdapter())
                {
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "select * from tipos_elementoTI";
                        da.SelectCommand = cmd;
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }


        public DataTable ObtenereMarca()
        {

            using (var cn = new SqlConnection(connString))
            {
                using (var da = new SqlDataAdapter())
                {
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "select * from elementoTI";
                        da.SelectCommand = cmd;
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        private void btnAgregarDepartamento_Click(object sender, EventArgs e)
        {

        }
    }
}
