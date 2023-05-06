
namespace jautomulti.Models {
    public class Marcas {
        public Marcas() {
            ListaCarros = new HashSet<Carros>();
            ListaMecanicos = new HashSet<Mecanicos>();
        }


        /// <summary>
        /// PK
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Denominação da Marca
        /// </summary>
        public string Nome { get; set; }

        // *************************************************

        /// <summary>
        /// Lista de Carros que pertencem à Marca escolhida
        /// </summary>
        public ICollection<Carros> ListaCarros { get; set; }

        /// <summary>
        /// lista dos criadores da Raça
        /// </summary>
        public ICollection<Mecanicos> ListaMecanicos { get; set; }
    }
}
