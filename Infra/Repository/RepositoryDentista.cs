using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository
{
    public class RepositoryDentista : RepositoryGeneric<Dentista>, IDentista
    {
        private readonly Contexto _contexto;

        public RepositoryDentista(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Dentista>> ListarDentistas(string userId)
        {
            return await _contexto.Dentistas.Where(d => d.UserId == userId).AsNoTracking().ToListAsync();
        }

        public async Task<List<Dentista>> ListarDentistasPorEspecialidadeAsync(string especialidade)
        {
            return await _contexto.Dentistas
                .Where(d => d.Especialidade == especialidade)
                .ToListAsync();
        }

        public async Task<Dentista> ObterDentistaPorCROAsync(string cro)
        {
            return await _contexto.Dentistas
                .FirstOrDefaultAsync(d => d.CRO == cro);
        }

       
    }
}
