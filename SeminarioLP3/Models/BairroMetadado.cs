using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeminarioLP3.Models
{
    [MetadataType(typeof(BairroMetadado))]
    public partial class Bairro { }

    public class BairroMetadado
    {
        [Required(ErrorMessage = "A Identificação do Bairro é obrigatória!")]
        [Display(Name = "Identificação Bairro")]
        public int IdBairro{get; set;}


        [Required(ErrorMessage = "A Cidade é obrigatória!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "A Cidade deve ter no máximo 50 Caracteres")]
        public string Cidade {get; set;}


        [Required(ErrorMessage = "A UF é obrigatória!")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "A UF deve ter exatamente 2 Caracteres")]
        public string UF { get; set; }


        [Required(ErrorMessage = "A Zona é obrigatória!")]
        [StringLength(10, MinimumLength = 2, ErrorMessage = "A Zona deve ter no máximo 10 Caracteres")]
        public string Zona { get; set; }


        [Required(ErrorMessage = "o Nome do Bairro é obrigatório!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "A Nome do Bairro deve ter no máximo 50 Caracteres")]
        [Display(Name = "Nome do Bairro")]
        public string Nome { get; set; }
    }
}