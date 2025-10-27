
using System.Xml.Linq;

namespace Logica
{
    public class Pila<T>
    {
        private readonly T[] _elementos;
        private int _contador = -1;
        public int Tamanio => _elementos.Length;

        public Pila(int tamanioPila)
        {
            _elementos = new T[tamanioPila];
        }

        public void AgregarElemento(T elemento)
        {
            _contador++;
            _elementos[_contador] = elemento;
        }

        public T ObtenerElemento()
        {
            return _elementos[_contador];
        }

        public T EliminarUltimoElemento()
        {
            var elemento = ObtenerElemento();
            _elementos[_contador] = default(T)!;
            _contador--;
            return elemento;
        }

        public object ObtenerCantidad()
        {
            throw new NotImplementedException();
        }
    }
}