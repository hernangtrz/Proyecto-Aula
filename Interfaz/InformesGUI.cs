using BLL;
using ENTITY;
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
    public partial class InformesGUI : Form
    {
        public Cuenta cuenta;
        CuentaService cuentaService;
        TransaccionesService transaccionesService;
        CategoriaService categoriaService;
        List<Categoria> listaCategorias;
        List<Transacciones> listaTransacciones;

        public InformesGUI(Cuenta c)
        {
            categoriaService = new CategoriaService();
            cuenta = c;
            transaccionesService = new TransaccionesService();
            cuentaService = new CuentaService();
            listaCategorias = cuentaService.BuscarCategorias(cuenta.Id);
            listaTransacciones = transaccionesService.BuscarPorCuenta(cuenta.Id);
            InitializeComponent();
        }

        private void Informes_Load(object sender, EventArgs e)
        {
            Decimal totalGastos = 0;
            Decimal totalIngresos = 0;
            GraficoGastosMes();
            GraficoIngresosCategoria();
            GraficoGastosCategoria();
            lblSaldo.Text = cuenta.Saldo.ToString();
            lblCategorias.Text = listaCategorias.Count.ToString();
            foreach (var item in listaTransacciones)
            {
                if(item.TipoTransaccion == "Gasto")
                {
                    totalGastos += item.Monto;
                }
                else
                {
                    totalIngresos += item.Monto;
                }
            }
            lblGastos.Text = totalGastos.ToString();
            lblIngresos.Text = totalIngresos.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            CategoriasGUI c = new CategoriasGUI(cuenta);
            c.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TransaccionesGUI t = new TransaccionesGUI(cuenta);
            t.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MenuPrincipalGUI m = new MenuPrincipalGUI(cuenta);
            m.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void GraficoGastosMes()
        {
            Dictionary<string, decimal> valoresPorMes = new Dictionary<string, decimal>();

            foreach (var item in listaTransacciones)
            {
                if (item.TipoTransaccion == "Gasto")
                {
                    string nombreMes = item.Fecha.ToString("MMM");

                    if (valoresPorMes.ContainsKey(nombreMes))
                    {
                        valoresPorMes[nombreMes] += item.Monto;
                    }
                    else
                    {
                        valoresPorMes.Add(nombreMes, item.Monto);
                    }
                }
            }

            chartGastosMes.Series[0].Points.DataBindXY(valoresPorMes.Keys.ToArray(), valoresPorMes.Values.ToArray());
        }

        private void GraficoGastosCategoria()
        {
            List<string> nombres = new List<string>();
            List<decimal> valores = new List<decimal>();

            foreach (var item in listaCategorias)
            {
                Decimal total = 0;
                if(item.Tipo == "Gasto")
                {
                    nombres.Add(item.Nombre);
                    foreach (var item1 in categoriaService.TransaccionesPorCategoria(item.Id))
                    {
                        total += item1.Monto;
                    }
                    valores.Add(total);
                }
                
            }

            chartGastosCategoria.Series[0].Points.DataBindXY(nombres, valores);
        }

        private void GraficoIngresosCategoria()
        {
            
            List<string> nombres = new List<string>();
            List<decimal> valores = new List<decimal>();

            foreach (var item in listaCategorias)
            {
                Decimal total = 0;
                if (item.Tipo == "Ingreso")
                {
                    nombres.Add(item.Nombre);
                    foreach (var item1 in categoriaService.TransaccionesPorCategoria(item.Id))
                    {
                        total += item1.Monto;
                    }
                    valores.Add(total);
                }

            }

            chartIngresosCategoria.Series[0].Points.DataBindXY(nombres, valores);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MenuPrincipalGUI m = new MenuPrincipalGUI(cuenta);
            m.Show();
            this.Dispose();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            TransaccionesGUI t = new TransaccionesGUI(cuenta);
            t.Show();
            this.Dispose();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            CategoriasGUI c = new CategoriasGUI(cuenta);
            c.Show();
            this.Dispose();
        }

        private void btnPresupuestos_Click(object sender, EventArgs e)
        {
            PresupuestosGUI p = new PresupuestosGUI(cuenta);
            p.Show();
            this.Dispose();

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
