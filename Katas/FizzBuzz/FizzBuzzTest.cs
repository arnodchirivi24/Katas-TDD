using FluentAssertions;

namespace Katas
{
    public class FizzBuzzTest
    {

        [Theory]
        [InlineData(3)]
        [InlineData(9)]
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

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(90)]
        public void Debe_ObtenerFizzBuzz_DevolverFizzBuzzSiLosNumerosSonMultiplosDeTresYCinco(int indice)
        {
            var fizzBuzz = new FizzBuzz();
            var palabraEsperada = "FizzBuzz";

            var resultado = fizzBuzz.ObtenerFizzBuzz();

            resultado[indice -1].Should().Be(palabraEsperada);
        }
    }

    internal class FizzBuzz
    {
        public List<object> ObtenerFizzBuzz()
        {
            List<object> resultadoFizzBuzz = new List<object>();

            for(int i= 1; i <= 100; i++) 
            {
                string texto = ObtenerTextoFizzBuzz(i);
                resultadoFizzBuzz.Add(string.IsNullOrEmpty(texto) ? i: texto);
            }

            return resultadoFizzBuzz;
        }

        public string ObtenerTextoFizzBuzz(int indice)
        {
            string texto = "";
            if (indice % 3 == 0) texto += "Fizz";            
            if (indice % 5 == 0) texto += "Buzz";
            return texto;
        }
    }


}
