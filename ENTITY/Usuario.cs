using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    [Serializable]
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasenia { get; set; }
        public string Correo { get; set; }
        public int CuentaId { get; set; }

        public Usuario(string nombre, string apellido, string nombreUsuario, string contrasenia, string correo)
        {
            Nombre = nombre;
            Apellido = apellido;
            NombreUsuario = nombreUsuario;
            Contrasenia = contrasenia;
            Correo = correo;
        }

        public Usuario(int id, string nombre, string apellido, string nombreUsuario, string contrasenia, string correo, int cuentaId)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            NombreUsuario = nombreUsuario;
            Contrasenia = contrasenia;
            Correo = correo;
            CuentaId = cuentaId;
        }
    }
}