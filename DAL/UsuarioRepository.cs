using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioRepository
    {
        private readonly string FileName = "Usuarios.txt";

        public void Guardar(Usuario usuario)
        {
            FileStream file = new FileStream(FileName, FileMode.Append);
            StreamWriter writer = new StreamWriter(file);
            writer.WriteLine($"{usuario.Id};{usuario.Nombre};{usuario.Apellido};{usuario.NombreUsuario};{usuario.Correo};{usuario.Contraseña};{usuario.telefono} ");
            writer.Close();
            file.Close();

        }

        public List<Usuario> ConsultarTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();
            FileStream file = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Read);
            StreamReader reader = new StreamReader(file);
            string linea = string.Empty;
            while ((linea = reader.ReadLine()) != null)
            {

                Usuario usuario = Map(linea);
                usuarios.Add(usuario);
            }
            reader.Close();
            file.Close();
            return usuarios;
        }
        private Usuario Map(string linea)
        {
            Usuario usuario = new Usuario();
            char delimiter = ';';
            string[] matrizPersona = linea.Split(delimiter);
            usuario.Id = int.Parse(matrizPersona[0]);
            usuario.Nombre = matrizPersona[1];
            usuario.Apellido = matrizPersona[2];
            usuario.NombreUsuario = matrizPersona[3];
            usuario.Correo = matrizPersona[4];
            usuario.Contraseña = matrizPersona[5];
            usuario.telefono = matrizPersona[6];
           

            return usuario;
        }
        private bool EsEncontrado(int identificacioRegistrada, int identificacionBuscada)
        {
            return identificacioRegistrada == identificacionBuscada;
        }

        public Usuario Buscar(int identificacion)
        {
            List<Usuario> usuarios = ConsultarTodos();
            foreach (var item in usuarios)
            {
                if (EsEncontrado(item.Id, identificacion))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
