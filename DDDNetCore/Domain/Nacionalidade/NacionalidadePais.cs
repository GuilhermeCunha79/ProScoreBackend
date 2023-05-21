using System.Globalization;
using ConsoleApp1.Infraestructure.Nacionalidade;
using ConsoleApp1.Shared;
using Microsoft.Data.SqlClient;

namespace ConsoleApp1.Domain.Nacionalidade;

public class NacionalidadePais:IValueObject
{
    private NacionalidadeService ola;
    public string NacionalidadePaiss { get; set; }

    public NacionalidadePais()
    {
    }

    public NacionalidadePais(string pais)
    {
        NacionalidadePaiss = SharedMethods.onlyLettersAndSpace(pais);
    }

    
}