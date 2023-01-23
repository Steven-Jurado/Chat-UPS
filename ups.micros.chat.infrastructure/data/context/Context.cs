using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using ups.micros.chat.domain.entities.mensaje;
using ups.micros.chat.domain.entities.usuario;

namespace ups.micros.chat.infrastructure.data.context
{
    public class Context : DbContext
    {
        public Context()
        {

        }

        public Context(DbContextOptions<Context> optionsBuilder) : base(optionsBuilder)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioChat> UsuarioChat { get; set; }
        public DbSet<Mensaje> Mensajes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=chatups;Trusted_Connection=True;");
        }

    }
}
