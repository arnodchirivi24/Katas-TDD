namespace Logica.RutinaMatutina
{
    public class Tarea
    {
        public DateTime Inicio { get; }
        public DateTime Fin { get; }
        public string Descripcion { get; }
        public Tarea(DateTime inicio, DateTime fin, string descripcion)
        {
            Inicio = inicio.ToUniversalTime();
            Fin = fin.ToUniversalTime();
            Descripcion = descripcion;
        }


        public bool EstaActiva(DateTime fechaYHoraActualUTC)
        {
            return fechaYHoraActualUTC >= this.Inicio && fechaYHoraActualUTC < this.Fin;
        }
    }
}