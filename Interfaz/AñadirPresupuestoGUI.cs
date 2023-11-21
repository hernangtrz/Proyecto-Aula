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
    public partial class AñadirPresupuestoGUI : Form
    {
        PresupuestoService presupuestoService;
        CuentaService cuentaService;
        Cuenta cuenta;
        List<Categoria> categorias;
        public AñadirPresupuestoGUI(Cuenta c)
        {
            this.cuenta = c;
            presupuestoService = new PresupuestoService();
            cuentaService = new CuentaService();
            categorias = cuentaService.BuscarCategorias(c.Id);
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e) { 

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
        }
        private void AñadirPresupuestoGUI_Load_1(object sender, EventArgs e)
        {
            foreach (var item in categorias)
            {
                if(item.Tipo == "Gasto")
                {
                    cbCategorias.Items.Add(item.Nombre);
                }
            }
        }
    }
}
