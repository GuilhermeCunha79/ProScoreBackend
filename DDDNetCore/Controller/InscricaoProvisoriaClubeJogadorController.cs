using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Domain.DocumentoIdentificacao;
using ConsoleApp1.Domain.DocumentosProcesso;
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.InscricaoProvisoriaClubeEquipa;
using ConsoleApp1.Domain.InscricaoProvisoriaClubeJogador;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Domain.Nacionalidade;
using ConsoleApp1.Domain.PaisNascenca;
using ConsoleApp1.Domain.Pessoa;
using ConsoleApp1.Domain.ProcessoInscricao;
using ConsoleApp1.Domain.VisualizacaoCriacaoPessoa;
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
    private readonly IEquipaService _service_equipa;

    private readonly IJogadorService _service_jogador;

    // private readonly IDocumentosProcessoService _service_doc_proc;
    private readonly DDDSample1DbContext DDDSample1DbContext;

    private readonly IProcessoInscricaoRepository _repo;
    private readonly IPessoaRepository _repo_pessoa;
    private readonly IJogadorRepository _repo_jogador;

    private readonly IDocIdentificacaoRepository _repo_doc;
    private readonly IDocumentosProcessoRepository _repo_doc_proc;

    private readonly IPaisNascencaRepository _paisNascencaRepository;


    public InscricaoProvisoriaClubeJogadorController(IInscricaoProvisoriaClubeJogadorService service,
        IProcessoInscricaoService _service11, IJogadorRepository _repo_jogador1,
        IPessoaRepository _repo_pessoa1, IDocIdentificacaoRepository _repo_doc1, IProcessoInscricaoRepository _repo1,
        DDDSample1DbContext context, IDocIdentificacaoService service1, IPessoaService service3,
        IPaisNascencaRepository _paisNascencaRepository1,IEquipaService _service_equipa1,
        IJogadorService service4 /*,IDocumentosProcessoService _service_doc_proc1,
        IDocumentosProcessoRepository _repo_doc_proc1*/)
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
        _paisNascencaRepository = _paisNascencaRepository1;
        //  _service_doc_proc = _service_doc_proc1;
        // _repo_doc_proc = _repo_doc_proc1;
        _service_equipa = _service_equipa1;
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

    [HttpPost("confirm")]
    public async
        Task<(CreatedAtActionResult, DocIdentificacaoDTO, PessoaDTO, JogadorDTO, InscricaoProvisoriaClubeJogadorDTO)>
        Create([FromBody] PessoaVisualizacaoDTO dto)
    {
        var processo = new ProcessoInscricaoDTO(Guid.NewGuid(),
            DDDSample1DbContext.ObterNumeroDeProcessos().ToString(), "AGUARDAR_APROVACAO_ASSOCIACAO", "-----",
            DateTime.Today.ToString(), "Primeira Inscrição", new EpocaDesportiva().EpocaDesp);

        var docId = new DocIdentificacaoDTO(Guid.NewGuid(), dto.NrIdentificacao, dto.CheckDigit,
            dto.ValidadeDocId,
            dto.Nif, CheckStatus(false));

        var pessoa = new PessoaDTO(Guid.NewGuid(), DDDSample1DbContext.ObterNumeroDePessoas(),
            dto.Nome,
            dto.DataNascimento,
            dto.Sexo, dto.Email, docId.NrIdentificacao, dto.PaisNascenca, dto.Nacionalidade, "false",
            new Telefone().Telemovel,
            new ConcelhoResidência().Concelho);

        var jogador1 = new JogadorDTO(Guid.NewGuid(), DDDSample1DbContext.ObterNumeroDeJogadores(), dto.Nacionalidade,
            pessoa.IdentificadorPessoa, 1,
            "false");

        var inscricao = new InscricaoProvisoriaClubeJogadorDTO(Guid.NewGuid(), Int32.Parse(processo.CodOperacao),
            Int32.Parse("1"), jogador1.Licenca, "false");


        var processo1 = await _service1.AddAsync(processo);
        var doc1 = await _service_doc.AddAsync(docId);
        var pessoa1 = await _service_pessoa.AddAsync(pessoa);
        var jogador11 = await _service_jogador.AddAsync(jogador1);
        var inscricao1 = await _service.AddAsync(inscricao);
        //    var docProc1 = await _service_doc_proc.AddAsync(docProc);
        return (CreatedAtAction(nameof(GetById), new { id = processo1.Id }, processo1), doc1, pessoa1, jogador11,
            inscricao1);
    }

    // POST: api/Jogadores
    [HttpPost]
    public async
        Task<ActionResult<PessoaVisualizacaoDTO>?> Create([FromBody] DocumentosProcessoDTO dto)
    {
        if (dto.CaminhoBoletim.Contains("base64"))
        {
            int index = dto.CaminhoBoletim.LastIndexOf("base64,");
            dto.CaminhoBoletim = dto.CaminhoBoletim.Substring(index + 7);
        }

        if (dto.CaminhoDocIdentificacao.Contains("base64"))
        {
            int index = dto.CaminhoDocIdentificacao.LastIndexOf("base64,");
            dto.CaminhoDocIdentificacao = dto.CaminhoDocIdentificacao.Substring(index + 7);
        }

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

        string nomeAssociacao = "";
        string nomeClube = "";
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
        string telefone = "";
        string modalidade = "";
        string categoria = "";


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
            
            //MODALIDADE
            if (document.Fields["futebol"].Content.Trim().Equals(":selected:"))
            {
                modalidade = "Futebol";
            }
            if (document.Fields["futsal"].Content.Trim().Equals(":selected:"))
            {
                modalidade = "Futsal";
            }
            
            //CATEGORIA
            if (document.Fields["senior"].Content.Trim().Equals(":selected:"))
            {
                categoria = "Sénior";
            }
            if (document.Fields["juniorA"].Content.Trim().Equals(":selected:"))
            {
                categoria = "JuniorA";
            }
            if (document.Fields["juniorB"].Content.Trim().Equals(":selected:"))
            {
                categoria = "JuniorB";
            }
            if (document.Fields["juniorC"].Content.Trim().Equals(":selected:"))
            {
                categoria = "JuniorC";
            }
            if (document.Fields["juniorD"].Content.Trim().Equals(":selected:"))
            {
                categoria = "JuniorD";
            }
            if (document.Fields["benjamim"].Content.Trim().Equals(":selected:"))
            {
                categoria = "Benjamim";
            }
            if (document.Fields["traquina"].Content.Trim().Equals(":selected:"))
            {
                categoria = "Traquina";
            }
            if (document.Fields["petiz"].Content.Trim().Equals(":selected:"))
            {
                categoria = "Petiz";
            }
            

            //EPOCA DESPORTIVA
            nomeAssociacao = document.Fields["associacao"].Content;
            //EMAIL
            email = document.Fields["email"].Content;
            telefone = document.Fields["telefone"].Content;
            nascencaPais = document.Fields["paisNascenca"].Content;
            nacionalidade1 = document.Fields["nacionalidade"].Content;
            codClube = document.Fields["codClubeJogador"].Content;
            nrLicenca = document.Fields["licencaFpf"].Content;
            nomeClube=document.Fields["clubeJogador"].Content;
        }

        string imageBase641 = dto.CaminhoDocIdentificacao;
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
                genero, email, docId.NrIdentificacao, nascencaPais, nacionalidade1, "false", telefone,
                new ConcelhoResidência().Concelho);

            var jogador1 = new JogadorDTO(Guid.NewGuid(), DDDSample1DbContext.ObterNumeroDeJogadores(),
                new EstatutoFpF(nacionalidade1).Estatuto,
                pessoa.IdentificadorPessoa, 1,
                "false");

            var inscricao = new InscricaoProvisoriaClubeJogadorDTO(Guid.NewGuid(), Int32.Parse(processo.CodOperacao),
                Int32.Parse(codClube), jogador1.Licenca, "false");
            var docProc = new DocumentosProcessoDTO(Guid.NewGuid(), dto.CaminhoBoletim, dto.CaminhoDocIdentificacao,
                processo.CodOperacao);

            var pessoaVisualizacao = new PessoaVisualizacaoDTO(pessoa.Nome, "Número de identificação civil",
                docId.NrIdentificacao, new CheckDigit(docId.CheckDigit).CheckDig,
                new ValidadeDoc(docId.ValidadeDoc).Data, jogador1.EstatutoFpF,
                docId.Nif, pessoa.TipoGenero, new DataNascimento(pessoa.DataNascimento).DataNasc,
                new PaisNascenca(pessoa.NascencaPais, DDDSample1DbContext.PaisNascenca.ToList()).NomePais.Nome,
                new NacionalidadePais(pessoa.NacionalidadePais).NacionalidadePaiss,
                pessoa.ConcelhoResidencia, pessoa.Telefone, pessoa.Email,docId.NrUtente,codClube,nomeAssociacao,nomeClube,modalidade,_service_equipa.GetByCatModAsync(codClube,categoria,modalidade,genero).Result.Divisao,categoria);
            try
            {
                //var processo1 = await _service1.AddAsync(processo);
                //   var doc1 = await _service_doc.AddAsync(docId);
                //   var pessoa1 = await _service_pessoa.AddAsync(pessoa);
                //     var jogador11 = await _service_jogador.AddAsync(jogador1);
                //  var inscricao1 = await _service.AddAsync(inscricao);
                //    var docProc1 = await _service_doc_proc.AddAsync(docProc);
                return pessoaVisualizacao;
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

//ALTERAR ISTO AQUIIIIIIIIIIIIIIIIIIIII
        if (_repo_jogador.GetAllAsync().Result.Any(e => e.Licenca.Lic == new Licenca(0.ToString()).Lic))
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
                genero, email, docId111.NrIdentificacao, nascencaPais, nacionalidade, "false", new Telefone().Telemovel,
                new ConcelhoResidência().Concelho);

            int licc = _repo_jogador.GetLicencaByIdPessoaAsync(pessoa111.IdentificadorPessoa.ToString()).Result
                .Licenca
                .Lic;

            var docProc = new DocumentosProcessoDTO(Guid.NewGuid(), dto.CaminhoBoletim, dto.CaminhoDocIdentificacao,
                processo111.CodOperacao);


            try
            {
                await _service1.AddAsync(processo111);
                var doc11 = await _service_doc.UpdateByNrIdAsync(docId111);
                var pessoa11 = await _service_pessoa.UpdateByIdPessoaAsync(pessoa111);
                var jogador111 = await _service_jogador.UpdateByJogadorLicencaAsync(
                    JogadorMapper.toDto(_repo_jogador
                        .GetLicencaByIdPessoaAsync(pessoa111.IdentificadorPessoa.ToString())
                        .Result));

                var inscricao111 = new InscricaoProvisoriaClubeJogadorDTO(Guid.NewGuid(),
                    Int32.Parse(processo111.CodOperacao),
                    Int32.Parse(codClube), licc, "false");
                await _service.AddAsync(inscricao111);
                // await _service_doc_proc.AddAsync(docProc);

                var pessoaVisualizacao = new PessoaVisualizacaoDTO(pessoa11.Nome, "Cartão de Cidadão",
                    doc11.NrIdentificacao, doc11.CheckDigit,
                    doc11.ValidadeDoc, jogador111.EstatutoFpF,
                    doc11.Nif, pessoa11.TipoGenero, pessoa11.DataNascimento, pessoa11.NascencaPais,
                    pessoa11.NacionalidadePais,
                    pessoa11.ConcelhoResidencia,
                    pessoa11.Telefone, pessoa11.Email,doc11.NrUtente,codClube,nomeAssociacao,nomeClube,modalidade,"",categoria);
                return pessoaVisualizacao;
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        return null;
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