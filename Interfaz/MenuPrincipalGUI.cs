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
    public partial class MenuPrincipalGUI : Form
    {
        public MenuPrincipalGUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CategoriasGUI c = new CategoriasGUI();
            c.Show();
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
            IniciarRegistrarSesionGUI t = new IniciarRegistrarSesionGUI();
            t.Show();
            this.Hide();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
