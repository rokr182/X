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
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            lblSucursal.Text = Sesion.sucursal.nombreSucursal.ToString();
            lblUsuario.Text = Sesion.usuario.Usuario.ToString();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            Inventario inv = new Inventario();
            inv.Show();
        }

        private void btnSucursales_Click(object sender, EventArgs e)
        {
            Sucursales suc = new Sucursales();
            suc.Show();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Modelo.Inventario prodcuto = null;
            int codigo;
            int index = -1;
            int cantidad = 1;
            int cantidaddgv = 0;
            if (Convert.ToInt32(e.KeyChar) == 13)
            {
                //MessageBox.Show(" Enter pressed ");
                codigo = Convert.ToInt32(txtCodigo.Text);
                Controlador.Controlador ctrl = new Controlador.Controlador();
                prodcuto = ctrl.datosProducto(codigo);
                if(prodcuto != null)
                {
                    if (agregado(codigo, index))
                    {
                        txtCodigo.Text = "";
                        txtCodigo.Focus();
                    }
                    else 
                    {
                        dgvVenta.Rows.Add(codigo, prodcuto.producto.nombreProducto, cantidad, prodcuto.producto.precio);
                        txtCodigo.Text = "";
                        txtCodigo.Focus();
                    }
                    
                }
            }
        }


        public bool agregado(int codigo, int index)
        {
            bool ok = false;

            for (int i = 0; i < dgvVenta.Rows.Count; i++)
            {
                index = i;
                if(Convert.ToInt32(dgvVenta.Rows[index].Cells[0].Value.ToString()) == codigo)
                {
                    dgvVenta.Rows[index].Cells[2].Value = Convert.ToInt32(dgvVenta.Rows[index].Cells[2].Value.ToString()) + 1;
                    ok = true;
                    break;
                }

            }
            return ok;

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {

        }
    }


}
