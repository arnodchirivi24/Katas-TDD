namespace Logica
{
    public record ProductoComprado(
        string Descripcion,
        int Cantidad,
        decimal ValorUnidad,
        string UnidadDeMedida = "Unidad"
    );

    public record LineaDeRecibo(
        string Descripcion,
        string UnidadDeMedida,
        int Cantidad,
        decimal ValorTotal,
        decimal ValorDescuento
    );

    public record Recibo(
        List<LineaDeRecibo> Lineas,
        decimal TotalCompra
    );
    public class ProcesadorDeCompras
    {
        private Dictionary<string, IEstrategiaDePrecio> _ofertaDeLaSemana;
        private readonly IEstrategiaDePrecio _precioRegular = new PrecioRegular();
        public ProcesadorDeCompras(Dictionary<string, IEstrategiaDePrecio> ofertaDeLaSemana)
        {
            _ofertaDeLaSemana = ofertaDeLaSemana;
        }

        public Recibo ProcesarCompra(List<ProductoComprado> productos)
        {
            var lineasDelRecibo = new List<LineaDeRecibo>();

            foreach (var producto in productos)
            {
                IEstrategiaDePrecio estrategia = _ofertaDeLaSemana.GetValueOrDefault(
                    producto.Descripcion,
                    _precioRegular
                    );

                ResultadoCalculo resultado = estrategia.CalcularCosto(
                    producto.Cantidad,
                    producto.ValorUnidad
                );


                var linea = new LineaDeRecibo(
                    producto.Descripcion,
                    producto.UnidadDeMedida,
                    producto.Cantidad,
                    resultado.ValorTotal,
                    resultado.ValorDescuento
                );

                lineasDelRecibo.Add(linea);
            }

            decimal totalCompra = lineasDelRecibo.Sum(linea => linea.ValorTotal);

            return new Recibo(lineasDelRecibo, totalCompra);
        }     
    }
}