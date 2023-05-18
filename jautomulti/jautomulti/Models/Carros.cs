using System.ComponentModel.DataAnnotations.Schema;

namespace jautomulti.Models {
    public class Carros {

        public Carros() {
            ListaFotografias = new HashSet<Fotografias>();
            ListaReparacoes = new HashSet<Reparacoes>();
       
        }

        public int Id { get; set; }

        /// <summary>
        /// Numero de identificação do carro
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// Data de matricula 
        /// </summary>
        public DateTime? DataMatricula { get; set; }

        /// <summary>
        /// Data de compra do veiculo 
        /// </summary>
        public DateTime? DataCompra { get; set; }

        /// <summary>
        /// Tipo do carro:
        /// C-Citadino
        /// S-Sedan
        /// T-Carrinha
        /// TT-Todo o terreno
        /// Suv- Jipe citadino 
        /// </summary>
        ///     
        public string Tipo { get; set; }

        /// <summary>
        /// Matricula do automovel
        /// </summary>
        public string Matricula { get; set; }

        public string Marca { get; set; }

        public string Modelo{ get; set; }

        public string Cor { get; set; }

        /* ++++++++++++++++++++++++++++++++++++++++++ 
         * Criação das chaves forasteiras
         * ++++++++++++++++++++++++++++++++++++++++++ 
         */


        /*
         * o uso de [anotadores] serve para formatar o comportamento
         * dos 'objetos' por ele referenciados
         * estes 'objetos' podem ser:
         *    - atributos
         *    - funções (métodos)
         *    - classes
         * */



        [ForeignKey(nameof(Proprietario))]
        public int ProprietarioFK { get; set; }
        public Proprietarios Proprietario{ get; set; }

        /// <summary>
        /// Lista das Fotografias associadas ao carro
        /// </summary>
        public ICollection<Fotografias> ListaFotografias { get; set; }

        public ICollection<Reparacoes> ListaReparacoes { get; set;}

      


    }
}
