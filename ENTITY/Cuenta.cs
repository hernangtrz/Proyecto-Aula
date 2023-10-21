using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class Cuenta
    {
        public Double Saldo { get; set; }
        public Usuario Usuario { get; set; }
        public Transacciones Transacciones { get; set; }
        public Categoria Categoria { get; set; }

        public Cuenta(double saldo, Usuario usuario, Transacciones transacciones, Categoria categoria)
        {
            Saldo = saldo;
            Usuario = usuario;
            Transacciones = transacciones;
            Categoria = categoria;
        }
    }
}
