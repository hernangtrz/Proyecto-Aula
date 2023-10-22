using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }
        public string Correo { get; set; }
        public String telefono { get; set; }
        public string Contraseña { get; set; }

        public Usuario(int id, string nombre, string apellido, string NombreUsuario, string correo, string contraseña, String telefono)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Correo = correo;
            this.telefono = telefono;
            this.Contraseña = contraseña;
            this.NombreUsuario = NombreUsuario;
        }

        public Usuario() { }

    }
}