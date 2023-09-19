using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Clinica_Odontologica.Controllers
{
    [Authorize]
    public class PacienteController : Controller
    {
        private readonly IPacienteApp _IPacienteApp;
        private readonly UserManager<IdentityUser> _userManager;
        public PacienteController(IPacienteApp pacienteApp, UserManager<IdentityUser> userManager)
        {
            _IPacienteApp = pacienteApp;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var idUsuario = await RetornaIdUsuarioLogado();

            return View(await _IPacienteApp.ListarPacientes(idUsuario));
        }

        [HttpGet]
        public async Task <IActionResult> Details(int id)
        {
            return View(await _IPacienteApp.GetEntityById(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(Paciente paciente)
        {
            try
            {
                var idUsuario = await RetornaIdUsuarioLogado();
                paciente.UserId = idUsuario;

                await _IPacienteApp.AddPaciente(paciente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet] 
        public async Task <IActionResult> Edit(int id)
        {
            return View(await _IPacienteApp.GetEntityById(id));
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(int id, Paciente paciente)
        {
            try
            {
                await _IPacienteApp.UpdatePaciente(paciente);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task  <IActionResult> Delete(int id)
        {
            return View(await _IPacienteApp.GetEntityById(id));
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task  <IActionResult> Delete(int id, Paciente paciente)
        {
            try
            {
                var deletePaciente = await _IPacienteApp.GetEntityById(id);
                await _IPacienteApp.Delete(deletePaciente);

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
