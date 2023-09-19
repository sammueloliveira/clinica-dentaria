using Application.Interfaces;
using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfaceServices;

namespace Application.OpenApp
{
    public class TratamentoApp : ItratamentoApp
    {
        private readonly ITratamento _Itratamento;
        private readonly IServiceTratamento _IServiceTratamento;
      
        public TratamentoApp(ITratamento itratamentoCadastro, IServiceTratamento iServiceTratamentoCadastro)
           
        {
            _Itratamento = itratamentoCadastro;
            _IServiceTratamento = iServiceTratamentoCadastro;
          
        }

        public async Task AddTratamento(Tratamento tratamnento)
        {
            await _IServiceTratamento.AddTratamento(tratamnento);
        }
        public async Task UpdateTratamento(Tratamento atualizaTratamento, Tratamento tratamento)
        {
            await _IServiceTratamento.UpdateTratamento(atualizaTratamento, tratamento);
        }
        public async Task Add(Tratamento objeto)
        {
            await _Itratamento.Add(objeto);
        }

        public async Task Update(Tratamento objeto)
        {
            await _Itratamento.Update(objeto);
        }
        public async Task Delete(Tratamento objeto)
        {
            await _Itratamento.Delete(objeto);
        }

        public async Task<Tratamento> GetEntityById(int Id)
        {
            return await _Itratamento.GetEntityById(Id);
        }

        public async Task<List<Tratamento>> List()
        {
            return await _Itratamento.List();
        }

        public async Task<List<Tratamento>> ListarTratamentosComAlergiasAsync()
        {
            return await _Itratamento.ListarTratamentosComAlergiasAsync();
        }

        public async Task<List<Tratamento>> ListarTratamentosPorDentistaAsync(int dentistaId)
        {
            return await _Itratamento.ListarTratamentosPorDentistaAsync(dentistaId);
        }

        public async Task<List<Tratamento>> ListarTratamentosPorPacienteAsync(int pacienteId)
        {
            return await _Itratamento.ListarTratamentosPorPacienteAsync(pacienteId);
        }

        public async Task<List<Tratamento>> ListaTratamentos(string userId)
        {
            return await _Itratamento.ListaTratamentos(userId);
        }

     
    }
}
