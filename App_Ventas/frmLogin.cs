using System;
using System.Windows.Forms;

namespace App_Ventas
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            frmPrincipal miprincipal = new frmPrincipal();
            miprincipal.Show();
            this.Hide();
        }
    }
}
