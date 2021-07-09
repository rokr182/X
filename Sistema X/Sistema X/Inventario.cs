using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema_X.Controlador;

namespace Sistema_X
{
    public partial class Inventario : Form
    {
        public Inventario()
        {
            InitializeComponent();
            Acomodar();

        }

        private void dgvInventario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Controlador.Controlador ctrl = new Controlador.Controlador();
            int CodgioBarra = Convert.ToInt32(dgvInventario.CurrentRow.Cells[0].Value.ToString());
            Producto prd = new Producto(ctrl.datosProducto(CodgioBarra));
            prd.ShowDialog();
            Acomodar();
        }

        public void Acomodar()
        {
            Controlador.Controlador ctrl = new Controlador.Controlador();
            dgvInventario.DataSource = ctrl.Inventario();
        }

        private void btnNuevoProducto_Click(object sender, EventArgs e)
        {
            Modelo.Inventario inventario = new Modelo.Inventario();
            inventario.producto.codigoBarras = 0;
            inventario.producto.nombreProducto = "";
            inventario.producto.precio = 0;
            inventario.producto_sucursal.cantidad = 0;
            inventario.producto_sucursal.idProductos_Sucursales = 0;
            Producto prd = new Producto(inventario);
            prd.ShowDialog();
            Acomodar();
        }
    }
}
