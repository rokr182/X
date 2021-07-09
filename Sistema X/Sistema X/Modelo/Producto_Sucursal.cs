using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_X.Modelo
{
    public class Producto_Sucursal
    {
        public int Producto_codigoBarras { get; set; }
        public int Sucursales_idSucursales { get; set; }
        public int cantidad { get; set; }
        public int idProductos_Sucursales { set; get; }
    }
}
