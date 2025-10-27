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

        [Fact]
        public void Debe_ElMetodoAgregarElemento_AñadirUnElementoEnLaParteSuperiorDeLaPila()
        {
            //Arrange
            //Arrange
            var tamanioPila = 5;


            //Act
            var pila = new Pila<string>(tamanioPila);
            pila.AgregarElemento("Manzana");
            pila.AgregarElemento("Naranja");

            //Assert
            var resultado = pila.ObtenerElemento();
            resultado.Should().Be("Naranja");
        }


        [Fact]
        public void Debe_ElMetodoEliminarUltimoElemento_QuitarElElementoEnLaParteSuperiorDeLaPilaYDevolverlo()
        {
            //Arrange       
            var tamanioPila = 5;

            //Act
            var pila = new Pila<string>(tamanioPila);
            pila.AgregarElemento("Manzana");
            pila.AgregarElemento("Naranja");
            pila.AgregarElemento("Piña");


            //Assert
            var resultado = pila.EliminarUltimoElemento();
            var valorIndice = pila.ObtenerElemento();

            resultado.Should().Be("Piña");
            valorIndice.Should().Be("Naranja");
        }

        [Fact]
        public void Debe_ElMetodoObtenerCantidadRetornarseElTamanioDeLaPila()
        {
            //Arrange       
            var tamanioPila = 5;

            //Act
            var pila = new Pila<string>(tamanioPila);
            pila.AgregarElemento("Manzana");
            pila.AgregarElemento("Naranja");

            //Assert
            pila.ObtenerCantidad().Should().Be(2);
        }

        [Fact]
        public void Debe_EsVacio_RetornarTrueCuandoEsteVaciaLaPila()
        {
            var tamanioPila = 5;

            //Act
            var pila = new Pila<string>(tamanioPila);

            //Assert
            pila.EsVacio.Should().BeTrue();
        }


    }
}
