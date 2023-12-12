using System.ComponentModel.DataAnnotations;

namespace BackEndFotology.Modelos
{
    public class Calificacion
    {
        [Key]
        public int IDcalificacion { get; set; }
        public int CalificacionValor { get; set; }
        public string IDfotografia { get; set; }
    }

}
