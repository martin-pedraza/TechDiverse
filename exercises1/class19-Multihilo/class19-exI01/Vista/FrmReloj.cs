namespace Vista
{
    public partial class FrmReloj : Form
    {
        CancellationTokenSource cancellationTokenSource;
        CancellationToken cancellationToken;
        public FrmReloj()
        {
            InitializeComponent();
            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;
        }

        private void FrmReloj_Load(object sender, EventArgs e)
        {
            Task hilo = Task.Run(() => ActualizarHora(lblHora), cancellationToken);
        }

        private void ActualizarHora(Label lbl)
        {
            try
            {
                while (true)
                {
                    CambiarHora(lbl);
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }
            catch (Exception)
            {
            }
            
        }

        private void CambiarHora(Label lbl)
        {
            if (InvokeRequired)
            {
                Action<Label> cambiarHora = CambiarHora;
                object[] parametros = new object[] { lbl };
                Invoke(cambiarHora, parametros);
            }
            else
            {
                lbl.Text = DateTime.Now.ToString();
            }
        }

        private void FrmReloj_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellationTokenSource.Cancel();
        }
    }
}