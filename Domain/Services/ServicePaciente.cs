using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfaceServices;

namespace Domain.Services
{
    public class ServicePaciente : IServicePaciente
    {
        private readonly IPaciente _IPaciente;
        public ServicePaciente(IPaciente iPaciente)
        {
            _IPaciente = iPaciente;
        }

        public async Task AddPaciente(Paciente paciente)
        {
            await _IPaciente.Add(paciente);
        }

        public async Task UpdatePaciente(Paciente paciente)
        {
            await _IPaciente.Update(paciente);
        }
    }
}
