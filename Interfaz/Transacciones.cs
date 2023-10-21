using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Interfaz
{
    public partial class Transacciones : Form
    {
        public Transacciones()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipal m = new MenuPrincipal();
            m.Show();
            this.Hide();    
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Categorias c = new Categorias();
            c.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();

            if (selectedItem == "Ingreso")
            {
                lbFuenteIngreso.Enabled = true;
                txtFuenteIngreso.Enabled = true;
                lbCategoria.Enabled = false;
                cbCategoria.Enabled = false;
            }
            if (selectedItem == "Gasto")
            {
                lbCategoria.Enabled = true;
                cbCategoria.Enabled = true;
                lbFuenteIngreso.Enabled = false;
                txtFuenteIngreso.Enabled = false;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
