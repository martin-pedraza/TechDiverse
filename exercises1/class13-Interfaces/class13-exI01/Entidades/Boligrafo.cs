namespace Entidades
{
    public class Boligrafo : IAcciones
    {
        private ConsoleColor colorTinta;
        private float tinta;

        public Boligrafo(float tinta, ConsoleColor colorTinta)
        {
            Color = colorTinta;
            UnidadesDeEscritura = tinta;
        }

        public ConsoleColor Color { get => colorTinta; set => colorTinta = value; }
        public float UnidadesDeEscritura { get => tinta; set => tinta = value; }


        public EscrituraWrapper Escribir(string texto)
        {
            if (UnidadesDeEscritura >= texto.Length * 0.3f)
            {
                UnidadesDeEscritura -= texto.Length * 0.3f;
                return new EscrituraWrapper(texto, Color);
            }

            return new EscrituraWrapper(texto.Substring(0, (int)(UnidadesDeEscritura / 0.3f)), Color);
        }

        public bool Recargar(int unidades)
        {
            if (unidades > 0)
            {
                UnidadesDeEscritura += unidades;
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return $"{this.GetType()}: {UnidadesDeEscritura} de color {Color}";
        }
    }
}