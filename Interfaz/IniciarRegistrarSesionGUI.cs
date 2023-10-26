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
    public partial class IniciarRegistrarSesionGUI : Form
    {
        public UsuarioService usuarioService;
        public CuentaService cuentaService;

        public IniciarRegistrarSesionGUI()
        {
            InitializeComponent();
            usuarioService = new UsuarioService();
            cuentaService = new CuentaService();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegistrarse_Click(object sender, EventArgs e)
        {
            String mensaje = GuardarUsuario();
            GuardarCuenta();
            MessageBox.Show(mensaje, "Información al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNombreUsuario.Text = "";
            txtCorreo.Text = "";
            txtContraseña.Text = "";
            txtTelefono.Text = "";
        }

        private void GuardarCuenta()
        {
            Cuenta cuenta;
            int id = 1;
            List<Transacciones> t = new List<Transacciones>();
            List<Categoria> c = new List<Categoria>();
            Usuario u = new Usuario();
            List<Usuario> listaUsuarios = usuarioService.ConsultarTodos().Usuarios;
            foreach (var item in listaUsuarios)
            {
                if(String.Equals(item.NombreUsuario, txtNombreUsuario.Text, StringComparison.OrdinalIgnoreCase))
                {
                    u = item;
                }
            }
            var cuentas = cuentaService.ConsultarTodos();
            if (cuentas.Cuentas.Any())
            {
                id = cuentas.Cuentas.Last().Id + 1;

            }
            cuenta = new Cuenta(id,u,t,c);  
            cuentaService.Guardar(cuenta);

        }

        private string GuardarUsuario()
        {
            if (ValidarTextosVacios())
            {
                int id = 1;
                String nombre = txtNombre.Text;
                String apellido = txtApellido.Text;
                String nombreUsuario = txtNombreUsuario.Text;
                String correo = txtCorreo.Text;
                String contraseña = txtContraseña.Text;
                String telefono = txtTelefono.Text;

                var usuarios = usuarioService.ConsultarTodos();
                if (usuarios.Usuarios.Any())
                {
                    id = usuarios.Usuarios.Last().Id + 1;

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

   

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            var consultaUsuarioResponse = usuarioService.ConsultarTodos();
            bool encontrado = false;
            
            foreach (var item in consultaUsuarioResponse.Usuarios)
            {
                if(String.Equals(item.NombreUsuario, txtUsuario.Text, StringComparison.OrdinalIgnoreCase)
                   && item.Contraseña == txtContraseña2.Text)
                {
                    Cuenta cuenta = cuentaService.buscarUsuario(item.Id);
                    MenuPrincipalGUI m = new MenuPrincipalGUI(cuenta);
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
