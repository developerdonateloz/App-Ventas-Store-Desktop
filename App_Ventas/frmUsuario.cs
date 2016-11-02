using System;
using System.Windows.Forms;

namespace App_Ventas
{
    public partial class frmUsuario : Form
    {
        protected override void OnResize(EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }
        public frmUsuario()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Persona opersona = new Persona();

            if (!Validado())
                return;

            int idpersona=opersona.CrearPersona(txtCodigo.Text.Trim(),
                                    txtNombre.Text.Trim(),
                                    txtApPaterno.Text.Trim(),
                                    txtApMaterno.Text.Trim(),
                                    txtUsuario.Text.Trim(),
                                    txtContrasenia.Text.Trim());
            if (idpersona > 0)
                tabBusqueda.Show();
        }
        private bool Validado()
        {
            bool validado = true;
            if(txtCodigo.Text.Trim().Length<8)
                validado = false;
            if (txtNombre.Text.Trim() == string.Empty)
                validado = false;
            if (txtApPaterno.Text.Trim() == string.Empty)
                validado = false;
            if (txtApMaterno.Text.Trim() == string.Empty)
                validado = false;

            return validado;
        }
    }
}
