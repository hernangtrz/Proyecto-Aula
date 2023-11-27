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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Interfaz
{
    public partial class MenuPrincipalGUI : Form
    {
        public Cuenta cuenta;
        CuentaService cuentaService;
        public Usuario usuario;
        UsuarioService usuarioService;
        TransaccionesService transaccionesService;
        CategoriaService categoriaService;
        public MenuPrincipalGUI(Cuenta cuenta)
        {
            cuentaService = new CuentaService();
            usuarioService = new UsuarioService();
            transaccionesService = new TransaccionesService();
            categoriaService = new CategoriaService();
            InitializeComponent();
            this.cuenta = cuenta;
            this.usuario = usuarioService.Buscar(cuenta.Id);
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            CargarGrillas(transaccionesService.BuscarPorCuenta(cuenta.Id));
            lblSaldo.Text = "$" + cuentaService.buscar(cuenta.Id).Saldo.ToString();
            lblNombre.Text = usuario.Nombre.ToUpper() + " " + usuario.Apellido.ToUpper();
        }

        void CargarGrillas(List<Transacciones> list)
        {
            grillaGastos.Rows.Clear();
            grillaIngresos.Rows.Clear();

            foreach (var item in list)
            {
                if (item.TipoTransaccion == "Gasto")
                {

                    grillaGastos.Rows.Add(item.Monto, categoriaService.Buscar(item.Categoria_id).Nombre, item.Descripcion, item.Fecha);
                }
                else
                {
                    grillaIngresos.Rows.Add(item.Monto, categoriaService.Buscar(item.Categoria_id).Nombre, item.Descripcion, item.Fecha);
                }
            }

        }

        void CargarGrillasFiltradas(List<Transacciones> list,int mes)
        {
            grillaGastos.Rows.Clear();
            grillaIngresos.Rows.Clear();

            foreach (var item in list)
            {
                if(item.Fecha.Month == mes)
                {
                    if (item.TipoTransaccion == "Gasto")
                    {

                        grillaGastos.Rows.Add(item.Monto, categoriaService.Buscar(item.Categoria_id).Nombre, item.Descripcion, item.Fecha);
                    }
                    else
                    {
                        grillaIngresos.Rows.Add(item.Monto, categoriaService.Buscar(item.Categoria_id).Nombre, item.Descripcion, item.Fecha);
                    }
                }
                
            }

        }

        private void btnTransacciones_Click(object sender, EventArgs e)
        {
            TransaccionesGUI t = new TransaccionesGUI(cuenta);
            t.Show();
            this.Hide();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
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

        private void btnInformes_Click(object sender, EventArgs e)
        {
            InformesGUI i = new InformesGUI(cuenta);
            i.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            IniciarRegistrarSesionGUI t = new IniciarRegistrarSesionGUI();
            t.Show();
            this.Hide();
        }


        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbMes.SelectedIndex != 0)
            {
                CargarGrillasFiltradas(transaccionesService.BuscarPorCuenta(cuenta.Id), cbMes.SelectedIndex);
            }
            else
            {
                CargarGrillas(transaccionesService.BuscarPorCuenta(cuenta.Id));
            }

        }
    }
}
