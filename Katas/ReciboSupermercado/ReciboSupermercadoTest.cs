using FluentAssertions;
using Logica;
using static Logica.ReciboSupermercado;
namespace Katas.ReciboSupermercadoTest
{
    public class ReciboSupermercadoTest
    {

        [Theory]
        [InlineData(7, 3.96, 2.97)]
        [InlineData(3, 1.98, 0.99)]
        [InlineData(2, 0.99, 0.99)]
        [InlineData(6, 2.97, 2.97)]
        public void Debe_CalcularCostoTotal_CuandoSeCompran_N_CepillosConPromocionDe2x1YPrecioDe0_99CadaUno_DevuelveTotalDeEurosCorrespondiente(int unidades, double valorTotal, double valorDescuento)
        {
            //Arrange      
            var valorUnidad = 0.99m;
            var reciboSuper = new ReciboSupermercado();
            ResultadoCalculo resultado = new ResultadoCalculo((decimal)valorTotal, (decimal)valorDescuento);
            //Act

            //Assert
            reciboSuper.CalcularCostoTotal(unidades, valorUnidad, "Cepillo").Should().Be(resultado);
        }

        [Theory]
        [InlineData(1, 1.59, 0.40)]
        [InlineData(2, 3.18, 0.80)]
        [InlineData(5, 7.96, 1.99)]
        public void Debe_CalcularCostoTotal_CuandoSeCompra_N_KiloDeManzanasConPrecioDe_1_99_AplicandoDescuentoDel20Porciento_DevuelveTotalDeEurosCorrespondiente(int cantidadKilosComprada, double valorTotalEsperado, double valorDescuento)
        {
            var valorUnidadKilo = 1.99m;
            var descripcionProducto = "Manzanas";
            var reciboSuperMercado = new ReciboSupermercado();
            ResultadoCalculo resultado = new ResultadoCalculo((decimal)valorTotalEsperado, (decimal)valorDescuento);

            reciboSuperMercado.CalcularCostoTotal(cantidadKilosComprada, valorUnidadKilo, descripcionProducto).Should().Be(resultado);
        }


        [Theory]
        [InlineData(1, 2.24, 0.25)]
        [InlineData(2, 4.48, 0.50)]
        [InlineData(8, 17.93, 1.99)]

        public void Debe_CalcularCostoTotal_CuandoSeCompra_N_BolsasDeArrozConPrecioDe_2_49_AplicandoDescuentoel_10_Porciento_DevuelveTotalDeEurosCorrespondiente(int unidad, double valorTotalEsperado, double valorDescuento)
        {
            var valorUnidad = 2.49m;
            var descripcionProducto = "Arroz";
            var reciboSuper = new ReciboSupermercado();
            ResultadoCalculo resultado = new ResultadoCalculo((decimal)valorTotalEsperado, (decimal)valorDescuento);

            reciboSuper.CalcularCostoTotal(unidad, valorUnidad, descripcionProducto).Should().Be(resultado);
        }


        [Theory]
        [InlineData(3, 5.37,0)]
        [InlineData(5, 7.49, 1.46)]
        [InlineData(10, 14.98, 2.92)]
        [InlineData(7, 11.07,1.46)]
        public void Debe_CalcularCostoTotal_CuandoSeCompra_N_TubosDePastaDeDientes_DevuelveTotalDeEurosCorrespondiente(int unidades, double valorTotalEsperado, double valorDescuento)
        {
            var valorUnidad = 1.79m;
            var descripcionProducto = "Tubo de pasta de dientes";
            var reciboSuper = new ReciboSupermercado();
            ResultadoCalculo resultado = new ResultadoCalculo((decimal)valorTotalEsperado, (decimal)valorDescuento);

            reciboSuper.CalcularCostoTotal(unidades, valorUnidad, descripcionProducto).Should().Be(resultado);
        }


        [Theory]
        [InlineData(2, 0.99, 0.39)]
        [InlineData(6, 2.97, 1.17)]
        [InlineData(7, 3.66, 1.17)]

        public void Debe_CalcularCostoTotal_CuandoSeCompra_N_CajasDeTomates_DevuelveTotalDeEurosCorrespondiente(int unidades, double valorTotalEsperado, double valorDescuento)
        {
            var valorUnidad = 0.69m;
            var descripcionProducto = "Cajas de tomates";
            var reciboSuper = new ReciboSupermercado();
            ResultadoCalculo resultado = new ResultadoCalculo((decimal)valorTotalEsperado, (decimal)valorDescuento);

            reciboSuper.CalcularCostoTotal(unidades, valorUnidad, descripcionProducto).Should().Be(resultado);
        }

        [Fact]
        public void Debe_ProcesarCompra_ProcesarUnaListaVaiaDeProductosY_DevolverUnReciboVacio()
        {
            var reciboSuper = new ReciboSupermercado();
            var listaDeCompraVacia = new List<ProductoComprado>();

            Recibo reciboGenerado = reciboSuper.ProcesarCompra(listaDeCompraVacia);

            reciboGenerado.Lineas.Should().BeEmpty();
            reciboGenerado.TotalCompra.Should().Be(0m);
        }

        [Fact]
        public void Debe_ProcesarCompra_ProcesarUnaListaDeProductoSimple_DevolverUnaListaSinDescuento()
        {
            var reciboSuper = new ReciboSupermercado();
            var listaDeCompras = new List<ProductoComprado>
            {
                new ProductoComprado("Shampo", 2, 1.0m, "Unidad")
            };

            Recibo reciboGenerado = reciboSuper.ProcesarCompra(listaDeCompras);

            reciboGenerado.Lineas.Should().HaveCount(1);
            var linea = reciboGenerado.Lineas[0];
            linea.Descripcion.Should().Be("Shampo");
            linea.Cantidad.Should().Be(2);
            linea.ValorTotal.Should().Be(2.0m);
            linea.ValorDescuento.Should().Be(0m);
        }
    }

}
