using FluentAssertions;
using Logica;


namespace Katas.PilaTest
{
    public class PilaTest
    {

        [Fact]
        public void Debe_LaPropiedadTamanio_TenerLaCantidadDeEspacioesDeLaPilaAConstruir()
        {
            //Arrange
            int tamanioPila = 5;

            //Act
            var pila = new Pila<string>();

            //Assert
            int resultado = pila.Tamanio;
            resultado.Should().Be(tamanioPila);
        }
    }
}
