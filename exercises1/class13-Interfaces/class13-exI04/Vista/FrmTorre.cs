using Entidades;

namespace Vista
{
    public partial class FrmTorre : Form
    {
        private TorreDeControl torre;
        public FrmTorre()
        {
            InitializeComponent();
            torre = new TorreDeControl();
        }

        private void FrmTorre_Load(object sender, EventArgs e)
        {
            cboVolador.Items.Add("Pato");
            cboVolador.Items.Add("Boing 747");
            cboVolador.Items.Add("BuzzLightyear");

            cboVolador.SelectedIndex = 2;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            switch (cboVolador.SelectedIndex)
            {
                case 0:
                    torre.AgregarVolador(new Pato());
                    MessageBox.Show("Pato agregado");
                    break;
                case 1:
                    torre.AgregarVolador(new Boing747());
                    MessageBox.Show("Boing 747 agregado");
                    break;
                case 2:
                    torre.AgregarVolador(new BuzzLightyear());
                    MessageBox.Show("BuzzLightYear agregado");
                    break;
                default:
                    break;
            }
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            torre.VuelenTodos();
            rboControl.Text = torre.DecirTextos();
        }
    }
}