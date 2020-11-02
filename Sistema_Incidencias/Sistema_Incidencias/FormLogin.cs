using Dominio;
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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserModel user = new UserModel();
            var validLogin = user.LoginUser(textBox1.Text, textBox2.Text);
            if (validLogin == true)
            {
                FormMenuPrincipal mainMenu = new FormMenuPrincipal();
                mainMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error de datos");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
