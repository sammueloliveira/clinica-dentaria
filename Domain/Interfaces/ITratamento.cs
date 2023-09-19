using Domain.Entities;

namespace Domain.Interfaces
{
    public interface ITratamento : IGeneric<Tratamento>
    {
        Task<List<Tratamento>> ListaTratamentos(string userId);
        Task<List<Tratamento>> ListarTratamentosPorPacienteAsync(int pacienteId);
        Task<List<Tratamento>> ListarTratamentosPorDentistaAsync(int dentistaId);
        Task<List<Tratamento>> ListarTratamentosComAlergiasAsync();
    }
}
