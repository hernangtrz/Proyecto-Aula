using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    [Serializable]
    public class Cuenta
    {
        public int Id { get; set; } 
        public Double Saldo { get; set; }
        public Usuario Usuario { get; set; }
        public List<Transacciones> Transacciones { get; set; }
        public List<Categoria> Categorias { get; set; }
        public Informe Informe { get; set; }

        public Cuenta(int id, Usuario usuario, List<Transacciones> transacciones, List<Categoria> categorias, Informe informe)
        {
            Id = id;
            Usuario = usuario;
            Transacciones = transacciones;
            Categorias = categorias;
            Informe = informe;
        }

        public Cuenta()
        {
        }

        public void calcularSaldo()
        {
            Double ingresos = 0;
            Double gastos = 0;

            foreach (var item in Transacciones)
            {
                if(item.TipoTransaccion == "Ingreso")
                {
                    ingresos += item.Monto;
                }
                else
                {
                    gastos += item.Monto;
                }
            }
            Saldo = ingresos - gastos;
        }
    }
}
