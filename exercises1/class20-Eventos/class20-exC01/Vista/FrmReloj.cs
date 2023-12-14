using Biblioteca;

namespace Vista
{
    public partial class FrmReloj : Form
    {
        CancellationTokenSource cancellationTokenSource;
        CancellationToken cancellationToken;
        Temporizador temporizador;
        public FrmReloj()
        {
            InitializeComponent();
            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;
        }

        private void FrmReloj_Load(object sender, EventArgs e)
        {
            Task hilo = Task.Run(() => ActualizarHora(lblHora), cancellationToken);
            temporizador = new Temporizador(1000);
            temporizador.TiempoCumplido += CambiarTiempo;
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

        public void CambiarTiempo()
        {
            CambiarHora(lblTiempo);
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
            temporizador.DetenerTemporizador();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            temporizador.IniciarTemporizador();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            temporizador.DetenerTemporizador();
        }
    }
}