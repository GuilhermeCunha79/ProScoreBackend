using ConsoleApp1.Domain.DocumentoIdentificacao;
using ConsoleApp1.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controller;

[Route("api/[controller]")]
[ApiController]
public class DocIdentificacaoController : ControllerBase
{
    private readonly IDocIdentificacaoService _service;

    public DocIdentificacaoController(IDocIdentificacaoService service)
    {
        _service = service;
    }

    // GET: api/Equipas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DocIdentificacaoDTO>>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    // GET: api/Jogadores/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DocIdentificacaoDTO>> GetById(Guid id)
    {
        var jogador = await _service.GetByIdAsync(new Identifier(id));

        if (jogador == null)
        {
            return NotFound();
        }

        return jogador;
    }

    // GET: api/Warehouses/ById/5M4
    [HttpGet("NrIdCivil/{licenca}")]
    public async Task<ActionResult<DocIdentificacaoDTO>> GetByNrId(string licenca)
    {
        var jogador = await _service.GetByNrId(licenca);

        if (jogador == null)
        {
            return NotFound();
        }

        return jogador;
    }

    // POST: api/Jogadores
    [HttpPost]
    public async Task<ActionResult<DocIdentificacaoDTO>> Create(DocIdentificacaoDTO dto)
    {
        var list = await _service.GetAllAsync();
       /* if (list != null)
        {
            foreach (var jogadorDto in list)
            {
                if (jogadorDto.IdentificadorEquipa.Equals(dto.IdentificadorEquipa))
                {
                    return BadRequest(new
                        { Message = "Já existe uma 'Equipa' registada com esse 'Identificador'." });
                }
            }
        }*/

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
  /*  [HttpPut("{id}")]
    public async Task<ActionResult<EquipaDTO>> Update(int id, EquipaDTO dto)
    {
        // if (id != dto.Id)
        // {
        //     return BadRequest();
        // }

        dto. = new IdentificadorEquipa(id);

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
        dto.IdentificadorEquipa = new IdentificadorEquipa(Int32.Parse(licenca));

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
    }*/
}

