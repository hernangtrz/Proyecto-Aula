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
    public class CategoriaRepository
    {
        private readonly string FileName = "Categorias.dat";

        public void Eliminar(int id)
        {
            List<Categoria> categorias = new List<Categoria>();
            categorias = ConsultarTodos();
            categorias.RemoveAll(obj => obj.Id == id);
            using (Stream file = File.Open(FileName, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(file, categorias);
            }

        }

        public void Guardar(Categoria categoria)
        {
            List<Categoria> categorias = ConsultarTodos();
            categorias.Add(categoria);
            BinaryFormatter formatter = new BinaryFormatter();

            FileStream stream = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.Write);
            formatter.Serialize(stream, categorias);
            stream.Close();


        }

        public List<Categoria> ConsultarTodos()
        {
            List<Categoria> categorias = new List<Categoria>();
            FileStream file = new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryFormatter formatter = new BinaryFormatter();

            if (new FileInfo(FileName).Length == 0)
            {
                Console.WriteLine("El archivo está vacío.");
                formatter.Serialize(file, categorias);
            }
            categorias = (List<Categoria>)formatter.Deserialize(file);
            file.Close();
            return categorias;
        }

        private bool EsEncontrado(Categoria t, int identificacionBuscada)
        {
            return t.Id == identificacionBuscada;
        }

        public Categoria Buscar(int identificacion)
        {
            List<Categoria> categorias = ConsultarTodos();
            foreach (var item in categorias)
            {
                if (EsEncontrado(item, identificacion))
                {
                    return item;
                }
            }
            return null;
        }

        public Categoria BuscarNombre(String nombre)
        {
            List<Categoria> categorias = ConsultarTodos();
            foreach (var item in categorias)
            {
                if (String.Equals(item.Nombre, nombre, StringComparison.OrdinalIgnoreCase))
                {
                    return item;
                }
            }
            return null;
        }
    }
}
