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
        List<Transacciones> list;
        TransaccionesService transaccionesService;
        CategoriaService categoriaService;
        List<Categoria> listaCategorias;
        public TransaccionesGUI()
        {
            transaccionesService = new TransaccionesService();
            categoriaService = new CategoriaService();
            listaCategorias = categoriaService.ConsultarTodos().Categorias;
            InitializeComponent();
            list = transaccionesService.ConsultarTodos().Transacciones;
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
            Categoria categoria = categoriaService.BuscarNombre(cbCategoria.Text);
            String descripcion = txtDescripcion.Text;
            var transacciones = transaccionesService.ConsultarTodos();
            if (transacciones.Transacciones.Any())
            {
                id = transacciones.Transacciones.Last().Id + 1;

            }
            Transacciones t = new Transacciones(id, tipoTransaccion, monto, fecha, categoria, descripcion);
            categoria.Transacciones.Add(t);
            categoriaService.Eliminar(categoria);
            categoria.calcularTotalGastato();
            categoriaService.Guardar(categoria);
            String message = transaccionesService.Guardar(t);
            MessageBox.Show(message);
            CargarGrilla(transaccionesService.ConsultarTodos().Transacciones);
        }

        void CargarGrilla(List<Transacciones> list)
        {
            grillaTransacciones.Rows.Clear();

            foreach (var item in list)
            {
                grillaTransacciones.Rows.Add(item.Id, item.Monto, item.TipoTransaccion, item.Fecha, item.Descripcion);
            }

        }



        private void TransaccionesGUI_Load(object sender, EventArgs e)
        {
            CargarGrilla(list);
            foreach (var item in listaCategorias)
            {
                cbCategoria.Items.Add(item.Nombre);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show(transaccionesService.Eliminar(int.Parse(txtId.Text)));
            CargarGrilla(transaccionesService.ConsultarTodos().Transacciones);
        }

        private void tabControl1_Resize(object sender, EventArgs e)
        {
            tabControl1.Size = new Size(this.ClientSize.Width - 20, this.ClientSize.Height - 40);
        }
    }
}
