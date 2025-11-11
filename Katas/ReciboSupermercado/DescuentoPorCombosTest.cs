using FluentAssertions;
using Logica;

namespace Katas.ReciboSupermercadoTest
{
    public class DescuentoPorCombosTest
    {
        [Theory]
        [InlineData(3, 5.37, 0, 5, 7.49, 1.79)]
        [InlineData(5, 7.49, 1.46, 5, 7.49, 1.79)]
        [InlineData(10, 14.98, 2.92, 5, 7.49, 1.79)]
        [InlineData(7, 11.07, 1.46, 5, 7.49, 1.79)]
        public void Debe_CalcularCostoTotal_CuandoSeCompra_N_TubosDePastaDeDientes_DevuelveTotalDeEurosCorrespondiente(int unidadesCompradas, double valorTotalEsperado, double valorDescuento, int unidadesDePromocion, double valorPromocion, double valorPrecioNormalPorUnidad)
        {
            ResultadoCalculo resultadoEsperado = new ResultadoCalculo((decimal)valorTotalEsperado, (decimal)valorDescuento);

            var resultadoDescuentoCombo = new DescuentoPorCombos(unidadesDePromocion, (decimal)valorPromocion);

            ResultadoCalculo resultadoCalculoDescuentoCombo = resultadoDescuentoCombo.CalcularCosto(unidadesCompradas, (decimal)valorPrecioNormalPorUnidad);

            resultadoCalculoDescuentoCombo.Should().Be(resultadoEsperado);
        }


        [Theory]
        [InlineData(2, 0.99, 0.39, 2, 0.99, 0.69)]
        [InlineData(6, 2.97, 1.17, 2, 0.99, 0.69)]
        [InlineData(7, 3.66, 1.17, 2, 0.99, 0.69)]

        public void Debe_CalcularCostoTotal_CuandoSeCompra_N_CajasDeTomates_DevuelveTotalDeEurosCorrespondiente(int unidadesCompradas, double valorTotalEsperado, double valorDescuento, int unidadesDePromocion, double valorPromocion, double valorPrecioNormalPorUnidad)
        {
            ResultadoCalculo resultadoEsperado = new ResultadoCalculo((decimal)valorTotalEsperado, (decimal)valorDescuento);

            var resultadoDescuentoCombo = new DescuentoPorCombos(unidadesDePromocion, (decimal)valorPromocion);

            ResultadoCalculo resultadoCalculoDescuentoCombo = resultadoDescuentoCombo.CalcularCosto(unidadesCompradas, (decimal)valorPrecioNormalPorUnidad);

            resultadoCalculoDescuentoCombo.Should().Be(resultadoEsperado);
        }
    }
}
