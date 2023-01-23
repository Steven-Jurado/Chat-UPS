using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ups.micros.chat.domain.entities.usuario
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [JsonIgnore]
        public int IdUsuario { get; set; }
        [Required]
        [Column("Usuario")]
        [StringLength(30)]
        public string NombreUsuario { get; set; }
        [Required]
        [StringLength(8)]
        public string Clave { get; set; }
        [JsonIgnore]
        public bool Activo { get; set; }

        [JsonIgnore]
        [InverseProperty(nameof(UsuarioChat.UsuariosNav))]
        public ICollection<UsuarioChat> UsuarioChatNav { get; set; }
    }
}
