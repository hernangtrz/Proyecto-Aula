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
        public Double Saldo { get; set; }
        public Transacciones Usuario { get; set; }
        public Transacciones Transacciones { get; set; }
        public Categoria Categoria { get; set; }

        public Cuenta(double saldo, Transacciones usuario, Transacciones transacciones, Categoria categoria)
        {
            this.Saldo = saldo;
            this.Usuario = usuario;
            this.Transacciones = transacciones;
            this.Categoria = categoria;
        }
    }
}
