using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UsuarioService
    {
        private readonly UsuarioRepository usuarioRepository;
        public UsuarioService()
        {
            usuarioRepository = new UsuarioRepository();
        }

        public string Guardar(Usuario usuario)
        {
            try
            {

                if (usuarioRepository.Buscar(usuario.Id) == null)
                {
                    usuarioRepository.Guardar(usuario);
                    return $"Se han guardado correctamente los datos del usuario: {usuario.NombreUsuario} ";
                }
                else
                {
                    return $"Lo sentimos,ya hay un usuario con la Identificación {usuario.Id}";
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicacion: {e.Message}";
            }
        }

        public ConsultaUsuarioResponse ConsultarTodos()
        {

            try
            {
                List<Usuario> usuarios = usuarioRepository.ConsultarTodos();
                if (usuarios != null)
                {
                    return new ConsultaUsuarioResponse(usuarios);
                }
                else
                {
                    return new ConsultaUsuarioResponse("La Persona buscada no se encuentra Registrada");
                }

            }
            catch (Exception e)
            {

                return new ConsultaUsuarioResponse("Error de Aplicacion: " + e.Message);
            }
        }

        public class ConsultaUsuarioResponse
        {
            public List<Usuario> Usuarios { get; set; }
            public string Message { get; set; }
            public bool Encontrado { get; set; }

            public ConsultaUsuarioResponse(List<Usuario> usuarios)
            {
                Usuarios = new List<Usuario>();
                Usuarios = usuarios;
                Encontrado = true;
            }
            public ConsultaUsuarioResponse(string message)
            {
                Message = message;
                Encontrado = false;
            }
        }

        public Usuario Buscar(int id)
        {
            return usuarioRepository.Buscar(id);
        }
    }

    
}
