﻿using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TransaccionesService
    {
        private readonly TransaccionRepository transaccionesRepository;
        public TransaccionesService()
        {
            transaccionesRepository = new TransaccionRepository();
        }

        

        public string Eliminar(int Id)
        {
            try
            {
                if (transaccionesRepository.Buscar(Id) != null)
                {
                    transaccionesRepository.Eliminar(Id);
                    return ($"se han Eliminado Satisfactoriamente los datos de la Transaccion: {Id} ");
                }
                else
                {
                    return ($"Lo sentimos, no se encuentra registrada una Transaccion con Id :  {Id}");
                }
            }
            catch (Exception e)
            {

                return $"Error de la Aplicacion: {e.Message}";
            }

        }

        public string Guardar(Transacciones transaccion)
        {
            try
            {

                if (transaccionesRepository.Buscar(transaccion.Id) == null)
                {

                    transaccionesRepository.Guardar(transaccion);
                    return $"Se han guardado correctamente los datos de la transaccion";
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

        public ConsultaTransaccionResponse ConsultarTodos()
        {

            try
            {
                List<Transacciones> transacciones = transaccionesRepository.ConsultarTodos();
                if (transacciones != null)
                {
                    return new ConsultaTransaccionResponse(transacciones);
                }
                else
                {
                    return new ConsultaTransaccionResponse("La transaccion buscada no se encuentra Registrada");
                }

            }
            catch (Exception e)
            {

                return new ConsultaTransaccionResponse("Error de Aplicacion: " + e.Message);
            }
        }

        public List<Transacciones> BuscarPorCuenta(int id)
        {
            return transaccionesRepository.BuscarPorCuenta(id);                
        }

        public class ConsultaTransaccionResponse
        {
            public List<Transacciones> Transacciones { get; set; }
            public string Message { get; set; }
            public bool Encontrado { get; set; }

            public ConsultaTransaccionResponse(List<Transacciones> transacciones)
            {
                Transacciones = new List<Transacciones>();
                Transacciones = transacciones;
                Encontrado = true;
            }
            public ConsultaTransaccionResponse(string message)
            {
                Message = message;
                Encontrado = false;
            }
        }
    }
}
