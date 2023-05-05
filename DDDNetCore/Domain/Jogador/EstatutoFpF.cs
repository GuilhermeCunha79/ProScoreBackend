namespace ConsoleApp1.Domain.Jogador;

public class EstatutoFpF
{
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
            "Alemanha", "Áustria", "Bélgica", "Bulgária", "Chipre", "Croácia", "Dinamarca", "Eslováquia", "Eslovênia",
            "Espanha", "Estônia", "Finlândia", "França", "Grécia", "Holanda", "Hungria", "Irlanda", "Itália", "Letônia",
            "Lituânia", "Luxemburgo", "Malta", "Polônia", "República Tcheca", "Romênia", "Suécia", "Portugal"
        };
        

        foreach (var t in paisesUe)
        {
            if (pais.ToUpper().Equals(t.ToUpper()))
            {
                return "União Europeia";
            }
        }

        return pais.ToUpper().Equals("PORTUGUÊS") ? "Português" : "Estrangeiro";
    }

    public override string ToString()
    {
        return Estatuto;
    }
}