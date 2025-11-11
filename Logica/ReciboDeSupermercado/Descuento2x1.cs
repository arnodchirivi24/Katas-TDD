namespace Logica
{
    public class Descuento2x1 : IEstrategiaDePrecio
    {
        public ResultadoCalculo CalcularCosto(int unidades, decimal valorUnidad)
        {
            var unidadesAPagar = (unidades / 2) + (unidades % 2);
            var unidadesGratis = unidades / 2;

            var valorTotal = unidadesAPagar * valorUnidad;
            var valorDescuento = unidadesGratis * valorUnidad;

            return new ResultadoCalculo(valorTotal, valorDescuento);
        }
    }
}
