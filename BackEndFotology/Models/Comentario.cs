using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndFotology.Modelos
{
    public class Comentario
    {
        [Key]
        public int IDcomentario { get; set; }
        public string IDfotografia { get; set; }
        [ForeignKey("IDcliente")]
        public string IDcliente { get; set; }
        public DateTime? FechaComentario { get; set; }
    }
}
