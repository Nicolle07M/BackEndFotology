using System.ComponentModel.DataAnnotations;

namespace BackEndFotology.Modelos
{
    public class Categoria
    {
        [Key]
        public int IDcategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string IDportafolio { get; set; }
    }

}
