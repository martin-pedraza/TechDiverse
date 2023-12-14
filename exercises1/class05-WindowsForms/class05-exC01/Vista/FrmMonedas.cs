using Billetes;

namespace Vista
{
    public partial class FrmMonedas : Form
    {
        public FrmMonedas()
        {
            InitializeComponent();
        }

        private void btnLockCotizacion_Click(object sender, EventArgs e)
        {
            if (btnLockCotizacion.ImageIndex == 0)
            {
                btnLockCotizacion.ImageIndex = 1;
            }
            else
            {
                btnLockCotizacion.ImageIndex = 0;
            }

            txtCotizacionDolar.Enabled = !txtCotizacionDolar.Enabled;
            txtCotizacionEuro.Enabled = !txtCotizacionEuro.Enabled;
            txtCotizacionPeso.Enabled = !txtCotizacionPeso.Enabled;

            Peso.SetCotizacion(double.Parse(txtCotizacionPeso.Text));
        }

        private void FrmMonedas_Load(object sender, EventArgs e)
        {
            txtCotizacionDolar.Text = Dolar.GetCotizacion().ToString();
            txtCotizacionEuro.Text = Euro.GetCotizacion().ToString();
            txtCotizacionPeso.Text = Peso.GetCotizacion().ToString();
        }

        private void btnEuroA_Click(object sender, EventArgs e)
        {
            Euro euro = new Euro(double.Parse(txtEuro.Text));
            txtEuroAEuro.Text = txtEuro.Text;
            txtEuroADolar.Text = ((Dolar)euro).GetCantidad().ToString();
            txtEuroAPeso.Text = ((Peso)euro).GetCantidad().ToString();
        }

        private void btnDolarA_Click(object sender, EventArgs e)
        {
            Dolar dolar = new Dolar(double.Parse(txtDolar.Text));
            txtDolarADolar.Text = txtDolar.Text;
            txtDolarAEuro.Text = ((Euro)dolar).GetCantidad().ToString();
            txtDolarAPeso.Text = ((Peso)dolar).GetCantidad().ToString();
        }

        private void btnPesoA_Click(object sender, EventArgs e)
        {
            Peso peso = new Peso(double.Parse(txtPeso.Text));
            txtPesoAPeso.Text = txtPeso.Text;
            txtPesoADolar.Text = ((Dolar)peso).GetCantidad().ToString();
            txtPesoAEuro.Text = ((Euro)peso).GetCantidad().ToString();
        }

        private void txtCotizacionEuro_Leave(object sender, EventArgs e)
        {
            double cotizacion;
            bool esValido = double.TryParse(txtCotizacionEuro.Text, out cotizacion);
            bool estaVacio = String.IsNullOrEmpty(txtCotizacionEuro.Text.Trim());
            if (esValido && cotizacion > 0 && !estaVacio)
            {
                Euro.SetCotizacion(cotizacion);
            }
            else
            {
                txtCotizacionEuro.Focus();
            }
        }

        private void txtCotizacionPeso_Leave(object sender, EventArgs e)
        {
            double cotizacion;
            bool esValido = double.TryParse(txtCotizacionPeso.Text, out cotizacion);
            bool estaVacio = String.IsNullOrEmpty(txtCotizacionPeso.Text.Trim());
            if (esValido && cotizacion > 0 && !estaVacio)
            {
                Peso.SetCotizacion(cotizacion);
            }
            else
            {
                txtCotizacionPeso.Focus();
            }
        }

        private void txtCotizacionDolar_Leave(object sender, EventArgs e)
        {
            txtCotizacionDolar.Text = "1";
        }
    }
}