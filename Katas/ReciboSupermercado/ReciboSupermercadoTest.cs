using FluentAssertions;
using Logica;
using static Logica.ReciboSupermercado;
namespace Katas.ReciboSupermercadoTest
{
    public class ReciboSupermercadoTest
    {

        private readonly ReciboSupermercado _reciboSupermercado;

        public ReciboSupermercadoTest()
        {
            var ofertaDeLaSemana = new Dictionary<string, IEstrategiaDePrecio>
            {
                { "Manzanas", new DescuentoPorcentaje(0.5m) },
                { "Pan", new PrecioRegular() }
            };
            _reciboSupermercado = new ReciboSupermercado(ofertaDeLaSemana);
        }

        [Theory]
        [InlineData(7, 3.96, 2.97)]
        [InlineData(3, 1.98, 0.99)]
        [InlineData(2, 0.99, 0.99)]
        [InlineData(6, 2.97, 2.97)]
        public void Debe_CalcularCostoTotal_CuandoSeCompran_N_CepillosConPromocionDe2x1YPrecioDe0_99CadaUno_DevuelveTotalDeEurosCorrespondiente(int unidades, double valorTotal, double valorDescuento)
        {
            //Arrange      
            var valorUnidad = 0.99m;
            ResultadoCalculo resultado = new ResultadoCalculo((decimal)valorTotal, (decimal)valorDescuento);
            //Act

            //Assert
            _reciboSupermercado.CalcularCostoTotal(unidades, valorUnidad, "Cepillo").Should().Be(resultado);
        }

        [Theory]
        [InlineData(1, 1.59, 0.40)]
        [InlineData(2, 3.18, 0.80)]
        [InlineData(5, 7.96, 1.99)]
        public void Debe_CalcularCostoTotal_CuandoSeCompra_N_KiloDeManzanasConPrecioDe_1_99_AplicandoDescuentoDel20Porciento_DevuelveTotalDeEurosCorrespondiente(int cantidadKilosComprada, double valorTotalEsperado, double valorDescuento)
        {
            var valorUnidadKilo = 1.99m;
            var descripcionProducto = "Manzanas";
            //var reciboSuperMercado = new ReciboSupermercado();
            ResultadoCalculo resultado = new ResultadoCalculo((decimal)valorTotalEsperado, (decimal)valorDescuento);

            _reciboSupermercado.CalcularCostoTotal(cantidadKilosComprada, valorUnidadKilo, descripcionProducto).Should().Be(resultado);
        }


        [Theory]
        [InlineData(1, 2.24, 0.25)]
        [InlineData(2, 4.48, 0.50)]
        [InlineData(8, 17.93, 1.99)]

        public void Debe_CalcularCostoTotal_CuandoSeCompra_N_BolsasDeArrozConPrecioDe_2_49_AplicandoDescuentoel_10_Porciento_DevuelveTotalDeEurosCorrespondiente(int unidad, double valorTotalEsperado, double valorDescuento)
        {
            var valorUnidad = 2.49m;
            var descripcionProducto = "Arroz";
        
            ResultadoCalculo resultado = new ResultadoCalculo((decimal)valorTotalEsperado, (decimal)valorDescuento);

           _reciboSupermercado.CalcularCostoTotal(unidad, valorUnidad, descripcionProducto).Should().Be(resultado);
        }


        [Theory]
        [InlineData(3, 5.37, 0)]
        [InlineData(5, 7.49, 1.46)]
        [InlineData(10, 14.98, 2.92)]
        [InlineData(7, 11.07, 1.46)]
        public void Debe_CalcularCostoTotal_CuandoSeCompra_N_TubosDePastaDeDientes_DevuelveTotalDeEurosCorrespondiente(int unidades, double valorTotalEsperado, double valorDescuento)
        {
            var valorUnidad = 1.79m;
            var descripcionProducto = "Tubo de pasta de dientes";
      
            ResultadoCalculo resultado = new ResultadoCalculo((decimal)valorTotalEsperado, (decimal)valorDescuento);

            _reciboSupermercado.CalcularCostoTotal(unidades, valorUnidad, descripcionProducto).Should().Be(resultado);
        }


        [Theory]
        [InlineData(2, 0.99, 0.39)]
        [InlineData(6, 2.97, 1.17)]
        [InlineData(7, 3.66, 1.17)]

        public void Debe_CalcularCostoTotal_CuandoSeCompra_N_CajasDeTomates_DevuelveTotalDeEurosCorrespondiente(int unidades, double valorTotalEsperado, double valorDescuento)
        {
            var valorUnidad = 0.69m;
            var descripcionProducto = "Cajas de tomates";
          
            ResultadoCalculo resultado = new ResultadoCalculo((decimal)valorTotalEsperado, (decimal)valorDescuento);

            _reciboSupermercado.CalcularCostoTotal(unidades, valorUnidad, descripcionProducto).Should().Be(resultado);
        }


        [Theory]
        [InlineData("Shampo", 2, 1.0, "Unidad", 2.0, 0.0)]
        [InlineData("Cajas de tomates", 2, 0.69, "Unidad", 0.99, 0.39)]
        public void Debe_ProcesarCompra_DevolverLineasCorrectas_ConOSinDescuento(
            string descripcion,
            int cantidad,
            decimal valorUnidad,
            string unidadDeMedida,
            decimal valorTotalEsperado,
            decimal valorDescuentoEsperado)
        {
      
            var listaDeCompras = new List<ProductoComprado>
            {
                new ProductoComprado(descripcion, cantidad, valorUnidad, unidadDeMedida)
            };

            Recibo reciboGenerado = _reciboSupermercado.ProcesarCompra(listaDeCompras);

            reciboGenerado.Lineas.Should().HaveCount(1);

            var linea = reciboGenerado.Lineas[0];
            linea.Descripcion.Should().Be(descripcion);
            linea.Cantidad.Should().Be(cantidad);
            linea.ValorTotal.Should().Be(valorTotalEsperado);
            linea.ValorDescuento.Should().Be(valorDescuentoEsperado);
        }



        [Fact]
        public void Debe_UsarLasOfertasDeLaSemanaInyectadasEnElConstructor_EnLugarDeLasReglasInternas()
        {
            //Arrange
     

            //var reciboSuper = new ReciboSupermercado(ofertaDeLaSemana);

            var listaDeCompra = new List<ProductoComprado>
            {
                new ProductoComprado("Manzana", 1, 1.99m, "Kilos"),
                new ProductoComprado("Pan", 2, 0.50m)
            };

            //Act

            Recibo reciboGenerado = _reciboSupermercado.ProcesarCompra(listaDeCompra);

            // Assert
            var lineaManzanas = reciboGenerado.Lineas.First(l => l.Descripcion == "Manzana");
            var lineaPan = reciboGenerado.Lineas.First(l => l.Descripcion == "Pan");

            lineaManzanas.ValorTotal.Should().Be(1.00m);
            lineaManzanas.ValorDescuento.Should().Be(0.99m);

            lineaPan.ValorTotal.Should().Be(1.00m);

            reciboGenerado.TotalCompra.Should().Be(2.00m);

        }
    }
}
