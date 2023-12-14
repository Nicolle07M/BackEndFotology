using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndFotology.Modelos
{
    public class Portafolio
    {
        [Key]
        public int IDportafolio { get; set; }

        [ForeignKey("Fotografo")]
        public int IDfotografo { get; set; }

        public string NombrePortafolio { get; set; }
    }

}
