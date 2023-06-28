using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using ConsoleApp1.Domain.DocumentoIdentificacao;
using ConsoleApp1.Domain.DocumentosProcesso;
using ConsoleApp1.Domain.InscricaoProvisoriaClubeJogador;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Domain.PaisNascenca;
using ConsoleApp1.Domain.Pessoa;
using ConsoleApp1.Domain.ProcessoInscricao;
using ConsoleApp1.Domain.VisualizacaoJogador;
using ConsoleApp1.Infraestructure;
using ConsoleApp1.Infraestructure.DocumentoIdentificacao;
using ConsoleApp1.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AnalyzeDoc = Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzedDocument;

namespace ConsoleApp1.Controller;

[Route("api/[controller]")]
[ApiController]
public class ProcessoInscricaoController : ControllerBase
{
    private readonly IProcessoInscricaoService _service;
    private readonly IInscricaoProvisoriaClubeJogadorService _service1;
    private readonly IDocIdentificacaoService _service_doc;
    private readonly IPessoaService _service_pessoa;
    private readonly IJogadorService _service_jogador;
    private readonly IDocumentosProcessoService _service_doc_proc;
    private readonly DDDSample1DbContext DDDSample1DbContext;

    private readonly IProcessoInscricaoRepository _repo;
    private readonly IPessoaRepository _repo_pessoa;
    private readonly IJogadorRepository _repo_jogador;
    private readonly IDocIdentificacaoRepository _repo_doc;
    private readonly IDocumentosProcessoRepository _repo_doc_proc;


    public ProcessoInscricaoController(IProcessoInscricaoService service,
        IInscricaoProvisoriaClubeJogadorService _service11, IJogadorRepository _repo_jogador1,
        IPessoaRepository _repo_pessoa1, IDocIdentificacaoRepository _repo_doc1, IProcessoInscricaoRepository _repo1,
        DDDSample1DbContext context, IDocIdentificacaoService service1, IPessoaService service3,
        IJogadorService service4,IDocumentosProcessoService _service_doc_proc1,IDocumentosProcessoRepository _repo_doc_proc1)
    {
        _service = service;
        _service1 = _service11;
        _repo = _repo1;
        _repo_jogador = _repo_jogador1;
        _repo_pessoa = _repo_pessoa1;
        _repo_doc = _repo_doc1;
        _service_doc = service1;
        _service_pessoa = service3;
        _service_jogador = service4;
        DDDSample1DbContext = context;
        _service_doc_proc = _service_doc_proc1;
        _repo_doc_proc = _repo_doc_proc1;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProcessoJogadorVisualizacaoDTO>>> GetAllProcessos()
    {
        return await _service.GetAllAsync1();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProcessoInscricaoDTO>> GetById(Guid id)
    {
        var jogador = await _service.GetByIdAsync(new Identifier(id));

        if (jogador == null)
        {
            return NotFound();
        }

        return jogador;
    }
    
    [HttpGet("ByAssociacao/{nomeAssociacao}")]
    public async Task<ActionResult<IEnumerable<ProcessoInscricaoDTO>>>  GetProcessosAssociacaoByNomeAssociacaoAsync(string nomeAssociacao)
    {
        var jogador = await _service.GetProcessosAssociacaoByNomeAssociacaoAsync(nomeAssociacao);

        if (jogador == null)
        {
            return NotFound();
        }

        return jogador;
    }

    
    public async Task<ActionResult<ProcessoInscricaoDTO>> Create(ProcessoInscricaoDTO dto)
    {

        dto.CodOperacao = DDDSample1DbContext.ObterNumeroDeProcessos().ToString();
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

    private string CheckStatus(bool status)
    {
        if (status)
        {
            return "Active";
        }

        return "Inactive";
    }


    // PUT: api/Jogadores/5
    [HttpPut("CodOperacao1/{licenca}")]
    public async Task<ActionResult<ProcessoInscricaoDTO>> UpdateByLicencaAsync(string licenca)
    {

        var dto = await _service.GetByCodOperacao(licenca);
        try
        {
            var jogador = await _service.UpdateByCodOperacaoAsync(dto);
           var processo= await _service1.UpdateByCodOperacaoAsync(_service1.GetByCodOperacao(licenca).Result);
           var jogador1 =
               await _service_jogador.UpdateByJogadorLicencaAsync(_service_jogador
                   .GetByLicencaJogador(processo.Licenca.ToString()).Result);
           var pessoa =
               await _service_pessoa.UpdateByIdPessoaAsync(_service_pessoa
                   .GetByIdPessoa(jogador1.IdentificadorPessoa.ToString()).Result);
           await _service_doc.UpdateByNrIdAsync(_service_doc.GetByNrId(pessoa.NrIdentificacao).Result);
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
    
    
    
    
    // DELETE: api/Deliveries/5
    [HttpDelete("{id}/hard")]
    public async Task<ActionResult<ProcessoInscricaoDTO>> HardDelete(string id)
    {
        try
        {
            var delivery = await _service.DeleteAsync(id);

            if (delivery == null)
            {
                return NotFound();
            }

            return Ok(delivery);
        }
        catch (BusinessRuleValidationException ex)
        {
            return BadRequest(new { ex.Message });
        }
    }
}