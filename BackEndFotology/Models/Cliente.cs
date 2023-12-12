using System.ComponentModel.DataAnnotations;

namespace BackEndFotology.Modelos
{
    public class Cliente
    {
        [Key]
        public int IDcliente { get; set; }
        public string NombreCliente { get; set; }
        public string Email { get; set; }
        public string Contrasena { get; set; }
        public string Telefono { get; set; }
    }
}
