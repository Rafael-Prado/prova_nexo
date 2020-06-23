using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace prova_nexo_web.Models
{
    public class ClienteModel
    {
        public Guid Id { get;  set; }
        //[Required(ErrorMessage = "Preencher campo Nome")]
        public string Nome { get;  set; }
        //[Required(ErrorMessage = "Preencher campo Sobre nome")]
        public string SobreNome { get;  set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail em formato inválido.")]
        public string Email { get;  set; }
        [DataType(DataType.Date, ErrorMessage = "Data deve ter o formato (format: MM/DD/YYYY)")]
        public DateTime? DataCadastro { get;  set; } 
        [Display(Name = "Ativo")]
        public bool? Ativo { get;  set; }

        public virtual IEnumerable<ProdutoModel> ProdutoList { get; set; }
    }
}