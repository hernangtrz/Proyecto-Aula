using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class InformeService
    {
        private readonly InformeRepository informeRepository;

        public InformeService(InformeRepository informeRepository)
        {
            this.informeRepository = informeRepository;
        }


    }
}
