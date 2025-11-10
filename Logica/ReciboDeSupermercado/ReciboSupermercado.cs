
namespace Logica
{
    public record ProductoComprado(
        string Descripcion,
        int Cantidad,
        decimal ValorUnidad,
        string UnidadDeMedida = "Unidad"
    );

    public record LineaDeRecibo(
        string Descripcion,
        string UnidadDeMedida,
        int Cantidad,
        decimal ValorTotal,
        decimal ValorDescuento
    );

    public record Recibo(
        List<LineaDeRecibo> Lineas,
        decimal TotalCompra
    );
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
                        return CalcularCostoProductosEnPromocionPorCombos(unidades,5, 7.49m, 1.79m);
                    }
                case "Cajas de tomates":
                    {
                        return CalcularCostoProductosEnPromocionPorCombos(unidades, 2, 0.99m, 0.69m);
                    }
                default:
                    return unidades * valorUnidad;
            }
        }

        private decimal CalcularCostoProductosEnPromocionPorCombos(int unidadesCompradas, int unidadesDePromocion, decimal valorPromocion, decimal valorPrecioNormalPorUnidad)
        {
            var gruposDePromocion = unidadesCompradas / unidadesDePromocion;

            var unidadesRestantes = unidadesCompradas % unidadesDePromocion;

            var costoPorPromocion = gruposDePromocion * valorPromocion;

            var costoPorUnidadesRestantes = unidadesRestantes * valorPrecioNormalPorUnidad;

            return costoPorPromocion + costoPorUnidadesRestantes;
        }

        private decimal CalcularCostoProductoConDescuento2x1(int unidades, decimal valorUnidad)
        {
            var unidadesApagar = unidades - unidades / 2;
            var totalCostoConDescuento2X1 = unidadesApagar * valorUnidad;
            return totalCostoConDescuento2X1;
        }

        private decimal CalcularCostoProductoConPorcentajeDeDescuento(int unidades, decimal valorUnidad, decimal porcentajeDescuento)
        {
            var totalSinDescuento = valorUnidad * unidades;
            var totalConDescuento = totalSinDescuento * (1 - porcentajeDescuento);
            return Math.Round(totalConDescuento, 2);
        }

        public Recibo ProcesarCompra(List<ProductoComprado> listaDeCompraVacia)
        {
            return new Recibo(new List<LineaDeRecibo>(), 0);
        }
    }
}