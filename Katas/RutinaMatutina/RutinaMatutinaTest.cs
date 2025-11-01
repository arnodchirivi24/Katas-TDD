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
            string tareaEsperada = "Tiempo libre";
            //Act

            //Assert
            rutinaMatutina.QueDeboHacerAhora().Should().Be(tareaEsperada);
        }


        [Fact]
        public void Debe_ElMetodoQueDeboHacerAhora_Devolver_LaTarea_HacerEjercicio_CuandoLaHoraSeaEntreLas06_00A_06_59()
        {
            //Arrange
            RutinaMatutina rutinaMatutina = new RutinaMatutina();
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
            RutinaMatutina rutinaMatutina = new RutinaMatutina();
            DateTime inicio = new DateTime(2025, 11, 1, 7, 0, 0);
            DateTime fin = new DateTime(2025, 11, 1, 7, 59, 59);
            string tarea = "Leer y estudiar";

            //Act
            rutinaMatutina.AgregarTarea(inicio, fin, tarea);

            //Assert
            rutinaMatutina.QueDeboHacerAhora().Should().Be(tarea);
        }

    }
}
