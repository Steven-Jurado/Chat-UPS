using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ups.micros.chat.application.interfaces.repository;
using ups.micros.chat.application.interfaces.service;
using ups.micros.chat.domain.entities.usuario;

namespace ups.micros.chat.application.services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepositoy _accountRepositoy;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountService(IAccountRepositoy accountRepositoy, IHttpContextAccessor httpContextAccessor)
        {
            _accountRepositoy = accountRepositoy;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<bool> AuthenticationAsync(Usuario usuario)
        {
            return await _accountRepositoy.AuthenticationAsync(usuario);
        }

        public async Task<bool> AuthenticationClientAsync(Usuario usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("userName", usuario.NombreUsuario);
                client.DefaultRequestHeaders.Add("password", usuario.Clave);

                var response = await client.PostAsync("http://localhost:5000/api/account/autenticacion", null!);

                if (response.IsSuccessStatusCode)
                {
                    var result = await _accountRepositoy.GetUser(usuario);

                    _httpContextAccessor.HttpContext.Session.SetInt32("IdUsuario", result!.IdUsuario);
                    _httpContextAccessor.HttpContext.Session.SetString("Usuario", result!.NombreUsuario);

                    return true;
                }

            }


            return false;
        }
    }
}
