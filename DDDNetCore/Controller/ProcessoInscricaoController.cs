using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using ConsoleApp1.Domain.DocumentoIdentificacao;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Domain.PaisNascenca;
using ConsoleApp1.Domain.Pessoa;
using ConsoleApp1.Domain.ProcessoInscricao;
using ConsoleApp1.Infraestructure;
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
    private readonly IDocIdentificacaoService _service_doc;
    private readonly IPessoaService _service_pessoa;
    private readonly IJogadorService _service_jogador;
    private readonly DDDSample1DbContext DDDSample1DbContext;


    public ProcessoInscricaoController(DDDSample1DbContext context,IProcessoInscricaoService service,IDocIdentificacaoService service1,IPessoaService service3,IJogadorService service4)
    {
        _service = service;
        _service_doc = service1;
        _service_pessoa = service3;
        _service_jogador = service4;
        DDDSample1DbContext = context;
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

    [HttpPost]
    public async Task<(CreatedAtActionResult, DocIdentificacaoDTO, PessoaDTO, JogadorDTO)> Create()
    {
        string endpoint = "https://cogniteveservices.cognitiveservices.azure.com/";
        string apiKey = "e4d7376d96d8471cba771af20e6d9110";
        var credential = new AzureKeyCredential(apiKey);
        var client = new DocumentAnalysisClient(new Uri(endpoint), credential);
        string caminhoBoletim =
            "C:/Users/Guilherme Cunha/Downloads/225075521-b30eb6e6-7b70-4106-9e53-c1cecb10a04e.jpeg";
        //BOLETIM

        string modelIdBoletim = "ef1da940-cf12-4858-a4e3-c3d01c222a3e";
        using var stream = new FileStream(caminhoBoletim, FileMode.Open);
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
        string epocaDesportiva = "";
        string genero = "";
        string email = "";
        string nascencaPais = "";
        string nacionalidade = "";


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
            epocaDesportiva = document.Fields["epocaDesportiva"].Content;

            //EMAIL
            email = document.Fields["email"].Content;

            nascencaPais = document.Fields["paisNascenca"].Content;


        }

        string caminhoDoc = "C:/Users/Guilherme Cunha/Downloads/Doc8.pdf";
        string modelIdDocId = "85776a2b-f2cc-4cb0-9306-a186768d20a4";
        using var stream1 = new FileStream(caminhoDoc, FileMode.Open);
        AnalyzeDocumentOperation operation1 =
            await client.AnalyzeDocumentAsync(WaitUntil.Completed, modelIdDocId, stream1);
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
        stream1.Close();

        var processo = new ProcessoInscricaoDTO(Guid.NewGuid(), tipoProcesso, epocaDesportiva);

        var docId = new DocIdentificacaoDTO(Guid.NewGuid(), nrId, letrasCheckDocId, SharedMethods.onlyLettersAndNumbers(letrasCheckDocId),
            validade, nif, nrUtente, CheckStatus(true));

        var pessoa = new PessoaDTO(Guid.NewGuid(), DDDSample1DbContext.ObterNumeroDePessoas(), String.Concat(nome1, nome2),
            dataNascimento,
            genero, email, docId.NrIdentificacao, nascencaPais, nacionalidade);

        var jogador1 = new JogadorDTO(Guid.NewGuid(), nacionalidade, pessoa.IdentificadorPessoa, 1,
            "true");


        var processo1 = await _service.AddAsync(processo);
        var doc1 = await _service_doc.AddAsync(docId);
        var pessoa1 = await _service_pessoa.AddAsync(pessoa);
        var jogador11 = await _service_jogador.AddAsync(jogador1);


        return (CreatedAtAction(nameof(GetById), new { id = processo1.Id }, processo1), doc1, pessoa1, jogador11);
    }


    private string CheckStatus(bool status)
    {
        if (status)
        {
            return "Active";
        }

        return "Inactive";
    }
}