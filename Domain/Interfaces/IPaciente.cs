using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPaciente : IGeneric<Paciente>
    {
        Task<List<Paciente>> ListarPacientes(string userId);
        Task<Paciente> ObterPacientePorCPFAsync(string cpf);
        Task<List<Paciente>> ListarPacientesComAlergiasAsync();
    }
}
