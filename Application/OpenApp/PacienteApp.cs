using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfaceServices;

namespace Application.OpenApp
{
    public class PacienteApp : IPacienteApp
    {
        private readonly IPaciente _IPaciente;
        private readonly IServicePaciente _IServicePaciente;
        public PacienteApp(IPaciente iPaciente, IServicePaciente servicePaciente)
        {
            _IPaciente = iPaciente;
            _IServicePaciente = servicePaciente;
        }

        public async Task AddPaciente(Paciente paciente)
        {
            await _IServicePaciente.AddPaciente(paciente);
        }
        public async Task UpdatePaciente(Paciente paciente)
        {
            await _IServicePaciente.UpdatePaciente(paciente);
        }
        public async Task Add(Paciente objeto)
        {
            await _IPaciente.Add(objeto);
        }

        public async Task Update(Paciente objeto)
        {
            await _IPaciente.Update(objeto);
        }
        public async Task Delete(Paciente objeto)
        {
            await _IPaciente.Delete(objeto);
        }

        public async Task<Paciente> GetEntityById(int Id)
        {
           return await _IPaciente.GetEntityById(Id);
        }

        public async Task<List<Paciente>> List()
        {
            return await _IPaciente.List();
        }

        public async Task<List<Paciente>> ListarPacientesComAlergiasAsync()
        {
            return await _IPaciente.ListarPacientesComAlergiasAsync();
        }
        public async Task<Paciente> ObterPacientePorCPFAsync(string cpf)
        {
            return await _IPaciente.ObterPacientePorCPFAsync(cpf);
        }

        public async Task<List<Paciente>> ListarPacientes(string userId)
        {
            return await _IPaciente.ListarPacientes(userId);
        }
    }
}
