using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoEquipa;
using ConsoleApp1.Domain.InscricaoProvisoriaClubeEquipa;
using ConsoleApp1.Domain.ProcessoInscricao;
using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controller;


[Route("api/[controller]")]

public class InscricaoProvisoriaClubeEquipaController : ControllerBase
{
    private readonly IInscricaoProvisoriaClubeEquipaService _service;
    private readonly IEquipaService _equipaService;
    private readonly DDDSample1DbContext _context;

    public InscricaoProvisoriaClubeEquipaController(IInscricaoProvisoriaClubeEquipaService service,
        IEquipaService service1,DDDSample1DbContext _context1)
    {
        _service = service;
        _equipaService = service1;
        _context = _context1;
    }

    // GET: api/Jogadores
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InscricaoProvisoriaClubeEquipaDTO>>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    // GET: api/Jogadores/5
    [HttpGet("{id}")]
    public async Task<ActionResult<InscricaoProvisoriaClubeEquipaDTO>> GetById(Guid id)
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
    public async Task<ActionResult<InscricaoProvisoriaClubeEquipaDTO>> GetByIdEquipa(string licenca)
    {
        var jogador = await _service.GetByIdEquipa(licenca);

        if (jogador == null)
        {
            return NotFound();
        }

        return jogador;
    }

    // POST: api/Jogadores
    [HttpPost]
    public async Task<ActionResult<(CreatedAtActionResult, CreatedAtActionResult)>> Create(
        EquipaDTO dtoEquipa)
    {
        var list = await _equipaService.GetAllAsync();
        if (list != null)
        {
            foreach (var jogadorDto in list)
            {
                if (jogadorDto.IdentificadorEquipa.Equals(dtoEquipa.IdentificadorEquipa))
                {
                    return BadRequest(new
                        { Message = "Esta 'Equipa' já está registada!" });
                }
            }
        }

        try
        {
            dtoEquipa.IdentificadorEquipa = dtoEquipa.IdentificadorEquipa;
            var processo = new ProcessoInscricaoDTO(Guid.NewGuid(), _context.ObterNumeroDeProcessos().ToString(),
                new Estado().Status, new DataRegisto().DataReg, new DataSubscricao().DataSubs, "Inscrição Equipa",
                new EpocaDesportiva().EpocaDesp);
            var inscricao = new InscricaoProvisoriaClubeEquipaDTO(Guid.NewGuid(), Int32.Parse(processo.CodOperacao),
                dtoEquipa.IdentificadorEquipa, dtoEquipa.CodigoClube);
            var jogador = await _service.AddAsync(inscricao);
            dtoEquipa.Status = false;
            var equipa = await _equipaService.AddAsync(dtoEquipa);

            return (CreatedAtAction(nameof(GetById), new { id = jogador.Id }, jogador),CreatedAtAction(nameof(GetById), new { id = equipa.Id },equipa));
        }
        catch (BusinessRuleValidationException ex)
        {
            return BadRequest(new { ex.Message });
        }
    }


    // PUT: api/Jogadores/5
    [HttpPut("{id}")]
    public async Task<ActionResult<InscricaoProvisoriaClubeEquipaDTO>> Update(Guid id,
        InscricaoProvisoriaClubeEquipaDTO dto)
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
    public async Task<ActionResult<InscricaoProvisoriaClubeEquipaDTO>> UpdateByLicencaAsync(string licenca,
        InscricaoProvisoriaClubeEquipaDTO dto)
    {
        dto.IdentificadorEquipa = Int32.Parse(new IdentificadorEquipa(Int32.Parse(licenca)).ToString());

        try
        {
            var jogador = await _service.UpdateByIdEquipaAsync(dto);

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
    public async Task<ActionResult<InscricaoProvisoriaClubeEquipaDTO>> SoftDelete(Guid id)
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
    public async Task<ActionResult<InscricaoProvisoriaClubeEquipaDTO>> HardDelete(Guid id)
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