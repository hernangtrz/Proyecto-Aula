using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Transacciones
    {
        public String tipoTransaccion{get; set;}
        public Double monto { get; set; }
        public DateTime Fecha { get; set; }
        public Categoria Categoria { get; set; }
        public String FuenteIngreso { get; set; }
        public String Descripcion { get; set; }


    }
}
