using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using ups.micros.chat.application.interfaces.repository;
using ups.micros.chat.domain.entities.usuario;
using ups.micros.chat.infrastructure.data.context;

namespace ups.micros.chat.infrastructure.data.repository
{
    internal class AccountRepositoy : IAccountRepositoy
    {
        private readonly Context _context;
        private IHttpContextAccessor _contextAccessor;
        public AccountRepositoy(Context context, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _contextAccessor = contextAccessor;
        }

        public async Task<bool> AuthenticationAsync(Usuario usuario)
        {
            var result = await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => usuario.NombreUsuario == x.NombreUsuario && usuario.Clave == x.Clave && x.Activo == true);

            if (result is not null)
                return true;

            return false;
        }

        public async Task<Usuario> GetUser(Usuario usuario)
        {
            return await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => usuario.NombreUsuario == x.NombreUsuario && usuario.Clave == x.Clave && x.Activo == true);

        }
    }
}
