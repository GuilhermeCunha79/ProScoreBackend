using ConsoleApp1.Controller;
using ConsoleApp1.Domain.Associacao;
using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Domain.DocumentoIdentificacao;
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Domain.Pessoa;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace TestProject1.Tests.Controller;

public class ClubeControllerTest
{
    
    private readonly ITestOutputHelper output;
    public ClubeControllerTest(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public async void GetByJogadorByLicenca()
    {
        var associacaoServiceMock = new Mock<IAssociacaoService>();
        var clubeServiceMock = new Mock<IClubeService>();

        string licenca = "1";
        string nomeAssociacao = "Associação de Futebol de Beja";
        string nomeCurto = "Ass. Futebol de Beja";
        string acronimo = "AFB";
        string nomeClube = "Sport Clube Olivas";
        string nifClube = "257980098";
        string morada = "Rua das Flores";
        string telefone = "910677945";
        int numEquipas = 0;
        
        var associacao = new Associacao(nomeAssociacao, nomeCurto, acronimo);
        var clube = new Clube(associacao.NomeAssociacao.NomeAss, nomeClube, nifClube, morada, telefone, numEquipas);

        associacaoServiceMock.Setup(_ => _.AddAsync(AssociacaoMapper.toDto(associacao)))
            .ReturnsAsync(AssociacaoMapper.toDto(associacao));
        clubeServiceMock.Setup(_ => _.AddAsync(ClubeMapper.toDto(clube)))
            .ReturnsAsync(ClubeMapper.toDto(clube));
        clubeServiceMock.Setup(_ => _.GetByCodClube(licenca)).ReturnsAsync(ClubeMapper.toDto(clube));

        var controller = new ClubeController(clubeServiceMock.Object);
        var actual = await controller.GetByCodClube("1");

        Assert.Equal(ClubeMapper.toDto(clube).ToString(), actual.Value.ToString());
    }
}

