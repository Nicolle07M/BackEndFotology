using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndFotology.Modelos
{
    public class Comentario
    {
        [Key]
        public int IDcomentario { get; set; }

        [ForeignKey("Fotografia")]
        public int IDfotografia { get; set; }

        [ForeignKey("Cliente")]
        public int IDcliente { get; set; }

        public DateTime? FechaComentario { get; set; }
    }
}
