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
    }
}
