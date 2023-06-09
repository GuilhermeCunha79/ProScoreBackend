using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Domain.Utilizador;
using ConsoleApp1.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConsoleApp1.Controller;

[Route("api/[controller]")]
[ApiController]
public class UtilizadorController : ControllerBase
{
    private readonly IUtilizadorService _service;


    public UtilizadorController(IUtilizadorService service)
    {
        _service = service;
    }

    // GET: api/Jogadores
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UtilizadorDTO>>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    // GET: api/Jogadores/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UtilizadorDTO>> GetById(Guid id)
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
    public async Task<ActionResult<UtilizadorDTO>> GetByEmail(string licenca)
    {
        var jogador = await _service.GetByEmail(licenca);

        if (jogador == null)
        {
            return NotFound();
        }

        return jogador;
    }

    // POST: api/Jogadores
    [HttpGet("authenticate/{emailPass}")]
    public async Task<ActionResult<UtilizadorDTO>> Create(string emailPass)
    {
        var list = await _service.GetAllAsync();
        if (list != null)
        {
            foreach (var jogadorDto in list)
            {
                string email = emailPass.Substring(0, emailPass.LastIndexOf('|'));
                if (emailPass.Substring(emailPass.LastIndexOf('|') + 1).Equals(jogadorDto.Password) &
                    email.Equals(jogadorDto.EmailUtilizador))
                {
                    try
                    {
                        var jogador = await _service.GetByEmail(email);
                        return jogador;
                    }
                    catch (BusinessRuleValidationException ex)
                    {
                        return BadRequest(new { ex.Message });
                    }
                }
            }
        }

        return BadRequest("Email ou Password errados!");
    }

    [HttpPost("registration")]
    public async Task<ActionResult<UtilizadorDTO>> Registration(UtilizadorDTO dto)
    {
        var list = await _service.GetAllAsync();
        if (list != null)
        {
            foreach (var jogadorDto in list)
            {
                if (jogadorDto.EmailUtilizador.Equals(dto.EmailUtilizador))
                {
                    return BadRequest(new
                        { Message = "Já existe um 'Utilizador' registado com este 'Email'." });
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
    public async Task<ActionResult<UtilizadorDTO>> Update(Guid id, UtilizadorDTO dto)
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
    public async Task<ActionResult<UtilizadorDTO>> UpdateByEmailAsync(string licenca,
        UtilizadorDTO dto)
    {
        dto.EmailUtilizador = new EmailUtilizador(licenca).ToString();

        try
        {
            var jogador = await _service.UpdateByEmailAsync(dto);

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
    public async Task<ActionResult<UtilizadorDTO>> SoftDelete(Guid id)
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
    public async Task<ActionResult<UtilizadorDTO>> HardDelete(Guid id)
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