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
    public partial class IniciarRegistrarSesion : Form
    {
        public UsuarioService usuarioService;    
        public IniciarRegistrarSesion()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            String mensaje = Guardar();
            MessageBox.Show(mensaje, "Información al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNombreUsuario.Text = "";
            txtCorreo.Text = "";
            txtContraseña.Text = "";
            txtTelefono.Text = "";
        }

        private string Guardar()
        {
            if (ValidarTextosVacios())
            {
                int id;
                String nombre = txtNombre.Text;
                String apellido = txtApellido.Text;
                String nombreUsuario = txtNombreUsuario.Text;
                String correo = txtCorreo.Text;
                String contraseña = txtContraseña.Text;
                String telefono = txtTelefono.Text;

                var consultaUsuarioResponse = usuarioService.ConsultarTodos();
                if (consultaUsuarioResponse.Usuarios.Count == 0)
                {
                    id = 1;
                }
                else
                {
                    id = consultaUsuarioResponse.Usuarios.Last().Id + 1;
                }
                if (validarUsuariosRepetidos(nombreUsuario))
                {
                    Usuario usuario = new Usuario(id, nombre, apellido, nombreUsuario, correo, contraseña, telefono);
                    return usuarioService.Guardar(usuario);
                }
                else
                {
                    return "El nombre de usuario ya se encuentra resgistrado";
                }

               
            }
            else
            {
                return "Rellene todos los campos!";
            }
        }

        private bool ValidarTextosVacios()
        {
            if (String.IsNullOrEmpty((txtNombre).Text))
            {
                return false;
            }
            if (String.IsNullOrEmpty((txtApellido).Text))
            {
                return false;
            }
            if (String.IsNullOrEmpty((txtCorreo).Text))
            {
                return false;
            }
            if (String.IsNullOrEmpty((txtContraseña).Text))
            {
                return false;
            }
            if (String.IsNullOrEmpty((txtTelefono).Text))
            {
                return false;
            }

            return true;
        }
        private bool validarUsuariosRepetidos(String usuario)
        {
            var consultaUsuarioResponse = usuarioService.ConsultarTodos();
            foreach (var item in consultaUsuarioResponse.Usuarios)
            {
                if(item.NombreUsuario == usuario)
                {
                    return false;
                }
            }
            return true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var consultaUsuarioResponse = usuarioService.ConsultarTodos();
            bool encontrado = false;
            foreach (var item in consultaUsuarioResponse.Usuarios)
            {
                if(item.NombreUsuario == txtUsuario.Text && item.Contraseña == txtContraseña2.Text)
                {
                    MenuPrincipal m = new MenuPrincipal();
                    m.Show();
                    this.Hide();
                    encontrado = true;
                }
            }
            if(!encontrado)
            {
                MessageBox.Show("Usuario o contraseña incorrctos");
            }
            txtUsuario.Text = "";
            txtContraseña2.Text = "";
        }
    }
}
