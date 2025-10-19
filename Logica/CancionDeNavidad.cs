
namespace Logica
{
    public class CancionDeNavidad
    {
 
        public List<List<string>> ObtenerCancion()
        {
           List<List<string>> estrofas = new List<List<string>>();
           for(int i = 0; i <12; i++)
           {
                List<string> estrofa = new List<string>();

                estrofa.Add("");

                estrofas.Add(estrofa);
           }

           return estrofas;
        }
    }
}