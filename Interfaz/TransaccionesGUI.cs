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
        Cuenta cuenta;
        CuentaService cuentaService;
        public TransaccionesGUI(Cuenta cuenta)
        {
            cuentaService = new CuentaService();
            this.cuenta = cuenta;
            transaccionesService = new TransaccionesService();
            categoriaService = new CategoriaService();
            InitializeComponent();
            list = transaccionesService.ConsultarTodos().Transacciones;
            this.cuenta = cuenta;   
        }

        public List<Categoria> CategoriaActualizadas()
        {
            return cuentaService.BuscarCategorias(cuenta.Id); 
        }

        public List<Transacciones> TransaccionesActualizadas()
        {
            return transaccionesService.BuscarPorCuenta(cuenta.Id);
        }


        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cbCategoria.Items.Clear();
            foreach (var item in CategoriaActualizadas())
            {
                if (cbTipoTransaccion.Text == "Ingreso")
                {
                    if(item.Tipo == "Ingreso")
                    {
                        cbCategoria.Items.Add(item.Nombre);
                    }
                }
                if (cbTipoTransaccion.Text == "Gasto")
                {
                    if (item.Tipo == "Gasto")
                    {
                        cbCategoria.Items.Add(item.Nombre);
                    }
                }
            }
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (ValidarTextosVacios())
            {
                String tipoTransaccion = cbTipoTransaccion.Text;
                Decimal monto = Decimal.Parse(txtMonto.Text);
                DateTime fecha = DateTime.Now;
                Categoria categoria = categoriaService.BuscarNombre(cbCategoria.Text);
                String descripcion = txtDescripcion.Text;

                Transacciones t = new Transacciones(tipoTransaccion, monto, fecha, descripcion, cuenta.Id, categoria.Id);


                String message = transaccionesService.Guardar(t);
                MessageBox.Show(message);
                cbTipoTransaccion.SelectedIndex = -1;
                txtMonto.Text = "";
                cbCategoria.SelectedIndex = -1;
                txtDescripcion.Text = "";
                CargarGrilla(TransaccionesActualizadas());
            }
            else
            {
                MessageBox.Show("Rellene todo los campos");
            }
            
        }

        private bool ValidarTextosVacios()
        {
            if (String.IsNullOrEmpty((cbTipoTransaccion).Text))
            {
                return false;
            }
            if (String.IsNullOrEmpty((txtMonto).Text))
            {
                return false;
            }
            if (String.IsNullOrEmpty((cbCategoria).Text))
            {
                return false;
            }
            if (String.IsNullOrEmpty((txtDescripcion).Text))
            {
                return false;
            }

            return true;
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
            CargarGrilla(TransaccionesActualizadas());
            
        }

        private void tabControl1_Resize(object sender, EventArgs e)
        {
            tabControl1.Size = new Size(this.ClientSize.Width - 20, this.ClientSize.Height - 40);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MenuPrincipalGUI m = new MenuPrincipalGUI(cuenta);
            m.Show();
            this.Hide();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            CategoriasGUI c = new CategoriasGUI(cuenta);
            c.Show();
            this.Hide();
        }

        private void btnPresupuestos_Click(object sender, EventArgs e)
        {
            PresupuestosGUI p = new PresupuestosGUI(cuenta);
            p.Show();
            this.Hide();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            InformesGUI i = new InformesGUI(cuenta);
            i.Show();
            this.Hide();

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
