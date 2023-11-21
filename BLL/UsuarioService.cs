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
        private readonly CuentaRepository cuentaRepository;
        public UsuarioService()
        {
            usuarioRepository = new UsuarioRepository();
            cuentaRepository = new CuentaRepository();
        }

        public string GuardarUsuarioYCuenta(Usuario usuario, Cuenta cuenta)
        {
            try
            {
                int cuentaId = cuentaRepository.Guardar(cuenta);

                // Asignar el Id de la cuenta al usuario
                usuario.CuentaId = cuentaId;

                // Guardar el usuario actualizado
                usuarioRepository.Guardar(usuario);

                return $"Se han guardado correctamente los datos de el usuario";

            }
            catch (Exception e)
            {

                return $"Error de la Aplicacion usuario: {e.Message}";
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
