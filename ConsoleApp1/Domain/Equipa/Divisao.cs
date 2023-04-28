using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Equipa;

public class Divisao: IValueObject
{
    public string Div { get; set; }

    public Divisao(string divisao)
    {
        Div = divisao;
    }
}