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

        [Theory]
        [InlineData(1, 1.59)]
        [InlineData(2, 3.18)]
        [InlineData(5, 7.96)]
        public void Debe_CalcularCostoTotal_CuandoSeCompra_N_KiloDeManzanasConPrecioDe_1_99_AplicandoDescuentoDel20Porciento_DevuelveTotalDeEurosCorrespondiente(int cantidadKilosComprada, double valorTotalEsperado)
        {
            var valorUnidadKilo = 1.99m;
            var costoTotalEsperado = (decimal)valorTotalEsperado;
            var descripcionProducto = "Manzanas";
            var reciboSuperMercado = new ReciboSupermercado();

            reciboSuperMercado.CalcularCostoTotal(cantidadKilosComprada, valorUnidadKilo, descripcionProducto).Should().Be(costoTotalEsperado);
        }


        [Fact]                   

        public void Debe_CalcularCostoTotal_CuandoSeCompra1BolsaDeArrozConPrecioDe_2_49_AplicandoDescuentoel_10_Porciento_DevolverElValorDe_2_24_Euros()
        {
            var unidad = 1;
            var valorUnidad = 2.49m;
            var valorDescuento = 0.10m;
            var valorSinDescuento = unidad * valorUnidad;
            var costoTotal = Math.Round(valorSinDescuento * (1 - valorDescuento), 2);
            var descripcionProducto = "Arroz";
            var reciboSuper = new ReciboSupermercado();

            reciboSuper.CalcularCostoTotal(unidad, valorUnidad, descripcionProducto).Should().Be(costoTotal);
        }

        [Fact]

        public void Debe_CalcularCostoTotal_CuandoSeCompra2BolsasDeArrozConPrecioDe_2_49_AplicandoDescuentoel_10_Porciento_DevolverElValorDe_4_48_Euros()
        {
            var unidad = 2;
            var valorUnidad = 2.49m;
            var valorDescuento = 0.10m;
            var valorSinDescuento = unidad * valorUnidad;
            var costoTotal = Math.Round(valorSinDescuento * (1 - valorDescuento), 2);
            var descripcionProducto = "Arroz";
            var reciboSuper = new ReciboSupermercado();

            reciboSuper.CalcularCostoTotal(unidad, valorUnidad, descripcionProducto).Should().Be(costoTotal);
        }
    }
}
