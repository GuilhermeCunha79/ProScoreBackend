using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Domain.DocumentoIdentificacao;
using ConsoleApp1.Domain.DocumentosProcesso;
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.InscricaoProvisoriaClubeEquipa;
using ConsoleApp1.Domain.InscricaoProvisoriaClubeJogador;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Domain.Pessoa;
using ConsoleApp1.Domain.ProcessoInscricao;
using ConsoleApp1.Infraestructure;
using ConsoleApp1.Infraestructure.DocumentoIdentificacao;
using ConsoleApp1.Shared;
using Microsoft.AspNetCore.Mvc;
using AnalyzeDoc = Azure.AI.FormRecognizer.DocumentAnalysis.AnalyzedDocument;

namespace ConsoleApp1.Controller;


[Route("api/[controller]")]

public class InscricaoProvisoriaClubeJogadorController : ControllerBase
{
    private readonly IInscricaoProvisoriaClubeJogadorService _service;
    private readonly IProcessoInscricaoService _service1;
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


    public InscricaoProvisoriaClubeJogadorController(IInscricaoProvisoriaClubeJogadorService service,
        IProcessoInscricaoService _service11, IJogadorRepository _repo_jogador1,
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
    

    // GET: api/Jogadores
    [HttpGet]
    public async Task<ActionResult<IEnumerable<InscricaoProvisoriaClubeJogadorDTO>>> GetAll()
    {
        return await _service.GetAllAsync();
    }

    // GET: api/Jogadores/5
    [HttpGet("{id}")]
    public async Task<ActionResult<InscricaoProvisoriaClubeJogadorDTO>> GetById(Guid id)
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
    public async Task<ActionResult<InscricaoProvisoriaClubeJogadorDTO>> GetByIdEquipa(string licenca)
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
    public async
        Task<(CreatedAtActionResult, DocIdentificacaoDTO, PessoaDTO, JogadorDTO, InscricaoProvisoriaClubeJogadorDTO,DocumentosProcessoDTO)>
        Create(DocumentosProcessoDTO dto)
    {
        string endpoint = "https://cogniteveservices.cognitiveservices.azure.com/";
        string apiKey = "e4d7376d96d8471cba771af20e6d9110";
        var credential = new AzureKeyCredential(apiKey);
        var client = new DocumentAnalysisClient(new Uri(endpoint), credential);

        //BOLETIM

        string modelIdBoletim = "5d706b52-9d63-46d0-815a-b20e1915f66b";

        string imageBase64 = dto.CaminhoBoletim;
        byte[] imageBytes = Convert.FromBase64String(imageBase64);

        using var stream = new MemoryStream(imageBytes);
        AnalyzeDocumentOperation operation =
            await client.AnalyzeDocumentAsync(WaitUntil.Completed, modelIdBoletim, stream);
        AnalyzeResult result = operation.Value;

        string tipoProcesso = "";
        string nrId = "";
        string letrasCheckDocId = "";
        string validade = "";
        string nif = "";
        string nrUtente = "";
        string nome1 = "";
        string nome2 = "";
        string dataNascimento = "";
        string genero = "";
        string email = "";
        string nascencaPais = "";
        string nacionalidade = "";
        string nacionalidade1 = "";
        string codClube = "";
        string nrLicenca = "";


        foreach (AnalyzedDocument document in result.Documents)
        {
            //JOGADOR


            //PROCESSO INSCRIÇÃO
            //TIPO DE BOLETIM
            if (document.Fields["primeiraInscricao"].Content.Trim().Equals(":selected:"))
            {
                tipoProcesso = "Primeira Inscrição";
            }

            if (document.Fields["inscricaoTransferenciaNacional"].Content.Trim().Equals(":selected:"))
            {
                tipoProcesso = "Inscrição c/Transferência Nacional";
            }

            if (document.Fields["revalidacaoInscricao"].Content.Trim().Equals(":selected:"))
            {
                tipoProcesso = "Revalidação de Inscrição";
            }

            if (document.Fields["inscricaoTranferenciaInternacional"].Content.Trim().Equals(":selected:"))
            {
                tipoProcesso = "Inscrição c/Transferência Internacional";
            }

            //GENERO
            if (document.Fields["masculino"].Content.Trim().Equals(":selected:"))
            {
                genero = "Masculino";
            }

            if (document.Fields["feminino"].Content.Trim().Equals(":selected:"))
            {
                genero = "Feminino";
            }


            //EPOCA DESPORTIVA

            //EMAIL
            email = document.Fields["email"].Content;

            nascencaPais = document.Fields["paisNascenca"].Content;
            nacionalidade1 = document.Fields["nacionalidade"].Content;
            codClube = document.Fields["codClubeJogador"].Content;
            nrLicenca = document.Fields["licencaFpf"].Content;
        }

        string imageBase641 = dto.CaminhoDocidentificacao;
        byte[] imageBytes1 = Convert.FromBase64String(imageBase641);
        using var stream11 = new MemoryStream(imageBytes1);
        string modelIdDocId = "d99f3e49-1851-4125-83ca-865d6ec30c25";
        AnalyzeDocumentOperation operation1 =
            await client.AnalyzeDocumentAsync(WaitUntil.Completed, modelIdDocId, stream11);
        AnalyzeResult result1 = operation1.Value;

        foreach (AnalyzeDoc document1 in result1.Documents)
        {
            //DOCUMENTO IDENTIFICAÇÃO
            nrId = document1.Fields["nic"].Content;
            nome1 = document1.Fields["primeirosNomes"].Content;
            nome2 = document1.Fields["UltimosNomes"].Content;
            letrasCheckDocId = document1.Fields["letrasEcheckDigit"].Content;
            validade = document1.Fields["dataValidade"].Content;
            nif = document1.Fields["nif"].Content;
            nrUtente = document1.Fields["utenteSaude"].Content;
            nacionalidade = document1.Fields["nacionalidade"].Content;
            dataNascimento = document1.Fields["dataNascimento"].Content;
        }

        stream11.Close();


        if (!tipoProcesso.Equals("Revalidação de Inscrição"))
        {
            var processo = new ProcessoInscricaoDTO(Guid.NewGuid(),
                DDDSample1DbContext.ObterNumeroDeProcessos().ToString(), "AGUARDAR_APROVACAO_ASSOCIACAO", "-----",
                DateTime.Today.ToString(), tipoProcesso, new EpocaDesportiva().EpocaDesp);

            var docId = new DocIdentificacaoDTO(Guid.NewGuid(), nrId, letrasCheckDocId,
                SharedMethods.onlyLettersAndNumbers(letrasCheckDocId),
                validade, nif, nrUtente, CheckStatus(false));

            var pessoa = new PessoaDTO(Guid.NewGuid(), DDDSample1DbContext.ObterNumeroDePessoas(),
                String.Concat(nome1, " ", nome2),
                dataNascimento,
                genero, email, docId.NrIdentificacao, nascencaPais, nacionalidade1, "false", "-----", "-----");

            var jogador1 = new JogadorDTO(Guid.NewGuid(), DDDSample1DbContext.ObterNumeroDeJogadores(), nacionalidade1,
                pessoa.IdentificadorPessoa, 1,
                "false");

            var inscricao = new InscricaoProvisoriaClubeJogadorDTO(Guid.NewGuid(), Int32.Parse(processo.CodOperacao),
                Int32.Parse(codClube), jogador1.Licenca, "false");
            var docProc = new DocumentosProcessoDTO(Guid.NewGuid(), dto.CaminhoBoletim, dto.CaminhoDocidentificacao,
                processo.CodOperacao);

            var processo1 = await _service1.AddAsync(processo);
            var doc1 = await _service_doc.AddAsync(docId);
            var pessoa1 = await _service_pessoa.AddAsync(pessoa);
            var jogador11 = await _service_jogador.AddAsync(jogador1);
            var inscricao1 = await _service.AddAsync(inscricao);
            var docProc1 = await _service_doc_proc.AddAsync(docProc);
            return (CreatedAtAction(nameof(GetById), new { id = processo1.Id }, processo1), doc1, pessoa1, jogador11,
                inscricao1,docProc1);
        }

        if (_repo_jogador.GetAllAsync().Result.Any(e => e.Licenca.Lic == new Licenca(0.ToString()).Lic) )
        {
            var processo111 = new ProcessoInscricaoDTO(Guid.NewGuid(),
                DDDSample1DbContext.ObterNumeroDeProcessos().ToString(), "AGUARDAR_APROVACAO_ASSOCIACAO", "-----",
                DateTime.Today.ToString(), tipoProcesso, new EpocaDesportiva().EpocaDesp);

            var docId111 = new DocIdentificacaoDTO(Guid.NewGuid(), nrId, letrasCheckDocId,
                SharedMethods.onlyLettersAndNumbers(letrasCheckDocId),
                validade, nif, nrUtente, CheckStatus(false));

            var pessoa111 = new PessoaDTO(Guid.NewGuid(), DDDSample1DbContext.ObterNumeroDePessoas(),
                String.Concat(nome1, " ", nome2),
                dataNascimento,
                genero, email, docId111.NrIdentificacao, nascencaPais, nacionalidade, "false", "-----", "-----");

            int licc = _repo_jogador.GetLicencaByIdPessoaAsync(pessoa111.IdentificadorPessoa.ToString()).Result
                .Licenca
                .Lic;

            var docProc = new DocumentosProcessoDTO(Guid.NewGuid(), dto.CaminhoBoletim, dto.CaminhoDocidentificacao,
                processo111.CodOperacao);
            

            var processo11 = await _service1.AddAsync(processo111);
            var doc11 = await _service_doc.UpdateByNrIdAsync(docId111);
            var pessoa11 = await _service_pessoa.UpdateByIdPessoaAsync(pessoa111);
            var jogador111 = await _service_jogador.UpdateByJogadorLicencaAsync(
                JogadorMapper.toDto(_repo_jogador.GetLicencaByIdPessoaAsync(pessoa111.IdentificadorPessoa.ToString())
                    .Result));
            
            var inscricao111 = new InscricaoProvisoriaClubeJogadorDTO(Guid.NewGuid(),
                Int32.Parse(processo111.CodOperacao),
                Int32.Parse(codClube), licc, "false");
            var inscricao11 = await _service.AddAsync(inscricao111);
            var docProc1 = await _service_doc_proc.AddAsync(docProc);
            return (CreatedAtAction(nameof(GetById), new { id = processo11.Id }, processo11), doc11, pessoa11, jogador111,
                inscricao11,docProc1);
        }

        return (null, null, null, null, null,null);
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
    [HttpPut("{id}")]
    public async Task<ActionResult<InscricaoProvisoriaClubeJogadorDTO>> Update(Guid id,
        InscricaoProvisoriaClubeJogadorDTO dto)
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
    public async Task<ActionResult<InscricaoProvisoriaClubeJogadorDTO>> UpdateByLicencaAsync(string licenca,
        InscricaoProvisoriaClubeJogadorDTO dto)
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
    public async Task<ActionResult<InscricaoProvisoriaClubeJogadorDTO>> SoftDelete(Guid id)
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
    public async Task<ActionResult<InscricaoProvisoriaClubeJogadorDTO>> HardDelete(Guid id)
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