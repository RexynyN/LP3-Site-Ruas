using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeminarioLP3.Models
{

    [MetadataType(typeof(TipoComercioMetadado))]
    public partial class TipoComercio { }

    public class TipoComercioMetadado
    {
        [Required(ErrorMessage = "O Tipo de Comércio é obrigatório!")]
        [Display(Name = "Identificação Tipo de Comércio")]
        public int IdComercio { get; set; }


        [Required(ErrorMessage = "A Descrição é obrigatória!")]
        [StringLength(1000, MinimumLength = 20, ErrorMessage = "A Descrição deve ter no máximo 1000 Caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }


        [Required(ErrorMessage = "O Orgão Regulador é obrigatório!")]
        [StringLength(200, MinimumLength = 10, ErrorMessage = "O Orgão Regulador deve ter no máximo 200 Caracteres")]
        [Display(Name = "Orgão Regulador")]
        public string OrgaoRegulador { get; set; }


        [Required(ErrorMessage = "A Permissão é obrigatória!")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "A Permissão deve ter no máximo 20 Caracteres")]
        [Display(Name = "Permissão")]
        public string Permissao { get; set; }


        [Required(ErrorMessage = "O Nome do Comércio é obrigatório!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O Nome do Comércio deve ter no máximo 50 Caracteres")]
        [Display(Name = "Nome do Comércio")]
        public string Nome { get; set; }
    }
}