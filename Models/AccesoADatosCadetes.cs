using System.Text.Json;
namespace PedidosYa
{
    public class AccesoADatosCadetes
    {
        private string nombreArchivo = "listaCadetes.json";

        public List<Cadete>? Obtener() {
            if (string.IsNullOrWhiteSpace(nombreArchivo)) return null;
            var listaCadetes = new List<Cadete>();
            using var sr = new StreamReader(nombreArchivo);
            listaCadetes = JsonSerializer.Deserialize<List<Cadete>>(sr.ReadToEnd()); 
            if(listaCadetes == null) return null;
            return listaCadetes;
        }

        public void Guardar(List<Cadete> cadetes) {
            var serealizer = JsonSerializer.Serialize(cadetes);
            using var sw = new StreamWriter(nombreArchivo);
            sw.Write(serealizer);
            sw.Close();
        }
    }
}