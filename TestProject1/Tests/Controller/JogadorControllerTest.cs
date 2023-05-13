using ConsoleApp1.Controller;
using ConsoleApp1.Domain.Jogador;
using Moq;
using Xunit;
using Xunit.Abstractions;

namespace TestProject1.Tests.Controller;

public class JogadorControllerTest
{
    
    private readonly ITestOutputHelper output;
    
    
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

        var controller = new JogadorController(jogadorServiceMock.Object);

        var actual = await controller.Create(deliveryDto);
       output.WriteLine(actual.ToString());

        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }
    
    [Fact]
    public async void GetByDeliveryIdentifier()
    {
        var deliveryServiceMock = new Mock<IJogadorService>();
        string licenca = "213";
        string estatuto = "Portugal";
        int idPessoa = 132;
        int idEquipa = 2342;
        string status = "Active";
        var delivery = new Jogador(estatuto, idPessoa,idEquipa);
        var deliveryDto = new JogadorDTO( delivery.Id.AsGuid(),delivery.Licenca.Lic,estatuto, idPessoa, idEquipa, status);
        
        deliveryServiceMock.Setup(_ => _.GetByLicencaJogador(licenca)).ReturnsAsync(deliveryDto);
        
        var controller = new JogadorController(deliveryServiceMock.Object);
        
        var actual = await controller.GetByLicencaJogador("213");

        Assert.Equal (deliveryDto, actual.Value);
    }
}