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
    public partial class MenuPrincipalGUI : Form
    {
        public Cuenta cuenta;
        CuentaService cuentaService;
        public MenuPrincipalGUI(Cuenta cuenta)
        {
            cuentaService = new CuentaService();
            InitializeComponent();
            this.cuenta = cuenta;
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

        private void button5_Click(object sender, EventArgs e)
        {
            IniciarRegistrarSesionGUI t = new IniciarRegistrarSesionGUI();
            t.Show();
            this.Hide();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            CargarGrillas(cuenta.Transacciones);
            cuenta.calcularSaldo();
            textBox1.Text = cuenta.Saldo.ToString();
            lblNombre.Text = cuenta.Usuario.Nombre.ToUpper() + " " + cuenta.Usuario.Apellido.ToUpper();
        }

        void CargarGrillas(List<Transacciones> list)
        {
            grillaGastos.Rows.Clear();
            grillaIngresos.Rows.Clear();

            foreach (var item in list)
            {
                if(item.TipoTransaccion == "Gasto")
                {
                    grillaGastos.Rows.Add(item.Monto, item.Categoria.Nombre, item.Descripcion, item.Fecha);
                }
                else
                {
                    grillaIngresos.Rows.Add(item.Monto, item.Categoria.Nombre, item.Descripcion, item.Fecha);
                }
            }

          

        }

       

        private void button4_Click(object sender, EventArgs e)
        {
            Informes c = new Informes();
            
        }
    }
}
