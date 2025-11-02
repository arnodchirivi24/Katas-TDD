using FluentAssertions;
using Logica;
using Moq;

namespace Katas.RutinaMatutinaTest
{

    public class RutinaMatutinaTest
    {
        [Fact]
        public void Debe_ElMetodoQueDeboHacerAhora_DevolverLaTareaTiempoLibre()
        {
            //Arrange
            Mock<IReloj> relojMock = MockHoraActual(new DateTime(2025, 11, 1, 12, 0, 0));
            var rutinaMatutina = new RutinaMatutina(relojMock.Object);
            string tareaEsperada = "Tiempo libre";
            //Act

            //Assert
            rutinaMatutina.QueDeboHacerAhora().Should().Be(tareaEsperada);
        }

    

        [Fact]
        public void Debe_ElMetodoQueDeboHacerAhora_Devolver_LaTarea_HacerEjercicio_CuandoLaHoraSeaEntreLas06_00A_06_59()
        {
            //Arrange
            Mock<IReloj> relojMock = MockHoraActual(new DateTime(2025, 11, 1, 06, 20, 0));
            RutinaMatutina rutinaMatutina = new RutinaMatutina(relojMock.Object);

            DateTime inicio = new DateTime(2025, 11, 1, 6, 0, 0);
            DateTime fin = new DateTime(2025, 11, 1, 6, 59, 59);
            string tarea = "Hacer ejercicio";

            //Act
            rutinaMatutina.AgregarTarea(inicio, fin, tarea);

            //Assert
            rutinaMatutina.QueDeboHacerAhora().Should().Be(tarea);
        }


        
        [Fact]
        public void Debe_ElMetodoQueDeboHacerAhora_Devolver_LaTarea_Leer_y_estudiar_CuandoLaHoraSeaEntreLas07_00A_07_59SinRecibirElParametroDeHoraActual()
        {
            //Arrange
            Mock<IReloj> relojMock = MockHoraActual(new DateTime(2025, 11, 1, 7, 59, 59));
            RutinaMatutina rutinaMatutina = new RutinaMatutina(relojMock.Object);
            DateTime inicio = new DateTime(2025, 11, 1, 7, 0, 0);
            DateTime fin = new DateTime(2025, 11, 1, 7, 59, 59);
            string tarea = "Leer y estudiar";

            //Act
            rutinaMatutina.AgregarTarea(inicio, fin, tarea);

            //Assert
            rutinaMatutina.QueDeboHacerAhora().Should().Be(tarea);
        }

        private static Mock<IReloj> MockHoraActual(DateTime hora)
        {
            var relojMock = new Mock<IReloj>();
            relojMock.Setup(reloj => reloj.Ahora()).Returns(hora);
            return relojMock;
        }

    }
}
