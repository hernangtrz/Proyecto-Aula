using ENTITY;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CategoriaRepository
    {
        private readonly string ConnectionString = "user id=hernan;password=h123;data source=" +
                             "(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" +
                             "(HOST=localhost)(PORT=1521))(CONNECT_DATA=" +
                             "(SERVICE_NAME=XEPDB1)))";

        public void Eliminar(int categoriaId, int cuentaId)
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                try
                {
                    connection.Open();

                    OracleCommand cmd = new OracleCommand("CategoriaPackage.EliminarCategoria", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("pCuentaId", OracleDbType.Int32).Value = cuentaId;
                    cmd.Parameters.Add("pCategoriaId", OracleDbType.Int32).Value = categoriaId;


                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error {ex}");
                }

            }
        }

        public void Guardar(Categoria categoria)
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                OracleCommand cmd = new OracleCommand("CategoriaPackage.CrearCategoria", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pNombre", OracleDbType.Varchar2).Value = categoria.Nombre;
                cmd.Parameters.Add("pTipo", OracleDbType.Varchar2).Value = categoria.Tipo;

                try
                {
                    cmd.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al intentar guardar la categoría: {ex.Message}");
                }
            }
        }

        public List<Categoria> ConsultarTodos()
        {
            List<Categoria> categorias = new List<Categoria>();

            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                OracleCommand cmd = new OracleCommand("CategoriaPackage.ConsultarTodas", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Categoria categoria = new Categoria
                    (
                        Convert.ToInt32(reader["Categoria_id"]),
                        reader["Nombre"].ToString(),
                        reader["Tipo"].ToString()

                    );

                    categorias.Add(categoria);
                }
            }

            return categorias;
        }

        public Categoria Buscar(int id)
        {
            Categoria categoria = null;

            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                OracleCommand cmd = new OracleCommand("CategoriaPackage.Buscar", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("cur", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add("pId", OracleDbType.Int32).Value = id;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["cur"].Value).GetDataReader();

                if (reader.Read())
                {
                    categoria = new Categoria
                    (
                        Convert.ToInt32(reader["Categoria_id"]),
                        reader["Nombre"].ToString(),
                        reader["Tipo"].ToString()
                    );


                }
            }

            return categoria;
        }

        public Categoria BuscarNombre(string nombre)
        {
            Categoria categoria = null;

            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                OracleCommand cmd = new OracleCommand("CategoriaPackage.BuscarNombre", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("cur", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add("pNombre", OracleDbType.Varchar2).Value = nombre;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["cur"].Value).GetDataReader();

                if (reader.Read())
                {
                    categoria = new Categoria
                    (
                        Convert.ToInt32(reader["Categoria_id"]),
                        reader["Nombre"].ToString(),
                        reader["Tipo"].ToString()

                    );
                }
            }

            return categoria;
        }

        public void ActualizarCategoria(int categoriaId, string nuevoNombre, string tipo)
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                OracleCommand cmd = new OracleCommand("CategoriaPackage.ActualizarCategoria", connection);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add("pCategoriaId", OracleDbType.Int32).Value = categoriaId;
                cmd.Parameters.Add("pNuevoNombre", OracleDbType.Varchar2).Value = nuevoNombre;
                cmd.Parameters.Add("pNuevoTipo", OracleDbType.Varchar2).Value = tipo;

                cmd.ExecuteNonQuery();
            }
        }

        public List<Transacciones> TransaccionesPorCategoria(int categoriaId)
        {
            List<Transacciones> transacciones = new List<Transacciones>();


            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                OracleCommand cmd = new OracleCommand("CategoriaPackage.TransaccionesPorCategoria", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("cur", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add("pCategoriaId", OracleDbType.Int32).Value = categoriaId;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["cur"].Value).GetDataReader();


                while (reader.Read())
                {
                    int Id = Convert.ToInt32(reader["Transaccion_id"]);
                    String TipoTransaccion = reader["tipo"].ToString();
                    Decimal Monto = Convert.ToDecimal(reader["Monto"]);
                    DateTime Fecha = Convert.ToDateTime(reader["Fecha"]);
                    String Descripcion = reader["Descripcion"].ToString();
                    int CategoriaId = Convert.ToInt32(reader["Categoria_id"]);
                    int CuentaId = Convert.ToInt32(reader["Cuenta_Id"]);
                    Transacciones transaccion = new Transacciones(Id, TipoTransaccion, Monto, Fecha, Descripcion, CategoriaId, CuentaId);
                    transacciones.Add(transaccion);
                }

            }

            return transacciones;


        }
    }
}
