using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfaceServices;

namespace Domain.Services
{
    public class ServiceDentista : IServiceDentista
    {
        private readonly IDentista _IDentista;
        public ServiceDentista(IDentista iDentista)
        {
            _IDentista = iDentista;
        }

        public async Task AddDentista(Dentista dentista)
        {
            await _IDentista.Add(dentista);
        }

        public async Task UpdateDentista(Dentista dentista)
        {
            await _IDentista.Update(dentista);
        }
    }
}
