using Dominio;
using System.Data.Entity;

namespace RepositorioEF
{
   public class ProjetoEstudoContex : DbContext
    {
        public ProjetoEstudoContex() : base("ProjetoEstudo") { }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
    }
}
