using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Presupuestos
    {
        public int Id { get; set; }
        public Decimal Monto { get; set; }   
        public String Mes { get; set; }
        public Decimal TotalTransferencias { get; set; }        

        public Presupuestos(Decimal monto, string mes)
        {
            this.Monto = monto;
            this.Mes = mes;
        }

        public Presupuestos(int id, Decimal monto, string mes, Decimal TotalTransferencias)
        {
            Id = id;
            Monto = monto;
            Mes = mes;
            this.TotalTransferencias = TotalTransferencias; 
        }
    }
}
