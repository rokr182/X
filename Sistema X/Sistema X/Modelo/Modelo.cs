using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Forms;


namespace Sistema_X.Modelo
{
    class Modelo
    {
        public Usuarios datosUsuarios(string usuario)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "SELECT idUsuario, nomUsuario, passUsuario FROM usuario WHERE nomUsuario = @usuario";
            MySqlCommand com = new MySqlCommand(sql,conexion);
            com.Parameters.AddWithValue("@usuario", usuario);
            
            reader = com.ExecuteReader();

            Usuarios usr = null;
            while (reader.Read())
            {
                usr = new Usuarios();
                usr.id = Convert.ToInt32( reader["idUsuario"].ToString());
                usr.Usuario = reader["nomUsuario"].ToString();
                usr.Password = reader["passUsuario"].ToString();
            }
            conexion.Close();
            return usr;
           
        }

        public List<Sucursales> llenarSucursales()
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "SELECT idSucursal, nomSucursal, dirSucursal FROM xbd.sucursales;";
            MySqlCommand com = new MySqlCommand(sql, conexion);
            

            reader = com.ExecuteReader();

            List<Sucursales> suc = new List<Sucursales>();
            while (reader.Read())
            {
                Sucursales datosSucursal = new Sucursales();
                datosSucursal.idSucursal = Convert.ToInt32(reader["idSucursal"].ToString());
                datosSucursal.nombreSucursal = reader["nomSucursal"].ToString();
                datosSucursal.direccionSucursal = reader["dirSucursal"].ToString();
                suc.Add(datosSucursal);
            }
            conexion.Close();
            return suc;
        }

        public Sucursales datosSucursal(string nombreSucursal)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "SELECT idSucursal, nomSucursal, dirSucursal FROM xbd.sucursales WHERE nomSucursal = @nombreSucursal;";
            MySqlCommand com = new MySqlCommand(sql, conexion);
            com.Parameters.AddWithValue("@nombreSucursal", nombreSucursal);

            reader = com.ExecuteReader();

            Sucursales suc = null;
            while (reader.Read())
            {
                suc = new Sucursales();
                suc.idSucursal = Convert.ToInt32(reader["idSucursal"].ToString());
                suc.nombreSucursal = reader["nomSucursal"].ToString();
                suc.direccionSucursal = reader["dirSucursal"].ToString();
            }
            conexion.Close();
            return suc;
        }


        public DataTable llenarInventario()
        {
            int idSucursal = Sesion.sucursal.idSucursal;
            DataTable dt = new DataTable();
            MySqlConnection conexion = Conexion.getConexion();
            string Consulta = "call LlenarInventario (@idSucursal); ";
            MySqlCommand com = new MySqlCommand(Consulta, conexion);
            com.Parameters.AddWithValue("@idSucursal", idSucursal);

            try
            {
                conexion.Open();
                com.Connection = conexion;
                MySqlDataAdapter adap = new MySqlDataAdapter(com);
                adap.Fill(dt);
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error >>> " + ex.Message);
            }
            finally
            {
                conexion.Dispose();
            }
            return dt;
        }


        public Inventario Producto(int codigo)
        {
            int sucursal = Sesion.sucursal.idSucursal;
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "call xbd.UnProducto(@codigo, @sucursal);";
            MySqlCommand com = new MySqlCommand(sql, conexion);
            com.Parameters.AddWithValue("@codigo", codigo);
            com.Parameters.AddWithValue("@sucursal", sucursal);

            reader = com.ExecuteReader();

            Inventario producto = null;
            
            
            while (reader.Read())
            {
                producto = new Inventario();
                producto.producto.codigoBarras = Convert.ToInt32(reader["codigoBarras"].ToString());
                producto.producto.nombreProducto = reader["nomProducto"].ToString();
                producto.producto.precio = Convert.ToDouble( reader["precio"].ToString());
                producto.producto_sucursal.cantidad = Convert.ToInt32(reader["cantidad"].ToString());
                producto.sucursal.nombreSucursal = Sesion.sucursal.nombreSucursal;
                producto.producto_sucursal.idProductos_Sucursales = Convert.ToInt32(reader["idProductos_Sucursales"]);
            }
            conexion.Close();
            return producto;

        }


        public bool InsertarOActualizarProducto(Inventario datosProducto)
        {

            bool ok = false;
            try
            {
                MySqlConnection conexion = Conexion.getConexion();
                conexion.Open();
                string sql = "call xbd.AgregarOActualizar(@codigo, @nombre, @precio, @cantidad, @idSucursal, @idProducto_Sucursal);";
                MySqlCommand com = new MySqlCommand(sql, conexion);
                com.Parameters.AddWithValue("@codigo", datosProducto.producto.codigoBarras.ToString()); ;
                com.Parameters.AddWithValue("@nombre", datosProducto.producto.nombreProducto.ToString());
                com.Parameters.AddWithValue("@precio", datosProducto.producto.precio.ToString());
                com.Parameters.AddWithValue("@cantidad", datosProducto.producto_sucursal.cantidad.ToString());
                com.Parameters.AddWithValue("@idSucursal", Sesion.sucursal.idSucursal.ToString());
                com.Parameters.AddWithValue("@idProducto_Sucursal", datosProducto.producto_sucursal.idProductos_Sucursales.ToString());
                com.ExecuteNonQuery();
                conexion.Close();
                ok = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); 
            }
            return ok;
        }


        public Sucursales datosSucursal(int idSucursal)
        {
            MySqlDataReader reader;
            MySqlConnection conexion = Conexion.getConexion();
            conexion.Open();

            string sql = "SELECT idSucursal, nomSucursal, dirSucursal FROM xbd.sucursales WHERE idSucursal = @idSucursal;";
            MySqlCommand com = new MySqlCommand(sql, conexion);
            com.Parameters.AddWithValue("@idSucursal", idSucursal);

            reader = com.ExecuteReader();

            Sucursales suc = null;
            while (reader.Read())
            {
                suc = new Sucursales();
                suc.idSucursal = Convert.ToInt32(reader["idSucursal"].ToString());
                suc.nombreSucursal = reader["nomSucursal"].ToString();
                suc.direccionSucursal = reader["dirSucursal"].ToString();
            }
            conexion.Close();
            return suc;
        }


        public bool InsertarOActualizarSucursal(Sucursales datosSucursal)
        {

            bool ok = false;
            try
            {
                MySqlConnection conexion = Conexion.getConexion();
                conexion.Open();
                string sql = "call xbd.AgregarOActualizarSucursal(@idSucursal, @nombre, @direccion);";
                MySqlCommand com = new MySqlCommand(sql, conexion);
                com.Parameters.AddWithValue("@idSucursal", datosSucursal.idSucursal.ToString()); ;
                com.Parameters.AddWithValue("@nombre", datosSucursal.nombreSucursal.ToString());
                com.Parameters.AddWithValue("@direccion", datosSucursal.direccionSucursal.ToString());
                
                com.ExecuteNonQuery();
                conexion.Close();
                ok = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return ok;
        }


        public DataTable buscarProducto( int codigo)
        {
            int idSucursal = Sesion.sucursal.idSucursal;
            DataTable dt = new DataTable();
            MySqlConnection conexion = Conexion.getConexion();
            string Consulta = "call buscarProducto (@codigo,@idSucursal); ";
            MySqlCommand com = new MySqlCommand(Consulta, conexion);
            com.Parameters.AddWithValue("@idSucursal", idSucursal);
            com.Parameters.AddWithValue("@codigo", codigo);

            try
            {
                conexion.Open();
                com.Connection = conexion;
                MySqlDataAdapter adap = new MySqlDataAdapter(com);
                adap.Fill(dt);
                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("error >>> " + ex.Message);
            }
            finally
            {
                conexion.Dispose();
            }
            return dt;
        }
    }
}
