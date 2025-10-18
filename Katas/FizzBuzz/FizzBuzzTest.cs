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
    }

    internal class FizzBuzz
    {
        public List<int> ObtenerFizzBuzz()
        {
            List<int> numeros = new List<int>();

            for(int i= 1; i <= 100; i++) 
            {
                numeros.Add(i);
            }

            return numeros;
        }

    }
}
