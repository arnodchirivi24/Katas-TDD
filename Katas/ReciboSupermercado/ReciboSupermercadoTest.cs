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
        [InlineData(1,2.24)]
        [InlineData(2,4.48)]
        [InlineData(8,17.93)]

        public void Debe_CalcularCostoTotal_CuandoSeCompra_N_BolsasDeArrozConPrecioDe_2_49_AplicandoDescuentoel_10_Porciento_DevuelveTotalDeEurosCorrespondiente(int unidad, double valorTotalEsperado)
        {
            var valorUnidad = 2.49m; 
            var costoTotal = (decimal)valorTotalEsperado;
            var descripcionProducto = "Arroz";
            var reciboSuper = new ReciboSupermercado();

            reciboSuper.CalcularCostoTotal(unidad, valorUnidad, descripcionProducto).Should().Be(costoTotal);
        }

        [Fact]
        public void Debe_CalcularCostoTotal_CuandoSeCompra_5_TubosDePastaDeDientes_DevolverElValorDe_7_49_Euros()
        {
            var unidades = 5;
            var valorUnidad = 1.79m;
            var valorEsperadoTotal = 7.49m;
            var descripcionProducto = "Tubo de pasta de dientes";
            var reciboSuper = new ReciboSupermercado();

            reciboSuper.CalcularCostoTotal(unidades, valorUnidad, descripcionProducto).Should().Be(valorEsperadoTotal);
        }

        [Fact]
                    
        public void Debe_CalcularCostoTotal_CuandoSeCompra_3_TubosDePastaDeDientes_DevolverElValorDe_5_37_Euros()
        {
            var unidades = 3;
            var valorUnidad = 1.79m;
            var valorEsperadoTotal = 5.37m;
            var descripcionProducto = "Tubo de pasta de dientes";
            var reciboSuper = new ReciboSupermercado();

            reciboSuper.CalcularCostoTotal(unidades, valorUnidad, descripcionProducto).Should().Be(valorEsperadoTotal);
        }

        [Fact]

        public void Debe_CalcularCostoTotal_CuandoSeCompra_10_TubosDePastaDeDientes_DevolverElValorDe_14_98_Euros()
        {
            var unidades = 10;
            var valorUnidad = 1.79m;
            var valorEsperadoTotal = 14.98m;
            var descripcionProducto = "Tubo de pasta de dientes";
            var reciboSuper = new ReciboSupermercado();

            reciboSuper.CalcularCostoTotal(unidades, valorUnidad, descripcionProducto).Should().Be(valorEsperadoTotal);
        }


        [Fact]
        
        public void Debe_CalcularCostoTotal_CuandoSeCompra_2_CajasDeTomates_DevolverElValorDe_0_99_Euros()
        {
            var unidades = 2;
            var valorUnidad = 0.69m;
            var valorEsperadoPorDosCajas = 0.99m;
            var descripcionProducto = "Cajas de tomates";
            var reciboSuper = new ReciboSupermercado();

            reciboSuper.CalcularCostoTotal(unidades, valorUnidad, descripcionProducto).Should().Be(valorEsperadoPorDosCajas);
        }


    }
}
