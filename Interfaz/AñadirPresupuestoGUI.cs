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
        public AñadirPresupuestoGUI(Cuenta c)
        {
            this.cuenta = c;
            presupuestoService = new PresupuestoService();
            cuentaService = new CuentaService();
            InitializeComponent();
        }

        private void AñadirPresupuestoGUI_Load_1(object sender, EventArgs e)
        {
            
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

        }
    }
}
