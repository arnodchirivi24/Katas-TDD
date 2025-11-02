
namespace Logica
{
    public class RutinaMatutina: IRutinaMatutina
    {
        private List<Tarea> _tareas = new List<Tarea>();
        private IReloj _reloj;

        public RutinaMatutina(IReloj reloj)
        {
            _reloj = reloj;
        }

        public void AgregarTarea(DateTime inicio, DateTime fin, string tarea)
        {
             Tarea nuevaTarea = new Tarea(inicio, fin, tarea);
             _tareas.Add(nuevaTarea);
        }

        public string QueDeboHacerAhora()
        {
            DateTime fechaYHoraActual = _reloj.Ahora().ToUniversalTime();
            var tareaActual = _tareas.SingleOrDefault(tarea => fechaYHoraActual >= tarea.Inicio && fechaYHoraActual <= tarea.Fin);
            
            if (tareaActual != null)
            {
                return tareaActual.Descripcion;
            }
            
            return "Tiempo libre";
        }
    }

    public class Tarea
    {
        public DateTime Inicio { get; }
        public DateTime Fin { get; }
        public string Descripcion { get; }
        public Tarea(DateTime inicio, DateTime fin, string descripcion)
        {
            Inicio = inicio.ToUniversalTime();
            Fin= fin.ToUniversalTime();
            Descripcion = descripcion;
        }
    }
}