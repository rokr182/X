using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_X.Modelo
{
    class Modelos
    {
        public interface Usuario
        {
            int id { get; set; }
            string Usuario { get; set; }
            string Password { get; set; }
        }
    }

    
}
