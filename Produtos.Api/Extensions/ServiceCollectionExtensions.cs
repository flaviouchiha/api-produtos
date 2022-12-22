using Produtos.Api.Data;
using Produtos.Api.Services;

namespace Produtos.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApiDependencies(this IServiceCollection services)
        {
            services.AddScoped<DataContext>();
            services.AddScoped<ICategoriaService, CategoriaService>();
            services.AddScoped<IProdutoService, ProdutoService>();
        }
    }
}
