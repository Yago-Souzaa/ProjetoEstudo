using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Pessoas")]
    public class Pessoa
    {
        [Key()]
        public int ID { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome { get; set; }

        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Digite um email valido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Insira no minimo 3 Caracteres e no maximo 10")]
        public string Senha { get; set; }

        [Required]
        [System.ComponentModel.DataAnnotations.Compare("Senha", ErrorMessage = "As senhas não se coincidem!")]
        [StringLength(10, MinimumLength = 3, ErrorMessage = "Insira no minimo 3 Caracteres e no maximo 10")]
        public string ConfirmarSenha { get; set; }
              
    }
}
