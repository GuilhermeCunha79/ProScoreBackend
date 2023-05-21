using ConsoleApp1.Domain.Associacao;
using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controller;


[Route("api/[controller]")]
[ApiController]
public class AssociacaoController : ControllerBase
{
    private readonly IAssociacaoService _service;

    public AssociacaoController(IAssociacaoService service)
    {
        _service = service;
    }

    // GET: api/Jogadores
    [HttpGet]
    public async Task<ActionResult<IEnumerable<AssociacaoDTO>>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    // GET: api/Jogadores/5
    [HttpGet("{id}")]
    public async Task<ActionResult<AssociacaoDTO>> GetById(Guid id)
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
    public async Task<ActionResult<AssociacaoDTO>> GetByCodClube(string licenca)
    {
        var jogador = await _service.GetByNomeAssociacao(licenca);

        if (jogador == null)
        {
            return NotFound();
        }

        return jogador;
    }

    // POST: api/Jogadores
    [HttpPost]
    public async Task<ActionResult<AssociacaoDTO>> Create(AssociacaoDTO dto)
    {
        var list = await _service.GetAllAsync();
        if (list != null)
        {
            foreach (var jogadorDto in list)
            {
                if (jogadorDto.NomeAssociacao.Equals(dto.NomeAssociacao)|jogadorDto.NomeAssociacao.Equals(dto.NomeAssociacao)|jogadorDto.Acronimo.Equals(dto.Acronimo))
                {
                    return BadRequest(new
                        { Message = "Já existe um 'Clube' registado com este 'Código'." });
                }
            }
        }

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
    public async Task<ActionResult<AssociacaoDTO>> Update(Guid id, AssociacaoDTO dto)
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
    public async Task<ActionResult<AssociacaoDTO>> UpdateByCodClubeAsync(string licenca,
        AssociacaoDTO dto)
    {
        dto.NomeAssociacao = licenca;

        try
        {
            var jogador = await _service.UpdateByNomeAssAsync(dto);

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
    public async Task<ActionResult<AssociacaoDTO>> SoftDelete(Guid id)
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
    public async Task<ActionResult<AssociacaoDTO>> HardDelete(Guid id)
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
