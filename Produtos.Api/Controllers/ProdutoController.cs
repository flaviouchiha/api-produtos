using Microsoft.AspNetCore.Mvc;
using Produtos.Api.Models.DTO;
using Produtos.Api.Services;

namespace Produtos.Api.Controllers
{
    [Produces("text/json")]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public IActionResult Listar([FromQuery] string filtro)
        {
            try
            {
                var result = _produtoService.Listar(filtro);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] ProdutoAdicionarDto produtoDto)
        {
            try
            {
                var result = await _produtoService.Adicionar(produtoDto);

                return StatusCode(201, result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Editar([FromBody] ProdutoDto produtoDto)
        {
            try
            {
                await _produtoService.Editar(produtoDto);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }

}