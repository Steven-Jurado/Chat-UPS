using Microsoft.AspNetCore.Mvc;
using ups.micros.chat.application.interfaces.service;
using ups.micros.chat.domain.entities.usuario;

namespace ups.micros.chat.mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Authentication(Usuario usuario)
        {

            bool response = await _accountService.AuthenticationClientAsync(usuario);

            return response ? RedirectToAction("Index", "Home") : RedirectToAction("Index","Account");

        }

    }
}
