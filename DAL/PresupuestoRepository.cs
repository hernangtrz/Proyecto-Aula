using ENTITY;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PresupuestoRepository
    {
        private readonly string ConnectionString = "user id=hernan;password=h123;data source=" +
                             "(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" +
                             "(HOST=localhost)(PORT=1521))(CONNECT_DATA=" +
                             "(SERVICE_NAME=XEPDB1)))";

        public void Eliminar(int presupuestoId)
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                OracleCommand cmd = new OracleCommand("PresupuestoPackage.EliminarPresupuesto", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pPresupuestoId", OracleDbType.Int32).Value = presupuestoId;

                cmd.ExecuteNonQuery();
            }
        }

        public int Guardar(Presupuestos presupuesto)
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                OracleCommand cmd = new OracleCommand("PresupuestoPackage.CrearPresupuesto", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pMonto", OracleDbType.Decimal).Value = presupuesto.Monto;
                cmd.Parameters.Add("pMes", OracleDbType.Varchar2).Value = presupuesto.Mes;

                cmd.ExecuteNonQuery();
                return ObtenerUltimoIdGenerado(connection); // Implementa este método según la lógica de tu base de datos

            }
        }

        private int ObtenerUltimoIdGenerado(OracleConnection connection)
        {
            using (OracleCommand cmd = new OracleCommand("SELECT presupuesto_seq.CURRVAL FROM DUAL", connection))
            {
                int ultimoIdGenerado = Convert.ToInt32(cmd.ExecuteScalar());
                return ultimoIdGenerado;
            }
        }

        public List<Presupuestos> ConsultarTodos()
        {
            List<Presupuestos> presupuestos = new List<Presupuestos>();

            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                OracleCommand cmd = new OracleCommand("PresupuestoPackage.ConsultarTodos", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                OracleDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Presupuestos presupuesto = new Presupuestos
                    (
                        int.Parse(reader["PRESUPUESTO_ID"].ToString()),
                        Convert.ToDecimal(reader["MONTO"]),
                        reader["MES"].ToString(),
                        int.Parse(reader["TotalTransacciones"].ToString())
                    );

                    presupuestos.Add(presupuesto);
                }
            }

            return presupuestos;
        }

        public Presupuestos Buscar(int presupuestoId)
        {
            Presupuestos presupuesto = null;

            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                OracleCommand cmd = new OracleCommand("PresupuestoPackage.Buscar", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("pPresupuestoId", OracleDbType.Int32).Value = presupuestoId;

                OracleDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    presupuesto = new Presupuestos
                    (
                        int.Parse(reader["PRESUPUESTO_ID"].ToString()),
                        Convert.ToDecimal(reader["MONTO"]),
                        reader["MES"].ToString(),
                        int.Parse(reader["TotalTransacciones"].ToString())
                    );
                }
            }

            return presupuesto;
        }

        public void AsignarPresupuestoACategoria(int categoriaId, int presupuestoId, int cuentaId)
        {
            using (OracleConnection connection = new OracleConnection(ConnectionString))
            {
                connection.Open();

                using (OracleCommand cmd = new OracleCommand("PresupuestoPackage.AsignarPresupuestoACategoria", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.Add("p_CategoriaId", OracleDbType.Int32).Value = categoriaId;
                    cmd.Parameters.Add("p_PresupuestoId", OracleDbType.Int32).Value = presupuestoId;
                    cmd.Parameters.Add("p_CuentaId", OracleDbType.Int32).Value = cuentaId;

                    cmd.ExecuteNonQuery();
                }
            }

        }

    }
}
