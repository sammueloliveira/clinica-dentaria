using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{

    public class Paciente 
    {
        [Column("PAC_CODIGO")]
        public int Id { get; set; }
        
        [Column("PAC_NOME")]
        [MaxLength(255)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Column("PAC_CELULAR")]
        [MaxLength(20)]
        [Display(Name = "Celular")]
        public string Celular { get; set; }

        public string UserId { get; set; }
       
        [Column("PAC_DATA_NASCIMENTO")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Column("PAC_CPF")]
        [MaxLength(50)]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Column("PAC_CEP")]
        [MaxLength(15)]
        [Display(Name = "CEP")]
        public string CEP { get; set; }

        [Column("PAC_ENDERECO")]
        [MaxLength(255)]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }
        public string Alergias { get; set; }
    
        public ICollection<Tratamento> Tratamentos { get; set; }



    }
}
