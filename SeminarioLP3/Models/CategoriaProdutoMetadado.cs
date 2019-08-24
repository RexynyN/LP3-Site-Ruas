using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SeminarioLP3.Models
{

    [MetadataType(typeof(CategoriaProdutoMetadado))]
    public partial class CategoriaProduto { }

    public class CategoriaProdutoMetadado
    {
        [Required(ErrorMessage = "A Identificação de Produto é obrigatória!")]
        [Display(Name = "Identificação de Produto")]
        public int IdCategoriaProduto { get; set; }


        [Required(ErrorMessage = "O Tipo de Comércio é obrigatório!")]
        [Display(Name = "Tipo de Comércio")]
        public int FkTipoComercio { get; set; }

        [Required(ErrorMessage = "O Tipo de Produto é obrigatório!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "O Tipo de Produto deve ter no máximo 50 caracteres")]
        [Display(Name = "Tipo de Produto")]
        public string Tipo { get; set; }


        [Required(ErrorMessage = "A Descrição é obrigatória!")]
        [StringLength(1000, MinimumLength = 10, ErrorMessage = "A Descrição deve ter no máximo 1000 Caracteres")]
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }
    }
}