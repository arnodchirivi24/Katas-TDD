using FluentAssertions;
using Logica;
namespace Katas.ReciboSupermercadoTest
{
    public class ReciboSupermercadoTest
    {
        [Fact]
        public void Debe_CalcularCostoTotal_CuandoSeCompran2CepillosConPromocionDe2x1YPrecioDe0_99CadaUno_DevuelveTotalDe0_99()
        {
            var costoTotal = 0.99m;
            var reciboSuper = new ReciboSupermercado();

            reciboSuper.CalcularCostoTotal(2, 0.99m, "Cepillo").Should().Be(costoTotal);
        }
    }
}
