using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Nacionalidade;

public class NacionalidadePais
{
    public string NacionalidadePaiss  { get; set; }

    public NacionalidadePais()
    {
        
    }
    public NacionalidadePais(string pais)
    {
        NacionalidadePaiss = validateNacao(pais);
    }
    
    private string validateNacao(string nacao)
    {
        if (nacao == null)
        {
            throw new BusinessRuleValidationException("Preencha o campo referente à 'Nacionalidade'!");
        }

        return SharedMethods.onlyLettersAndSpace(nacao);
    }
}