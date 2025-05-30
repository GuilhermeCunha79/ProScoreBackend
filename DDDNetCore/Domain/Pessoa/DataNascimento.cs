﻿using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Pessoa;

public class DataNascimento : IValueObject
{
    public string DataNasc { get; set; }
    

    public DataNascimento()
    {
        DataNasc = "xxxxxxx";
    }
    
    public DataNascimento(string data)
    {
        DataNasc=String.Concat(GetDay(validateValidadeDoc(data)),'/',GetMonth(validateValidadeDoc(data)),'/',GetYear(validateValidadeDoc(data)));
    }

    private string validateValidadeDoc(string data)
    {
        if (data == null)
        {
            throw new BusinessRuleValidationException("Preencha o campo relativo à 'Validade do Documento de Identificação'!");
        }

        return data;
    }

    private int GetDay(string date)
    {
        return SharedMethods.onlyNumbers(date.Substring(0 , 2));
    }
   
    private int GetYear(string date)
    {
        return SharedMethods.onlyNumbers(date.Substring(date.Length - 4, 4));
    }
   
    private int GetMonth(string date)
    {
        return SharedMethods.onlyNumbers(date.Substring(date.Length - 7, 2));
    }

    public override string ToString()
    {
        return DataNasc;
    }
}