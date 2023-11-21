using ENTITY;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System;
using Oracle.ManagedDataAccess.Types;

public class CuentaRepository
{
    private readonly string ConnectionString = "user id=hernan;password=h123;data source=" +
                             "(DESCRIPTION=(ADDRESS=(PROTOCOL=tcp)" +
                             "(HOST=localhost)(PORT=1521))(CONNECT_DATA=" +
                             "(SERVICE_NAME=XEPDB1)))";

    public int Guardar(Cuenta cuenta)
    {
        using (OracleConnection connection = new OracleConnection(ConnectionString))
        {
            connection.Open();

            OracleCommand cmd = new OracleCommand("CuentaPackage.CrearCuenta", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.Add("pSaldo", OracleDbType.Decimal).Value = cuenta.Saldo; // Asegúrate de que cuenta.Saldo es de tipo decimal

            cmd.ExecuteNonQuery();

            return ObtenerUltimoIdGenerado(connection); // Implementa este método según la lógica de tu base de datos
        }
    }

    private int ObtenerUltimoIdGenerado(OracleConnection connection)
    {
        using (OracleCommand cmd = new OracleCommand("SELECT cuenta_seq.CURRVAL FROM DUAL", connection))
        {
            int ultimoIdGenerado = Convert.ToInt32(cmd.ExecuteScalar());
            return ultimoIdGenerado;
        }
    }



    public List<Cuenta> ConsultarTodos()
    {
        List<Cuenta> cuentas = new List<Cuenta>();

        using (OracleConnection connection = new OracleConnection(ConnectionString))
        {
            connection.Open();

            OracleCommand cmd = new OracleCommand("CuentaPackage.ConsultarTodos", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("resultado_cursor", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.ExecuteNonQuery();
            OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["resultado_cursor"].Value).GetDataReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Cuenta cuenta = new Cuenta
                    (
                        Convert.ToInt32(reader["Cuenta_id"]),
                        Convert.ToDecimal(reader["Saldo"])
                    );

                    cuentas.Add(cuenta);

                }
            }
            
        }

        return cuentas;
    }

    public Cuenta Buscar(int identificacion)
    {
        Cuenta cuenta = null;

        using (OracleConnection connection = new OracleConnection(ConnectionString))
        {
            connection.Open();

            OracleCommand cmd = new OracleCommand("CuentaPackage.Buscar", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("cur", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.Parameters.Add("pId", OracleDbType.Varchar2).Value = identificacion.ToString();
            cmd.ExecuteNonQuery();
            OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["cur"].Value).GetDataReader();

            if (reader.Read())
            {
                cuenta = new Cuenta
                (
                    Convert.ToInt32(reader["Cuenta_id"]),
                    Convert.ToDecimal(reader["Saldo"])

                );
            }

            return cuenta;
        }
    }

    public void Eliminar(int identificacion)
    {
        using (OracleConnection connection = new OracleConnection(ConnectionString))
        {
            connection.Open();

            OracleCommand cmd = new OracleCommand("CuentaPackage.EliminarCuenta", connection);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("pId", OracleDbType.Varchar2).Value = identificacion.ToString();

            cmd.ExecuteNonQuery();
        }
    }

    public List<Categoria> BuscarCategoriasPorCuenta(int cuentaId)
    {
        List<Categoria> categorias = new List<Categoria>();

        using (OracleConnection connection = new OracleConnection(ConnectionString))
        {
            connection.Open();

            OracleCommand cmd = new OracleCommand("CuentaPackage.BuscarCategorias", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("cur", OracleDbType.RefCursor).Direction = System.Data.ParameterDirection.ReturnValue;
            cmd.Parameters.Add("pCuentaId", OracleDbType.Int32).Value = cuentaId;

            cmd.ExecuteNonQuery();

            OracleDataReader reader = ((OracleRefCursor)cmd.Parameters["cur"].Value).GetDataReader();

            while (reader.Read())
            {
                Categoria categoria;
                categoria = new Categoria
                (
                    Convert.ToInt32(reader["Categoria_id"]),
                    reader["Nombre"].ToString(),
                    reader["Tipo"].ToString()

                );

                categorias.Add(categoria);
            }

            return categorias;
        }
    }

    public void AsociarCategoria(int cuentaId, int categoriaId)
    {
        using (OracleConnection connection = new OracleConnection(ConnectionString))
        {
            connection.Open();

            OracleCommand cmd = new OracleCommand("CuentaPackage.AsociarCategoria", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("pCuentaId", OracleDbType.Int32).Value = cuentaId;
            cmd.Parameters.Add("pCategoriaId", OracleDbType.Int32).Value = categoriaId;

            cmd.ExecuteNonQuery();
        }
    }



}
