namespace  Logica
{
    public class DescuentoPorcentaje : IEstrategiaDePrecio
    {
        private decimal v;

        public DescuentoPorcentaje(decimal v)
        {
            this.v = v;
        }
    }
}