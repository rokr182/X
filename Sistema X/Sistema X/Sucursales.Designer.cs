
namespace Sistema_X
{
    partial class Sucursales
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvSucursales = new System.Windows.Forms.DataGridView();
            this.idSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DireccionSucursal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnNuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursales)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSucursales
            // 
            this.dgvSucursales.AllowUserToAddRows = false;
            this.dgvSucursales.AllowUserToDeleteRows = false;
            this.dgvSucursales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSucursales.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idSucursal,
            this.NombreSucursal,
            this.DireccionSucursal});
            this.dgvSucursales.Location = new System.Drawing.Point(12, 75);
            this.dgvSucursales.Name = "dgvSucursales";
            this.dgvSucursales.ReadOnly = true;
            this.dgvSucursales.Size = new System.Drawing.Size(776, 334);
            this.dgvSucursales.TabIndex = 0;
            this.dgvSucursales.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSucursales_CellDoubleClick);
            // 
            // idSucursal
            // 
            this.idSucursal.HeaderText = "idSucursal";
            this.idSucursal.Name = "idSucursal";
            this.idSucursal.ReadOnly = true;
            // 
            // NombreSucursal
            // 
            this.NombreSucursal.HeaderText = "Nombre Sucursal";
            this.NombreSucursal.Name = "NombreSucursal";
            this.NombreSucursal.ReadOnly = true;
            // 
            // DireccionSucursal
            // 
            this.DireccionSucursal.HeaderText = "Direccion Sucursal";
            this.DireccionSucursal.Name = "DireccionSucursal";
            this.DireccionSucursal.ReadOnly = true;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(39, 28);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "Agregar Sucursal";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // Sucursales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 415);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgvSucursales);
            this.Name = "Sucursales";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sucursales";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSucursales)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSucursales;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreSucursal;
        private System.Windows.Forms.DataGridViewTextBoxColumn DireccionSucursal;
    }
}