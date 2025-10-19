
namespace Logica
{
    public class CancionDeNavidad
    {
        public List<string> ObtenerCancion()
        {
           List<string> cancion = new List<string>();
           for(int i = 0; i <12; i++)
           {
                cancion.Add(i.ToString());
           }

           return cancion;
        }
    }
}