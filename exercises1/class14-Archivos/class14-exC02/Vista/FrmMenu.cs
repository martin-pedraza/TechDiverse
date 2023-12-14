using Entidades;
namespace Vista
{
    public partial class FrmMenu : Form
    {
        Centralita centralita;
        public FrmMenu()
        {
            InitializeComponent();
            centralita = new Centralita();
        }

        private void btnFacturacionTotal_Click(object sender, EventArgs e)
        {
            FrmMostrar frmMostrar = new FrmMostrar(centralita, TipoLlamada.Todas);
            frmMostrar.ShowDialog();
        }

        private void btnFacturacionLocal_Click(object sender, EventArgs e)
        {
            FrmMostrar frmMostrar = new FrmMostrar(centralita, TipoLlamada.Local);
            frmMostrar.ShowDialog();
        }

        private void btnFacturacionProvincial_Click(object sender, EventArgs e)
        {
            FrmMostrar frmMostrar = new FrmMostrar(centralita, TipoLlamada.Provincial);
            frmMostrar.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            // Mis 4 llamadas
            Local l1 = new Local(30, "Rosario", "Bernal", 2.65f);
            Provincial l2 = new Provincial(21, Provincial.Franja.Franja_1, "Morón", "Bernal");
            Local l3 = new Local(45, "San Rafael", "Lanús", 1.99f);
            Provincial l4 = new Provincial(Provincial.Franja.Franja_3, l2);

            try
            {
                centralita += l1;
                centralita += l2;
                centralita += l3;
                //centralita += l4;
            }
            catch (CentralitaException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerarLlamada_Click(object sender, EventArgs e)
        {
            FrmLlamador frmLlamador = new FrmLlamador(centralita);
            frmLlamador.ShowDialog();
            centralita = frmLlamador.Centralita;
        }

        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show(centralita.Leer());
        }
    }
}