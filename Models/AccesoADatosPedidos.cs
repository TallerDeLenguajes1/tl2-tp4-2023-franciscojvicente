using System.Text.Json;
namespace PedidosYa
{
    public class AccesoADatosPedidos
    {
        private string nombreArchivo = "listaPedidos.json";

        public List<Pedido>? Obtener() {
            if (string.IsNullOrWhiteSpace(nombreArchivo)) return null;
            var listaPedido = new List<Pedido>();
            using var sr = new StreamReader(nombreArchivo);
            listaPedido = JsonSerializer.Deserialize<List<Pedido>>(sr.ReadToEnd());  
            if(listaPedido == null) return null;  
            return listaPedido;
        }

        public void Guardar(List<Pedido> pedidos) {
            var serealizer = JsonSerializer.Serialize(pedidos);
            using var sw = new StreamWriter(nombreArchivo);
            sw.Write(serealizer);
            sw.Close();
        }
    }
}