using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class CuentaRepository
    {
        private readonly string FileName = "Cuentas.dat";

        public void Eliminar(int id)
        {
            List<Cuenta> cuentas = new List<Cuenta>();
            cuentas = ConsultarTodos();
            cuentas.RemoveAll(obj => obj.Id == id);
            using (Stream file = File.Open(FileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(file, cuentas);
            }

        }

        public void Guardar(Cuenta cuenta)
        {
            List<Cuenta> cuentas = ConsultarTodos();
            cuentas.Add(cuenta);
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            formatter.Serialize(stream, cuentas);
            stream.Close();


        }

        public List<Cuenta> ConsultarTodos()
        {
            List<Cuenta> cuentas = new List<Cuenta>();
            BinaryFormatter formatter = new BinaryFormatter();
            if (File.Exists(FileName) && new FileInfo(FileName).Length > 0)
            {
                using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    return (List<Cuenta>)formatter.Deserialize(fs);
                }
            }
            else
            {
                using (FileStream fs = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    formatter.Serialize(fs, cuentas);
                    return cuentas;
                }
            }
        }

        private bool EsEncontrado(int identificacion, int identificacionBuscada)
        {
            return identificacion == identificacionBuscada;
        }

        public Cuenta Buscar(int identificacion)
        {
            List<Cuenta> cuentas = ConsultarTodos();
            foreach (var item in cuentas)
            {
                if (EsEncontrado(item.Id, identificacion))
                {
                    return item;
                }
            }
            return null;
        }

        public Cuenta BuscarUsuario(int identificacion)
        {
            List<Cuenta> cuentas = ConsultarTodos();
            foreach (var item in cuentas)
            {
                if (EsEncontrado(item.Usuario.Id, identificacion))
                {
                    return item;
                }
            }
            return null;
        }

    }
}
