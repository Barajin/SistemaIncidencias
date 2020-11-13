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

    public partial class FormTimbrarIncidencias : Form
    {
        string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";

        public FormTimbrarIncidencias()
        {
            InitializeComponent();
        }

        private void FormTimbrarIncidencias_Load(object sender, EventArgs e)
        {
            DataTable dt = ObtenerEstadoIncidencia();
            comboBox3.DataSource = dt;
            comboBox3.ValueMember = "id";
            comboBox3.DisplayMember = "nombre";

            DataTable dtr = ObtenerTiposElementosTI();
            comboBox1.DataSource = dtr;
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "nombre";
        }

        public DataTable ObtenerEstadoIncidencia()
        {

            using (var cn = new SqlConnection(connString))
            {
                using (var da = new SqlDataAdapter())
                {
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "select * from tipos_incidencia";
                        da.SelectCommand = cmd;
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable ObtenerTiposElementosTI()
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
    }
}
