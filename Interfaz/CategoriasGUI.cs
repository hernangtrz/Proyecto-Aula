﻿using System;
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
    public partial class CategoriasGUI : Form
    {
        public CategoriasGUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipalGUI m = new MenuPrincipalGUI();
            m.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TransaccionesGUI t = new TransaccionesGUI();
            t.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add("Dato1", "Dato2", "Dato3");
            dataGridView1.Rows.Add("Dato4", "Dato5", "Dato6");

        }




        private void btnEditar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow fila in dataGridView1.SelectedRows)
            {
                string dato = fila.Cells[2].Value.ToString();
                MessageBox.Show(dato);
            }
        }

       
    }
}
