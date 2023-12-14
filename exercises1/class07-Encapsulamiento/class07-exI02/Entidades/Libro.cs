namespace Entidades
{
    public class Libro
    {
        private List<string> paginas = new List<string>();

        public string this[int i]
        {
            get
            {
                if (paginas.Count > i && i >= 0)
                {
                    return paginas[i];
                }
                return String.Empty;
            }
            set
            {
                if (paginas.Count < i)
                {
                    paginas.Add(value);
                }
                else if (i >= 0)
                {
                    paginas.Insert(i, value);
                }
            }
        }
    }
}