﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEndFotology.Modelos
{
    public class Fotografia
    {
        [Key]
        public int IDfotografia { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        [ForeignKey("IDcategoria")]
        public string IDcategoria { get; set; }
        [ForeignKey("IDfotografo")]
        public int IDfotografo { get; set; }
        [ForeignKey("IDcalificacion")]
        public int IDcalificacion { get; set; }
    }

}
