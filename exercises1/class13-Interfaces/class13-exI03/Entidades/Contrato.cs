namespace Entidades
{
    public class Contrato : IImprimible
    {
        public void Imprimir()
        {
            Console.WriteLine(DecirTexto());
        }
        public string DecirTexto()
        {
            return "Soy un contrato muy legal";
        }
    }
}