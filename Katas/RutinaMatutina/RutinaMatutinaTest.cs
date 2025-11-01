using FluentAssertions;
using Logica;

namespace Katas.RutinaMatutinaTest
{
    public class RutinaMatutinaTest
    {
        [Fact]
        public void Debe_ElMetodoQueDeboHacerAhora_DevolverLaTareaHacerEjercicio_CuandoLaHoraLocalSeaEntre_06_00__06_59()
        {
            //Arrange
            var rutinaMatutina = new RutinaMatutina();
            DateTime horaSimulada = new DateTime(2025, 11, 1, 6, 0, 0);
            string tareaEsperada = "Hacer ejercicio";
            //Act

            //Assert
            rutinaMatutina.QueDeboHacerAhora(horaSimulada).Should().Be(tareaEsperada);
        }
    }
}
