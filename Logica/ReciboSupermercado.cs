namespace Logica
{
    public class ReciboSupermercado
    {
        public decimal CalcularCostoTotal(int unidades, decimal valorUnidad, string descripcionProducto)
        {      
            if (descripcionProducto == "Cepillo")
            {
                var unidadesAPagar = unidades - (unidades / 2);
                return unidadesAPagar * valorUnidad;
            }
            if (descripcionProducto == "Manzanas")
            {
                var valorNormalManzanas = unidades * valorUnidad;
                var valorConDescuento20Porciento = valorNormalManzanas * (1 - 0.2m);
                return Math.Round(valorConDescuento20Porciento, 2);
            }
            return 0;
        }
    }
}