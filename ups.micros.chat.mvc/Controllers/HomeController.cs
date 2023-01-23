using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ups.micros.chat.application.interfaces.service;
using ups.micros.chat.mvc.Models;

namespace ups.micros.chat.mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserChatService _userChatService;
        private readonly IHttpContextAccessor _contextAccessor;

        public HomeController(ILogger<HomeController> logger, IUserChatService userChatService, IHttpContextAccessor contextAccessor)
        {
            _logger = logger;
            _userChatService = userChatService;
            _contextAccessor = contextAccessor;
        }

        public async Task<IActionResult> Index()
        {

            var nameUser = _contextAccessor?.HttpContext?.Session.GetString("Usuario");
            ViewData["Usuario"] = nameUser;

            var listUserChat = await _userChatService.GetUserChatOfClient();

            return View(listUserChat);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}