
namespace Logica
{
    public class DescuentoPorCombos : IEstrategiaDePrecio
    {
        private readonly int _unidadesDePromocion;
        private readonly decimal _valorPromocion;  

        public DescuentoPorCombos(int unidadesDePromocion, decimal valorPromocion)
        {
            _unidadesDePromocion = unidadesDePromocion;
            _valorPromocion = valorPromocion;
        }
        public ResultadoCalculo CalcularCosto(int unidadesCompradas, decimal valorPrecioNormalPorUnidad)
        {
            var unidadesRestantes = unidadesCompradas % _unidadesDePromocion;

            var gruposDePromocion = unidadesCompradas / _unidadesDePromocion;
            var costoPorPromocion = gruposDePromocion * _valorPromocion;

            var costoPorUnidadesRestantes = unidadesRestantes * valorPrecioNormalPorUnidad;
            var valorTotal = costoPorPromocion + costoPorUnidadesRestantes;

            var precioNormalTotal = unidadesCompradas * valorPrecioNormalPorUnidad;
            var valorDescuento = precioNormalTotal - valorTotal;

            return new ResultadoCalculo(valorTotal, valorDescuento);
        }
    }
}
