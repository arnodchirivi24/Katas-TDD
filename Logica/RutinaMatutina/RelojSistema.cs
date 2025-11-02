namespace Logica.RutinaMatutina
{
    public class RelojSistema : IReloj
    {
        public DateTime Ahora()
        {
            return DateTime.Now;
        }
    }
}
