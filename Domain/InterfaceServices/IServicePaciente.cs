using Domain.Entities;

namespace Domain.InterfaceServices
{
    public interface IServicePaciente
    {
        Task AddPaciente(Paciente paciente);
        Task UpdatePaciente(Paciente paciente);
    }
}
