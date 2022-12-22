using System.Collections.ObjectModel;

namespace Produtos.Api.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Situacao { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; } = new Collection<Produto>();
    }
}
