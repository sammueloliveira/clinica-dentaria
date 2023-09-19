using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IDentista : IGeneric<Dentista>
    {
        Task<List<Dentista>> ListarDentistas(string userId);
        Task<List<Dentista>> ListarDentistasPorEspecialidadeAsync(string especialidade);
        Task<Dentista> ObterDentistaPorCROAsync(string cro);
        
    }
}
