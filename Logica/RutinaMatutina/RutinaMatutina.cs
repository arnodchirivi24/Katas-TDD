namespace Logica.RutinaMatutina
{
    public class RutinaMatutina: IRutinaMatutina
    {
        private List<Tarea> _tareas = new List<Tarea>();
        private IReloj _reloj;

        public RutinaMatutina(IReloj reloj)
        {
            _reloj = reloj;
        }

        public void AgregarTarea(DateTime inicio, DateTime fin, string descripcionTarea)
        {
             Tarea nuevaTarea = new Tarea(inicio, fin, descripcionTarea);
             var existeTareaEnRangoDeFechasYHora = _tareas.SingleOrDefault(t => t.Inicio >= nuevaTarea.Inicio && t.Fin <= nuevaTarea.Fin);
             if (existeTareaEnRangoDeFechasYHora != null)
                throw new InvalidOperationException();

             _tareas.Add(nuevaTarea);
        }

        public string QueDeboHacerAhora()
        {
            DateTime fechaYHoraActualUtc = _reloj.Ahora().ToUniversalTime();

            var tareaActual = _tareas.SingleOrDefault(tarea => tarea.EstaActiva(fechaYHoraActualUtc));

            return tareaActual !=null ? tareaActual.Descripcion : "Tiempo libre";
        } 
    }
}