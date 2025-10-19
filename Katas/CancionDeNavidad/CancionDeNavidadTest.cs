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


        [Theory]
        [InlineData(0, "A partridge in a pear tree.")]
        [InlineData(1, "Two turtle doves and")]
        [InlineData(2, "Three french hens")]
        [InlineData(8, "Nine ladies dancing")]
        [InlineData(11, "Twelve drummers drumming")]
        public void Debe_ObtenerCancion_RetornarEnLaTerceraLineaDeCadaEstrofaElRegaloDeCadaDiaConNumeroCardinal(int indiceEstrofa, string lineaEsperada)
        {
            var cancion = new CancionDeNavidad();
            var indiceNumeroLineaEvaluada = 2;

            var resultado = cancion.ObtenerCancion();

            resultado[indiceEstrofa][indiceNumeroLineaEvaluada].Should().Be(lineaEsperada);
        }



        [Fact]
        public void Debe_ObtenerCancionCompleta_GenerarLaLetraCompletaCorrectamente()
        {

            var cancion = new CancionDeNavidad();

            string letraEsperada = @"On the first day of Christmas
                                    My true love sent to me:
                                    A partridge in a pear tree.

                                    On the second day of Christmas
                                    My true love sent to me:
                                    Two turtle doves and
                                    A partridge in a pear tree.

                                    On the third day of Christmas
                                    My true love sent to me:
                                    Three french hens
                                    Two turtle doves and
                                    A partridge in a pear tree.

                                    On the fourth day of Christmas
                                    My true love sent to me:
                                    Four calling birds
                                    Three french hens
                                    Two turtle doves and
                                    A partridge in a pear tree.

                                    On the fifth day of Christmas
                                    My true love sent to me:
                                    Five golden rings
                                    Four calling birds
                                    Three french hens
                                    Two turtle doves and
                                    A partridge in a pear tree.

                                    On the sixth day of Christmas
                                    My true love sent to me:
                                    Six geese a-laying
                                    Five golden rings
                                    Four calling birds
                                    Three french hens
                                    Two turtle doves and
                                    A partridge in a pear tree.

                                    On the seventh day of Christmas
                                    My true love sent to me:
                                    Seven swans a-swimming
                                    Six geese a-laying
                                    Five golden rings
                                    Four calling birds
                                    Three french hens
                                    Two turtle doves and
                                    A partridge in a pear tree.

                                    On the eight day of Christmas
                                    My true love sent to me:
                                    Eight maids a-milking
                                    Seven swans a-swimming
                                    Six geese a-laying
                                    Five golden rings
                                    Four calling birds
                                    Three french hens
                                    Two turtle doves and
                                    A partridge in a pear tree.

                                    On the ninth day of Christmas
                                    My true love sent to me:
                                    Nine ladies dancing
                                    Eight maids a-milking
                                    Seven swans a-swimming
                                    Six geese a-laying
                                    Five golden rings
                                    Four calling birds
                                    Three french hens
                                    Two turtle doves and
                                    A partridge in a pear tree.

                                    On the tenth day of Christmas
                                    My true love sent to me:
                                    Ten lords a-leaping
                                    Nine ladies dancing
                                    Eight maids a-milking
                                    Seven swans a-swimming
                                    Six geese a-laying
                                    Five golden rings
                                    Four calling birds
                                    Three french hens
                                    Two turtle doves and
                                    A partridge in a pear tree.

                                    On the eleventh day of Christmas
                                    My true love sent to me:
                                    Eleven pipers piping
                                    Ten lords a-leaping
                                    Nine ladies dancing
                                    Eight maids a-milking
                                    Seven swans a-swimming
                                    Six geese a-laying
                                    Five golden rings
                                    Four calling birds
                                    Three french hens
                                    Two turtle doves and
                                    A partridge in a pear tree.

                                    On the twelfth day of Christmas
                                    My true love sent to me:
                                    Twelve drummers drumming
                                    Eleven pipers piping
                                    Ten lords a-leaping
                                    Nine ladies dancing
                                    Eight maids a-milking
                                    Seven swans a-swimming
                                    Six geese a-laying
                                    Five golden rings
                                    Four calling birds
                                    Three french hens
                                    Two turtle doves and
                                    A partridge in a pear tree.";

    
            string resultadoObtenido = cancion.ObtenerCancionCompleta();

            resultadoObtenido.Replace("\r\n", "\n").Should().Be(letraEsperada.Replace("\r\n", "\n"));
        }
    }
}
