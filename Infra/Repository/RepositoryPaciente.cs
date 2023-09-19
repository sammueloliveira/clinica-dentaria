using Domain.Entities;
using Domain.Interfaces;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repository
{
    public class RepositoryPaciente : RepositoryGeneric<Paciente>, IPaciente
    {
        private readonly Contexto _contexto;

        public RepositoryPaciente(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<Paciente>> ListarPacientes(string userId)
        {
            return await _contexto.Pacientes.Where(p => p.UserId == userId).AsNoTracking().ToListAsync();
        }

        public async Task<List<Paciente>> ListarPacientesComAlergiasAsync()
        {
            return await _contexto.Pacientes
                .Where(p => !string.IsNullOrEmpty(p.Alergias))
                .ToListAsync();
        }
        public async Task<Paciente> ObterPacientePorCPFAsync(string cpf)
        {
            return await _contexto.Pacientes
                .FirstOrDefaultAsync(p => p.CPF == cpf);
        }
    }
}
