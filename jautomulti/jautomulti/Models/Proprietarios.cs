using System.ComponentModel.DataAnnotations.Schema;

namespace jautomulti.Models {
    public class Proprietarios {
        public Proprietarios() {
            ListaCarros = new HashSet<Carros>();

        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sexo { get; set; }

        public string Telemovel { get; set; }

        public string Email { get; set; }

        public string NIF { get; set; }


        public ICollection<Carros> ListaCarros { get; set; }


    }
}
