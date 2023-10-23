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
        public int Id { get; set; } 
        public String Nombre { get; set; }
        public Double Presupuesto { get; set; }
        public String Mes { get; set; }
        public List<Transacciones> Transacciones { get; set; }
        public Double TotalGastado { get; set; } = 0;

        public Categoria(int id, string nombre, Double presupuesto, string mes, List<Transacciones> transacciones)
        {
            Id = id;
            Nombre = nombre;
            Presupuesto = presupuesto;
            Mes = mes;
            Transacciones = transacciones;
        }

        public void calcularTotalGastato()
        {
            foreach (var item in Transacciones)
            {
                TotalGastado = TotalGastado + item.Monto;                
            }
        }
        public Categoria()
        {
        }
    }
}
