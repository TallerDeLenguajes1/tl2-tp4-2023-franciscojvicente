namespace PedidosYa
{
    public class ServicioCadeteria
    {
        
        private static ServicioCadeteria? instance;
        private ServicioCadeteria() {
            cadeteria = new();
        }
        public static ServicioCadeteria Instance {
            get {
                return instance ??= new ServicioCadeteria();
            }
        }

        private Cadeteria cadeteria;
        public Cadeteria Cadeteria { get => cadeteria;}

        public void InicializarCadeteria() {
            var datosCadeteria = new AccesoADatosCadeteria();
            cadeteria = datosCadeteria.Obtener() ?? new Cadeteria();
            var datosCadetes = new AccesoADatosCadetes();
            cadeteria.AgregarCadetes(datosCadetes.Obtener());
            var datosPedidos = new AccesoADatosPedidos();
            cadeteria.AgregarPedidos(datosPedidos.Obtener());
        }
    }
}