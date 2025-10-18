namespace Logica
{
    public class FizzBuzzWhizz
    {
        private readonly Dictionary<int, string> _palabrasEspeciales = new Dictionary<int, string>
        {
           { 3, "Fizz" },
           { 5, "Buzz" },
           { 7, "Whizz" },
           { 11, "Bang" }
        };

        private string _palabraDeSalida { get; }

        public FizzBuzzWhizz()
        {
            _palabraDeSalida = string.Concat(_palabrasEspeciales.Values);
        }

        public List<object> ObtenerFizzBuzzWhizz()
        {
            List<object> resultadoFizzBuzz = new List<object>();

            for(int i= 1; ; i++) 
            {
                string texto = ObtenerTextoFizzBuzzWhizz(i);
                resultadoFizzBuzz.Add(string.IsNullOrEmpty(texto) ? i: texto);
                if (texto == _palabraDeSalida) break;
            }

            return resultadoFizzBuzz;
        }

        private string ObtenerTextoFizzBuzzWhizz(int indice)
        {    
            string texto = "";

            foreach(var item in _palabrasEspeciales)
                if(indice % item.Key == 0) texto += item.Value;
            
            return texto;
        }
    }
}
