using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using Azure.AI.FormRecognizer.Models;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Infraestructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Shared;

public class SharedMethods
{


    public static string onlyNumbersAndSeparator(string epoca)
    {

        string textTrim = epoca.Trim();
        string final = "";
        string integerString = string.Empty;

        foreach (Char c in textTrim)
        {
            if (Char.IsDigit(c) | c.Equals('/'))
            {
                integerString += c;
            }
            else if (integerString.Length > 0)
            {

                final += integerString;
                integerString = "";

            }
        }

        return final;
    }

    public static int onlyNumbers(string epoca)
    {

        string textTrim = epoca.Trim();
        string final = "";
        string integerString = string.Empty;

        foreach (char c in textTrim)
        {
            if (char.IsNumber(c))
            {
                integerString += c;
            }
            else if (integerString.Length > 0)
            {
                
                integerString = "";

            }
        }

        return Int32.Parse(integerString);
    }

    public static string onlyLetters(string epoca)
    {

        string textTrim = epoca.Trim();
        string final = "";
        string integerString = string.Empty;

        foreach (char c in textTrim)
        {
            if (char.IsLetter(c))
            {
                integerString += c;
            }
            else if (integerString.Length > 0)
            {

                final += integerString;
                integerString = "";

            }
        }

        return final+integerString;
    }

    public static string onlyLettersAndNumbers(string epoca)
    {

        string textTrim = epoca.Trim();
        string final = "";
        string integerString = string.Empty;

        foreach (char c in textTrim)
        {
            if (char.IsLetter(c) | char.IsNumber(c))
            {
                integerString += c;
            }
            else if (integerString.Length > 0)
            {

                final += integerString;
                integerString = "";

            }
        }

        return final+integerString;
    }

    public static string onlyLettersAndSpace(string epoca)
    {

        string textTrim = epoca.Trim();
        string final = "";
        string integerString = string.Empty;

        foreach (char c in textTrim)
        {
            if (char.IsLetter(c) | char.IsWhiteSpace(c))
            {
                integerString += c;
            }
            else if (integerString.Length > 0)
            {

                final += integerString;
                integerString = "";

            }
        }

        return final;
    }

    public static DbContextOptions<DDDSample1DbContext> connection()
    {
        return new DbContextOptionsBuilder<DDDSample1DbContext>()
            .UseSqlServer("DefaultConnection")
            .Options;
    }

    
}