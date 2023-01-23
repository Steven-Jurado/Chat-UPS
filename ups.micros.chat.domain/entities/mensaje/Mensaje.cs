using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ups.micros.chat.domain.entities.mensaje
{
    public class Mensaje
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdMensaje { get; set; }
        public string ContenidoMensaje { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
