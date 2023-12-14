using Entidades;

namespace Vista
{
    public partial class FrmImpresora : Form
    {
        public Impresora impresora;
        public FrmImpresora()
        {
            InitializeComponent();
            impresora = new Impresora();
        }

        private void FrmImpresora_Load(object sender, EventArgs e)
        {
            cboDocumento.Items.Add("Foto");
            cboDocumento.Items.Add("Documento");
            cboDocumento.Items.Add("Contrato");

            cboDocumento.SelectedIndex = 1;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            switch (cboDocumento.SelectedIndex)
            {
                case 0:
                    Impresora.AgregarImprimible(impresora, new Foto());
                    MessageBox.Show("Foto agregada a la cola de impresion");
                    break;
                case 1:
                    Impresora.AgregarImprimible(impresora, new Documento());
                    MessageBox.Show("Documento agregado a la cola de impresion");
                    break;
                case 2:
                    Impresora.AgregarImprimible(impresora, new Contrato());
                    MessageBox.Show("Contrato agregado a la cola de impresion");
                    break;
                default:
                    break;
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            rboImpresion.Text = Impresora.DecirTextos(impresora);
        }
    }
}