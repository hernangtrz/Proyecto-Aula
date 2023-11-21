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

namespace Interfaz
{
    public partial class PresupuestosGUI : Form
    {
        PresupuestoService presupuestoService;
        CuentaService cuentaService;
        Cuenta cuenta;
        public PresupuestosGUI(Cuenta c)
        {
            this.cuenta = c;
            presupuestoService = new PresupuestoService();
            cuentaService = new CuentaService();
            InitializeComponent();
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            AñadirPresupuestoGUI añadirPresupuestoGUI = new AñadirPresupuestoGUI(cuenta);
            añadirPresupuestoGUI.Show();
        }
    }
}
