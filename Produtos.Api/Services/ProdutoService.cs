using Produtos.Api.Data;
using Produtos.Api.Models.DTO;
using Produtos.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Produtos.Api.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly DataContext _dataContext;

        public ProdutoService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Produto> Adicionar(ProdutoAdicionarDto produtoDto)
        {
            var produto = new Produto
            {
                Nome = produtoDto.Nome,
                Descricao = produtoDto.Descricao,
                Preco = produtoDto.Preco,
                Situacao = produtoDto.Situacao,
                IdCategoria = produtoDto.IdCategoria
            };

            _dataContext.Produtos.Add(produto);

            await _dataContext.SaveChangesAsync();

            return produto;
        }

        public async Task Editar(ProdutoDto produtoDto)
        {
            var produto = _dataContext.Produtos
                .Where(x => x.Id == produtoDto.Id)
                .FirstOrDefault();

            if (produto is null)
                throw new Exception("Produto não localizado");

            produto.Nome = string.IsNullOrEmpty(produtoDto.Nome) ? produto.Nome : produtoDto.Nome;
            produto.Descricao = string.IsNullOrEmpty(produtoDto.Descricao) ? produto.Descricao : produtoDto.Descricao;
            produto.Preco = produtoDto.Preco == 0 ? produto.Preco : produtoDto.Preco;
            produto.Situacao = string.IsNullOrEmpty(produtoDto.Situacao) ? produto.Situacao : produtoDto.Situacao;
            produto.IdCategoria = produtoDto.IdCategoria == 0 ? produto.IdCategoria : produtoDto.IdCategoria;

            await _dataContext.SaveChangesAsync();
        }

        public IEnumerable<ProdutoDto> Listar(string filtro)
        {
            var query = _dataContext.Produtos
                .Include(x => x.Categoria)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(filtro))
            {
                filtro = filtro.ToUpper();

                query = query.Where(x =>
                    x.Categoria.Nome.ToUpper().Contains(filtro) ||
                    x.Descricao.ToUpper().Contains(filtro) ||
                    x.Situacao.ToUpper() == filtro);
            }

            return query.Select(x => new ProdutoDto
            {
                Id = x.Id,
                Nome = x.Nome,
                Descricao = x.Descricao,
                Preco = x.Preco,
                Situacao = x.Situacao,
                IdCategoria = x.IdCategoria,
                Categoria = x.Categoria.Nome
            }).AsEnumerable();
        }
    }
}
