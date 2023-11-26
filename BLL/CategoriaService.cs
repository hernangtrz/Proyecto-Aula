using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CategoriaService
    {
        private readonly CategoriaRepository categoriaRepository;
        public CategoriaService()
        {
            categoriaRepository = new CategoriaRepository();
        }



        public string Eliminar(Categoria c, int cuentaId)
        {
            try
            {
                if (categoriaRepository.Buscar(c.Id) != null)
                {
                    categoriaRepository.Eliminar(c.Id,cuentaId);
                    return ($"se han Eliminado Satisfactoriamente los datos de la Categoria: {c.Id} ");
                }
                else
                {
                    return ($"Lo sentimos, no se encuentra registrada una Categoria con Id :  {c.Id}");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicacion: {e.Message}";
            }

        }

 

        public string Guardar(Categoria categoria)
        {
            try
            {

                if (categoriaRepository.Buscar(categoria.Id) == null)
                {

                    categoriaRepository.Guardar(categoria);
                    return $"Se han guardado correctamente los datos de la categoria con la id: {categoria.Id} ";
                }
                else
                {
                    return $"Hubo un error";
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicacion: {e.Message}";
            }
        }

        public ConsultaCategoriaResponse ConsultarTodos()
        {

            try
            {
                List<Categoria> categorias = categoriaRepository.ConsultarTodos();
                if (categorias != null)
                {
                    return new ConsultaCategoriaResponse(categorias);
                }
                else
                {
                    return new ConsultaCategoriaResponse("La categoria buscada no se encuentra Registrada");
                }

            }
            catch (Exception e)
            {

                return new ConsultaCategoriaResponse("Error de Aplicacion: " + e.Message);
            }
        }

        public Categoria BuscarNombre(String nombre)
        {
            return categoriaRepository.BuscarNombre(nombre);
        }

        public Categoria Buscar(int id)
        {
            return categoriaRepository.Buscar(id);
        }


        public class ConsultaCategoriaResponse
        {
            public List<Categoria> Categorias { get; set; }
            public string Message { get; set; }
            public bool Encontrado { get; set; }

            public ConsultaCategoriaResponse(List<Categoria> categorias)
            {
                Categorias = new List<Categoria>();
                Categorias = categorias;
                Encontrado = true;
            }
            public ConsultaCategoriaResponse(string message)
            {
                Message = message;
                Encontrado = false;
            }
        }

        public void ActualizarCategoria(int id, string nombre, string tipo)
        {
            categoriaRepository.ActualizarCategoria(id,nombre,tipo);
        }

        public List<Transacciones> TransaccionesPorCategoria(int categoriaId)
        {
            return categoriaRepository.TransaccionesPorCategoria(categoriaId);
        }
    }
}
