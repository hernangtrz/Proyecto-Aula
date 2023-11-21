using ENTITY;
using System;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.Runtime.InteropServices.ComTypes;
using System.Data;
using Oracle.ManagedDataAccess.Types;

namespace DAL
{
    public class TransaccionRepository
    {
        private readonly string ConnectionString = "user id=hernan;password=h123;data source=" +
                             "(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" +
                             "(HOST=localhost)(PORT=1521))(CONNECT_DATA=" +
                             "(SERVICE_NAME=XEPDB1)))";

        public void Eliminar(int id)
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                OracleCommand cmd = new OracleCommand("TransaccionPackage.EliminarTransaccion", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pId", OracleDbType.Int32).Value = id;

                cmd.ExecuteNonQuery();
            }
        }

        public void Guardar(Transacciones transaccion)
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                OracleCommand cmd = new OracleCommand("TransaccionPackage.CrearTransaccion", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pTipo", OracleDbType.Varchar2).Value = transaccion.TipoTransaccion;
                cmd.Parameters.Add("pMonto", OracleDbType.Decimal).Value = transaccion.Monto;
                cmd.Parameters.Add("pFecha", OracleDbType.Date).Value = transaccion.Fecha;
                cmd.Parameters.Add("pDescripcion", OracleDbType.Varchar2).Value = transaccion.Descripcion;
                cmd.Parameters.Add("pCuentaId", OracleDbType.Int32).Value = transaccion.CuentaId;
                cmd.Parameters.Add("pCategoriaId", OracleDbType.Int32).Value = transaccion.Categoria_id;


                cmd.ExecuteNonQuery();
            }
        }

        public List<Transacciones> ConsultarTodos()
        {
            List<Transacciones> transacciones = new List<Transacciones>();

            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                OracleCommand cmd = new OracleCommand("TransaccionPackage.ConsultarTodos", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("cur", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Transacciones transaccion = new Transacciones
                    {
                        Id = Convert.ToInt32(reader["Transaccion_id"]),
                        TipoTransaccion = reader["tipo"].ToString(),
                        Monto = Convert.ToDecimal(reader["Monto"]),
                        Fecha = Convert.ToDateTime(reader["Fecha"]),
                        Descripcion = reader["Descripcion"].ToString(),
                        CuentaId = Convert.ToInt32(reader["Cuenta_Id"])
                    };

                    transacciones.Add(transaccion);
                }
            }

            return transacciones;
        }

        public List<Transacciones> BuscarPorCuenta(int id)
        {
            List<Transacciones> transacciones = new List<Transacciones>();


            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                OracleCommand cmd = new OracleCommand("TransaccionPackage.BuscarPorCuenta", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("cur", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add("pId", OracleDbType.Int32).Value = id;
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

        public Transacciones Buscar(int id)
        {
            Transacciones transaccion = null;

            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                OracleCommand cmd = new OracleCommand("TransaccionPackage.Buscar", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("cur", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.ReturnValue;
                cmd.Parameters.Add("pId", OracleDbType.Int32).Value = id;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["cur"].Value).GetDataReader();


                if (reader.Read())
                {
                    int Id = Convert.ToInt32(reader["Transaccion_id"]);
                    String TipoTransaccion = reader["tipo"].ToString();
                    Decimal Monto = Convert.ToDecimal(reader["Monto"]);
                    DateTime Fecha = Convert.ToDateTime(reader["Fecha"]);
                    String Descripcion = reader["Descripcion"].ToString();
                    int CategoriaId = Convert.ToInt32(reader["Categoria_id"]);
                    int CuentaId = Convert.ToInt32(reader["Cuenta_Id"]);
                    transaccion = new Transacciones(Id, TipoTransaccion, Monto, Fecha, Descripcion, CategoriaId, CuentaId);

                }
            }

            return transaccion;
        }
    }
}
