using FluentAssertions;
using Logica;


namespace Katas.PilaTest
{
    public class PilaTest
    {

        private readonly int _tamanioPila = 5;
        private readonly Pila<string> _pila;

        public PilaTest()
        {
            _pila = new Pila<string>(_tamanioPila);
        }

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
            _pila.AgregarElemento("Manzana");
            _pila.AgregarElemento("Naranja");
            _pila.AgregarElemento("Piña");


            //Assert
            var resultado = _pila.ObtenerElemento();
            resultado.Should().Be("Piña");
        }

        [Fact]
        public void Debe_ElMetodoAgregarElemento_AñadirUnElementoEnLaParteSuperiorDeLaPila()
        {
            //Arrange

            //Act
            _pila.AgregarElemento("Manzana");
            _pila.AgregarElemento("Naranja");

            //Assert
            var resultado = _pila.ObtenerElemento();
            resultado.Should().Be("Naranja");
        }


        [Fact]
        public void Debe_ElMetodoEliminarUltimoElemento_QuitarElElementoEnLaParteSuperiorDeLaPilaYDevolverlo()
        {
            //Arrange       

            //Act
            _pila.AgregarElemento("Manzana");
            _pila.AgregarElemento("Naranja");
            _pila.AgregarElemento("Piña");


            //Assert
            var resultado = _pila.EliminarUltimoElemento();
            var valorIndice = _pila.ObtenerElemento();

            resultado.Should().Be("Piña");
            valorIndice.Should().Be("Naranja");
        }

        [Fact]
        public void Debe_ElMetodoObtenerCantidadRetornarseElTamanioDeLaPila()
        {
            //Arrange       

            //Act
            _pila.AgregarElemento("Manzana");
            _pila.AgregarElemento("Naranja");

            //Assert
            _pila.ObtenerCantidad().Should().Be(2);
        }

        [Fact]
        public void Debe_EsVacio_RetornarTrueCuandoEsteVaciaLaPila()
        {
            //Arrange  
            //Act
            //Assert
            _pila.EsVacio.Should().BeTrue();
        }


        [Fact]
        public void Debe_EsVacio_RetornarFalseCuandoEsteVaciaLaPila()
        {
            //Arrange  
            //Act
            _pila.AgregarElemento("Manzana");

            //Assert
            _pila.EsVacio.Should().BeFalse();
        }
    }
}
