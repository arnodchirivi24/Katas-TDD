namespace Logica
{
    public record ResultadoCalculo(decimal ValorTotal, decimal ValorDescuento);
    public interface IEstrategiaDePrecio
    {
        ResultadoCalculo CalcularCosto(int unidades, decimal valorUnidad);
    }
}