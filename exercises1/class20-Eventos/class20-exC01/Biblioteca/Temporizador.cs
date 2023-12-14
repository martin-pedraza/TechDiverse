namespace Biblioteca
{
    public class Temporizador
    {
        public delegate void DelegadoTemporizador();
        public event DelegadoTemporizador TiempoCumplido;
        private CancellationToken cancellationToken;
        private CancellationTokenSource cancellationTokenSource;
        private Task hilo;
        private int intervalo;

        public bool EstaActivo
        {
            get
            {
                return hilo is not null &&
                    (hilo.Status == TaskStatus.Running ||
                    hilo.Status == TaskStatus.WaitingToRun ||
                    hilo.Status == TaskStatus.WaitingForActivation);
            }
        }

        public int Intervalo
        {
            get
            {
                return intervalo;
            }
        }

        public Temporizador(int intervalo)
        {
            this.intervalo = intervalo;

        }

        public void IniciarTemporizador()
        {
            if (!EstaActivo)
            {
                cancellationTokenSource = new CancellationTokenSource();
                cancellationToken = cancellationTokenSource.Token;
                hilo = new Task(CorrerTiempo, cancellationToken);
                hilo.Start();
            }
        }

        public void DetenerTemporizador()
        {
            if (EstaActivo)
            {
                cancellationTokenSource.Cancel();
            }
        }

        private void CorrerTiempo()
        {
            do
            {
                if (TiempoCumplido is not null)
                {
                    TiempoCumplido.Invoke();
                }

                Thread.Sleep(intervalo);
            } while (!cancellationToken.IsCancellationRequested);
        }
    }
}