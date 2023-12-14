namespace Biblioteca
{
    public enum Estaciones { otonio, invierno, primavera, verano };
    public static class DateTimeExtension
    {
        public static string ObtenerPlacaCronicaTV(this DateTime date, Estaciones estacion)
        {
            DateTime estacionIngresada = DateTime.Now;
            switch (estacion)
            {
                case Estaciones.otonio:
                    estacionIngresada = DateTime.Parse("21 March");
                    break;
                case Estaciones.invierno:
                    estacionIngresada = DateTime.Parse("21 June");
                    break;
                case Estaciones.primavera:
                    estacionIngresada = DateTime.Parse("21 September");
                    break;
                case Estaciones.verano:
                    estacionIngresada = DateTime.Parse("21 December");
                    break;
                default:
                    break;
            }
            int dias = estacionIngresada.Subtract(date).Days;
            if (dias < 0)
            {
                dias += 365;
            }
            return $"Faltan {dias} dias para la estacion {estacion.ToString()}";
        }
    }
}