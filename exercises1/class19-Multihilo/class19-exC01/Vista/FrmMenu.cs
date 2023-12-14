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
            Task hilo = Task.Run(() =>
            {
                Random r = new Random();
                while (true)
                {
                    centralita += new Local(r.Next(100), "Destino " + r.Next(100), "Origen " + r.Next(100), r.Next(10));
                    Thread.Sleep(r.Next(1000, 5000));
                    centralita += new Provincial(r.Next(100), Provincial.Franja.Franja_1, "Destino " + r.Next(100), "Origen " + r.Next(100));
                    Thread.Sleep(r.Next(1000, 5000));
                }
            });
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