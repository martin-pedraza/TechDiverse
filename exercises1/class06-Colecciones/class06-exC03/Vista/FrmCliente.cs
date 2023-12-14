using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class FrmCliente : Form
    {
        private string nombre;
        public string Nombre { get; set; }
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtNombre.Text))
            {
                Nombre = txtNombre.Text;
                CerrarFormulario(DialogResult.OK);
            }
            else
            {
                MessageBox.Show("Ingrese datos validos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CerrarFormulario()
        {
            DialogResult = DialogResult.Cancel;
        }

        private void CerrarFormulario(DialogResult dg)
        {
            DialogResult = dg;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CerrarFormulario();
        }
    }
}
