using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class RepositoryTratamento : RepositoryGeneric<Tratamento>, ITratamento
    {
        private readonly Contexto _contexto;

        public RepositoryTratamento(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Tratamento>> ListarTratamentosComAlergiasAsync()
        {
            return await _contexto.Tratamentos
                .Where(t => !string.IsNullOrEmpty(t.Alergias))
                .ToListAsync();
        }

        public async Task<List<Tratamento>> ListarTratamentosPorDentistaAsync(int dentistaId)
        {
            return await _contexto.Tratamentos
                .Where(t => t.DentistaId == dentistaId)
                .ToListAsync();
        }

        public async Task<List<Tratamento>> ListarTratamentosPorPacienteAsync(int pacienteId)
        {
            return await _contexto.Tratamentos
                .Where(t => t.PacienteId == pacienteId)
                .ToListAsync();
        }

        public async Task<List<Tratamento>> ListaTratamentos(string userId)
        {
            return await _contexto.Tratamentos.Where(p => p.UserId == userId).AsNoTracking().ToListAsync();
        }
    }
}
