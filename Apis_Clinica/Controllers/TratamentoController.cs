using Apis_Clinica.Models;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Apis_Clinica.Controllers
{
    [Route("api/tratamento")]
    [ApiController]
    public class TratamentoController : ControllerBase
    {
        private readonly ItratamentoApp _ITratamentoApp;
        private readonly IPacienteApp _IPacienteApp;
        private readonly IDentistaApp _IDentistaApp;
        private readonly IMapper _mapper;

        public TratamentoController(ItratamentoApp tratamentoApp, IMapper mapper, IDentistaApp dentistaApp, IPacienteApp pacienteApp)
        {
            _ITratamentoApp = tratamentoApp;
            _IDentistaApp = dentistaApp;
            _IPacienteApp = pacienteApp;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TratamentoDTO>>> GetTratamentos()
        {
            var tratamentos = await _ITratamentoApp.List();

            var tratamentosDTO = new List<TratamentoDTO>();

            foreach (var tratamento in tratamentos)
            {
                var paciente = await _IPacienteApp.GetEntityById(tratamento.PacienteId);
                var dentista = await _IDentistaApp.GetEntityById(tratamento.DentistaId);

                var tratamentoDTO = _mapper.Map<TratamentoDTO>(tratamento);
                tratamentoDTO.PacienteNome = paciente?.Nome;
                tratamentoDTO.DentistaNome = dentista?.Nome;

                tratamentosDTO.Add(tratamentoDTO);
            }

            return Ok(tratamentosDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TratamentoDTO>> GetTratamento(int id)
        {
            var tratamento = await _ITratamentoApp.GetEntityById(id);

            if (tratamento == null)
            {
                return NotFound();
            }

            var tratamentoDTO = _mapper.Map<TratamentoDTO>(tratamento);
            return tratamentoDTO;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTratamento(int id, TratamentoDTO tratamentoDTO)
        {
            if (id != tratamentoDTO.Id)
            {
                return BadRequest();
            }

            var tratamento = _mapper.Map<Tratamento>(tratamentoDTO);

            try
            {
                await _ITratamentoApp.Update(tratamento);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TratamentoDTO>> PostTratamento(TratamentoDTO tratamentoDTO)
        {
            var tratamento = _mapper.Map<Tratamento>(tratamentoDTO);
            await _ITratamentoApp.Add(tratamento);

            tratamentoDTO.Id = tratamento.Id; 

            return CreatedAtAction("GetTratamento", new { id = tratamentoDTO.Id }, tratamentoDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTratamento(int id)
        {
            var tratamento = await _ITratamentoApp.GetEntityById(id);
            if (tratamento == null)
            {
                return NotFound();
            }

            await _ITratamentoApp.Delete(tratamento);

            return NoContent();
        }
    }
}
