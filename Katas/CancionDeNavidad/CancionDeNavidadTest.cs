using FluentAssertions;
using Logica;
namespace Katas.CancionDeNavidadTest
{
    public class CancionDeNavidadTest
    {
        [Fact]
        public void Debe_ObtenerCancion_RetornarUnaListaDeDoceElementos()
        {
            var cancion = new CancionDeNavidad();

            var resultado = cancion.ObtenerCancion();

            resultado.Count().Should().Be(12);
        }

        [Theory]
        [InlineData(0, "On the first day of Christmas")]
        [InlineData(5, "On the sixth day of Christmas")]
        [InlineData(10, "On the eleventh day of Christmas")]
        public void Debe_ObtenerCancion_RetornarEnLaPrimeraLineaDeCadaEstrofaLaFrase_On_the_x_day_of_Christmas_EnDondeXSeaElNumeroOrdinalDeCadaDia(int indiceEstrofa, string textoEsperado)
        {
            var cancion = new CancionDeNavidad();
            var indicePrimeraLinea = 0;

            var resultado = cancion.ObtenerCancion();

            resultado[indiceEstrofa][indicePrimeraLinea].Should().Be(textoEsperado);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(4, 1)]
        [InlineData(9, 1)]
        public void Debe_ObtenerCancion_RetornarEnLaSegundaLineaDeCadaEstrofa_My_true_love_sent_to_me(int indiceEstrofa, int indiceLinea)
        {
            var cancion = new CancionDeNavidad();
            var segundaLineaEsperada = "My true love sent to me:";

            var resultado = cancion.ObtenerCancion();

            resultado[indiceEstrofa][indiceLinea].Should().Be(segundaLineaEsperada);
        }
    }
}
