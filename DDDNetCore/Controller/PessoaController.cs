using ConsoleApp1.Domain.Pessoa;
using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controller;

[Route("api/[controller]")]
[ApiController]
public class PessoaController : ControllerBase
{
    private readonly IPessoaService _service;
    public PessoaController(IPessoaService service)
    {
        _service = service;
    }

    // GET: api/Equipas
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PessoaDTO>>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    // GET: api/Jogadores/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PessoaDTO>> GetById(Guid id)
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
    public async Task<ActionResult<PessoaDTO>> GetByIdPessoa(string licenca)
    {
        var jogador = await _service.GetByIdPessoa(licenca);

        if (jogador == null)
        {
            return NotFound();
        }

        return jogador;
    }
    
    
    [HttpGet("NrIdentificacao/{licenca}")]
    public async Task<ActionResult<PessoaDTO>> GetByNrId(string licenca)
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
    public async Task<ActionResult<PessoaDTO>> Create(PessoaDTO dto)
    {
        var list = await _service.GetAllAsync();
        /*if (list != null)
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
        dto.IdentificadorPessoa = _service.GetAllAsync().Result.Count+1;
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
    public async Task<ActionResult<PessoaDTO>> Update(int id, PessoaDTO dto)
    {
        // if (id != dto.Id)
        // {
        //     return BadRequest();
        // }

        dto.IdentificadorPessoa = Int32.Parse(new IdentificadorPessoa(id).ToString());

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
    public async Task<ActionResult<PessoaDTO>> UpdateByIdPessoaAsync(string licenca,
        PessoaDTO dto)
    {
        dto.IdentificadorPessoa = Int32.Parse(new IdentificadorPessoa(Int32.Parse(licenca)).ToString());

        try
        {
            var jogador = await _service.UpdateByIdPessoaAsync(dto);

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
    public async Task<ActionResult<PessoaDTO>> SoftDelete(Guid id)
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
    public async Task<ActionResult<PessoaDTO>> HardDelete(Guid id)
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

