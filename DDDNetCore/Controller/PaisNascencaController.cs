using ConsoleApp1.Domain.PaisNascenca;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controller;


[Route("api/[controller]")]
[ApiController]
public class PaisNascencaController : ControllerBase
{
    private readonly IPaisNascencaService _service;
    
    public PaisNascencaController(IPaisNascencaService service)
    {
        _service = service;
    }

    // GET: api/Jogadores
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PaisNascencaDTO>>> GetAll()
    {
        return await _service.GetAllAsync();
    }
}