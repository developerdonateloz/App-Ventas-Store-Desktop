using System;
using System.Windows.Forms;

namespace App_Ventas
{
    public partial class frmPrincipal : Form
    {
        frmUsuario miformusuario;
        frmProducto miformproducto;
        frmVenta miformventa;
        frmStock miformstock;
        frmReporte miformreporte;

        public frmPrincipal()
        {
            InitializeComponent();
            
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(miformusuario == null)
            {
                miformusuario = new frmUsuario();
                miformusuario.MdiParent = this;
                miformusuario.FormClosed += MiFormUsuario_FormClosed;
                miformusuario.WindowState = FormWindowState.Maximized;
                miformusuario.AutoSize = true;
                miformusuario.AutoSizeMode = AutoSizeMode.GrowOnly;
                miformusuario.MaximizeBox = false;
                miformusuario.MinimizeBox = false;
                miformusuario.Show();
            }
            else
            {
                miformusuario.Activate();
            }
        }

        private void MiFormUsuario_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            miformusuario = null;
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (miformproducto == null)
            {
                miformproducto = new frmProducto();
                miformproducto.MdiParent = this;
                miformproducto.FormClosed += MiFormProducto_FormClosed;
                miformproducto.Show();
            }
            else
            {
                miformproducto.Activate();
            }
        }
        private void MiFormProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            miformproducto = null;
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void ingresoStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (miformstock == null)
            {
                miformstock = new frmStock();
                miformstock.MdiParent = this;
                miformstock.FormClosed += MiFormStock_FormClosed;
                miformstock.Show();
            }
            else
            {
                miformstock.Activate();
            }
        }
        private void MiFormStock_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();

            miformstock = null;
        }
        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (miformventa == null)
            {
                miformventa = new frmVenta();
                miformventa.MdiParent = this;
                miformventa.FormClosed += MiFormVenta_FormClosed;
                miformventa.Show();
            }
            else
            {
                miformventa.Activate();
            }
        }
        private void MiFormVenta_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            miformventa = null;
        }
        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (miformreporte == null)
            {
                miformreporte = new frmReporte();
                miformreporte.MdiParent = this;
                miformreporte.FormClosed += MiFormReporte_FormClosed;
                miformreporte.Show();
            }
            else
            {
                miformreporte.Activate();
            }
        }
        private void MiFormReporte_FormClosed(object sender, FormClosedEventArgs e)
        {
            //throw new NotImplementedException();
            miformreporte = null;
        }

        private void frmPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
