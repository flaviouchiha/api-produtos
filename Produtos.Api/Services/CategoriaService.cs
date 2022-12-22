using Microsoft.EntityFrameworkCore;
using Produtos.Api.Data;
using Produtos.Api.Extensions;
using Produtos.Api.Models;
using Produtos.Api.Models.DTO;

namespace Produtos.Api.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly DataContext _dataContext;

        public CategoriaService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Categoria> Adicionar(CategoriaAdicionarDto categoriaDto)
        {
            var categoria = new Categoria
            {
                Nome = categoriaDto.Nome,
                Situacao = categoriaDto.Situacao
            };

            _dataContext.Categorias.Add(categoria);

            await _dataContext.SaveChangesAsync();

            return categoria;
        }

        public async Task Editar(CategoriaDto categoriaDto)
        {
            var categoria = _dataContext.Categorias
                .Where(x => x.Id == categoriaDto.Id)
                .FirstOrDefault();

            if (categoria is null)
                throw new Exception("Categoria não localizada");

            categoria.Nome = string.IsNullOrEmpty(categoriaDto.Nome) ? categoria.Nome : categoriaDto.Nome;
            categoria.Situacao = string.IsNullOrEmpty(categoriaDto.Situacao) ? categoria.Situacao : categoriaDto.Situacao;

            await _dataContext.SaveChangesAsync();
        }

        public IEnumerable<CategoriaDto> Listar(string filtro)
        {
            var query = _dataContext.Categorias.AsNoTracking();

            if (!string.IsNullOrEmpty(filtro))
            {
                filtro = filtro.ToUpper();

                query = query.Where(x =>
                    x.Nome.ToUpper().Contains(filtro) ||
                    x.Situacao.ToUpper() == filtro);
            }

            return query.Select(x => new CategoriaDto
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Situacao = x.Situacao
                }).AsEnumerable();
        }
    }
}