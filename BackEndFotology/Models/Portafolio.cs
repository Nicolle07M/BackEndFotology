using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndFotology.Modelos
{
    public class Portafolio
    {
        public string IDportafolio { get; set; }
        [ForeignKey("IDfotografo")]
        public int IDfotografo { get; set; }
        public string NombrePortafolio { get; set; }
    }

}
