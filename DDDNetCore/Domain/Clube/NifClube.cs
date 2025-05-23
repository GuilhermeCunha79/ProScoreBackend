﻿using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Clube;

public class NifClube: IValueObject
{
    public int ClubeNif { get; set; }

    public NifClube()
    {
        
    }

    public NifClube(string nif)
    {
        ClubeNif = validateNif(nif);
    }

    public int validateNif(string nif)
    {
       
        if (nif == null)
        {
            throw new BusinessRuleValidationException("Insira o 'NIF' do clube que pretende inscrever!");
        }

     /*   if (SharedMethods.onlyNumbers(nif).ToString().Length != 9)
        {
            throw new BusinessRuleValidationException("O 'NIF' do Clube deve ter exatamente 9 digitos númericos!");
        }*/

        return SharedMethods.onlyNumbers(nif);
    }

    public override string ToString()
    {
        return ClubeNif.ToString();
    }
}