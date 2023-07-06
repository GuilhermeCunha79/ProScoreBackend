using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.Jogador;
using Xunit;

namespace TestProject1.Tests.Domain;

public class EquipaTest
{
    [Fact]
    public void ValidDelivery()
    {
        string licenca = "2";
        string estatuto = "Portugal";
        int idPessoa = 132;
        int idEquipa = 2342;
        string status = "Active";
        string licenca1 = "2";
        string estatuto1 = "Portugal";
        string idPessoa1= "132";
        string idEquipa1 = "2342";
        string status1 = "Active";
     //   var delivery = new Equipa(estatuto, idPessoa,status,status,status);

    //     Assert.True(delivery.GetType() == new Equipa().GetType());
      //  Assert.True(delivery.GetType() == new Equipa().GetType());
    }
    
    
}