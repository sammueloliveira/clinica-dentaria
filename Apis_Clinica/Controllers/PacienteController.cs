using Apis_Clinica.Models;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Apis_Clinica.Controllers
{
    [Route("api/paciente")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteApp _IPacienteApp;
        private readonly IMapper _mapper;

        public PacienteController(IPacienteApp pacienteApp, IMapper mapper)
        {
            _IPacienteApp = pacienteApp;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PacienteDTO>>> GetPacientes()
        {
            var pacientes = await _IPacienteApp.List();
            var pacientesDTO = _mapper.Map<List<PacienteDTO>>(pacientes);
            return Ok(pacientesDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PacienteDTO>> GetPaciente(int id)
        {
            var paciente = await _IPacienteApp.GetEntityById(id);

            if (paciente == null)
            {
                return NotFound();
            }

            var pacienteDTO = _mapper.Map<PacienteDTO>(paciente);
            return pacienteDTO;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(int id, PacienteDTO pacienteDTO)
        {
            if (id != pacienteDTO.Id)
            {
                return BadRequest();
            }

            var paciente = _mapper.Map<Paciente>(pacienteDTO);

            try
            {
                await _IPacienteApp.Update(paciente);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<PacienteDTO>> PostPaciente(PacienteDTO pacienteDTO)
        {
            var paciente = _mapper.Map<Paciente>(pacienteDTO);
            await _IPacienteApp.Add(paciente);

            pacienteDTO.Id = paciente.Id; 

            return CreatedAtAction("GetPaciente", new { id = pacienteDTO.Id }, pacienteDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaciente(int id)
        {
            var paciente = await _IPacienteApp.GetEntityById(id);
            if (paciente == null)
            {
                return NotFound();
            }

            await _IPacienteApp.Delete(paciente);

            return NoContent();
        }
    }
}
