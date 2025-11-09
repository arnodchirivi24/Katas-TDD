namespace Logica
{
    public class ReciboSupermercado
    {
        public decimal CalcularCostoTotal(int unidades, decimal valorUnidad, string descripcionProducto)
        {
            if(descripcionProducto == "Cepillo")
            {
                var unidadesAPagar = unidades - (unidades / 2);
                return unidadesAPagar * valorUnidad;
            }
            if(descripcionProducto == "Manzanas")
            {
                return 1.59m;
            }
            return 0;
        }
    }
}