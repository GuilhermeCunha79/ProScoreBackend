
using System.Globalization;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Pais;

public class NomePais: IValueObject
{
    public string Nome { get; set; }

    public NomePais()
    {
        
    }
    public NomePais(string nomePais)
    {
        Nome = nomePais;

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
    
    public static List<string> carregaListaPaises()
    {
        //cria uma lista de paises
        List<string> CulturaLista = new List<string>();
        //Obtem a cultura especifica a partir da classe CultureInfo
        CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
        foreach (CultureInfo getCulture in getCultureInfo)
        {
            //cria um objeto da classe RegionInfo
            RegionInfo GetRegionInfo = new RegionInfo(getCulture.LCID);
            //Incluir cada nome de pais no arraylist
            if (!(CulturaLista.Contains(GetRegionInfo.DisplayName)))
            {
                CulturaLista.Add(GetRegionInfo.DisplayName);
            }
        }
        //ordena o array usando o método sort para obter os paises em ordem alfabética
        CulturaLista.Sort();
        //retorna a lista de paises
        return CulturaLista;
    }
}