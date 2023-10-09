namespace PedidosYa
{
    public class Pedido
    {
        private static int autonumerico = 1;
        private int numeroPedido;
        private string? observacionPedido;
        private Cliente? cliente;
        private EstadosPedidos estadosPedido;
        private Cadete? cadete;

        public int NumeroPedido { get => numeroPedido; set => numeroPedido = value;}
        public string? ObservacionPedido { get => observacionPedido; set => observacionPedido = value;}
        public EstadosPedidos EstadosPedido { get => estadosPedido;  }
        public Cadete? Cadete { get => cadete; set => cadete = value; }
        public Cliente? Cliente { get => cliente; set => cliente = value; }
        
        public Pedido() {

        }

        public Pedido(string? observacion, string? nombre, string? direccion, string? telefono, string? datosReferenciaDireccion)
        {
            if(nombre == null || direccion == null || telefono == null || datosReferenciaDireccion == null ) return;
            Cliente = new Cliente(nombre, direccion, telefono, datosReferenciaDireccion);
            numeroPedido = autonumerico++;
            observacionPedido = observacion;
            estadosPedido = EstadosPedidos.Pendiente;
        }
        public static void InicializarId(int ultimoId) {
            autonumerico = ultimoId + 1;
        }

        public void Asignado()
        {
            estadosPedido = EstadosPedidos.Asignado;
        }

        public void Rechazar()
        {
            estadosPedido = EstadosPedidos.Rechazado;
        }

        public void Entregar()
        {
            estadosPedido = EstadosPedidos.Entregado;
        }

        public void Pendiente() {
            estadosPedido = EstadosPedidos.Pendiente;
        }
        public void AsignarCadete(Cadete cadete) {
            this.cadete = cadete;
            Asignado();
        }
        
    }
}