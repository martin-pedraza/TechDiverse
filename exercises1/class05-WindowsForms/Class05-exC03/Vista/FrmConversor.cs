using Entidades;

namespace Vista
{
    public partial class FrmConversor : Form
    {
        public FrmConversor()
        {
            InitializeComponent();
        }

        private void txtBinario_Leave(object sender, EventArgs e)
        {
            DarFoco(txtBinario.Text, txtBinario);
        }

        private void txtDecimal_Leave(object sender, EventArgs e)
        {
            DarFoco(txtDecimal.Text, txtDecimal);
        }

        private bool ValidarValor(string valor)
        {
            return int.TryParse(valor, out int valorVal) && valorVal >= 0;
        }

        private bool DarFoco(string valor, Control control)
        {
            if (!ValidarValor(valor))
            {
                control.Focus();
                return true;
            }
            return false;
        }

        private void btnBinarioA_Click(object sender, EventArgs e)
        {
            if (!DarFoco(txtBinario.Text, txtBinario))
            {
                txtBinarioADecimal.Text = Conversor.ConvertirBinarioADecimal(int.Parse(txtBinario.Text)).ToString();
            }
            if (txtBinarioADecimal.Text == "-1")
            {
                MessageBox.Show("No es un numero binario valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecimalA_Click(object sender, EventArgs e)
        {
            if (!DarFoco(txtDecimal.Text, txtDecimal))
            {
                txtDecimalABinario.Text = Conversor.ConvertirDecimalABinario(int.Parse(txtDecimal.Text));
            }
        }
    }
}