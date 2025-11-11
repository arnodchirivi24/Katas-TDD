
using FluentAssertions;
using Logica;

namespace Katas.ReciboSupermercadoTest
{
    public class Descuento2x1Test
    {

        [Theory]
        [InlineData(7, 0.99, 3.96, 2.97)]
        [InlineData(3, 0.99, 1.98, 0.99)]
        [InlineData(2, 0.99, 0.99, 0.99)]
        [InlineData(6, 0.99, 2.97, 2.97)]
        public void Debe_CalcularCostoTotal_CuandoSeCompran_N_CepillosConPromocionDe2x1YPrecioDe0_99CadaUno_DevuelveTotalDeEurosCorrespondiente(int unidades, double valorPor2x1, double valorTotal, double valorDescuento)
        {
            //Arrange      
            ResultadoCalculo resultadoEsperado = new ResultadoCalculo((decimal)valorTotal, (decimal)valorDescuento);
            var tipoDeDescuento2X1 = new Descuento2x1();
            //Act
            ResultadoCalculo resultadoCalculo2X1 = tipoDeDescuento2X1.CalcularCosto(unidades, (decimal)valorPor2x1);

            //Assert
            resultadoCalculo2X1.Should().Be(resultadoEsperado);
        }
    }
}
