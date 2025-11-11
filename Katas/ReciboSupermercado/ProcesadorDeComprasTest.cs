using FluentAssertions;
using Logica;

namespace Katas.ReciboSupermercadoTest
{
    public class ProcesadorDeComprasTest
    {

        private readonly ProcesadorDeCompras _reciboSupermercado;

        public ProcesadorDeComprasTest()
        {
            var ofertaDeLaSemana = new Dictionary<string, IEstrategiaDePrecio>
            {
                { "Cepillo", new Descuento2x1() },
                { "Manzanas", new DescuentoPorcentaje(0.2m) },
                { "Arroz", new DescuentoPorcentaje(0.1m) },
                { "Tubo de pasta de dientes", new DescuentoPorCombos(5, 7.49m) },
                { "Cajas de tomates", new DescuentoPorCombos(2,0.99m) },
            };
            _reciboSupermercado = new ProcesadorDeCompras(ofertaDeLaSemana);
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
            var listaDeCompra = new List<ProductoComprado>
            {
                new ProductoComprado("Manzanas", 2, 1.99m, "Kilos"),
                new ProductoComprado("Pan", 2, 0.50m),
                new ProductoComprado("Cepillo", 2, 0.99m),
                new ProductoComprado("Tubo de pasta de dientes", 10, 1.79m)
            };

            //Act
            Recibo reciboGenerado = _reciboSupermercado.ProcesarCompra(listaDeCompra);

            // Assert
            var lineaManzanas = reciboGenerado.Lineas.First(l => l.Descripcion == "Manzanas");
            var lineaPan = reciboGenerado.Lineas.First(l => l.Descripcion == "Pan");
            var lineaCepillos = reciboGenerado.Lineas.First(l => l.Descripcion == "Cepillo");
            var lineaTubo = reciboGenerado.Lineas.First(l => l.Descripcion == "Tubo de pasta de dientes");

            lineaManzanas.ValorTotal.Should().Be(3.18m);
            lineaManzanas.ValorDescuento.Should().Be(0.80m);

            lineaPan.ValorTotal.Should().Be(1.00m);

            lineaCepillos.ValorTotal.Should().Be(0.99m);
            lineaCepillos.ValorDescuento.Should().Be(0.99m);

            lineaTubo.ValorTotal.Should().Be(14.98m);
            lineaTubo.ValorDescuento.Should().Be(2.92m);

            reciboGenerado.TotalCompra.Should().Be(20.15m);
        }
    }
}
