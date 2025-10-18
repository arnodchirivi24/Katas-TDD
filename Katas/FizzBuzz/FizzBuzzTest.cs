using FluentAssertions;

namespace Katas
{
    public class FizzBuzzTest
    {
        [Fact]
        public void Debe_ObtenerFizzBuzz_DevolverLosNumerosDel_UnoAl_Cien()
        {
            var fizzBuzz = new FizzBuzz();

            var resultadoNumerosUnoAlCien = fizzBuzz.ObtenerFizzBuzz();

            resultadoNumerosUnoAlCien.Should().BeEquivalentTo(Enumerable.Range(1, 100).ToList());
        }

        [Theory]
        [InlineData(3)]
        [InlineData(30)]
        [InlineData(99)]
        public void Debe_ObtenerFizzBuzz_DevolverFizzSiSonNumerosMultiplosDeTres(int indice)
        {
            var fizzBuzz = new FizzBuzz();
            var palabraEsperada = "Fizz";

            var resultado = fizzBuzz.ObtenerFizzBuzz();

            resultado[indice - 1].Should().Be(palabraEsperada);
        }
    }

    internal class FizzBuzz
    {
        public List<object> ObtenerFizzBuzz()
        {
            List<object> numeros = new List<object>();

            for(int i= 1; i <= 100; i++) 
            {
                numeros.Add(i);
            }

            return numeros;
        }

    }
}
