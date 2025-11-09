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

        [Fact]
        public void Debe_CalcularCostoTotal_CuandoSeCompran2CepillosConPromocionDe2x1YPrecioDe0_99CadaUno_DevuelveTotalDe1_98_Euros()
        {
            //Arrange
            var unidades = 3;
            var valorUnidad = 0.99m;
            var costoTotal = 1.98m;
            var reciboSuper = new ReciboSupermercado();
            //Act

            //Assert
            reciboSuper.CalcularCostoTotal(unidades, valorUnidad, "Cepillo").Should().Be(costoTotal);
        }
    }
}
