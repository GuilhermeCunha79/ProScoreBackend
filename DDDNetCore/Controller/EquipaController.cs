using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoEquipa;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controller;

[Route("api/[controller]")]
[ApiController]
public class EquipaController : ControllerBase
{
    private readonly IEquipaService _service;
    private readonly IClubeService _service_clube;


    public EquipaController(IEquipaService service,IClubeService _service_clube1)
    {
        _service = service;
        _service_clube = _service_clube1;
    }

    // GET: api/Equipas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<EquipaDTO>>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    // GET: api/Jogadores/5
    [HttpGet("{id}")]
    public async Task<ActionResult<EquipaDTO>> GetById(Guid id)
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
    public async Task<ActionResult<EquipaDTO>> GetByLicencaJogador(string licenca)
    {
        var jogador = await _service.GetByIdentificadorEquipa(licenca);

        if (jogador == null)
        {
            return NotFound();
        }

        return jogador;
    }

    // POST: api/Jogadores
    [HttpPost]
    public async Task<ActionResult<EquipaDTO>> Create(EquipaDTO dto)
    {
        var list = await _service.GetAllAsync();
        if (list != null)
        {
            foreach (var jogadorDto in list)
            {
                if (jogadorDto.IdentificadorEquipa.Equals(dto.IdentificadorEquipa))
                {
                    return BadRequest(new
                        { Message = "Já existe uma 'Equipa' registada com esse 'Identificador'." });
                }
            }
        }

        dto.IdentificadorEquipa = _service.GetAllAsync().Result.Count+1;
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
    public async Task<ActionResult<EquipaDTO>> Update(int id, EquipaDTO dto)
    {
        // if (id != dto.Id)
        // {
        //     return BadRequest();
        // }

        dto.IdentificadorEquipa = Int32.Parse(new IdentificadorEquipa(id).ToString());

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
    public async Task<ActionResult<EquipaDTO>> UpdateByLicencaAsync(string licenca,
        EquipaDTO dto)
    {
        dto.IdentificadorEquipa = Int32.Parse(new IdentificadorEquipa(Int32.Parse(licenca)).ToString());

        try
        {
            var jogador = await _service.UpdateByIdentificadorEquipaAsync(dto);

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
    public async Task<ActionResult<EquipaDTO>> SoftDelete(Guid id)
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
    public async Task<ActionResult<EquipaDTO>> HardDelete(Guid id)
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

