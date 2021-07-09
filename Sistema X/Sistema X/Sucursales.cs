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
    public partial class Sucursales : Form
    {
        public Sucursales()
        {
            InitializeComponent();
            cargarSucursales();
        }


        public void cargarSucursales()
        {
            dgvSucursales.Rows.Clear();
            Controlador.Controlador ctrl = new Controlador.Controlador();
            foreach(Modelo.Sucursales suc in ctrl.llenarcbSucursales() )
            {
                
                dgvSucursales.Rows.Add(suc.idSucursal,suc.nombreSucursal,suc.direccionSucursal);
            }
            

        }

        private void dgvSucursales_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Controlador.Controlador ctrl = new Controlador.Controlador();
            int idSucursal = Convert.ToInt32(dgvSucursales.CurrentRow.Cells[0].Value.ToString());
            infoSucursal prd = new infoSucursal(ctrl.sucursal(idSucursal));
            prd.ShowDialog();
            cargarSucursales();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Modelo.Sucursales sucursales = new Modelo.Sucursales();
            sucursales.idSucursal = 0;
            sucursales.nombreSucursal = "";
            sucursales.direccionSucursal = "";
            infoSucursal info = new infoSucursal(sucursales);

            info.ShowDialog();

            cargarSucursales();
        }
    }
}
