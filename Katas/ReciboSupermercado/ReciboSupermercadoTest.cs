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


        [Theory]
        [InlineData(1, 2.24)]
        [InlineData(2, 4.48)]
        [InlineData(8, 17.93)]

        public void Debe_CalcularCostoTotal_CuandoSeCompra_N_BolsasDeArrozConPrecioDe_2_49_AplicandoDescuentoel_10_Porciento_DevuelveTotalDeEurosCorrespondiente(int unidad, double valorTotalEsperado)
        {
            var valorUnidad = 2.49m;
            var costoTotal = (decimal)valorTotalEsperado;
            var descripcionProducto = "Arroz";
            var reciboSuper = new ReciboSupermercado();

            reciboSuper.CalcularCostoTotal(unidad, valorUnidad, descripcionProducto).Should().Be(costoTotal);
        }


        [Theory]
        [InlineData(3, 5.37)]
        [InlineData(5, 7.49)]
        [InlineData(10, 14.98)]
        [InlineData(7, 11.07)]
        public void Debe_CalcularCostoTotal_CuandoSeCompra_N_TubosDePastaDeDientes_DevuelveTotalDeEurosCorrespondiente(int unidades, double valorTotalEsperado)
        {
            var valorUnidad = 1.79m;
            var costoTotal = (decimal)valorTotalEsperado;
            var descripcionProducto = "Tubo de pasta de dientes";
            var reciboSuper = new ReciboSupermercado();

            reciboSuper.CalcularCostoTotal(unidades, valorUnidad, descripcionProducto).Should().Be(costoTotal);
        }


        [Theory]
        [InlineData(2, 0.99)]
        [InlineData(6, 2.97)]
        [InlineData(7, 3.66)]

        public void Debe_CalcularCostoTotal_CuandoSeCompra_N_CajasDeTomates_DevuelveTotalDeEurosCorrespondiente(int unidades, double valorTotalEsperado)
        {
            var valorUnidad = 0.69m;
            var costoTotal = (decimal)valorTotalEsperado;
            var descripcionProducto = "Cajas de tomates";
            var reciboSuper = new ReciboSupermercado();

            reciboSuper.CalcularCostoTotal(unidades, valorUnidad, descripcionProducto).Should().Be(costoTotal);
        }
    }
}
