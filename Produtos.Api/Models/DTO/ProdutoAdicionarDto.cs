namespace Produtos.Api.Models.DTO
{
    public class ProdutoAdicionarDto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string Situacao { get; set; }
        public int IdCategoria { get; set; }
    }
}