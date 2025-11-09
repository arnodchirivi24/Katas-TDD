namespace Logica
{
    public class ReciboSupermercado
    {
        public decimal CalcularCostoTotal(int unidades, decimal valorUnidad, string descripcionProducto)
        {
            switch (descripcionProducto)
            {
                case "Cepillo":
                    {
                        return CalcularCostoProductoConDescuento2x1(unidades, valorUnidad);
                    }
                case "Manzanas":
                    {
                        return CalcularCostoProductoConPorcentajeDeDescuento(unidades, valorUnidad, 0.2m);
                    }
                case "Arroz":
                    {
                        
                        return CalcularCostoProductoConPorcentajeDeDescuento(unidades, valorUnidad, 0.1m);
                    }
                case "Tubo de pasta de dientes":
                    {   
                        if(unidades % 5 ==0)
                            return (unidades/5)* 7.49m;
                        return unidades * valorUnidad;
                    }
                case "Cajas de tomates":
                    {
                        return 0.99m;
                    }
                default:
                    return 0;
            }
        }

        private decimal CalcularCostoProductoConDescuento2x1(int unidades, decimal valorUnidad)
        {
            var unidadesApagar = unidades - (unidades / 2);
            var totalCostoConDescuento2X1 = unidadesApagar * valorUnidad;
            return totalCostoConDescuento2X1;
        }

        private decimal CalcularCostoProductoConPorcentajeDeDescuento(int unidades, decimal valorUnidad, decimal porcentajeDescuento)
        {
            var totalSinDescuento = valorUnidad * unidades;
            var totalConDescuento = totalSinDescuento * (1 - porcentajeDescuento);
            return Math.Round(totalConDescuento, 2);
        }
    }
}