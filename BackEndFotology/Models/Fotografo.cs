using System.ComponentModel.DataAnnotations;

namespace BackEndFotology.Modelos
{
    public class Fotografo
    {
        [Key]
        public int IDfotografo { get; set; }
        public string NombreFotografo { get; set; }
        public string Descripcion { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Portafolio { get; set; }
    }

}
