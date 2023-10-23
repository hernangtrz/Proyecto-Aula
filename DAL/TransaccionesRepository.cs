using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO.Pipes;
using System.Runtime.InteropServices.ComTypes;

namespace DAL
{
    public class TransaccionesRepository
    {
        private readonly string FileName = "Transacciones.dat";

        //public void Eliminar(int id)
        //{
        //    List<Transacciones> transacciones = new List<Transacciones>();
        //    transacciones = ConsultarTodos();
        //    FileStream file = new FileStream(FileName, FileMode.Create);
        //    file.Close();
        //    foreach (var item in transacciones)
        //    {
        //        if (!EsEncontrado(item, id))
        //        {
        //            Guardar(item);
        //        }

        //    }

        //}

        public void Guardar(Transacciones transaccion)
        {
            List<Transacciones> transacciones = ConsultarTodos();
            transacciones.Add(transaccion); 
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            formatter.Serialize(stream, transacciones);
            stream.Close();
            

        }

        public List<Transacciones> ConsultarTodos()
        {
            List<Transacciones> transacciones = new List<Transacciones>();
            FileStream file = new FileStream(FileName, FileMode.Open, FileAccess.ReadWrite);
            BinaryFormatter formatter = new BinaryFormatter();

            if (new FileInfo(FileName).Length == 0)
             {
                Console.WriteLine("El archivo está vacío.");
                formatter.Serialize(file, transacciones);
            }
            transacciones = (List<Transacciones>)formatter.Deserialize(file);
            file.Close();
            return transacciones;
        }

        private bool EsEncontrado(Transacciones t, int identificacionBuscada)
        {
            return t.Id == identificacionBuscada;
        }

        public Transacciones Buscar(int identificacion)
        {
            List<Transacciones> transacciones = ConsultarTodos();
            foreach (var item in transacciones)
            {
                if (EsEncontrado(item, identificacion))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
