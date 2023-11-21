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
        public Decimal Saldo { get; set; } = 0;
       

        public Cuenta(Decimal saldo)
        {
            Saldo = saldo;
        }

        public Cuenta(int id, decimal saldo)
        {
            Id = id;
            Saldo = saldo;
        }
    }
}
