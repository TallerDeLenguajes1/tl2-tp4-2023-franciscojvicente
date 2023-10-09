namespace PedidosYa
{
    public class ServicioCadeteria
    {
        
        const string ArchivoCadeteria = "cadeteria";
        const string ArchivoCadetes = "listaCadetes"; 
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

        public void InicializarCadeteria(bool esJSON ) {
            AccesoADatos repositorio;
            if (esJSON) {
                repositorio = new AccesoJSON(ArchivoCadeteria, ArchivoCadetes);
            } else {
                repositorio = new AccesoCSV(ArchivoCadeteria, ArchivoCadetes);
            }
            cadeteria = repositorio.Cadeteria ?? cadeteria;
        }
        
    }
}