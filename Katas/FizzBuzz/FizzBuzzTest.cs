using FluentAssertions;

namespace Katas
{
    public class FizzBuzzTest
    {

        [Theory]
        [InlineData(3)]
        [InlineData(9)]
        [InlineData(27)]
        public void Debe_ObtenerFizzBuzzWhizz_DevolverFizzSiSonNumerosMultiplosDeTres(int indice)
        {
            var fizzBuzz = new FizzBuzzWhizz();
            var palabraEsperada = "Fizz";

            var resultado = fizzBuzz.ObtenerFizzBuzzWhizz();

            resultado[indice - 1].Should().Be(palabraEsperada);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(85)]
        [InlineData(95)]
        public void Debe_ObtenerFizzBuzzWhizz_DevolverBuzzSiSonNumerosMultiplosDeCinco(int indice)
        {
            var fizzBuzz = new FizzBuzzWhizz();
            var palabraEsperada = "Buzz";

            var resultado = fizzBuzz.ObtenerFizzBuzzWhizz();

            resultado[indice - 1].Should().Be(palabraEsperada);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(90)]
        public void Debe_ObtenerFizzBuzzWhizz_DevolverFizzBuzzSiLosNumerosSonMultiplosDeTresYCinco(int indice)
        {
            var fizzBuzz = new FizzBuzzWhizz();
            var palabraEsperada = "FizzBuzz";

            var resultado = fizzBuzz.ObtenerFizzBuzzWhizz();

            resultado[indice -1].Should().Be(palabraEsperada);
        }

        [Theory]
        [InlineData(14)]
        [InlineData(49)]
        [InlineData(56)]
        public void Debe_ObtenerFizzBuzzWhizz_DevolverWhizzSiLosNumerosSonMultiplosDeSiete(int indice)
        {
            var fizzBuzz = new FizzBuzzWhizz();
            var palabraEsperada = "Whizz";

            var resultado = fizzBuzz.ObtenerFizzBuzzWhizz();

            resultado[indice - 1].Should().Be(palabraEsperada);
        }

        [Theory]
        [InlineData(21)]
        [InlineData(42)]
        [InlineData(84)]
        public void Debe_ObtenerFizzBuzzWhizz_DevolverFizzWhizzSiLosNumerosSonMultiplosDeTresYSiete(int indice)
        {
            var fizzBuzz = new FizzBuzzWhizz();
            var palabraEsperada = "FizzWhizz";

            var resultado = fizzBuzz.ObtenerFizzBuzzWhizz();

            resultado[indice - 1].Should().Be(palabraEsperada);
        }

        [Theory]
        [InlineData(22)]
        [InlineData(44)]
        [InlineData(88)]
        public void Debe_ObtenerFizzBuzzWhizz_DevolverBangSiLosNumerosSonMultiplosDeOnce(int indice)
        {
            var fizzBuzzWhizz = new FizzBuzzWhizz();
            var palabraEsperada = "Bang";

            var resultado = fizzBuzzWhizz.ObtenerFizzBuzzWhizz();

            resultado[indice - 1].Should().Be(palabraEsperada);
        }

        [Theory]
        [InlineData(66)]
        [InlineData(99)]
        public void Debe_ObtenerFizzBuzzWhizz_DevolverFizzBangSiLosNumerosSonMultiplosDeTresYOnce(int indice)
        {
            var fizzBuzzWhizz = new FizzBuzzWhizz();
            var palabraEsperada = "FizzBang";

            var resultado = fizzBuzzWhizz.ObtenerFizzBuzzWhizz();

            resultado[indice - 1].Should().Be(palabraEsperada);
        }

        [Fact]
        public void Debe_ObtenerFizzBuzzWhizz_TenerEnLaUltimaPosicionDelResultadoLaPalabra_FizzBuzzWhizzBang()
        {
            var fizzBuzzWhizz = new FizzBuzzWhizz();
            var palabraEsperada = "FizzBuzzWhizzBang";

            var resultado = fizzBuzzWhizz.ObtenerFizzBuzzWhizz();
            var ultimoElemento = resultado.Count() - 1;

            resultado[ultimoElemento].Should().Be(palabraEsperada);
        }
    }

    internal class FizzBuzzWhizz
    {
        private readonly Dictionary<int, string> _palabrasEspeciales = new Dictionary<int, string>
        {
           { 3, "Fizz" },
           { 5, "Buzz" },
           { 7, "Whizz" },
           { 11, "Bang" }
        };

        private readonly string _palabraFizzBuzzWhizzBang = "FizzBuzzWhizzBang";

        public List<object> ObtenerFizzBuzzWhizz()
        {
            List<object> resultadoFizzBuzz = new List<object>();

            for(int i= 1; ; i++) 
            {
                string texto = ObtenerTextoFizzBuzzWhizz(i);
                resultadoFizzBuzz.Add(string.IsNullOrEmpty(texto) ? i: texto);
                if (texto == _palabraFizzBuzzWhizzBang) break;
            }

            return resultadoFizzBuzz;
        }

        public string ObtenerTextoFizzBuzzWhizz(int indice)
        {    
            string texto = "";

            foreach(var item in _palabrasEspeciales)
                if(indice % item.Key == 0) texto += item.Value;
            
            return texto;
        }
    }
}
