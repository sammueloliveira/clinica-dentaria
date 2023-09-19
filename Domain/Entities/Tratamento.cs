using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Tratamento 
    {
        public int Id { get;set; }

        [Column("DATA_CONSULTA")]
        [Display(Name = "Data da Consulta")]
        public DateTime DataConsulta { get; set; }

        [Display(Name = "Paciente")]

        [ForeignKey("Paciente")]
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        [Display(Name = "Dentista")]

        [ForeignKey("Dentista")]
        public int DentistaId { get; set; }
        public Dentista Dentista { get; set; }
        public string UserId { get; set; }

        [Column("DESCRICAO")]
        [MaxLength(500)]
        [Display(Name = "Descrição do Tratamento")]
        public string Descricao { get; set; }

        [Column("ALERGIAS")]
        [MaxLength(255)]
        [Display(Name = "Alergias")]
        public string Alergias { get; set; }
       
        [Column("INFORMAÇÕES")]
        [MaxLength(500)]
        [Display(Name = "Outras Informações")]
        public string OutrasInformacoes { get; set; }
       


    }
}
