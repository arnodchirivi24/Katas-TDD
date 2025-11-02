using FluentAssertions;
using Logica.RutinaMatutina;
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



        [Theory]
        [MemberData(nameof(CasosValidos))]
        public void Debe_ElMetodoQueDeboHacerAhora_Devolver_LaTarea_Correspondiente_DeacuerdoALaHoraIngresadada(DateTime inicio,DateTime fin, DateTime fechaHoraConsultada, string tarea)
        {
            //Arrange
            Mock<IReloj> relojMock = MockHoraActual(fechaHoraConsultada);
            RutinaMatutina rutinaMatutina = new RutinaMatutina(relojMock.Object);        

            //Act
            rutinaMatutina.AgregarTarea(inicio, fin, tarea);

            //Assert
            rutinaMatutina.QueDeboHacerAhora().Should().Be(tarea);
        }

        [Fact]
        public void Debe_ElMetodoQueDeboHacerAhora_DevolverLaTarea_Hacer_mercado_CuandoSeAgregaLaTareaConHoraLocal_11_00_YLaHoraUtcEs_04_00_DeLaTarde()
        {
            //Arrange
            DateTime fechaYHoraUtc = new DateTime(2025, 11, 1, 16, 0, 0, DateTimeKind.Utc);
            Mock<IReloj> relojMockUTC = MockHoraActual(fechaYHoraUtc);
            var rutinaMatutina = new RutinaMatutina(relojMockUTC.Object);


            DateTime inicio = new DateTime(2025, 11, 1, 11, 0, 0, DateTimeKind.Local);
            DateTime fin = new DateTime(2025, 11, 1, 11, 59, 59, DateTimeKind.Local);
            string tarea = "Hacer mercado";

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

        public static IEnumerable<object[]> CasosValidos =>
        new List<object[]>
        {
            new object[]
            {
                new DateTime(2025, 11, 1, 7, 0, 0),
                new DateTime(2025, 11, 1, 7, 59, 59),
                new DateTime(2025, 11, 1, 12, 30, 50,DateTimeKind.Utc),
                "Leer y estudiar"
            },
            new object[]
            {
                new DateTime(2025, 11, 1, 8, 0, 0),
                new DateTime(2025, 11, 1, 8, 59, 59),
                new DateTime(2025, 11, 1, 13, 15, 30, DateTimeKind.Utc),
                "Desayunar"
            }
        };

    }
}
