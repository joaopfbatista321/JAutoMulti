using jautomulti.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jautomulti.Models {

    /// <summary>
    /// Representa os dados do Proprietario de um Carro
    /// </summary>
    public class Proprietarios {
        public Proprietarios() {
            ListaCarros = new HashSet<Carros>();

        }

        public int Id { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(30, ErrorMessage = "O {0} não pode ter mais do que {1} caracteres.")]
        [RegularExpression("[A-ZÂÓÍa-záéíóúàèìòùâêîôûãõäëïöüñç '-]+",
                          ErrorMessage = "No {0} só são aceites letras")]
        public string Nome { get; set; }

        /// <summary>
        /// sexo do Proprierario 
        /// Ff - feminino; Mm - masculino
        /// </summary>
        [StringLength(1, ErrorMessage = "O {0} só aceita um caráter.")]
        [RegularExpression("[FfMm]", ErrorMessage = "No {0} só se aceitam as letras F ou M.")]
        public string Sexo { get; set; }

        public string Telemovel { get; set; }

        [EmailAddress(ErrorMessage = "Introduza um email correto, por favor.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O {0} deve ter exatamente {1} caracteres.")]
        [RegularExpression("[123578]+[0-9]{8}", ErrorMessage = "O {0} deve começar por 1, 2, 3, 5, 7 ou 8, e só ter algarismos.")]
        public string NIF { get; set; }

        [Display(Name = "Lista de carros")]
        public ICollection<Carros> ListaCarros { get; set; }

          //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
      /// <summary>
      /// atributo para executar a FK que permitirá ligar a tabela da 
      /// autenticação à tabela dos donos
      /// </summary>
      public string UserID { get; set; }
   //   public ApplicationUser user { get; set; }
      //+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    }
}
