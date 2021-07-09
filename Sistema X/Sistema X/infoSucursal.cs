using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema_X
{
    public partial class infoSucursal : Form
    {
        Modelo.Sucursales datosSucursal;
        public infoSucursal(Modelo.Sucursales datos)
        {
            
            InitializeComponent();
            this.datosSucursal = datos;
            llenar();
            
        }

        public void llenar()
        {
            txtDireccion.Text = datosSucursal.direccionSucursal.ToString();
            
            txtNombre.Text = datosSucursal.nombreSucursal.ToString();
            txtidSucursal.Text = datosSucursal.idSucursal.ToString();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Controlador.Controlador ctrl = new Controlador.Controlador();
            datosSucursal.nombreSucursal = txtNombre.Text;
            datosSucursal.direccionSucursal = txtDireccion.Text;

            if (ctrl.actualizarSucursal(datosSucursal))
            {
                
                this.Close();
                
            }
        }
    }
}
