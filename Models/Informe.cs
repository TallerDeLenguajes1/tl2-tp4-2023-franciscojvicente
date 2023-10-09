namespace PedidosYa
{
    public class Informe
    {
        public List<CadeteInforme> Cadetes { get; private set;} = new();
        public decimal TotalCobrado {get; private set;}
        public int TotalPedidos {get; private set;}
        public decimal EnviosPromedioPorCadete {get; private set;}

        public Informe(Cadeteria cadeteria) {
            Cadetes = cadeteria.ListadoCadetes.Select(c => new CadeteInforme(c.Nombre, cadeteria.JornalACobrar(c.Id))).ToList();
            TotalCobrado = Cadetes.Sum(c => c.Monto);
            TotalPedidos = cadeteria.ListadoPedidos.Count();
            var pedidosConCadete = cadeteria.ListadoPedidos.Where(p => p.Cadete != null && p.EstadosPedido == EstadosPedidos.Entregado);
            var cadetes = pedidosConCadete.DistinctBy(p => p.Cadete?.Id).Count();
            EnviosPromedioPorCadete = cadetes > 0 ? pedidosConCadete.Count() / cadetes : 0;
        }
    }

    public class CadeteInforme
    {
        private string? nombre;
        private decimal monto;

        public string? Nombre { get => nombre; }
        public decimal Monto { get => monto;}

        public CadeteInforme(string? nombre, decimal monto) {
            this.nombre = nombre;
            this.monto = monto;
        }
    }
}