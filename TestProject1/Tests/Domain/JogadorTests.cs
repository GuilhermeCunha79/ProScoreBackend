using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Shared;
using Xunit;
using Assert = NUnit.Framework.Assert;

namespace TestProject1.Tests.Domain;

public class JogadorTests
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
        var jogador = new Jogador(estatuto, idPessoa,idEquipa);

       Assert.True(jogador.GetType() == new Jogador().GetType());
    }
    
    
}