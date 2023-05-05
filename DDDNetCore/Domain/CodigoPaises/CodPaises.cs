using System.Globalization;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.CodigoPaises;

public class CodPaises:IValueObject
{

    public string CodigoPais { get; set; }

    public CodPaises()
    {
        
    }
    public CodPaises(string nome)
    {
        CodigoPais = validateCodPais(nome);
    }
    
    public string validateCodPais(string codPais)
    {
        ResourceHelper.ChangeLanguage("en");
        string n= SharedMethods.onlyLetters(ResourceHelper.GetString(codPais));

        var regions = CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.LCID));
        var englishRegion = regions.FirstOrDefault(region => region.EnglishName.Contains(n));
        var countryAbbrev = englishRegion?.ThreeLetterISORegionName;
        return countryAbbrev ?? throw new BusinessRuleValidationException("Verifique o 'Código/País' introduzido!");
    }

}