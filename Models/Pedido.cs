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

        
        public int NumeroPedido { get => numeroPedido;}
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

        public void CambiarEstado()
        {
            int siguienteValor = ((int)EstadosPedido + 1) % Enum.GetValues(typeof(EstadosPedidos)).Length;
            EstadosPedidos siguienteEstado = (EstadosPedidos)siguienteValor;

            if (siguienteEstado > EstadosPedido)
            {
                estadosPedido = siguienteEstado;
            }
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
        // solo
        public void Pendiente() {
            estadosPedido = EstadosPedidos.Pendiente;
        }
        public void AsignarCadete(Cadete cadete) {
            this.cadete = cadete;
            Asignado();
        }
    }
}