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
        public String Tipo { get; set; }    
        public int TotalTransacciones { get; set; } 

        public Categoria(string nombre, string tipo)
        {
            Nombre = nombre;
            Tipo = tipo;    
        }

        public Categoria(int id, string nombre, string tipo)
        {
            Id = id;
            Nombre = nombre;
            Tipo = tipo;
        }

        //public void calcularTotalGastado()
        //{
        //    foreach (var item in Transacciones)
        //    {
        //        TotalGastado = TotalGastado + item.Monto;                
        //    }
        //}

    }
}
