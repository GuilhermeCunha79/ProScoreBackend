using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Jogador;

public class EstatutoFpF:IValueObject
{
    public Jogador Jogador { get; set; }
    public string Estatuto { get; set; }

    public EstatutoFpF()
    {
        
    }
    public EstatutoFpF(string pais)
    {
        Estatuto = validateEstatutoFpF(pais);
    }


    private string validateEstatutoFpF(string pais)
    {
        
        string[] paisesUe =
        {
            "Alemã", "Austríaca", "Belga", "Búlgara", "Cipriota", "Croata", "Dinamarquesa", "Eslovaca", "Eslovena", "Espanhola", "Estoniana", "Finlandesa", "Francesa", "Grega", "Holandesa", "Húngara", "Irlandesa", "Italiana", "Letã", "Lituana", "Luxemburguesa", "Maltesa", "Polonesa", "Tcheca", "Romena", "Sueca"
        };
        

        foreach (var t in paisesUe)
        {
            if (pais.ToUpper().Equals(t.ToUpper()))
            {
                return "União Europeia";
            }
        }

        return pais.ToUpper().Equals("PORTUGUESA") ? "Português" : "Estrangeiro";
    }

    public override string ToString()
    {
        return Estatuto;
    }
}