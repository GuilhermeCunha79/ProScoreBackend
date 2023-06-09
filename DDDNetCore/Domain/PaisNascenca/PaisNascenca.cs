using System.Globalization;
using ConsoleApp1.Domain.CodigoPaises;
using ConsoleApp1.Domain.Pais;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.PaisNascenca;

public class PaisNascenca:Entity<Identifier>
{

    public PaisCodigo.PaisCodigo PaisCodigo { get; set; }
    public NomePais NomePais { get; set; }
    public CodPaises CodPaises{ get; set; }
    public NascencaPais NascencaPais { get; set; }

    public Pessoa.Pessoa Pessoa { get; set; }

    public PaisNascenca()
    {
        
    }

    public PaisNascenca(string pais,List<PaisNascenca> lista)
    {
        NascencaPais = new NascencaPais(FindMostSimilarCountry(pais,lista));
        NomePais = new NomePais(pais);
        CodPaises = new CodPaises(pais);
    }

    private string validatePais(string pais)
    {
        if (pais == null)
        {
            throw new BusinessRuleValidationException("Preencha o campo referente ao 'Pais de Nascença' ou 'Código'!");
        }
        return pais;
    }
    

    public string paisCod(string pais)
    {
        
        string twoLetterCode="";

        foreach (CultureInfo culture in CultureInfo.GetCultures(CultureTypes.AllCultures))
        {
            RegionInfo region;
           
                region = new RegionInfo(culture.Name);
                
            if (region.ThreeLetterISORegionName.Equals(pais, StringComparison.OrdinalIgnoreCase))
            {
                twoLetterCode = region.TwoLetterISORegionName;
                break;
            }
        }

        RegionInfo region1 = new RegionInfo(twoLetterCode);
        string countryName = region1.EnglishName;

        return countryName;

    }

    
    
    public static string FindMostSimilarCountry(string input, List<PaisNascenca> countries)
    {
        

        int minDistance = int.MaxValue;
        string mostSimilarCountry = "";

        foreach (PaisNascenca country in countries)
        {
            int distance = LevenshteinDistance(input, country.NomePais.Nome);
            if (distance < minDistance)
            {
                minDistance = distance;
                mostSimilarCountry = country.NomePais.Nome;
            }
        }
        return mostSimilarCountry;
    }

    public static int LevenshteinDistance(string s, string t)
    {
        int[,] d = new int[s.Length + 1, t.Length + 1];

        for (int i = 0; i <= s.Length; i++)
        {
            d[i, 0] = i;
        }

        for (int j = 0; j <= t.Length; j++)
        {
            d[0, j] = j;
        }

        for (int j = 1; j <= t.Length; j++)
        {
            for (int i = 1; i <= s.Length; i++)
            {
                int cost = (s[i - 1] == t[j - 1]) ? 0 : 1;
                d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
            }
        }

        return d[s.Length, t.Length];
    }
    
    
}