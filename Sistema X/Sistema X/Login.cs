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
using Sistema_X.Modelo;
namespace Sistema_X
{
    public partial class Login : Form
    {
        List<Modelo.Sucursales> sucursales;
        public Login()
        {
            InitializeComponent();
            llenarcb();
           
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPass.Text;
            string sucursal = cbSucursales.Text;
            try
            {
                Controlador.Controlador ctrl = new Controlador.Controlador();
                string Mensaje = ctrl.Login(usuario, password, sucursal);
                if (Mensaje.Length > 0)
                {
                    MessageBox.Show(Mensaje, "Aviso");
                }
                else
                {
                    MenuPrincipal mp = new MenuPrincipal();
                    mp.Show();
                    this.Hide();

                }
            }
            catch (Exception ex) { }
        }

        public void llenarcb()
        {
            Controlador.Controlador ctrl = new Controlador.Controlador();
            sucursales= ctrl.llenarcbSucursales();

            for (int i = 0; i < sucursales.Count; i++)
            {
                cbSucursales.Items.Add(sucursales[i].nombreSucursal);
                
            }
            cbSucursales.Text = sucursales[0].nombreSucursal;
        }

        
    }
}
