using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Domain.Nacionalidade;
using ConsoleApp1.Infraestructure;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controller;


[Route("api/[controller]")]
[ApiController]
public class NacionalidadeController : ControllerBase
{
    private readonly INacionalidadeService _service;
    
    public NacionalidadeController(INacionalidadeService service)
    {
        _service = service;
    }

    // GET: api/Jogadores
    [HttpGet]
    public async Task<ActionResult<IEnumerable<NacionalidadeDTO>>> GetAll()
    {
        return await _service.GetAllAsync();
    }
}