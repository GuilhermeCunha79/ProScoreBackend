using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Associacao;

public class Acronimo: IValueObject
{

    public string Acronimoo { get; set; }

    public Acronimo(string acronimoo)
    {
        Acronimoo = acronimoo;
    }

}