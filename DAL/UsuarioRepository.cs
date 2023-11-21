using ENTITY;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UsuarioRepository
    {
        private readonly string ConnectionString = "user id=hernan;password=h123;data source=" +
                             "(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" +
                             "(HOST=localhost)(PORT=1521))(CONNECT_DATA=" +
                             "(SERVICE_NAME=XEPDB1)))";

        public int Guardar(Usuario usuario)
        {

            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                OracleCommand cmd = new OracleCommand("UsuarioPackage.CrearUsuario", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pNombre", OracleDbType.Varchar2).Value = usuario.Nombre;
                cmd.Parameters.Add("pApellido", OracleDbType.Varchar2).Value = usuario.Apellido;
                cmd.Parameters.Add("pNombreUsuario", OracleDbType.Varchar2).Value = usuario.NombreUsuario;
                cmd.Parameters.Add("pContrasenia", OracleDbType.Varchar2).Value = usuario.Contrasenia;
                cmd.Parameters.Add("pCorreo", OracleDbType.Varchar2).Value = usuario.Correo;
                cmd.Parameters.Add("pCuentaId", OracleDbType.Int32).Value = usuario.CuentaId;
                cmd.ExecuteNonQuery();
                return ObtenerUltimoIdGenerado(connection); // Implementa este método según la lógica de tu base de datos
            }
        }

        private int ObtenerUltimoIdGenerado(OracleConnection connection)
        {
            using (OracleCommand cmd = new OracleCommand("SELECT usuario_seq.CURRVAL FROM DUAL", connection))
            {
                int ultimoIdGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                return ultimoIdGenerado;
            }
        }

        public List<Usuario> ConsultarTodos()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                OracleCommand cmd = new OracleCommand("UsuarioPackage.ConsultarTodos", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("resultado_cursor", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();
                OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["resultado_cursor"].Value).GetDataReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int Id = Convert.ToInt32(reader["IDENTIFICACION"]);
                        String Nombre = reader["NOMBRES"].ToString();
                        String Apellido = reader["APELLIDOS"].ToString();
                        String NombreUsuario = reader["NOMBRE_USUARIO"].ToString();
                        String Contrasenia = reader["CONTRASENIA"].ToString();
                        String Correo = reader["CORREO"].ToString();
                        int CuentaId = Convert.ToInt32(reader["CUENTA_ID"]);
                        Usuario usuario = new Usuario(Id, Nombre,Apellido,NombreUsuario,Contrasenia,Correo,CuentaId);

                        usuarios.Add(usuario);
                    }
                }
                
            }

            return usuarios;
        }

        public Usuario Buscar(int identificacion)
        {
            Usuario usuario = null;

  
                using (OracleConnection connection = new OracleConnection(ConnectionString))
                {
                    connection.Open();

                    OracleCommand cmd = new OracleCommand("UsuarioPackage.Buscar", connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add("cur", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.ReturnValue;
                    cmd.Parameters.Add("pId", OracleDbType.Int32).Value = identificacion;
                    cmd.ExecuteNonQuery();

                    OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["cur"].Value).GetDataReader();

                    if (reader.HasRows)
                    {
                        if (reader.Read())
                        {
                        int Id = Convert.ToInt32(reader["IDENTIFICACION"]);
                        String Nombre = reader["NOMBRES"].ToString();
                        String Apellido = reader["APELLIDOS"].ToString();
                        String NombreUsuario = reader["NOMBRE_USUARIO"].ToString();
                        String Contrasenia = reader["CONTRASENIA"].ToString();
                        String Correo = reader["CORREO"].ToString();
                        int CuentaId = Convert.ToInt32(reader["CUENTA_ID"]);
                        usuario = new Usuario(Id, Nombre, Apellido, NombreUsuario, Contrasenia, Correo, CuentaId);

                        }
                    }
                    
                }

            return usuario;
        }



        public void Eliminar(int identificacion)
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                OracleCommand cmd = new OracleCommand("UsuarioPackage.EliminarUsuario", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("pId", OracleDbType.Varchar2).Value = identificacion;

                cmd.ExecuteNonQuery();
            }
        }
    }
}
