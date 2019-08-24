using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeminarioLP3.Models
{
    [MetadataType(typeof(RuaMetadado))]
    public partial class Rua { }

    public class RuaMetadado
    {
        [Required(ErrorMessage = "A Identificação da Rua é obrigatória!")]
        [Display(Name = "Identificação Rua")]
        public int IdRua { get; set; }


        [Required(ErrorMessage = "O Identidicação de Bairro é obrigatório!")]
        [Display(Name = "Identificação Bairro")]
        public int FkBairro { get; set; }

        [Required(ErrorMessage = "A Identificação do Tipo de Comércio é obrigatória!")]
        [Display(Name ="Identificação Tipo de Comércio")]
        public int FkTipoComercio { get; set; }


        [Required(ErrorMessage = "O Nome da Rua é obrigatório!")]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "O Nome da Rua deve ter no máximo 100 Caracteres")]
        [Display(Name = "Nome Rua")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "O CEP é obrigatório!")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "O CEP deve ter exatamente 8 caracteres")]
        public string CEP { get; set; }
    }
}