using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfaceServices;

namespace Application.OpenApp
{
    public class DentistaApp : IDentistaApp
    {
        private readonly IDentista _IDentista;
        private readonly IServiceDentista _IServiceDentista;
        public DentistaApp(IDentista iDentista, IServiceDentista iServiceDentista)
        {
            _IDentista = iDentista;
            _IServiceDentista = iServiceDentista;
        }

        public async Task AddDentista(Dentista dentista)
        {
            await _IServiceDentista.AddDentista(dentista);
        }
        public async Task UpdateDentista(Dentista dentista)
        {
            await _IServiceDentista.UpdateDentista(dentista);
        }
        public async Task Add(Dentista objeto)
        {
            await _IDentista.Add(objeto);
        }

        public async Task Update(Dentista objeto)
        {
            await _IDentista.Update(objeto);
        }
        public async Task Delete(Dentista objeto)
        {
            await _IDentista.Delete(objeto);
        }

        public async Task<Dentista> GetEntityById(int Id)
        {
            return await _IDentista.GetEntityById(Id);
        }

        public async Task<List<Dentista>> List()
        {
            return await _IDentista.List();
        }
         public async Task<List<Dentista>> ListarDentistasPorEspecialidadeAsync(string especialidade)
        {
            return await _IDentista.ListarDentistasPorEspecialidadeAsync(especialidade);
        }

        public async Task<Dentista> ObterDentistaPorCROAsync(string cro)
        {
            return await _IDentista.ObterDentistaPorCROAsync(cro);
        }

        public async Task<List<Dentista>> ListarDentistas(string userId)
        {
            return await _IDentista.ListarDentistas(userId);
        }
    }
}
