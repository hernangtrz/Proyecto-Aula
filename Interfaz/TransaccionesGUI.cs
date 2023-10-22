using BLL;
using System;
using ENTITY;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using static BLL.UsuarioService;

namespace Interfaz
{
    public partial class TransaccionesGUI : Form
    {
        TransaccionesService transaccionesService;
        public TransaccionesGUI()
        {
            transaccionesService = new TransaccionesService();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipalGUI m = new MenuPrincipalGUI();
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
            CategoriasGUI c = new CategoriasGUI();
            c.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            int id = 1;
            String tipoTransaccion = cbTipoTransaccion.Text;
            Double monto = Double.Parse(txtMonto.Text);
            DateTime fecha = dtFecha.Value;
            Categoria categoria = new Categoria();
            String descripcion = txtDescripcion.Text;
            var transacciones = transaccionesService.ConsultarTodos();
            if (transacciones.Transacciones != null)
            {
                id = transacciones.Transacciones.Last().Id + 1;

            }
            Transacciones t = new Transacciones(id, tipoTransaccion, monto, fecha, categoria, descripcion);
            String message = transaccionesService.Guardar(t);
            MessageBox.Show(message);
        }
    }
}
