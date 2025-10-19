
namespace Logica
{
    public class CancionDeNavidad
    {
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

            CrearPrimeraYSegundaLineaEstrofa(indiceEstrofa, estrofa);

            for (int j = indiceEstrofa; j >= 0; j--)
            {
                estrofa.Add(CancionDeNavidadHelpers.Regalos[j]);
            }

            return estrofa;
        }

        private static void CrearPrimeraYSegundaLineaEstrofa(int indiceEstrofa, List<string> estrofa)
        {
            estrofa.Add(CancionDeNavidadHelpers.PimeraLinea.Replace("[x]", CancionDeNavidadHelpers.DiasOrdinales[indiceEstrofa]));
            estrofa.Add(CancionDeNavidadHelpers.SegundaLinea);
        }

        public string ObtenerCancionCompleta()
        {
            var resultadoListadoEstrofas = ObtenerCancion();
            var estrofasComoTexto = new List<string>();

            foreach (List<string> estrofa in resultadoListadoEstrofas)
            {
                string estrofaUnida = string.Join("\n", estrofa);
                estrofasComoTexto.Add(estrofaUnida);
            }

            return string.Join("\n\n", estrofasComoTexto);
        }
    }
}