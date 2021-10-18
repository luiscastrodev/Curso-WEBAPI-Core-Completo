using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MinhaAPICore.Model
{
    public class Fornecedor
    {
        [Key]
        public Guid Id { get; set; }

       [Required(ErrorMessage = "O campo eh obrigatorio")]
       [StringLength(100,ErrorMessage ="O campo {0} deve ter entre {2} {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        public string Documento { get; set; }

        public int TipoForcedor { get; set; }

        public bool Ativo { get; set; }
    }
}
