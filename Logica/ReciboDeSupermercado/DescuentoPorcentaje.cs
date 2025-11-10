namespace Logica
{
    public class DescuentoPorcentaje : IEstrategiaDePrecio
    {
        private readonly decimal _porcentaje;
        public DescuentoPorcentaje(decimal porcentaje)
        {
            _porcentaje = porcentaje;
        }

        public ResultadoCalculo CalcularCosto(int unidad, decimal valorUnidad)
        {
            var totalSinDescuento = valorUnidad * unidad;
            var totalConDescuento = totalSinDescuento * (1 - _porcentaje);

            var valorTotal = Math.Round(totalConDescuento, 2);

            var valorDescuento = Math.Round(totalSinDescuento - valorTotal, 2);

            return new ResultadoCalculo(valorTotal, valorDescuento);
        }
    }
}