using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    [Table("Anuncios")]
    public class Anuncio
    {
        [Key()]
        public int ID { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }


        [ForeignKey("Pessoa")]
        public int PessoaID { get; set; }
        public virtual Pessoa Pessoa { get; set; }
    }
}
