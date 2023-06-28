using System.Net.Http.Headers;
using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using ConsoleApp1.Domain.Associacao;
using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Domain.DocumentoIdentificacao;
using ConsoleApp1.Domain.DocumentosProcesso;
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.InscricaoProvisoriaClubeJogador;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Domain.Nacionalidade;
using ConsoleApp1.Domain.PaisNascenca;
using ConsoleApp1.Domain.Pessoa;
using ConsoleApp1.Domain.ProcessoInscricao;
using ConsoleApp1.Domain.VisualizacaoCriacaoPessoa;
using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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

    private readonly IClubeService _service_clube;

    private readonly IJogadorService _service_jogador;
    private readonly INacionalidadeService _service_nacionalidade;

    // private readonly IDocumentosProcessoService _service_doc_proc;
    private readonly DDDSample1DbContext DDDSample1DbContext;

    private readonly IAssociacaoService _service_associacao;


    public InscricaoProvisoriaClubeJogadorController(IInscricaoProvisoriaClubeJogadorService service,
        IProcessoInscricaoService _service11,
        DDDSample1DbContext context, IDocIdentificacaoService service1, IPessoaService service3,
        IEquipaService _service_equipa1,
        IJogadorService service4, IClubeService _service_clube1,
        IAssociacaoService _service_associacao1,INacionalidadeService _service_nacionalidade1 /*,IDocumentosProcessoService _service_doc_proc1,
        IDocumentosProcessoRepository _repo_doc_proc1*/)
    {
        _service = service;
        _service1 = _service11;
        _service_doc = service1;
        _service_pessoa = service3;
        _service_jogador = service4;
        DDDSample1DbContext = context;
        _service_associacao = _service_associacao1;
        //  _service_doc_proc = _service_doc_proc1;
        // _repo_doc_proc = _repo_doc_proc1;
        _service_equipa = _service_equipa1;
        _service_clube = _service_clube1;
        _service_nacionalidade = _service_nacionalidade1;
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
            dto.Sexo, dto.Email, docId.NrIdentificacao, dto.PaisNascenca, dto.Nacionalidade, CheckStatus(false),
            dto.Telefone,
            dto.ConcelhoResidencia);

        var jogador1 = new JogadorDTO(Guid.NewGuid(), DDDSample1DbContext.ObterNumeroDeJogadores(), dto.Nacionalidade,
            pessoa.IdentificadorPessoa,
            _service_equipa.GetByCatModAsync(dto.CodClube, dto.Categoria, dto.Modalidade, pessoa.TipoGenero).Result
                .IdentificadorEquipa,
            CheckStatus(false));

        var inscricao = new InscricaoProvisoriaClubeJogadorDTO(Guid.NewGuid(), Int32.Parse(processo.CodOperacao),
            int.Parse(dto.CodClube), jogador1.Licenca, CheckStatus(false));


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
    public async Task<ActionResult<object>?> Create([FromBody] DocumentosProcessoDTO dto)
    {
        
        string nomeAssociacao;
        string modelIdBoletim = "5d706b52-9d63-46d0-815a-b20e1915f66b";
        string modelIdDocId = "d99f3e49-1851-4125-83ca-865d6ec30c25";
        string selected = ":selected:";
        string nomeClube = "";
        string tipoProcesso = "";
        string nrId = "";
        string letrasCheckDocId = "";
        string validade = "";
        string nif = "";
        string nrUtente = "";
        string nome1 = "";
        string nome2 = "";
        string divisao;
        string dataNascimento = "";
        string genero = "";
        string email = "";
        string nascencaPais = "";
        string nacionalidade = "";
        string codClube = "";
        string telefone = "";
        string modalidade = "";
        string categoria = "";
        string nrDocIdBoletim = "";
        string concelhoResidencia;
        
        
        foreach (AnalyzedDocument document in _service1.AnalyseImage(Base64(dto.CaminhoBoletim),
                     modelIdBoletim).Result.Documents)
        {
            //TIPO PROCESSO
            if (document.Fields["primeiraInscricao"].Content.Trim().Equals(selected))
            {
                tipoProcesso = "Primeira Inscrição";
            }
            else if (document.Fields["inscricaoTransferenciaNacional"].Content.Trim().Equals(selected))
            {
                tipoProcesso = "Inscrição c/Transferência Nacional";
            }
            else if (document.Fields["revalidacaoInscricao"].Content.Trim().Equals(selected))
            {
                tipoProcesso = "Revalidação de Inscrição";
            }
            else if (document.Fields["inscricaoTranferenciaInternacional"].Content.Trim().Equals(selected))
            {
                tipoProcesso = "Inscrição c/Transferência Internacional";
            }

            //GENERO
            if (document.Fields["masculino"].Content.Trim().Equals(selected))
            {
                genero = "Masculino";
            }
            else if (document.Fields["feminino"].Content.Trim().Equals(selected))
            {
                genero = "Feminino";
            }

            //MODALIDADE
            if (document.Fields["futebol"].Content.Trim().Equals(selected))
            {
                modalidade = "Futebol";
            }
            else if (document.Fields["futsal"].Content.Trim().Equals(selected))
            {
                modalidade = "Futsal";
            }

            //CATEGORIA
            if (document.Fields["senior"].Content.Trim().Equals(selected))
            {
                categoria = "Sénior";
            }
            else if (document.Fields["juniorA"].Content.Trim().Equals(selected))
            {
                categoria = "JuniorA";
            }
            else if (document.Fields["juniorB"].Content.Trim().Equals(selected))
            {
                categoria = "JuniorB";
            }
            else if (document.Fields["juniorC"].Content.Trim().Equals(selected))
            {
                categoria = "JuniorC";
            }
            else if (document.Fields["juniorD"].Content.Trim().Equals(selected))
            {
                categoria = "JuniorD";
            }
            else if (document.Fields["benjamim"].Content.Trim().Equals(selected))
            {
                categoria = "Benjamim";
            }
            else if (document.Fields["traquina"].Content.Trim().Equals(selected))
            {
                categoria = "Traquina";
            }
            else if (document.Fields["petiz"].Content.Trim().Equals(selected))
            {
                categoria = "Petiz";
            }

            email = document.Fields["email"].Content;
            telefone = document.Fields["telefone"].Content;
            nascencaPais = document.Fields["paisNascenca"].Content;
            nacionalidade = document.Fields["nacionalidade"].Content;
            codClube = document.Fields["codClubeJogador"].Content;
            nomeClube = document.Fields["clubeJogador"].Content;
            nrDocIdBoletim = document.Fields["nrDocId"].Content;
        }

        foreach (AnalyzeDoc document1 in _service1.AnalyseImage(Base64(dto.CaminhoDocIdentificacao),
                     modelIdDocId).Result.Documents)
        {
            nrId = document1.Fields["nic"].Content;
            nome1 = document1.Fields["primeirosNomes"].Content;
            nome2 = document1.Fields["UltimosNomes"].Content;
            letrasCheckDocId = document1.Fields["letrasEcheckDigit"].Content;
            validade = document1.Fields["dataValidade"].Content;
            nif = document1.Fields["nif"].Content;
            nrUtente = document1.Fields["utenteSaude"].Content;
           // nacionalidade = document1.Fields["nacionalidade"].Content;
            dataNascimento = document1.Fields["dataNascimento"].Content;
        }

        /* if (tipoProcesso.Equals("Primeira Inscrição"))
       {
           return StatusCode(500, "O boletim de Modelo2 submetido não corresponde a uma 'Primeira Inscrição.");
       }

       if (!_service_clube.GetAllAsync().Result.Any(o => o.CodigoClube.ToString() == codClube))
       {
           return StatusCode(500, "O 'Código de Clube' do boletim não coincide com nenhum clube registado.");
       }
       
           if (nrDocIdBoletim != nrId)
       {
           return StatusCode(500,
               "O 'Número de identificação' do documento de identificação inserido não coincide com o do Modelo2.");
       }
       
       */
       
        if (_service_doc.GetAllAsync().Result.Any(o => o.NrIdentificacao == nrId))
       {
           return StatusCode(500, "O portador do 'Documento de Identificação' submetido, já se encontra registado.");
       }



        try
        {
            var pessoaVisualizacao = new PessoaVisualizacaoDTO(String.Concat(nome1, " ", nome2),
                "Número de identificação civil", nrId, new CheckDigit(letrasCheckDocId).CheckDig, 
                new ValidadeDoc(validade).Data,
                new EstatutoFpF(nacionalidade).Estatuto, nif, genero, new DataNascimento(dataNascimento).DataNasc,
                new PaisNascenca(nascencaPais, DDDSample1DbContext.PaisNascenca.ToList()).NomePais.Nome,
                new NacionalidadePais(nacionalidade).NacionalidadePaiss,
                new ConcelhoResidência().Concelho, telefone, email, nrUtente, codClube,
                _service_associacao.GetNomeAssociacaoByCodClube(codClube).Result.NomeAssociacao, nomeClube, modalidade, 
                _service_equipa.GetByCatModAsync(codClube,categoria,modalidade,genero).Result.Divisao,categoria);
            return pessoaVisualizacao;
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Ocorreu um erro na API. Por favor, tente novamente mais tarde.");
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
        dto.Licenca = int.Parse(new Licenca(licenca).ToString());

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


    public async Task<List<double>> PredictionRequest(byte[] bytes)
    {
        var client = new HttpClient();

        client.DefaultRequestHeaders.Add("Prediction-Key", "e4d7376d96d8471cba771af20e6d9110");

        string url =
            "https://cogniteveservices.cognitiveservices.azure.com/customvision/v3.0/Prediction/ca7461d2-c027-48e9-9c0c-af1722476469/classify/iterations/form-cc-classification/image";

        string tipo;
        List<double> probabilities = new List<double>();
        HttpResponseMessage responseMessage;

        using (var content = new ByteArrayContent(bytes))
        {
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            responseMessage = await client.PostAsync(url, content);
            tipo = await responseMessage.Content.ReadAsStringAsync();

            JObject jsonObject = JsonConvert.DeserializeObject<JObject>(tipo);


            if (jsonObject["predictions"] is JArray predictions)
            {
                foreach (JObject prediction in predictions.Children<JObject>())
                {
                    if (prediction.TryGetValue("probability", out JToken probabilityToken) &&
                        probabilityToken.Type == JTokenType.Float)
                    {
                        double probability = (double)probabilityToken;
                        probabilities.Add(probability);
                    }
                }
            }
        }

        return probabilities;
    }


    private string Base64(string path)
    {
        if (path.Contains("base64"))
        {
            int index = path.LastIndexOf("base64,");
            path.Substring(index + 7);
        }

        return path;
    }
}

/*
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
                    pessoa11.Telefone, pessoa11.Email, doc11.NrUtente, codClube, nomeAssociacao, nomeClube, modalidade,
                    "", categoria);
                return pessoaVisualizacao;
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
 */