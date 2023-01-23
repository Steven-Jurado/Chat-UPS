using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ups.micros.chat.domain.entities.usuario
{
    public class UsuarioChat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdUsuarioChat { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public Guid IdentificadorGrupo { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public int IdUsuario { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(Usuario.UsuarioChatNav))]
        public Usuario UsuariosNav { get; set; }
    }
}
