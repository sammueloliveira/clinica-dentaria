using Domain.Entities;
using Domain.Interfaces;
using Domain.InterfaceServices;

namespace Domain.Services
{
    public class ServiceTratamento : IServiceTratamento
    {
        private readonly ITratamento _ITratamento;

        public ServiceTratamento(ITratamento iTratamentoCadastro)
        {
            _ITratamento = iTratamentoCadastro;
        }

        public async Task AddTratamento(Tratamento tratamnento)
        {
            await _ITratamento.Add(tratamnento);
        }

       public async Task UpdateTratamento(Tratamento atualizaTratamento, Tratamento tratamento)
       {
            atualizaTratamento.DataConsulta = tratamento.DataConsulta;
            atualizaTratamento.Descricao = tratamento.Descricao;
            atualizaTratamento.OutrasInformacoes = tratamento.OutrasInformacoes;

            await _ITratamento.Update(atualizaTratamento);
       }
    }
}
