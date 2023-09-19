using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Clinica_Odontologica.Controllers
{
    [Authorize]
    public class DentistaController : Controller
    {
        private readonly IDentistaApp _IDentistaApp;
        private readonly UserManager<IdentityUser> _userManager;
        public DentistaController(IDentistaApp dentistaApp, UserManager<IdentityUser> userManager)
        {
            _IDentistaApp = dentistaApp;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var idUsuario = await RetornaIdUsuarioLogado();

            return View(await _IDentistaApp.ListarDentistas(idUsuario)); 
        }

        [HttpGet]
        public async Task <IActionResult> Details(int id)
        {
            return View(await _IDentistaApp.GetEntityById(id));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(Dentista dentista)
        {
            try
            {
                var idUsuario = await RetornaIdUsuarioLogado();
                dentista.UserId = idUsuario;

                await _IDentistaApp.AddDentista(dentista);
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
            return View(await _IDentistaApp.GetEntityById(id));
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Edit(int id, Dentista dentista)
        {
            try
            {
                await _IDentistaApp.UpdateDentista(dentista);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task <IActionResult> Delete(int id)
        {
            return View(await _IDentistaApp.GetEntityById(id));
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task  <IActionResult> Delete(int id, Dentista dentista)
        {
            try
            {
                var deletaDentista = await _IDentistaApp.GetEntityById(id);
                await _IDentistaApp.Delete(deletaDentista);

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
