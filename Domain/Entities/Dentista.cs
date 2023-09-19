using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{

    public class Dentista
    {
        [Column("DNT_ID")]
        public int Id { get; set; }

        [Column("DNT_NOME")]
        [MaxLength(255)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        public string UserId { get; set; }
      
        [Column("DNT_CRO")]
        [MaxLength(20)]
        [Display(Name = "CRO")]
        public string CRO { get; set; }

        [Column("DNT_ESPECIALIDADE")] 
        [MaxLength(100)]
        [Display(Name = "Especialidade")]
        public string Especialidade { get; set; }
        public ICollection<Tratamento> Tratamentos { get; set; }

    }


}

