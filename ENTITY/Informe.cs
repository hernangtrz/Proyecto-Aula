using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    [Serializable]
    public class Informe
    {
        public int Id { get; set; }
        public Double Saldo { get; set; }
        public Usuario Usuario { get; set; }
        public List<Transacciones> Transacciones { get; set; }
        public List<Categoria> Categorias { get; set; }

        public Informe(int id, double saldo, Usuario usuario, List<Transacciones> transacciones, List<Categoria> categorias)
        {
            Id = id;
            Saldo = saldo;
            Usuario = usuario;
            Transacciones = transacciones;
            Categorias = categorias;
        }
    }
}
