using Produtos.Api.Models;
using Produtos.Api.Models.DTO;

namespace Produtos.Api.Services
{
    public interface IProdutoService
    {
        Task<Produto> Adicionar(ProdutoAdicionarDto produtoDto);
        Task Editar(ProdutoDto produtoDto);
        IEnumerable<ProdutoDto> Listar(string filtro);
    }
}
