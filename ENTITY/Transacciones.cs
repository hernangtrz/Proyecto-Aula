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
        public Decimal Monto { get; set; }
        public DateTime Fecha { get; set; }
        public int Categoria_id { get; set; }
        public String Descripcion { get; set; }
        public int CuentaId { get; set; }

        public Transacciones(int id, string tipoTransaccion, decimal monto, DateTime fecha, string descripcion, int categoria_id, int cuentaId)
        {
            Id = id;
            TipoTransaccion = tipoTransaccion;
            Monto = monto;
            Fecha = fecha;
            Categoria_id = categoria_id;
            Descripcion = descripcion;
            CuentaId = cuentaId;
        }

        public Transacciones(string tipoTransaccion, Decimal monto, DateTime fecha, string descripcion, int cuentaId, int categoria_id)
        {
            TipoTransaccion = tipoTransaccion;
            Monto = monto;
            Fecha = fecha;
            Descripcion = descripcion;
            CuentaId = cuentaId;
            Categoria_id = categoria_id;

        }

        public Transacciones()
        {
        }
    }
}
