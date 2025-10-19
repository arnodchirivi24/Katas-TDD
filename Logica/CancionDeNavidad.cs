
namespace Logica
{
    public class CancionDeNavidad
    {
        private readonly string _primeraLinea = "On the [x] day of Christmas";
        private readonly string[] _diasOrdinales = new string[]
        {
                "first",
                "second",
                "third",
                "fourth",
                "fifth",
                "sixth",
                "seventh",
                "eighth",
                "ninth",
                "tenth",
                "eleventh",
                "twelfth"
        };

        public List<List<string>> ObtenerCancion()
        {
           List<List<string>> estrofas = new List<List<string>>();
           for(int i = 0; i <12; i++)
           {
                List<string> estrofa = new List<string>();

                string primeraLinea = _primeraLinea.Replace("[x]", _diasOrdinales[i]);
                estrofa.Add(primeraLinea);

                estrofas.Add(estrofa);
           }

           return estrofas;
        }
    }
}