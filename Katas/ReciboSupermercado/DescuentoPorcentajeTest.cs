using FluentAssertions;
using Logica;

namespace Katas.ReciboSupermercadoTest
{
    public class DescuentoPorcentajeTest
    {

        [Theory]
        [InlineData(1,1.99, 1.59, 0.40, 0.20)]
        //[InlineData(2,1.99, 3.18, 0.80, 0.20)]
        //[InlineData(5,1.99, 7.96, 1.99, 0.20)]
        //[InlineData(10,1.99, 9.95, 9.95, 0.50)]
        public void Debe_CalcularCostoTotal_CuandoSeCompra_N_KiloDeManzanasConPrecioDe_1_99_AplicandoDescuentoDel20Porciento_DevuelveTotalDeEurosCorrespondiente(int cantidadKilosComprada, double valorUnidadKilo, double valorTotalEsperado, double valorDescuento, double valorPorcentajePromocion)
        {            
            var descuentoPorPorcentaje = new DescuentoPorcentaje((decimal)valorPorcentajePromocion);
            ResultadoCalculo resultadoEsperado = new ResultadoCalculo((decimal)valorTotalEsperado, (decimal)valorDescuento);

            ResultadoCalculo resultadoCalculoPorcentaje = descuentoPorPorcentaje.CalcularCosto(cantidadKilosComprada, (decimal)valorUnidadKilo);

            resultadoCalculoPorcentaje.Should().Be(resultadoEsperado);
        }


        [Theory]
        [InlineData(1, 2.49, 2.24, 0.25, 0.10)]
        [InlineData(2, 2.49, 4.48, 0.50, 0.10)]
        [InlineData(8, 2.49, 17.93, 1.99, 0.10)]

        public void Debe_CalcularCostoTotal_CuandoSeCompra_N_BolsasDeArrozConPrecioDe_2_49_AplicandoDescuentoel_10_Porciento_DevuelveTotalDeEurosCorrespondiente(int unidad, double valorUnidadBolsa, double valorTotalEsperado, double valorDescuento, double valorPorcentajePromocion)
        {
            var descuentoPorPorcentaje = new DescuentoPorcentaje((decimal)valorPorcentajePromocion);
            ResultadoCalculo resultadoEsperado = new ResultadoCalculo((decimal)valorTotalEsperado, (decimal)valorDescuento);

            ResultadoCalculo resultadoCalculoPorcentaje = descuentoPorPorcentaje.CalcularCosto(unidad, (decimal)valorUnidadBolsa);

            resultadoCalculoPorcentaje.Should().Be(resultadoEsperado);
        }
    }
}
