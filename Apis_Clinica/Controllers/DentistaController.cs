using Apis_Clinica.Models;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Apis_Clinica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DentistaController : ControllerBase
    {
        private readonly IDentistaApp _IDentistaApp;
        private readonly IMapper _mapper;

        public DentistaController(IDentistaApp dentistaApp, IMapper mapper)
        {
            _IDentistaApp = dentistaApp;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DentistaDTO>>> GetDentistas()
        {
           
            var dentistas = await _IDentistaApp.List();
            var dentistasDTO = _mapper.Map<List<DentistaDTO>>(dentistas);
            return Ok(dentistasDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DentistaDTO>> GetDentista(int id)
        {
            var dentista = await _IDentistaApp.GetEntityById(id);

            if (dentista == null)
            {
                return NotFound();
            }

            var dentistaDTO = _mapper.Map<DentistaDTO>(dentista);
            return dentistaDTO;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDentista(int id, DentistaDTO dentistaDTO)
        {
            if (id != dentistaDTO.Id)
            {
                return BadRequest();
            }

            var dentista = _mapper.Map<Dentista>(dentistaDTO);

            try
            {
                await _IDentistaApp.Update(dentista);
            }
            catch (Exception)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<DentistaDTO>> PostDentista(DentistaDTO dentistaDTO)
        {
            var dentista = _mapper.Map<Dentista>(dentistaDTO);
            await _IDentistaApp.Add(dentista);

            dentistaDTO.Id = dentista.Id; 


            return CreatedAtAction("GetDentista", new { id = dentistaDTO.Id }, dentistaDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDentista(int id)
        {
            var dentista = await _IDentistaApp.GetEntityById(id);
            if (dentista == null)
            {
                return NotFound();
            }

            await _IDentistaApp.Delete(dentista);

            return NoContent();
        }

    }
}
