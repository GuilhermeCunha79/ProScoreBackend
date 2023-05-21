using ConsoleApp1.Domain.Associacao;
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoEquipa;
using ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoJogador;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Domain.ProcessoInscricao;
using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controller;

[Route("api/[controller]")]
public class InscricaoDefinitivaAssociacaoJogadorController : ControllerBase
{
    private readonly IInscricaoDefinitivaAssociacaoJogadorService _service;
    private readonly IJogadorService _jogadorService;
    private readonly IProcessoInscricaoService _processoInscricaoService;
    private readonly IAssociacaoService _associacaoService;
    private readonly DDDSample1DbContext _dddSample1DbContext;

    public InscricaoDefinitivaAssociacaoJogadorController(IInscricaoDefinitivaAssociacaoJogadorService service,
        IJogadorService service1, IProcessoInscricaoService _processoInscricaoService1,
        IAssociacaoService _associacaoService1, DDDSample1DbContext _dddSample1DbContext1)
    {
        _service = service;
        _jogadorService = service1;
        _associacaoService = _associacaoService1;
        _dddSample1DbContext = _dddSample1DbContext1;
        _processoInscricaoService = _processoInscricaoService1;
    }

    // GET: api/Jogadores
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InscricaoDefinitivaAssociacaoJogadorDTO>>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    // GET: api/Jogadores/5
    [HttpGet("{id}")]
    public async Task<ActionResult<InscricaoDefinitivaAssociacaoJogadorDTO>> GetById(Guid id)
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
    public async Task<ActionResult<InscricaoDefinitivaAssociacaoJogadorDTO>> GetByLicencaJogador(string licenca)
    {
        var jogador = await _service.GetByLicencaJogador(licenca);

        if (jogador == null)
        {
            return NotFound();
        }

        return jogador;
    }

    // POST: api/Jogadores
    [HttpPost]
    public async Task<ActionResult<(CreatedAtActionResult, InscricaoDefinitivaAssociacaoJogadorDTO, JogadorDTO)>> Create(
        [FromBody]JogadorDTO dtoEquipa)
    {
        var list = await _jogadorService.GetAllAsync();
        if (list != null)
        {
            foreach (var jogadorDto in list)
            {
                if (jogadorDto.IdentificadorPessoa.Equals(dtoEquipa.IdentificadorPessoa)
                   )
                {
                    return BadRequest(new
                        { Message = "O 'Jogador' já se encontra inscrito!" });
                }
            }
        }

        var associacao = _associacaoService.GetNomeAssociacaoByLicenca(dtoEquipa.IdentificadorEquipa.ToString()).Result
            .NomeAssociacao;
        dtoEquipa.Licenca = _dddSample1DbContext.ObterNumeroDeJogadores();
        var processo = new ProcessoInscricaoDTO(Guid.NewGuid(),
            _dddSample1DbContext.ObterNumeroDeProcessos().ToString(), "APROVADO",
            String.Concat(DateTime.Today.ToShortDateString(), " ", DateTime.Today.ToLongTimeString()),
            String.Concat(DateTime.Today.ToShortDateString(), " ", DateTime.Today.ToLongTimeString()),
            "Inscrição de Equipa", new EpocaDesportiva().EpocaDesp);
        var inscricao =
            new InscricaoDefinitivaAssociacaoJogadorDTO(Guid.NewGuid(), associacao, dtoEquipa.Licenca.ToString());

        try
        {
            var processo1 = await _processoInscricaoService.AddAsync(processo);
            var equipa = await _jogadorService.AddAsync(dtoEquipa);
            var inscricao1 = await _service.AddAsync(inscricao);

            return (CreatedAtAction(nameof(GetById), new { id = processo1.Id }, processo1), inscricao1, equipa);
        }
        catch (BusinessRuleValidationException ex)
        {
            return BadRequest(new { ex.Message });
        }
    }


// PUT: api/Jogadores/5
    [HttpPut("{id}")]
    public async Task<ActionResult<InscricaoDefinitivaAssociacaoJogadorDTO>> Update(Guid id,
        InscricaoDefinitivaAssociacaoJogadorDTO dto)
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
    public async Task<ActionResult<InscricaoDefinitivaAssociacaoJogadorDTO>> UpdateByLicencaAsync(string licenca,
        InscricaoDefinitivaAssociacaoJogadorDTO dto)
    {
        dto.Licenca = new Licenca(licenca);

        try
        {
            var jogador = await _service.UpdateByLicencaJogadorAsync(dto);

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
    public async Task<ActionResult<InscricaoDefinitivaAssociacaoJogadorDTO>> SoftDelete(Guid id)
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
    public async Task<ActionResult<InscricaoDefinitivaAssociacaoJogadorDTO>> HardDelete(Guid id)
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