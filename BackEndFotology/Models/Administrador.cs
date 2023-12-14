using System.ComponentModel.DataAnnotations;

namespace BackEndFotology.Modelos
{
    public class Administrador
    {
        [Key]
        public long IDadministrador { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
    }

}
