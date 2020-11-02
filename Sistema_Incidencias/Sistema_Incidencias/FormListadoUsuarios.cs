using Sistema_Incidencias.Properties;
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
using DataAccess;
using System.Security.Cryptography.X509Certificates;

namespace Sistema_Incidencias
{
    public partial class FormListadoUsuarios : Form
    {
        public FormListadoUsuarios()
        {
            InitializeComponent();

            var select = "SELECT * FROM Persona";
            var comando = new SqlConnection("Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True"); // Your Connection String here
            var dataAdapter = new SqlDataAdapter(select, comando);

            var commandBuilder = new SqlCommandBuilder(dataAdapter);
            var ds = new DataSet();
            dataAdapter.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            ocultarMoverAnchoColumnas();
            ObtenerCantidades();
        }



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
         
        }

        private void dataGridView2_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
          

        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
           
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
          

        }

        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            //I supposed your button column is at index 0
            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.EditarProducto.Width;
                var h = Properties.Resources.EditarProducto.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Resources.EditarProducto, new Rectangle(x, y, w, h));
                e.Handled = true;
            }


            if (e.ColumnIndex == 1)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.EliminarProducto.Width;
                var h = Properties.Resources.EliminarProducto.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Resources.EliminarProducto, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        public void ocultarMoverAnchoColumnas() {
            dataGridView1.Columns[2].Visible = false;

            dataGridView1.Columns[0].DisplayIndex = 9;
            dataGridView1.Columns[1].DisplayIndex = 9;

        }

        public void ObtenerCantidades()
        {
            int cantidadPersonas = 0;
            int cantidadTecnicos = 0;
            int cantidadJefesDepartamento = 0;
            int cantidadJefesTaller = 0;

            string sql = "Select count(id) From Persona";
            //change this connection string... visit www.connectionstrings.com
            string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(sql, conn))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cantidadPersonas = Convert.ToInt32(reader[0].ToString());
                        //break for single row or you can continue if you have multiple rows...
                        break;
                    }
                }
                lblCantidadPersonas.Text = cantidadPersonas.ToString();
                conn.Close();
            }

        }


    }
}
