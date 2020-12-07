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
    public partial class FormAñadirElementosDepartamentos : Form
    {
        String tipoElementoTmp = "";
        DataTable dt2;
        DataTable dt3;
        String tmp1 = "";
        String tmp2 = "";

        string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";
        public FormAñadirElementosDepartamentos()
        {
            InitializeComponent();
        }

        private void FormAñadirElementosDepartamentos_Load(object sender, EventArgs e)
        {
            DataTable dt = CategoryAll();
            CmboTipoElemento.DataSource = dt;
            CmboTipoElemento.ValueMember = "id";
            CmboTipoElemento.DisplayMember = "id";

        }

        public DataTable CategoryAll()
        {

            using (var cn = new SqlConnection(connString))
            {
                using (var da = new SqlDataAdapter())
                {
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "Select * from elementoTI where id not in (Select fk_elementoTI from elementoTI_departamento);";
                        da.SelectCommand = cmd;
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable CategoryAll2()
        {

            using (var cn = new SqlConnection(connString))
            {
                using (var da = new SqlDataAdapter())
                {
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "Select id, tipo, marca, modelo, Descripcion from elementoTI where id = " + tipoElementoTmp;
                        da.SelectCommand = cmd;
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public DataTable CategoryAll3()
        {

            using (var cn = new SqlConnection(connString))
            {
                using (var da = new SqlDataAdapter())
                {
                    using (var cmd = cn.CreateCommand())
                    {
                        cmd.CommandText = "select id from departamento;";
                        da.SelectCommand = cmd;
                        var dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public void Incersion()
        {
            string connString = "Server=.\\SQLEXPRESS; Database= Sistema_Incidencias; Integrated Security=True";



            using (SqlConnection connection = new SqlConnection(connString))
            {
                String query = "INSERT INTO elementoTI_departamento " +
                    "VALUES (@fk_elementoTi, @fkDepartamento)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@fkDepartamento", tmp2);
                    command.Parameters.AddWithValue("@fk_elementoTi", tmp1);



                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");
                    else
                        MessageBox.Show(("Se asignó correctamente el departamento al Elemento de TI"), "Asignación de elemento de TI correcta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            this.tmp1 = CmboTipoElemento.Text;

            if (CmboTipoElemento.Text == "")
            {
                MessageBox.Show(("Epale está vacio"), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.tipoElementoTmp = CmboTipoElemento.Text;
                dt2 = CategoryAll2();

                txt_marca.Text = dt2.Rows[0].Field<String>(2);
                txt_modelo.Text = dt2.Rows[0].Field<String>(3);
                txt_descripcion.Text = dt2.Rows[0].Field<String>(4);
                cmb_departamento.Enabled = true;

                dt3 = CategoryAll3();
                cmb_departamento.DataSource = dt3;
                cmb_departamento.ValueMember = "id";
                cmb_departamento.DisplayMember = "id";
                btnAgregarDepartamento.Enabled = true;
            }

        }

        private void btnAgregarDepartamento_Click(object sender, EventArgs e)
        {
            this.tmp2 = cmb_departamento.Text;

            Incersion();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
