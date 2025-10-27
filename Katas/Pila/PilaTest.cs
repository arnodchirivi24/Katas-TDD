using FluentAssertions;
using Logica;


namespace Katas.PilaTest
{
    public class PilaTest
    {

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(3)]
        public void Debe_LaPropiedadTamanio_TenerLaCantidadDeEspacioesDeLaPilaAConstruir(int tamanioPila)
        {
            //Arrange

            //Act
            var pila = new Pila<string>(tamanioPila);

            //Assert
            int resultado = pila.Tamanio;
            resultado.Should().Be(tamanioPila);
        }
    }
}
