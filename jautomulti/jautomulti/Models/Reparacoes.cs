using MySqlX.XDevAPI;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jautomulti.Models {
    public class Reparacoes {

        public Reparacoes() {
            ListaProfissionaisNaReparacao = new HashSet<Profissionais>();
        }

        public int Id { get; set; }

        /// <summary>
        /// Data de início da reperação
        /// </summary>
        [Display(Name = "Data do Inicio da Reparação")]
        public DateTime DataInicio { get; set; }
        [Display(Name = "Data do Fim da Reparação")]
        public DateTime DataFim { get; set; }
        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        /// <summary>
        /// Este valor auxilia a app a obter o Preço da Reparaçao
        /// </summary>
        [NotMapped] // esta anotação é para o atributo não ser representado na base dados
        [Required(ErrorMessage = "Preencha, pf, o valor da Reparação")]
        // tem de introduzir um valor de 0 a 9 de 1 a 8 algarismos, podendo conter um valor com duas casas decimais
        [RegularExpression("[0-9]{1,8}[,.]?[0-9]{0,2}", ErrorMessage = "Tem de introduzir o Preço da Marcação")] // tem de introduzir um valor de 
        [Display(Name = "Preço")]
        public string AuxPreco { get; set; }
       
        public decimal Preco { get; set; }


        [Display(Name = "Carros")]
        [ForeignKey(nameof(Carro))]
        public int CarroFK { get; set; }
        public Carros Carro { get; set; }

        //[ForeignKey(nameof(Mecanicos))]
        //public int MecanicoFK { get; set; }
        //public Mecanicos Mecanico { get; set; }

      
        public ICollection<Profissionais> ListaProfissionaisNaReparacao { get; set; }
      


    }
}
