using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistema_X.Modelo;
using System.Data;

namespace Sistema_X.Controlador
{
    public class Controlador
    {
        Modelo.Modelo modelo = new Modelo.Modelo();

        public string Login(string usuario, string password,string sucursal)
        {
            
            string Mensaje = "";
            Usuarios datosUsuario = null;
            Modelo.Sucursales datosSucursal = null;

            if(string.IsNullOrEmpty(usuario)||string.IsNullOrEmpty(password))
            {
                Mensaje = "LLENAR TODOS LOS CAMPOS!";
            }
            else
            {
                datosUsuario = modelo.datosUsuarios(usuario);
                datosSucursal = modelo.datosSucursal(sucursal);

                if (datosUsuario == null)
                {
                    Mensaje = "El usuario no existe!";
                }
                else
                {
                    if(password != datosUsuario.Password)
                    {
                        Mensaje = "El usuario/password no existe!";
                    }
                    else
                    {
                        
                        Sesion.usuario = datosUsuario;
                        Sesion.sucursal = datosSucursal;
                    }
                }
            }

            return Mensaje;

        }

        public List<Modelo.Sucursales> llenarcbSucursales()
        {
            
            return modelo.llenarSucursales(); 
        }

        public DataTable Inventario()
        {
           
            DataTable dt = modelo.llenarInventario();
            return dt;
        }

        public Modelo.Inventario datosProducto(int codigo)
        {
            
            return modelo.Producto(codigo);
        }


        public bool actualizarProducto(Modelo.Inventario datosProducto)
        {
            return modelo.InsertarOActualizarProducto(datosProducto);

            
        }


        public Modelo.Sucursales sucursal(int idSucursal)
        {
            return modelo.datosSucursal(idSucursal);

            
        }


        public bool actualizarSucursal(Modelo.Sucursales datosSucursal)
        {
            return modelo.InsertarOActualizarSucursal(datosSucursal);
        }

    }
}
