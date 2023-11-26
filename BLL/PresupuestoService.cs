using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class PresupuestoService
    {
        private readonly PresupuestoRepository presupuestoRepository;
        public PresupuestoService()
        {
            presupuestoRepository = new PresupuestoRepository();
        }



        //public string Eliminar(int Id)
        //{
        //    try
        //    {
        //        if (cuentaRepository.Buscar(Id) != null)
        //        {
        //            cuentaRepository.Eliminar(Id);
        //            return ($"se han Eliminado Satisfactoriamente la cuenta: {Id} ");
        //        }
        //        else
        //        {
        //            return ($"Lo sentimos, no se encuentra registrada una cuenta con Id :  {Id}");
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        return $"Error de la Aplicacion: {e.Message}";
        //    }

        //}

        public int Guardar(Presupuestos presupuesto)
        {
            return presupuestoRepository.Guardar(presupuesto);

        }

        public ConsultaPresupuestoResponse ConsultarTodos()
        {

            try
            {
                List<Presupuestos> presupuestos = presupuestoRepository.ConsultarTodos();
                if (presupuestos != null)
                {
                    return new ConsultaPresupuestoResponse(presupuestos);
                }
                else
                {
                    return new ConsultaPresupuestoResponse("El presupuesto buscado no se encuentra Registrada");
                }

            }
            catch (Exception e)
            {

                return new ConsultaPresupuestoResponse("Error de Aplicacion: " + e.Message);
            }
        }

        public class ConsultaPresupuestoResponse
        {
            public List<Presupuestos> Presupuestos { get; set; }
            public string Message { get; set; }
            public bool Encontrado { get; set; }

            public ConsultaPresupuestoResponse(List<Presupuestos> presupuestos)
            {
                Presupuestos = new List<Presupuestos>();
                Presupuestos = presupuestos;
                Encontrado = true;
            }
            public ConsultaPresupuestoResponse(string message)
            {
                Message = message;
                Encontrado = false;
            }
        }

        public Presupuestos buscar(int id)
        {
            return presupuestoRepository.Buscar(id);
        }

        public Categoria buscarCategoriaPorPresupuesto(int id)
        {
            return presupuestoRepository.BuscarCategoriaPorPresupuesto(id);
        }

        public void AsignarPresupuestoACategoria(int categoriaId, int presupuestoId, int cuentaId)
        {
            presupuestoRepository.AsignarPresupuestoACategoria(categoriaId, presupuestoId, cuentaId);
        }

    }
}
