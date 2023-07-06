using ConsoleApp1.Controller;
using ConsoleApp1.Domain.Associacao;
using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Domain.DocumentoIdentificacao;
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Domain.Pessoa;
using ConsoleApp1.Infraestructure;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace TestProject1.Tests.Controller;

public class JogadorControllerTest
{
    private readonly DDDSample1DbContext _context;
    private readonly ITestOutputHelper output;
    private readonly IPessoaService _service_pessoa;
    
    public JogadorControllerTest(ITestOutputHelper output)
    {
        this.output = output;
    }
    
    [Fact]
    public async void Create()
    {
        var jogadorServiceMock = new Mock<IJogadorService>();
        int licenca = 2;
        string estatuto = "Portugal";
        int idPessoa = 132;
        int idEquipa = 2342;
        string status = "Active";
        var delivery = new Jogador(estatuto, idPessoa,idEquipa);
        var deliveryDto = new JogadorDTO( delivery.Id.AsGuid(),licenca,estatuto,  idPessoa, idEquipa, status);

        jogadorServiceMock.Setup(_ => _.GetByIdAsync(delivery.Id)).ReturnsAsync(deliveryDto);
        jogadorServiceMock.Setup(_ => _.AddAsync(deliveryDto)).ReturnsAsync(deliveryDto);

        var controller = new JogadorController(jogadorServiceMock.Object,new Mock<IPessoaService>().Object);

        var actual = await controller.Create(deliveryDto);
       output.WriteLine(actual.ToString());

        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }
    
    [Fact]
    public async void GetJogadorByLicenca()
    {
        var jogadorServiceMock = new Mock<IJogadorService>();
        var associacaoServiceMock = new Mock<IAssociacaoService>();
        var clubeServiceMock = new Mock<IClubeService>();
        var equipaServiceMock = new Mock<IEquipaService>();
        var docIdServiceMock = new Mock<IDocIdentificacaoService>();
        var pessoaServiceMock = new Mock<IPessoaService>();
        
        string licenca = "1";
        string estatuto = "Portugal";
        string status = "Active";

        string nomeAssociacao = "Associação de Futebol de Beja";
        string nomeCurto = "Ass. Futebol de Beja";
        string acronimo = "AFB";

        string nomeClube = "Sport Clube Olivas";
        string nifClube = "257980098";
        string morada = "Rua das Flores";
        string telefone = "910677945";
        int numEquipas = 0;
        
        int idEquipa = 1;
        string divisao = "1 Liga";
        string categoria = "Sénior";
        string modalidade = "Futebol";
        string genero = "Masculino";

        string nomePessoa = "Luís";
        int idPessoa = 1;
        string email = "email@email.pt";
        string dataNascimento = "23/12/2002";
        string telefonePessoa = "910499845";
        string concelho = "Rua das Flores";
        string generoPessoa = "Masculino";
        string paisNascenca = "Portugal";
        string nacionalidade = "Portuguesa";

        string nrId = "13456789";
        string checkDigit = "1";
        string validade = "20/12/2025";
        string nif = "233455678";

        
        var associacao = new Associacao(nomeAssociacao,nomeCurto,acronimo);
        var clube = new Clube(associacao.NomeAssociacao.NomeAss,nomeClube,nifClube,morada,telefone,numEquipas);
        var equipa = new Equipa(idEquipa,divisao,clube.CodigoClube.CodClube,categoria,modalidade,genero);
        var docId = new DocIdentificacao(nrId,checkDigit,validade,nif);
        var pessoa = new Pessoa(nomePessoa,idPessoa,dataNascimento,telefone,email,concelho,genero,
            docId.NrIdentificacao.NumeroId.ToString(), paisNascenca,nacionalidade);
        var jogador = new Jogador(estatuto, pessoa.IdentificadorPessoa.IdPessoa,equipa.IdentificadorEquipa.IdEquipa);
        
        associacaoServiceMock.Setup(_ => _.AddAsync(AssociacaoMapper.toDto(associacao)))
            .ReturnsAsync(AssociacaoMapper.toDto(associacao));
        clubeServiceMock.Setup(_ => _.AddAsync(ClubeMapper.toDto(clube)))
            .ReturnsAsync(ClubeMapper.toDto(clube));
        equipaServiceMock.Setup(_ => _.AddAsync(EquipaMapper.toDto(equipa)))
            .ReturnsAsync(EquipaMapper.toDto(equipa));
        docIdServiceMock.Setup(_ => _.AddAsync(DocumentoIdentificacaoMapper.toDto(docId)))
            .ReturnsAsync(DocumentoIdentificacaoMapper.toDto(docId));
        pessoaServiceMock.Setup(_ => _.AddAsync(PessoaMapper.toDto(pessoa)))
            .ReturnsAsync(PessoaMapper.toDto(pessoa));

        jogadorServiceMock.Setup(_ => _.AddAsync(JogadorMapper.toDto(jogador)))
            .ReturnsAsync(JogadorMapper.toDto(jogador));
        jogadorServiceMock.Setup(_ => _.GetByLicencaJogador(licenca)).ReturnsAsync(JogadorMapper.toDto(jogador));
        
        var controller = new JogadorController(jogadorServiceMock.Object,pessoaServiceMock.Object);
        
        var actual = await controller.GetByLicencaJog("1");
        
        Assert.Equal (JogadorMapper.toDto(jogador).ToString(), actual.Value.ToString());
    }
}