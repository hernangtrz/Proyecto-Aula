using BLL;
using System;
using ENTITY;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Reflection.Emit;

namespace Interfaz
{
    public partial class PresupuestosGUI : Form
    {
        PresupuestoService presupuestoService;
        CuentaService cuentaService;
        Cuenta cuenta;
        List<Categoria> categorias;

        public PresupuestosGUI(Cuenta c)
        {
            this.cuenta = c;
            presupuestoService = new PresupuestoService();
            cuentaService = new CuentaService();
            categorias = cuentaService.BuscarCategorias(c.Id);
            InitializeComponent();
        }

        private void PresupuestosGUI_Load(object sender, EventArgs e)
        {

            CargarComponentes();
            foreach (var item in categorias)
            {
                if (item.Tipo == "Gasto")
                {
                    cbCategorias.Items.Add(item.Nombre);
                }
            }
        }

        private void CargarComponentes()
        {
            layoutPadre.Controls.Clear();
            foreach (var item in cuentaService.BuscarPresupuestos(cuenta.Id))
            {
                Console.WriteLine(cuentaService.BuscarPresupuestos(cuenta.Id).Count);
                FlowLayoutPanel layoutMes = new FlowLayoutPanel();
                FlowLayoutPanel layoutCategoriaMonto = new FlowLayoutPanel();
                FlowLayoutPanel layoutValores = new FlowLayoutPanel();
                FlowLayoutPanel layoutBarra = new FlowLayoutPanel();
                FlowLayoutPanel layoutEspacio = new FlowLayoutPanel();


                System.Windows.Forms.Label categoria = new System.Windows.Forms.Label();
                System.Windows.Forms.Label mes = new System.Windows.Forms.Label();
                System.Windows.Forms.ProgressBar barraPresupuesto = new System.Windows.Forms.ProgressBar();
                System.Windows.Forms.Label valorMax = new System.Windows.Forms.Label();
                System.Windows.Forms.Label totalTransacciones = new System.Windows.Forms.Label();
                System.Windows.Forms.Label Espacio = new System.Windows.Forms.Label();
                categoria.Text = presupuestoService.buscarCategoriaPorPresupuesto(item.Id).Nombre.ToUpper();
                mes.Text = item.Mes;
                valorMax.Text = "Tope: $" + item.Monto.ToString();
                totalTransacciones.Text = "Total $" + item.TotalTransacciones.ToString();

                barraPresupuesto.Maximum = (int)item.Monto;
                if (item.Monto > item.TotalTransacciones)
                {
                    barraPresupuesto.Value = (int)item.TotalTransacciones;
                }
                else
                {
                    barraPresupuesto.Value = (int)item.Monto;
                }
                barraPresupuesto.BackColor = Color.Blue;
                barraPresupuesto.ForeColor = Color.White;
                barraPresupuesto.Width = 230;

                mes.ForeColor = Color.Silver;
                categoria.ForeColor = Color.White;
                totalTransacciones.ForeColor = Color.White;
                valorMax.ForeColor = Color.White;

                categoria.Font = new Font(categoria.Font, FontStyle.Bold);
                totalTransacciones.Font = new Font(categoria.Font, FontStyle.Bold);
                valorMax.Font = new Font(categoria.Font, FontStyle.Bold);
                Espacio.Font = new Font(categoria.Font, FontStyle.Bold);

                layoutMes.Size = new Size(91, 19);
                layoutCategoriaMonto.Size = new Size(280, 14);
                layoutBarra.Size = new Size(280, 32);
                layoutValores.Size = new Size(280, 24);
                layoutEspacio.Size = new Size(280, 20);

                layoutMes.Controls.Add(mes);
                layoutCategoriaMonto.Controls.Add(categoria);
                layoutCategoriaMonto.Controls.Add(valorMax);
                layoutBarra.Controls.Add(barraPresupuesto);
                layoutValores.Controls.Add(totalTransacciones);

                layoutPadre.AutoScroll = true;
                layoutPadre.AutoScrollMargin = new Size(0, 0);

                layoutPadre.Controls.Add(layoutMes);
                layoutPadre.Controls.Add(layoutCategoriaMonto);
                layoutPadre.Controls.Add(layoutBarra);
                layoutPadre.Controls.Add(layoutValores);
                layoutPadre.Controls.Add(layoutEspacio);
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private bool ValidarTextosVacios()
        {
            if (String.IsNullOrEmpty((txtMonto).Text))
            {
                return false;
            }
            if (String.IsNullOrEmpty((cbMes).Text))
            {
                return false;
            }
            if (String.IsNullOrEmpty((cbCategorias).Text))
            {
                return false;
            }

            return true;
        }
        private void btnAñadir_Click_1(object sender, EventArgs e)
        {
            if (ValidarTextosVacios())
            {
                Decimal monto = Convert.ToDecimal(txtMonto.Text);
                String mes = cbMes.Text;
                Presupuestos p = new Presupuestos(monto, mes);
                int presupuestoId = presupuestoService.Guardar(p);
                foreach (var item in categorias)
                {
                    if (String.Equals(cbCategorias.Text, item.Nombre, StringComparison.OrdinalIgnoreCase))
                    {
                        presupuestoService.AsignarPresupuestoACategoria(item.Id, presupuestoId, cuenta.Id);
                    }
                }
                MessageBox.Show($"Presupuesto asignado correctamente a la categoria {cbCategorias.Text}");
                CargarComponentes();
                this.Refresh();
            }
            else
            {
                MessageBox.Show("Rellene todos los campos");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipalGUI m = new MenuPrincipalGUI(cuenta);
            m.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TransaccionesGUI t = new TransaccionesGUI(cuenta);
            t.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CategoriasGUI c = new CategoriasGUI(cuenta);
            c.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            InformesGUI i = new InformesGUI(cuenta);
            i.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
