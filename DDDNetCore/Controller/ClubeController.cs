using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controller;

[Route("api/[controller]")]
[ApiController]
public class ClubeController : ControllerBase
{
    private readonly IClubeService _service;
    private readonly IEquipaService _service_equipa;

    public ClubeController(IClubeService service)
    {
        _service = service;
    }

    // GET: api/Jogadores
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClubeDTO>>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    // GET: api/Jogadores/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ClubeDTO>> GetById(Guid id)
    {
        var jogador = await _service.GetByIdAsync(new Identifier(id));

        if (jogador == null)
        {
            return NotFound();
        }

        return jogador;
    }

    // GET: api/Warehouses/ById/5M4
    [HttpGet("ByIdentifier/{licenca}")]
    public async Task<ActionResult<ClubeDTO>> GetByCodClube(string licenca)
    {
        var jogador = await _service.GetByCodClube(licenca);

        if (jogador == null)
        {
            return NotFound();
        }

        return jogador;
    }

    [HttpGet("NomeClube/{licenca}")]
    public async Task<ActionResult<ClubeDTO>> GetByNomeClube(string licenca)
    {
        var jogador = await _service.GetByCodClube(licenca);

        if (jogador == null)
        {
            return NotFound();
        }

        return jogador;
    }

    // POST: api/Jogadores
    [HttpPost]
    public async Task<ActionResult<ClubeDTO>> Create(ClubeDTO dto)
    {
        var list = await _service.GetAllAsync();

        if (list != null)
        {
            foreach (var jogadorDto in list)
            {
                if (jogadorDto.CodigoClube.Equals(dto.CodigoClube))
                {
                    return BadRequest(new
                        { Message = "Já existe um 'Clube' registado com este 'Código'." });
                }
            }
        }

        dto.CodigoClube = _service.GetAllAsync().Result.Count+1;
        try
        {
            var jogador = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = jogador.Id }, jogador);
        }
        catch (BusinessRuleValidationException ex)
        {
            return BadRequest(new { ex.Message });
        }
    }


    // PUT: api/Jogadores/5
    [HttpPut("{id}")]
    public async Task<ActionResult<JogadorDTO>> Update(Guid id, ClubeDTO dto)
    {
        // if (id != dto.Id)
        // {
        //     return BadRequest();
        // }

        dto.Id = id;

        try
        {
            //var showJogador = await GetGetById(id); 

            var jogador = await _service.UpdateAsync(dto);

            if (jogador == null)
            {
                return NotFound();
            }

            return Ok(jogador);
        }
        catch (BusinessRuleValidationException ex)
        {
            return BadRequest(new { ex.Message });
        }
    }

    // PUT: api/jogador/5
    [HttpPut("ByIdentifier/{licenca}")]
    public async Task<ActionResult<ClubeDTO>> UpdateByCodClubeAsync(string licenca,
        ClubeDTO dto)
    {
        dto.CodigoClube = Int32.Parse(licenca);

        try
        {
            var jogador = await _service.UpdateByCodClubeAsync(dto);

            if (jogador == null)
            {
                return NotFound();
            }

            return Ok(jogador);
        }
        catch (BusinessRuleValidationException ex)
        {
            return BadRequest(new { ex.Message });
        }
    }

    // Inactivate: api/Jogadores/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<JogadorDTO>> SoftDelete(Guid id)
    {
        var jogador = await _service.InactivateAsync(new Identifier(id));

        if (jogador == null)
        {
            return NotFound();
        }

        return Ok(jogador);
    }

    // DELETE: api/Jogadores/5
    [HttpDelete("{id}/hard")]
    public async Task<ActionResult<ClubeDTO>> HardDelete(Guid id)
    {
        try
        {
            var jogador = await _service.DeleteAsync(new Identifier(id));

            if (jogador == null)
            {
                return NotFound();
            }

            return Ok(jogador);
        }
        catch (BusinessRuleValidationException ex)
        {
            return BadRequest(new { ex.Message });
        }
    }
}