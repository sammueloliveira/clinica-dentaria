using Application.Interfaces;
using Domain.Entities;
using Infra.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinica_Odontologica.Controllers
{
    [Authorize]
    public class TratamentoController : Controller
    {
        private readonly ItratamentoApp _ItratamentoApp;
        private readonly IDentistaApp _IDentistaApp;
        private readonly IPacienteApp _IPacienteApp;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly Contexto _context;

        public TratamentoController(Contexto context, ItratamentoApp itratamentoApp, IDentistaApp iDentistaApp, 
            IPacienteApp iPacienteApp,UserManager<IdentityUser> userManager, Contexto contexto)
        {
            _userManager = userManager;
            _ItratamentoApp = itratamentoApp;
            _IDentistaApp = iDentistaApp;
            _IPacienteApp = iPacienteApp;
            _context = contexto;
        }

        public async Task<IActionResult> Index()
        {
            var tratamentos = await _ItratamentoApp.ListaTratamentos(await RetornaIdUsuarioLogado());
            foreach (var tratamento in tratamentos)
            {
                tratamento.Paciente = await _IPacienteApp.GetEntityById(tratamento.PacienteId);
                tratamento.Dentista = await _IDentistaApp.GetEntityById(tratamento.DentistaId);
            }

            return View(tratamentos);
        }


        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var tratamento = await _ItratamentoApp.GetEntityById(id);
            tratamento.Paciente = await _IPacienteApp.GetEntityById(tratamento.PacienteId);
            tratamento.Dentista = await _IDentistaApp.GetEntityById(tratamento.DentistaId);

            return View(tratamento);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var userId = await RetornaIdUsuarioLogado();

            ViewData["Dentistas"] = new SelectList(await _IDentistaApp.ListarDentistas(userId), "Id", "Nome");
            ViewData["Pacientes"] = new SelectList(await _IPacienteApp.ListarPacientes(userId), "Id", "Nome");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DataConsulta,PacienteId,DentistaId,UserId,Descricao,Alergias,OutrasInformacoes")] Tratamento tratamento)
        {
                try
                {
                   
                    tratamento.UserId = await RetornaIdUsuarioLogado();

                    await _ItratamentoApp.AddTratamento(tratamento);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Ocorreu um erro ao salvar os dados.");
                }
            

            ViewData["Dentistas"] = new SelectList(await _IDentistaApp.ListarDentistas(tratamento.UserId), "Id", "Nome");
            ViewData["Pacientes"] = new SelectList(await _IPacienteApp.ListarPacientes(tratamento.UserId), "Id", "Nome");

            return View(tratamento);
        }


      [HttpGet]
      public async Task<IActionResult> Edit(int id)
      {
        var tratamento = await _ItratamentoApp.GetEntityById(id);
        tratamento.Paciente = await _IPacienteApp.GetEntityById(tratamento.PacienteId);
        tratamento.Dentista = await _IDentistaApp.GetEntityById(tratamento.DentistaId);

        ViewData["Dentistas"] = new SelectList(await _IDentistaApp.ListarDentistas(tratamento.UserId), "Id", "Nome");
        ViewData["Pacientes"] = new SelectList(await _IPacienteApp.ListarPacientes(tratamento.UserId), "Id", "Nome");

        return View(tratamento);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Tratamento tratamento)
        {
            try
            {
                var atualizarTratamento = await _ItratamentoApp.GetEntityById(id);

                await _ItratamentoApp.UpdateTratamento(atualizarTratamento, tratamento);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocorreu um erro ao salvar os dados: " + ex.ToString());
            }

            ViewData["Dentistas"] = new SelectList(await _IDentistaApp.ListarDentistas(tratamento.UserId), "Id", "Nome");
            ViewData["Pacientes"] = new SelectList(await _IPacienteApp.ListarPacientes(tratamento.UserId), "Id", "Nome");

            return View(tratamento);
        }



        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var tratamento = await _ItratamentoApp.GetEntityById(id);
            tratamento.Paciente = await _IPacienteApp.GetEntityById(tratamento.PacienteId);
            tratamento.Dentista = await _IDentistaApp.GetEntityById(tratamento.DentistaId);

            return View(tratamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Tratamento tratamento)
        {
            try
            {
                var deleteTratamento = await _ItratamentoApp.GetEntityById(id);
                await _ItratamentoApp.Delete(deleteTratamento);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private async Task<string> RetornaIdUsuarioLogado()
        {
            var idUsuario = await _userManager.GetUserAsync(User);

            return idUsuario.Id;
        }

    }
}
