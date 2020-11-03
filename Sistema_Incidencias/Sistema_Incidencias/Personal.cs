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
    public partial class Personal : Form
    {
        public Personal()
        {
            InitializeComponent();
        }

        private void tablaPersonalDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AsignarCargo asignar = new AsignarCargo();
            asignar.Show();
        }

        private void Agregarbtn_Click(object sender, EventArgs e)
        {
            AltaPersonas alta = new AltaPersonas();
            alta.Show();
        }
    }
}
