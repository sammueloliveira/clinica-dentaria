using Swashbuckle.AspNetCore.Annotations;

namespace Apis_Clinica.Models
{
    public class PacienteDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string UserId { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string CEP { get; set; }
        public string Endereco { get; set; }
        public string Alergias { get; set; }
    }
}
