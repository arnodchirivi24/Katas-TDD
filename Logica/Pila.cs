
namespace Logica
{
    public class Pila<T>
    {
        private readonly T[] _elementos;
        public int Tamanio => _elementos.Length;

        public Pila(int tamanioPila)
        {
            _elementos = new T[tamanioPila];
        }

        public void AgregarElemento(string v)
        {
            throw new NotImplementedException();
        }

        public object ObtenerElemento()
        {
            throw new NotImplementedException();
        }
    }
}