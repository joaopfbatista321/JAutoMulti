using System.ComponentModel.DataAnnotations.Schema;

namespace jautomulti.Models {
    public class Carros {

        public Carros() {
            ListaFotografias = new HashSet<Fotografias>();
        }

        public int Id { get; set; }

        /// <summary>
        /// Numero de identificação do carro
        /// </summary>
        public string VIN { get; set; }

        /// <summary>
        /// Data de matricula 
        /// </summary>
        public DateTime DataMatricula { get; set; }

        /// <summary>
        /// Data de compra do veiculo 
        /// </summary>
        public DateTime DataCompra { get; set; }

        /// <summary>
        /// sexo do animal: 
        /// C-Citadino
        /// S-Sedan
        /// T-Carrinha
        /// TT-Todo o terreno
        /// Suv- Jipe citadino 
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Matricula do automovel
        /// </summary>
        public string Matricula { get; set; }

        /* ++++++++++++++++++++++++++++++++++++++++++ 
         * Criação das chaves forasteiras
         * ++++++++++++++++++++++++++++++++++++++++++ 
         */

        /// <summary>
        /// FK para o Mecanico do carro
        /// </summary>
        [ForeignKey(nameof(Mecanico))]
        public int MecanicoFK { get; set; }
        public Mecanicos Mecanico { get; set; } // efetivamente, esta é q é a FK, para a EF
        /*
         * o uso de [anotadores] serve para formatar o comportamento
         * dos 'objetos' por ele referenciados
         * estes 'objetos' podem ser:
         *    - atributos
         *    - funções (métodos)
         *    - classes
         * */

        /// <summary>
        /// FK do Carro para a sua Marca
        /// </summary>
        [ForeignKey(nameof(Marca))]
        public int MarcaFK { get; set; }
        public Marcas Marca { get; set; }

        /// <summary>
        /// Lista das Fotografias associadas ao carro
        /// </summary>
        public ICollection<Fotografias> ListaFotografias { get; set; }


    }
}
