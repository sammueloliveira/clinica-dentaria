using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPacienteApp : IGenericApp<Paciente>
    {
        Task AddPaciente(Paciente paciente);
        Task UpdatePaciente(Paciente paciente);
        Task<List<Paciente>> ListarPacientes(string userId);
        Task<Paciente> ObterPacientePorCPFAsync(string cpf);
        Task<List<Paciente>> ListarPacientesComAlergiasAsync();
    }
}
