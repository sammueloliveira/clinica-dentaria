using Domain.Entities;

namespace Domain.InterfaceServices
{
    public interface IServiceDentista
    {
        Task AddDentista(Dentista dentista);
        Task UpdateDentista(Dentista dentista);
       
    }
}
