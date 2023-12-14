using Entidades;

namespace Vista
{
    public partial class FrmConversor : Form
    {
        public FrmConversor()
        {
            InitializeComponent();
        }

        private void btnFahrenheit_Click(object sender, EventArgs e)
        {
            if (!DarFoco(txtFahrenheit.Text, txtFahrenheit))
            {
                txtFahrenheitAFahrenheit.Text = txtFahrenheit.Text;
                txtFahrenheitACelsius.Text = Conversor.ConvertirFaC(float.Parse(txtFahrenheit.Text)).ToString();
                txtFahrenheitAKelvin.Text = Conversor.ConvertirFaK(float.Parse(txtFahrenheit.Text)).ToString();
            }
        }

        private void btnCelsius_Click(object sender, EventArgs e)
        {
            if (!DarFoco(txtCelsius.Text, txtCelsius))
            {
                txtCelsiusACelsius.Text = txtCelsius.Text;
                txtCelsiusAFahrenheit.Text = Conversor.ConvertirCaF(float.Parse(txtCelsius.Text)).ToString();
                txtCelsiusAKelvin.Text = Conversor.ConvertirCaK(float.Parse(txtCelsius.Text)).ToString();
            }
        }

        private void btnKelvin_Click(object sender, EventArgs e)
        {
            if (!DarFoco(txtKelvin.Text, txtKelvin))
            {
                txtKelvinAKelvin.Text = txtKelvin.Text;
                txtKelvinACelsius.Text = Conversor.ConvertirKaC(float.Parse(txtKelvin.Text)).ToString();
                txtKelvinAFahrenheit.Text = Conversor.ConvertirKaF(float.Parse(txtKelvin.Text)).ToString();
            }
        }

        private void txtFahrenheit_Leave(object sender, EventArgs e)
        {
            DarFoco(txtFahrenheit.Text, txtFahrenheit);
        }

        private bool ValidarGrados(string grados)
        {
            return !float.TryParse(grados, out float resultado) || String.IsNullOrEmpty(grados);
        }

        private bool DarFoco(string grados, Control txt)
        {
            if (ValidarGrados(grados))
            {
                txt.Focus();
                return true;
            }
            return false;
        }

        private void txtCelsius_Leave(object sender, EventArgs e)
        {
            DarFoco(txtCelsius.Text, txtCelsius);
        }

        private void txtKelvin_Leave(object sender, EventArgs e)
        {
            DarFoco(txtKelvin.Text, txtKelvin);
        }
    }
}