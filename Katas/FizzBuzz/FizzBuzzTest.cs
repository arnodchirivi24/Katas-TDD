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

        [Theory]
        [InlineData(5)]
        [InlineData(85)]
        [InlineData(95)]
        public void Debe_ObtenerFizzBuzz_DevolverBuzzSiSonNumerosMultiplosDeCinco(int indice)
        {
            var fizzBuzz = new FizzBuzz();
            var palabraEsperada = "Buzz";

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
                if (i % 3 == 0)
                {
                    numeros.Add("Fizz");
                }
                else
                {
                    numeros.Add(i);
                }
            }

            return numeros;
        }

    }
}
