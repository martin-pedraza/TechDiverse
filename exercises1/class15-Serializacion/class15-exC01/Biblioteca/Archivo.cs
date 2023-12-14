namespace Biblioteca
{
    public abstract class Archivo
    {
        public abstract string Extension { get; }
        public bool ValidarSiExisteElArchivo(string ruta)
        {
            if (File.Exists(ruta))
            {
                return true;
            }
            throw new ArchivoIncorrectoException("El archivo no se encontró");
        }
        public bool ValidarExtensión(string ruta)
        {
            if (Path.GetExtension(ruta) == Extension)
            {
                return true;
            }
            throw new ArchivoIncorrectoException($"El archivo no tiene la extensión {Extension}");
        }
    }
}