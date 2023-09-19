using Domain.Entities;

namespace Application.Interfaces
{
     public interface IDentistaApp : IGenericApp<Dentista>
    {
        Task AddDentista(Dentista dentista);
        Task UpdateDentista(Dentista dentista);
        Task<List<Dentista>> ListarDentistas(string userId);
        Task<List<Dentista>> ListarDentistasPorEspecialidadeAsync(string especialidade);
        Task<Dentista> ObterDentistaPorCROAsync(string cro);
        
    }
}
