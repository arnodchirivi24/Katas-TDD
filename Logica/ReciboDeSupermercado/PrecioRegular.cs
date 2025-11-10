namespace Logica
{
    public class PrecioRegular : IEstrategiaDePrecio
    {
        public ResultadoCalculo CalcularCosto(int unidades, decimal valorUnidad)
        {
            var valorTotal = unidades * valorUnidad;
            return new ResultadoCalculo(valorTotal, 0m);
        }
    }
}