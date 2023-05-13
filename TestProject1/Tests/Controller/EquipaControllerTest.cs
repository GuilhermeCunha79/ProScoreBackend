using ConsoleApp1.Controller;
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.Jogador;
using Moq;
using Xunit;
using Xunit.Abstractions;
using Assert = NUnit.Framework.Assert;

namespace TestProject1.Tests.Controller;

public class EquipaControllerTest
{
    private readonly ITestOutputHelper output;


    public EquipaControllerTest(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Fact]
    public async void Create()
    {
        var jogadorServiceMock = new Mock<IEquipaService>();
        string licenca = "2";
        string estatuto = "Portugal";
        int idPessoa = 132;
        int idEquipa = 2342;
        string status = "Active";
        var delivery = new Equipa(estatuto, idPessoa,status,status,status);

        var deliveryDto = new EquipaDTO( Guid.NewGuid(),idEquipa,estatuto, idPessoa,status,status,status);

        jogadorServiceMock.Setup(_ => _.GetByIdAsync(delivery.Id)).ReturnsAsync(deliveryDto);
        jogadorServiceMock.Setup(_ => _.AddAsync(deliveryDto)).ReturnsAsync(deliveryDto);

        var controller = new EquipaController(jogadorServiceMock.Object);

        var actual = await controller.Create(deliveryDto);
        output.WriteLine(actual.ToString());

        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
    }

    [Fact]
    public async void GetByDeliveryIdentifier()
    {
        var deliveryServiceMock = new Mock<IEquipaService>();
        string licenca = "213";
        string estatuto = "Portugal";
        int idPessoa = 132;
        int idEquipa = 2342;
        string status = "Active";
        var delivery = new Equipa(estatuto, idPessoa,status,status,status);

        var deliveryDto = new EquipaDTO( Guid.NewGuid(),idEquipa,estatuto, idPessoa,status,status,status);

        deliveryServiceMock.Setup(_ => _.GetByIdentificadorEquipa(licenca)).ReturnsAsync(deliveryDto);

        var controller = new EquipaController(deliveryServiceMock.Object);

        var actual = await controller.GetByLicencaJogador("213");

        Assert.Equals(deliveryDto, actual.Value);
    }
}