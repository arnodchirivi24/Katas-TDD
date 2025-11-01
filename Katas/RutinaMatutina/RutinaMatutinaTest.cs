using FluentAssertions;
using Logica;

namespace Katas.RutinaMatutinaTest
{
    public class RutinaMatutinaTest
    {
        [Fact]
        public void Debe_ElMetodoObtenerTareaActual_DevolverLaTareaHacerEjercicio_CuandoLaHoraLocalSeaEntre_06_00__06_59()
        {
            //Arrange
            var rutinaMatutina = new RutinaMatutina();
            string tareaEsperada = "HacerEjercicio";
            //Act

            //Assert
            rutinaMatutina.ObtenerTareaActual().Should().Be(tareaEsperada);
        }
    }
}
