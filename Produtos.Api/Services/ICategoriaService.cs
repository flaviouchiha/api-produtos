using Produtos.Api.Models;
using Produtos.Api.Models.DTO;

namespace Produtos.Api.Services
{
    public interface ICategoriaService
    {
        Task<Categoria> Adicionar(CategoriaAdicionarDto categoriaDto);
        Task Editar(CategoriaDto categoriaDto);
        IEnumerable<CategoriaDto> Listar(string filtro);
    }
}
