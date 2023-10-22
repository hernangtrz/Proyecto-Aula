using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    [Serializable]
    public class Categoria
    {
        public String Nombre { get; set; }
        public Transacciones Transacciones { get; set; }
        public Double TotalGastado { get; set; }
        public String Presupuesto { get; set; }
        public String Mes { get; set; }

        public Categoria(string nombre, Transacciones transacciones, double totalGastado, string presupuesto, string mes)
        {
            this.Nombre = nombre;
            this.Transacciones = transacciones;
            this.TotalGastado = totalGastado;
            this.Presupuesto = presupuesto;
            this.Mes = mes;
        }

        public Categoria()
        {
        }
    }
}
