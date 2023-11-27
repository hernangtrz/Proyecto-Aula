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
        PresupuestoService presupuestoService;
        CuentaService cuentaService;
        Cuenta cuenta;
        public CategoriasGUI(Cuenta cuenta)
        {
            cuentaService = new CuentaService();    
            categoriaService = new CategoriaService();
            presupuestoService = new PresupuestoService();
            InitializeComponent();
            this.cuenta = cuenta;   
        }

        private List<Categoria> CategoriasActualizadas()
        {
             return cuentaService.BuscarCategorias(cuenta.Id);

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
            this.Dispose();
        }

        private void Categorias_Load(object sender, EventArgs e)
        {
            CargarGrilla(cuentaService.BuscarCategorias(cuenta.Id));
        }

        private void btnAñadir_Click(object sender, EventArgs e)
        {
            
        }

        void CargarGrilla(List<Categoria> list)
        {
            dataGridViewCategorias.Rows.Clear();

            foreach (var item in list)
            {
                dataGridViewCategorias.Rows.Add(item.Nombre, item.Tipo);
            }

        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //Categoria c = categoriaEncontrada();
            //if (c == null)
            //{
            //    MessageBox.Show("No se encontro la categoria con el nombre: " + txtNombreEliminar.Text);
            //}
            //else
            //{
            //    cbMesEditar.Visible = true;
            //    txtPresupuestoEditar.Visible = true;
            //    lblMes.Visible = true;
            //    lblPresupuesto.Visible = true;
            //    txtPresupuestoEditar.Text = c.Presupuesto.ToString();
            //    cbMesEditar.Text = c.Mes;
            //    btnActualizar.Enabled = true;
            //}
        }

        String nombre;
        public Categoria categoriaEncontrada()
        {
            nombre = txtNombre.Text;
            Categoria c = categoriaService.BuscarNombre(nombre);
            if (c != null)
            {
                return c;
            }
            return null;
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            //Categoria c = categoriaService.BuscarNombre(nombre);
            //c.Nombre = txtNombreEditar.Text;
            //c.Mes = cbMesEditar.Text;
            //c.Presupuesto = Double.Parse(txtPresupuestoEditar.Text);
            //categoriaService.Eliminar(c);
            //categoriaService.Guardar(c);
            //btnActualizar.Enabled = false;
            //cbMesEditar.Visible = false;
            //txtPresupuestoEditar.Visible = false;
            //lblMes.Visible = false;
            //lblPresupuesto.Visible = false;
            //txtNombreEditar.Text = "";
            //MessageBox.Show("Categoria Actualizada");
            //CargarGrilla(categoriaService.ConsultarTodos().Categorias);
        }

        private void cbMes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            InformesGUI i = new InformesGUI(cuenta);
            i.Show();
            this.Hide();
        }

        private void grillaCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private bool ValidarTextosVacios()
        {
            if (String.IsNullOrEmpty((txtNombre).Text))
            {
                return false;
            }
            if (String.IsNullOrEmpty((cbTipo).Text))
            {
                return false;
            }

            return true;
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            if (ValidarTextosVacios())
            {
                Categoria categoria;
                bool encontro = false;
                foreach (var item in cuentaService.BuscarCategorias(cuenta.Id))
                {
                    if (item.Nombre == txtNombre.Text)
                    {
                        encontro = true;
                    }
                }
                if (editar == false)
                {
                    String nombre = txtNombre.Text;
                    String tipo = cbTipo.Text;
                    if (categoriaService.BuscarNombre(nombre) == null)
                    {
                        categoria = new Categoria(nombre, tipo);
                        categoriaService.Guardar(categoria);
                    }


                    if (!encontro)
                    {
                        cuentaService.AsociarCategoria(cuenta.Id, categoriaService.BuscarNombre(nombre).Id);
                        MessageBox.Show("Categoria Añadida");
                        txtNombre.Text = "";
                        cbTipo.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Ya hay una categoria con ese nombre");
                    }
                    CargarGrilla(CategoriasActualizadas());
                }
                else
                {
                    if (!encontro)
                    {
                        foreach (var item in CategoriasActualizadas())
                        {
                            if (item.Nombre == dataGridViewCategorias.SelectedRows[0].Cells["nombreCategoria"].Value.ToString())
                            {
                                categoriaService.ActualizarCategoria(item.Id, txtNombre.Text, cbTipo.Text);
                            }
                        }
                        MessageBox.Show("Categoria Actualizada");
                        txtNombre.Text = "";
                        cbTipo.Text = "";
                        editar = false;
                    }
                    else
                    {
                        MessageBox.Show("Ya hay una categoria con ese nombre");
                    }
                    CargarGrilla(CategoriasActualizadas());

                }
            }
            else
            {
                MessageBox.Show("Rellene todos los campos");
            }
        }

        private bool editar = false;
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategorias.SelectedRows.Count > 0)
            {
                editar = true;
                txtNombre.Text = dataGridViewCategorias.SelectedRows[0].Cells["nombreCategoria"].Value.ToString();
                string tipo = dataGridViewCategorias.SelectedRows[0].Cells["tipoCategoria"].Value.ToString();   
                if(tipo == "Ingreso")
                {
                    cbTipo.SelectedIndex = 0;
                }
                else
                {
                    cbTipo.SelectedIndex = 1;
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (dataGridViewCategorias.SelectedRows.Count > 0)
            {
                foreach (var item in CategoriasActualizadas())
                {
                    if (item.Nombre == dataGridViewCategorias.SelectedRows[0].Cells["nombreCategoria"].Value.ToString())
                    {
                        categoriaService.Eliminar(item, cuenta.Id);
                    }
                }
                MessageBox.Show("Categoria Eliminada");
                txtNombre.Text = "";
                cbTipo.Text = "";
                CargarGrilla(CategoriasActualizadas());
                editar = false;

            }
            else
            {
                MessageBox.Show("Seleccione una fila");
            }
        }

        private void btnPresupuestos_Click(object sender, EventArgs e)
        {
            PresupuestosGUI p = new PresupuestosGUI(cuenta);
            p.Show();
            this.Hide();
        }
    }
}
