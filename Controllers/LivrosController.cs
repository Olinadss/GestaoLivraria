using GestaoLivraria.Communication.Request;
using GestaoLivraria.Communication.Response;
using GestaoLivraria.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static GestaoLivraria.Enum.GenerousEnum;

namespace GestaoLivraria.Controllers;
[Route("api/[controller]")]
[ApiController]
public class LivrosController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(CreateNewBook), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] CreateNewBook request)
    {
        var nameGenre = GetGenre(request.Generous);

        var response = new ResponseCreatedBook
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Autor = request.Autor,
            Generous = nameGenre,
            Price = request.Price,
        };

        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<ResponseCreatedBook>), StatusCodes.Status200OK)]
    public IActionResult Get()
    {
        var response = new List<ResponseCreatedBook>()
        {
            new ResponseCreatedBook { Id = Guid.NewGuid(), Autor = "Teste1", Generous = GetGenre(2), Price = 20.5, Title = "Teste1"},
            new ResponseCreatedBook { Id = Guid.NewGuid(), Autor = "Teste2", Generous = GetGenre(1), Price = 26.5, Title = "Teste2"},
            new ResponseCreatedBook { Id = Guid.NewGuid(), Autor = "Teste3", Generous = GetGenre(5), Price = 36.5, Title = "Teste3"},
        };
        return Ok(response);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Put([FromBody] CreateNewBook request)
    {
        return NoContent();
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult Delete([FromRoute] string id)
    {
        return NoContent();
    }

    private string GetGenre(int genre)
    {
        try
        {
            return ((BookGenre)genre).ToString();
        }
        catch (Exception)
        {
            return null;
        }
    }
}
