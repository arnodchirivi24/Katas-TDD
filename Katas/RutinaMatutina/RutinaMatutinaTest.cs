using FluentAssertions;
using Logica;

namespace Katas.RutinaMatutinaTest
{
    public class RutinaMatutinaTest
    {
        [Fact]
        public void Debe_ElMetodoQueDeboHacerAhora_DevolverLaTareaTiempoLibre()
        {
            //Arrange
            var rutinaMatutina = new RutinaMatutina();
            DateTime horaSimulada = new DateTime(2025, 11, 1, 6, 0, 0);
            string tareaEsperada = "Tiempo libre";
            //Act

            //Assert
            rutinaMatutina.QueDeboHacerAhora(horaSimulada).Should().Be(tareaEsperada);
        }


        [Fact]
        public void Debe_ElMetodoQueDeboHacerAhora_Devolver_LaTarea_HacerEjercicio_CuandoLaHoraSeaEntreLas06_00A_06_59()
        {
            //Arrange
            RutinaMatutina rutinaMatutina = new RutinaMatutina();
            DateTime inicio = new DateTime(2025, 11, 1, 6, 0, 0);
            DateTime fin = new DateTime(2025, 11, 1, 6, 59, 59);
            string tarea = "Hacer ejercicio";
            DateTime horaSimulada = new DateTime(2025, 11, 1, 6, 30, 0);

            //Act
            rutinaMatutina.AgregarTarea(inicio, fin, tarea);

            //Assert
            rutinaMatutina.QueDeboHacerAhora(horaSimulada).Should().Be(tarea);
        }
    }
}
