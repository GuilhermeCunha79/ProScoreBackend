using ConsoleApp1.Domain.Associacao;
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.InscricaoDefinitivaAssociacaoEquipa;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Domain.ProcessoInscricao;
using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controller;

[Route("api/[controller]")]

public class InscricaoDefinitivaAssociacaoEquipaController : ControllerBase
{
    private readonly IInscricaoDefinitivaAssociacaoEquipaService _service;
    private readonly IEquipaService _equipaService;
    private readonly IProcessoInscricaoService _processoInscricaoService;
    private readonly IAssociacaoService _associacaoService;
    private readonly DDDSample1DbContext _context;

    public InscricaoDefinitivaAssociacaoEquipaController(IInscricaoDefinitivaAssociacaoEquipaService service,
        IEquipaService service1,DDDSample1DbContext _context1,IProcessoInscricaoService _processoInscricaoService1,IAssociacaoService _associacaoService1)
    {
        _service = service;
        _equipaService = service1;
        _processoInscricaoService = _processoInscricaoService1;
        _associacaoService = _associacaoService1;
        _context = _context1;
    }

    // GET: api/Jogadores
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InscricaoDefinitivaAssociacaoEquipaDTO>>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    // GET: api/Jogadores/5
    [HttpGet("{id}")]
    public async Task<ActionResult<InscricaoDefinitivaAssociacaoEquipaDTO>> GetById(Guid id)
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
    public async Task<ActionResult<InscricaoDefinitivaAssociacaoEquipaDTO>> GetByCodClube(string licenca)
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
    public async Task<ActionResult<(CreatedAtActionResult, InscricaoDefinitivaAssociacaoEquipaDTO,EquipaDTO)>> Create([FromBody]EquipaDTO dtoEquipa)
    {
        
        var list = await _equipaService.GetAllAsync();
        if (list != null)
        {
            foreach (var jogadorDto in list)
            {
                if (jogadorDto.Categoria.Equals(dtoEquipa.Categoria) & jogadorDto.Modalidade.Equals(dtoEquipa.Modalidade) & jogadorDto.Genero.Equals(dtoEquipa.Genero) & jogadorDto.Divisao.Equals(dtoEquipa.Divisao))
                {
                    return BadRequest(new
                        { Message = "O 'Clube' já tem uma 'Equipa' registada com estas características!" });
                }
            }
        }

        var associacao = _associacaoService.GetNomeAssociacaoByCodClube(dtoEquipa.CodigoClube.ToString()).Result.NomeAssociacao;
        dtoEquipa.IdentificadorEquipa = _context.ObterNumeroDeEquipas();
        var processo = new ProcessoInscricaoDTO(Guid.NewGuid(),
            _context.ObterNumeroDeProcessos().ToString(), "APROVADO",
            String.Concat(DateTime.Today.ToShortDateString(), " ", DateTime.Today.ToLongTimeString()),
            String.Concat(DateTime.Today.ToShortDateString(), " ", DateTime.Today.ToLongTimeString()),
            "Inscrição de Equipa", new EpocaDesportiva().EpocaDesp);
        var inscricao = new InscricaoDefinitivaAssociacaoEquipaDTO(Guid.NewGuid(),processo.CodOperacao, associacao,
            dtoEquipa.IdentificadorEquipa, new Estado().Status);
        
        try
        {
            var processo1 = await _processoInscricaoService.AddAsync(processo);
            var equipa = await _equipaService.AddAsync(dtoEquipa);
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
    public async Task<ActionResult<InscricaoDefinitivaAssociacaoEquipaDTO>> Update(Guid id,
        InscricaoDefinitivaAssociacaoEquipaDTO dto)
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
    public async Task<ActionResult<InscricaoDefinitivaAssociacaoEquipaDTO>> UpdateByLicencaAsync(string licenca,
        InscricaoDefinitivaAssociacaoEquipaDTO dto)
    {
        dto.IdentificadorEquipa = Int32.Parse(new IdentificadorEquipa(Int32.Parse(licenca)).ToString());

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
    public async Task<ActionResult<InscricaoDefinitivaAssociacaoEquipaDTO>> SoftDelete(Guid id)
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
    public async Task<ActionResult<InscricaoDefinitivaAssociacaoEquipaDTO>> HardDelete(Guid id)
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