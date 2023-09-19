using Domain.Entities;

namespace Domain.InterfaceServices
{
    public interface IServiceTratamento
    {
        Task AddTratamento(Tratamento tratamnento);
        Task UpdateTratamento(Tratamento atualizaTratamento, Tratamento tratamento);
    }


}

