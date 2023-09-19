using Domain.Entities;

namespace Application.Interfaces
{
    public interface ItratamentoApp : IGenericApp<Tratamento>
    {
        Task AddTratamento(Tratamento tratamnento);
        Task UpdateTratamento(Tratamento atualizaTratamento, Tratamento tratamento);
        Task<List<Tratamento>> ListaTratamentos(string userId);
        Task<List<Tratamento>> ListarTratamentosPorPacienteAsync(int pacienteId);
        Task<List<Tratamento>> ListarTratamentosPorDentistaAsync(int dentistaId);
        Task<List<Tratamento>> ListarTratamentosComAlergiasAsync();
    }
}
