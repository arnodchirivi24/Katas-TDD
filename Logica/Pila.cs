namespace Logica
{
    public class Pila<T>
    {
        private readonly T[] _elementos;
        private int _contador = -1;
        public int Tamanio => _elementos.Length;

        public bool EsVacio => _contador == -1;

        public Pila(int tamanioPila)
        {
            if (tamanioPila < 1) throw new ArgumentException("El tamaño de la pila no puede ser 0 o negativo ", nameof(tamanioPila));
            _elementos = new T[tamanioPila];
        }

        public void AgregarElemento(T elemento)
        {
            if (ObtenerCantidadDeElementosIngresadosPila() == Tamanio) throw new PilaLlenaException();

            _contador++;
            _elementos[_contador] = elemento;
        }

        public T ObtenerElemento()
        {
            LanzarErrorSiPilaEstaVacia();
            return _elementos[_contador];
        }

        public T EliminarUltimoElemento()
        {
            LanzarErrorSiPilaEstaVacia();
            var elemento = ObtenerElemento();
            _elementos[_contador] = default(T)!;
            _contador--;
            return elemento;
        }

        public int ObtenerCantidadDeElementosIngresadosPila()
        {
            return _contador + 1;
        }

        private void LanzarErrorSiPilaEstaVacia()
        {
            if (EsVacio) throw new PilaVaciaException();
        }
    }

    [Serializable]
    public class PilaLlenaException: InvalidOperationException
    {
        public PilaLlenaException() : base("La operación no es válida porque la pila está llena") { }
    }


    [Serializable]
    public class PilaVaciaException : InvalidOperationException
    {
        public PilaVaciaException() : base("La operación no es válida porque la pila está vacia y no puede extraer el elemento") { }
    }
}