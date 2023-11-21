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
            MessageBox.Show(mensaje, "Información al Guardar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtNombreUsuario.Text = "";
            txtCorreo.Text = "";
            txtContraseña.Text = "";
        }

        private string GuardarUsuario()
        {
            if (ValidarTextosVacios())
            {
                String nombre = txtNombre.Text;
                String apellido = txtApellido.Text;
                String nombreUsuario = txtNombreUsuario.Text;
                String correo = txtCorreo.Text;
                String contrasenia = txtContraseña.Text;
                
                if (validarUsuariosRepetidos(nombreUsuario))
                {
                    Cuenta cuenta = new Cuenta(0);
                    Usuario usuario = new Usuario(nombre, apellido, nombreUsuario, contrasenia, correo);
                    return usuarioService.GuardarUsuarioYCuenta(usuario, cuenta);
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

            return true;
        }
        private bool validarUsuariosRepetidos(String usuario)
        {
            var consultaUsuarioResponse = usuarioService.ConsultarTodos();
            if( consultaUsuarioResponse.Usuarios == null){
                return true;
            }
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
                   && item.Contrasenia == txtContraseña2.Text)
                {
                    Cuenta cuenta = cuentaService.buscar(item.CuentaId);
                    MenuPrincipalGUI m = new MenuPrincipalGUI(cuenta);
                    m.Show();
                    this.Hide();
                    encontrado = true;
                }
            }
            if(!encontrado)
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
            txtUsuario.Text = "";
            txtContraseña2.Text = "";
        }

        private void IniciarRegistrarSesionGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
