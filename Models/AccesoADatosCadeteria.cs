using System.Text.Json;
namespace PedidosYa
{
    public class AccesoADatosCadeteria
    {
        private string nombreArchivo = "cadeteria.json";

        public Cadeteria? Obtener() {
            if (string.IsNullOrWhiteSpace(nombreArchivo)) return null;
            using var sr = new StreamReader(nombreArchivo);
            var contenido = sr.ReadToEnd();
            return JsonSerializer.Deserialize<Cadeteria>(contenido);
        }
    }
}