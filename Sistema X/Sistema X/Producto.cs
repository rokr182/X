using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_X.Modelo;

namespace Sistema_X
{
    public partial class Producto : Form
    {
        Modelo.Inventario datosProducto;
        public Producto(Modelo.Inventario datosProducto)
        {
            this.datosProducto = datosProducto;
            InitializeComponent();
            acomodar();

        }

        public void acomodar()
        {
            txtCodigoBarras.Text = datosProducto.producto.codigoBarras.ToString() ;
            if (txtCodigoBarras.Text.Length > 1)
            {
                txtCodigoBarras.Enabled = false;

            }
            
            txtNombreProducto.Text = datosProducto.producto.nombreProducto.ToString();
            txtPrecio.Text = datosProducto.producto.precio.ToString();
            txtCantidad.Text = datosProducto.producto_sucursal.cantidad.ToString();
            txtSucursal.Text = Sesion.sucursal.nombreSucursal.ToString();


        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            datosProducto.producto.codigoBarras = Convert.ToInt32(txtCodigoBarras.Text);
            datosProducto.producto.nombreProducto = txtNombreProducto.Text;
            datosProducto.producto.precio = Convert.ToDouble(txtPrecio.Text);
            datosProducto.producto_sucursal.cantidad = Convert.ToInt32(txtCantidad.Text);


            Controlador.Controlador ctrl = new Controlador.Controlador();
            
            if (ctrl.actualizarProducto(datosProducto))
            {
                this.Close();
            }
           


           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
