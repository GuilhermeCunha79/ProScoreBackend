using ConsoleApp1.Controller;
using ConsoleApp1.Domain.Forms;
using Moq;
using Xunit;

namespace TestProject1.Tests.Controller;

public class JogadorControllerTest
{
    [Fact]
    public async void Create()
    {
        var deliveryServiceMock = new Mock<IJogadorService>();
        string licenca = "2";
        string estatuto = "Portugal";
        string idPessoa = "132";
        string idEquipa = "2342";
        string status = "Active";
        var delivery = new Jogador(licenca,estatuto,idPessoa);
        var deliveryDto = new JogadorDTO(delivery.Id.AsGuid(), estatuto, licenca, idPessoa, idEquipa, status);

        deliveryServiceMock.Setup (_ => _.GetByIdAsync (delivery.Id)).ReturnsAsync (deliveryDto);
        deliveryServiceMock.Setup (_ => _.AddAsync (deliveryDto)).ReturnsAsync (deliveryDto);

           
        var controller = new JogadorController(deliveryServiceMock.Object);

        var actual = await controller.Create(deliveryDto);

        Assert.NotNull(actual);
        Assert.NotNull(actual.Result);
        
    }
}