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

        //- [ ] Debe en la primera linea de cada estrofa tener la frase "On the [x] day of Christmas" en donde[x] sea el numero ordinal de cada dia

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
    }
}
