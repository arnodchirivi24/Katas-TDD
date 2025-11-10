
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
        private Dictionary<string, IEstrategiaDePrecio> _ofertaDeLaSemana;
        public ReciboSupermercado(Dictionary<string, IEstrategiaDePrecio> ofertaDeLaSemana)
        {
            _ofertaDeLaSemana = ofertaDeLaSemana;
        }
        public record ResultadoCalculo(decimal ValorTotal, decimal ValorDescuento);
        public ResultadoCalculo CalcularCostoTotal(int unidades, decimal valorUnidad, string descripcionProducto)
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
                    var valorTotal = unidades * valorUnidad;
                    return new ResultadoCalculo(valorTotal, 0m);
            }
        }

        private ResultadoCalculo CalcularCostoProductosEnPromocionPorCombos(int unidadesCompradas, int unidadesDePromocion, decimal valorPromocion, decimal valorPrecioNormalPorUnidad)
        {
            var gruposDePromocion = unidadesCompradas / unidadesDePromocion;
            var unidadesRestantes = unidadesCompradas % unidadesDePromocion;

            var costoPorPromocion = gruposDePromocion * valorPromocion;
            var costoPorUnidadesRestantes = unidadesRestantes * valorPrecioNormalPorUnidad;

            var valorTotal = costoPorPromocion + costoPorUnidadesRestantes;

            var precioNormalTotal = unidadesCompradas * valorPrecioNormalPorUnidad;
            var valorDescuento = precioNormalTotal - valorTotal;

            return new ResultadoCalculo(valorTotal, valorDescuento);
        }

        private ResultadoCalculo CalcularCostoProductoConDescuento2x1(int unidades, decimal valorUnidad)
        {
            var unidadesAPagar = (unidades / 2) + (unidades % 2);
            var unidadesGratis = unidades / 2;

            var valorTotal = unidadesAPagar * valorUnidad;
            var valorDescuento = unidadesGratis * valorUnidad;

            return new ResultadoCalculo(valorTotal, valorDescuento);
        }

        private ResultadoCalculo CalcularCostoProductoConPorcentajeDeDescuento(int unidades, decimal valorUnidad, decimal porcentajeDescuento)
        {
            var totalSinDescuento = valorUnidad * unidades;
            var totalConDescuento = totalSinDescuento * (1 - porcentajeDescuento);

            var valorTotal = Math.Round(totalConDescuento, 2);

            var valorDescuento = Math.Round(totalSinDescuento - valorTotal, 2);
            
            return new ResultadoCalculo(valorTotal, valorDescuento);
        }

        public Recibo ProcesarCompra(List<ProductoComprado> productos)
        {
            var lineasDelRecibo = new List<LineaDeRecibo>();

            foreach(var producto in productos)
            {
                ResultadoCalculo resultado = CalcularCostoTotal(
                    producto.Cantidad,
                    producto.ValorUnidad,
                    producto.Descripcion
                );


                var linea = new LineaDeRecibo(
                    producto.Descripcion,
                    producto.UnidadDeMedida,
                    producto.Cantidad,
                    resultado.ValorTotal,
                    resultado.ValorDescuento
                );

                lineasDelRecibo.Add(linea);
            }

            decimal totalCompra = lineasDelRecibo.Sum(linea => linea.ValorTotal);

            return new Recibo(lineasDelRecibo, totalCompra);
        }
    }
}