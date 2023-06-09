using ConsoleApp1.Domain.Divisao;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controller;

[Route("api/[controller]")]
[ApiController]

public class DivisaoController : ControllerBase
{
    private readonly IDivisaoService _service;
    
    public DivisaoController(IDivisaoService service)
    {
        _service = service;
    }

    // GET: api/Jogadores
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DivisaoDTO>>> GetAll()
    {
        return await _service.GetAllAsync();
    }
}