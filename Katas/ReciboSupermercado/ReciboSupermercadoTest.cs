using FluentAssertions;
using Logica;
namespace Katas.ReciboSupermercadoTest
{
    public class ReciboSupermercadoTest
    {

        [Theory]
        [InlineData(7, 3.96)]
        [InlineData(3, 1.98)]
        [InlineData(2, 0.99)]
        [InlineData(6, 2.97)]
        public void Debe_CalcularCostoTotal_CuandoSeCompran_N_CepillosConPromocionDe2x1YPrecioDe0_99CadaUno_DevuelveTotalDeEurosCorrespondiente(int unidades, double valorEsperado)
        {
            //Arrange      
            var valorUnidad = 0.99m;
            var costoTotal = (decimal)valorEsperado;
            var reciboSuper = new ReciboSupermercado();
            //Act

            //Assert
            reciboSuper.CalcularCostoTotal(unidades, valorUnidad, "Cepillo").Should().Be(costoTotal);
        }


        [Fact]
        public void Debe_CalcularCostoTotal_CuandoSeCompraUnKiloDeManzanasConPrecioDe_1_99_AplicandoDescuentoDel20Porciento_Devolver_1_59()
        {
            var valorUnidadKilo = 1.99m;
            var costoTotalEsperado = 1.59m;
            var descripcionProducto = "Manzanas";
            var reciboSuperMercado = new ReciboSupermercado();

            reciboSuperMercado.CalcularCostoTotal(1, valorUnidadKilo, descripcionProducto).Should().Be(costoTotalEsperado);
        }
    }
}
