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
    public partial class CategoriasGUI : Form
    {
        CategoriaService categoriaService;
        List<Categoria> listaCategorias;
        CuentaService cuentaService;
        Cuenta cuenta;
        public CategoriasGUI(Cuenta cuenta)
        {
            cuentaService = new CuentaService();    
            categoriaService = new CategoriaService();
            listaCategorias = categoriaService.ConsultarTodos().Categorias;
            InitializeComponent();
            this.cuenta = cuenta;   
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

        private void button5_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            CargarGrilla(cuenta.Categorias);
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            int id = 1;
            String nombre = txtNombreAñadir.Text;
            Double presupuesto = Double.Parse(txtPresupuestoAñadir.Text);
            string mes = cbMes.Text;
            List<Transacciones> listaTransacciones = new List<Transacciones>();
            var categorias = categoriaService.ConsultarTodos();
            if (categorias.Categorias.Any())
            {
                id = categorias.Categorias.Last().Id + 1;

            }

            Categoria c = new Categoria(id, nombre, presupuesto, mes, listaTransacciones);
            cuenta.Categorias.Add(c);
            cuentaService.Eliminar(cuenta.Id);
            cuentaService.Guardar(cuenta);
            String message = categoriaService.Guardar(c);
            MessageBox.Show(message);
            CargarGrilla(cuenta.Categorias);
        }

        void CargarGrilla(List<Categoria> list)
        {
            grillaCategorias.Rows.Clear();

            foreach (var item in list)
            {
                grillaCategorias.Rows.Add(item.Nombre, item.Transacciones.Count, item.TotalGastado, item.Presupuesto,item.Mes);
            }

        }


        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            Categoria c = categoriaService.BuscarNombre(txtNombreEliminar.Text);
            if(c == null)
            {
                MessageBox.Show("No se encontro la categoria con el nombre: " + txtNombreEliminar.Text);
            }
            else
            {
                MessageBox.Show(categoriaService.Eliminar(c));
                CargarGrilla(categoriaService.ConsultarTodos().Categorias);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Categoria c = categoriaEncontrada();
            if (c == null){
                MessageBox.Show("No se encontro la categoria con el nombre: " + txtNombreEliminar.Text);
            }
            else
            {
                cbMesEditar.Visible = true;
                txtPresupuestoEditar.Visible = true;
                lblMes.Visible = true;
                lblPresupuesto.Visible = true;
                txtPresupuestoEditar.Text = c.Presupuesto.ToString();
                cbMesEditar.Text = c.Mes;
                btnActualizar.Enabled = true;
            }              
        }

        String nombre;
        public Categoria categoriaEncontrada()
        {
            nombre = txtNombreEditar.Text;
            Categoria c = categoriaService.BuscarNombre(nombre);
            if (c != null)
            {
                return c;
            }
            return null;
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Categoria c = categoriaService.BuscarNombre(nombre);
            c.Nombre = txtNombreEditar.Text;
            c.Mes = cbMesEditar.Text;
            c.Presupuesto = Double.Parse(txtPresupuestoEditar.Text);
            categoriaService.Eliminar(c);
            categoriaService.Guardar(c);
            btnActualizar.Enabled = false;
            cbMesEditar.Visible = false;
            txtPresupuestoEditar.Visible = false;
            lblMes.Visible = false;
            lblPresupuesto.Visible = false;
            txtNombreEditar.Text = "";
            MessageBox.Show("Categoria Actualizada");
            CargarGrilla(categoriaService.ConsultarTodos().Categorias);
        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Informes c = new Informes();
        }
    }
}
