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
    }
}