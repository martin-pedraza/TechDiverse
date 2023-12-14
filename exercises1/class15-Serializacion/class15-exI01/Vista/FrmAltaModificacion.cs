namespace Vista
{
    public partial class FrmAltaModificacion : Form
    {
        public string Objeto
        {
            get
            {
                return txtObjeto.Text;
            }
        }
        public FrmAltaModificacion(string titulo, string texto, string boton)
        {
            InitializeComponent();
            Text = titulo;
            txtObjeto.Text = texto;
            btnConfirmar.Text = boton;
        }

        private void txtObjeto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ValidarCampo();
            }
            if (e.KeyChar == (char)27)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }

        private void ValidarCampo()
        {
            if (!String.IsNullOrEmpty(Objeto))
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Valor no valido");
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            ValidarCampo();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}