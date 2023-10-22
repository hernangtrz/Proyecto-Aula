using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    [Serializable]
    public class Transacciones
    {
        public int Id { get; set; } 
        public String TipoTransaccion{get; set;}
        public Double Monto { get; set; }
        public DateTime Fecha { get; set; }
        public Categoria Categoria { get; set; }
        public String Descripcion { get; set; }

        public Transacciones(int id, string tipoTransaccion, double monto, DateTime fecha, Categoria categoria, string descripcion)
        {
            Id = id;
            TipoTransaccion = tipoTransaccion;
            Monto = monto;
            Fecha = fecha;
            Categoria = categoria;
            Descripcion = descripcion;
        }

        public Transacciones()
        {
        }
    }
}
