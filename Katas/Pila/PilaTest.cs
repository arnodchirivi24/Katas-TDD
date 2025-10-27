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


        [Fact]
        public void Debe_ElMetodoObtenerElemento_DevolverElUltimoElementoAgregadoALaPila()
        {
            //Arrange
            var tamanioPila = 5;
            //Act
            var pila = new Pila<string>(tamanioPila);
            pila.AgregarElemento("Manzana");
            pila.AgregarElemento("Naranja");
            pila.AgregarElemento("Piña");


            //Assert
            var resultado = pila.ObtenerElemento();
            resultado.Should().Be("Piña");
        }

    }
}
