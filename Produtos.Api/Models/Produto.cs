namespace Produtos.Api.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string Situacao { get; set; }
        public int IdCategoria { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
