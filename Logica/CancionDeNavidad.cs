
namespace Logica
{
    public class CancionDeNavidad
    {
        private const string PimeraLinea = "On the [x] day of Christmas";
        private const string SegundaLinea = "My true love sent to me:";
        private static readonly string[] DiasOrdinales = new string[]
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

        private static readonly string[] Regalos = new string[]
        {
            "A partridge in a pear tree.",
            "Two turtle doves and",
            "Three french hens",
            "Four calling birds",
            "Five golden rings",
            "Six geese a-laying",
            "Seven swans a-swimming",
            "Eight maids a-milking",
            "Nine ladies dancing",
            "Ten lords a-leaping",
            "Eleven pipers piping",
            "Twelve drummers drumming"
        };


        public List<List<string>> ObtenerCancion()
        {
           List<List<string>> estrofas = new List<List<string>>();

           for (int i = 0; i <12; i++)
           {
                estrofas.Add(CrearEstrofa(i));
           }

           return estrofas;
        }

        private List<string> CrearEstrofa(int indiceEstrofa)
        {
            List<string> estrofa = new List<string>();

            string primeraLinea = PimeraLinea.Replace("[x]", DiasOrdinales[indiceEstrofa]);
            estrofa.Add(primeraLinea);
            estrofa.Add(SegundaLinea);

            for(int j= indiceEstrofa; j >=0; j--)
            {
                estrofa.Add(Regalos[j]);
            }

            return estrofa;
        }
    }
}