namespace Vista
{
    public partial class FrmPrincipal : Form
    {
        private FrmMostrar frmMostrar;
        private FrmTestDelegados testDelegados;
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            frmMostrar = new FrmMostrar();
            frmMostrar.MdiParent = this;

            testDelegados = new FrmTestDelegados(frmMostrar.ActualizarNombre);
            testDelegados.MdiParent = this;
        }

        private void testDelegadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            testDelegados.Show();
            mostrarToolStripMenuItem.Enabled = true;
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMostrar.Show();
        }
    }
}