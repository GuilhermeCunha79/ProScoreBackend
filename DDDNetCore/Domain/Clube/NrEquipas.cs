﻿using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Clube;

public class NrEquipas: IValueObject
{
    public int NumeroEquipas { get; set; }

    public NrEquipas(int nr)
    {

            NumeroEquipas =nr;
        
    }

    public override string ToString()
    {
        return NumeroEquipas.ToString();
    }
}