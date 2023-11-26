using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CuentaService
    {
        private readonly CuentaRepository cuentaRepository;
        public CuentaService()
        {
            cuentaRepository = new CuentaRepository();
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

        public string Guardar(Cuenta cuenta)
        {
            try
            {
                cuentaRepository.Guardar(cuenta);
                
                return $"Se han guardado correctamente los datos de la cuenta con la id: {cuenta.Id} ";
            }
            catch (Exception e)
            {

                return $"Error de la Aplicacion cuenta: {e.Message}";
            }
        }

        public ConsultaCuentaResponse ConsultarTodos()
        {

            try
            {
                List<Cuenta> cuentas = cuentaRepository.ConsultarTodos();
                if (cuentas != null)
                {
                    return new ConsultaCuentaResponse(cuentas);
                }
                else
                {
                    return new ConsultaCuentaResponse("La cuenta buscada no se encuentra Registrada");
                }

            }
            catch (Exception e)
            {

                return new ConsultaCuentaResponse("Error de Aplicacion cuenta: " + e.Message);
            }
        }

        public class ConsultaCuentaResponse
        {
            public List<Cuenta> Cuentas { get; set; }
            public string Message { get; set; }
            public bool Encontrado { get; set; }

            public ConsultaCuentaResponse(List<Cuenta> cuentas)
            {
                Cuentas = new List<Cuenta>();
                Cuentas = cuentas;
                Encontrado = true;
            }
            public ConsultaCuentaResponse(string message)
            {
                Message = message;
                Encontrado = false;
            }
        }

        public Cuenta buscar(int id)
        {
            return cuentaRepository.Buscar(id);
        }

        public List<Categoria> BuscarCategorias(int id)
        {
            return cuentaRepository.BuscarCategoriasPorCuenta(id);
        }

        public void AsociarCategoria(int idCuenta, int idCategoria) {
            cuentaRepository.AsociarCategoria(idCuenta, idCategoria);
        }

        public List<Presupuestos> BuscarPresupuestos(int id)
        {
            return cuentaRepository.BuscarPresupuestosPorCuenta(id);
        }
    }
}
