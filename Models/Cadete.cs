namespace PedidosYa
{
    public class Cadete
    {
        private static int autonumerico = 1;
        private int id;
        private string? nombre;
        private string? direccion;
        private string? telefono;

        public int Id { get => id; set => id = value;}
        public string? Nombre { get => nombre; set => nombre = value; }
        public string? Direccion { get => direccion; set => direccion = value; }
        public string? Telefono { get => telefono; set => telefono = value; }

        public Cadete(){
            
        }

        public Cadete(string nombre, string direccion, string telefono) {
            id = autonumerico++;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
        }

        public static void InicializarId(int ultimoId) {
            autonumerico = ultimoId + 1;
        }

        public void TomarPedido(Pedido pedido) {
            pedido.Asignado();
        }

        public void AbandonarPedido(Pedido pedido) {
            // listadoPedidos.Remove(pedido);
            pedido.Pendiente();
        }
    }
}