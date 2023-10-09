using System.IO.Compression;
using System.IO.Pipes;
using System.Security.Cryptography.X509Certificates;

namespace PedidosYa {
    public class Cadeteria
    {
        private string? nombre;
        private string? telefono;
        private List<Cadete> listadoCadetes = new();
        private List<Pedido> listadoPedidos = new();

        public List<Cadete> ListadoCadetes { get => listadoCadetes;}
        internal List<Pedido> ListadoPedidos { get => listadoPedidos;}
        public string? Nombre { get => nombre;  }
        public string? Telefono { get => telefono; }

        public Cadeteria(){

        }
        public Cadeteria(string nombre, string telefono) {
            this.nombre = nombre;
            this.telefono = telefono;
        }

        public void AgregarPedido(string? observacion, string? nombre, string? direccion, string? telefono, string? datosReferenciaDireccion) {
            if(observacion == null || nombre == null || direccion == null || telefono == null || datosReferenciaDireccion == null ) return;
            var pedido = new Pedido(observacion, nombre, direccion, telefono, datosReferenciaDireccion);
            listadoPedidos.Add(pedido);
            GuardarPedidos();
        }

        public decimal JornalACobrar(int idCadete) {
            var cadete = listadoCadetes.FirstOrDefault(c => c.Id == idCadete);
            if (cadete == null) return 0;
            var totalPedidos = listadoPedidos.Count(p => p.Cadete?.Id == cadete.Id && p.EstadosPedido == EstadosPedidos.Entregado);
            return totalPedidos * 500;
        }
        public void AsignarCadeteAPedido(int idCadete, int idPedido) {
            var cadete = listadoCadetes.FirstOrDefault(c => c.Id == idCadete);
            var pedido = listadoPedidos.FirstOrDefault(p => p.NumeroPedido == idPedido);
            if (pedido == null || cadete == null) return;
            pedido.AsignarCadete(cadete);
            GuardarPedidos();
        }

        public int PedidosEntregados() {
            return listadoPedidos.Count(p => p.EstadosPedido == EstadosPedidos.Entregado);
        }

        public IEnumerable<Pedido> PedidosPendientes() {
            return listadoPedidos.Where(p => p.EstadosPedido == EstadosPedidos.Pendiente);
        }
        public IEnumerable<Pedido> PedidosAsignados() {
            return listadoPedidos.Where(p => p.EstadosPedido == EstadosPedidos.Asignado);
        }

        public void CambiarEstado(int idPedido, int nuevoEstado)
        {
            var pedidoSeleccionado = listadoPedidos.FirstOrDefault(p => p.NumeroPedido == idPedido);
            if (pedidoSeleccionado == null) return;
            if(nuevoEstado == 1) pedidoSeleccionado.Rechazar();
            else pedidoSeleccionado.Entregar();
            GuardarPedidos();
        }
        public void ReasignarPedidoCadete(int idPedido, int idNuevoCadete) {
            var pedidoSeleccionado = listadoPedidos.FirstOrDefault(p => p.NumeroPedido == idPedido);
            if (pedidoSeleccionado == null) return;
            var cadeteNuevo = listadoCadetes.FirstOrDefault(c => c.Id == idNuevoCadete);
            if (cadeteNuevo == null) return;
            AsignarCadeteAPedido(cadeteNuevo.Id, pedidoSeleccionado.NumeroPedido);   
            GuardarPedidos();
        }

        public void AgregarCadetes(List<Cadete>? listaCadetes)
        {
            if (listaCadetes == null) return;
            listadoCadetes.AddRange(listaCadetes);
            var ultimoId = listadoCadetes.Max(c => c.Id);
            Cadete.InicializarId(ultimoId);
        }

        public void AgregarPedidos(List<Pedido>? listaPedidos)
        {
            if(listaPedidos == null) return;
            listadoPedidos.AddRange(listaPedidos);
            var ultimoId = listadoPedidos.Max(p => p.NumeroPedido);
            Pedido.InicializarId(ultimoId);
        }
        private void GuardarPedidos() {
            var datosPedidos = new AccesoADatosPedidos();
            datosPedidos.Guardar(listadoPedidos);
        }

        private void GuardarCadetes() {
            var datosCadetes = new AccesoADatosCadetes();
            datosCadetes.Guardar(listadoCadetes);
        }

        public Pedido? ListarPedidoPorId(int idPedido)
        {
            var pedidoSeleccionado = listadoPedidos.FirstOrDefault(p => p.NumeroPedido == idPedido);
            if (pedidoSeleccionado == null) return null;
            return pedidoSeleccionado;
        }

        public Cadete? ListarCadetePorId(int idCadete)
        {
            var cadeteSeleccionado = listadoCadetes.FirstOrDefault(c => c.Id == idCadete);
            if (cadeteSeleccionado == null) return null;
            return cadeteSeleccionado;
        }

        public void AgregarCadete(string? nombre, string? direccion, string? telefono) 
        {
            if (nombre == null || direccion == null || telefono == null) return;
            var cadete = listadoCadetes.FirstOrDefault(c => c.Nombre == nombre && c.Direccion == direccion && c.Telefono == telefono);
            if (cadete == null)
            {
                cadete = new Cadete(nombre, direccion, telefono);
                listadoCadetes.Add(cadete);
                GuardarCadetes(); 
            }
        }
    }
}