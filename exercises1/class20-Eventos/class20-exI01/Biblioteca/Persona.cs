namespace Biblioteca
{
    public class Persona
    {
        public delegate void DelegadoString(string msg);
        public event DelegadoString EventoString;

        private string nombre;
        private string apellido;

        public string Nombre
        {
            get => nombre;
            set
            {
                nombre = value;
                EventoString("Nombre cambiado");
            }
        }
        public string Apellido
        {
            get => apellido;
            set
            {
                apellido = value;
                EventoString("Apellido cambiado");
            }
        }

        public Persona()
        {
        }

        public string Mostrar()
        {
            return $"{Nombre} {Apellido}";
        }
    }
}