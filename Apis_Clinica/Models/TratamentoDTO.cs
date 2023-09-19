namespace Apis_Clinica.Models
{
    public class TratamentoDTO
    {
        public int Id { get; set; }

        public DateTime DataConsulta { get; set; }
        public int PacienteId { get; set; }
        public string PacienteNome { get; set; }
        public int DentistaId { get; set; }
        public string DentistaNome { get; set; }
        public string UserId { get; set; }
        public string Descricao { get; set; }
        public string Alergias { get; set; }
        public string OutrasInformacoes { get; set; }
    }
}
