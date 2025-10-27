
namespace Logica
{
    public class CancionDeNavidad
    {
        public List<List<string>> ConstruirCancion()
        { 
            return Enumerable.Range(0, 12).Select(e => (CrearEstrofa(e))).ToList();
        }          

        private List<string> CrearEstrofa(int indiceEstrofa)
        {
            List<string> estrofa = new List<string>();

            CrearPrimeraYSegundaLineaEstrofa(indiceEstrofa, estrofa);

            List<string> estrofasConRegalos = CancionDeNavidadHelpers.Regalos.Take(indiceEstrofa +1).Reverse().ToList();

            estrofa.AddRange(estrofasConRegalos);

            return estrofa;
        }

        private static void CrearPrimeraYSegundaLineaEstrofa(int indiceEstrofa, List<string> estrofa)
        {
            estrofa.Add(CancionDeNavidadHelpers.PimeraLinea.Replace("[x]", CancionDeNavidadHelpers.DiasOrdinales[indiceEstrofa]));
            estrofa.Add(CancionDeNavidadHelpers.SegundaLinea);
        }

        public string ObtenerCancionCompleta()
        {
            var resultadoListadoEstrofas = ConstruirCancion();
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