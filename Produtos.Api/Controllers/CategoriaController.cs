using Microsoft.AspNetCore.Mvc;
using Produtos.Api.Models;
using Produtos.Api.Models.DTO;
using Produtos.Api.Services;

namespace Produtos.Api.Controllers
{
    [Produces("text/json")]
    [Route("api/[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public IActionResult Listar([FromQuery] string filtro)
        {
            try
            {
                var result = _categoriaService.Listar(filtro);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] CategoriaAdicionarDto categoria)
        {
            try
            {
                var result = await _categoriaService.Adicionar(categoria);

                return StatusCode(201, result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Editar([FromBody] CategoriaDto categoriaDto)
        {
            try
            {
                await _categoriaService.Editar(categoriaDto);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }

}
