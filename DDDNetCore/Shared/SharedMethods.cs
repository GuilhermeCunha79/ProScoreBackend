using ConsoleApp1.Infraestructure;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Shared;

public class SharedMethods
{
    
    
    public static string onlyNumbersAndSeparator(string epoca)
    {
        
        string textTrim = epoca.Trim();
        string final = "";
        string integerString = string.Empty;

        foreach(Char c in textTrim)
        {
            if ( Char.IsDigit(c) | c.Equals('/') )
            {
                integerString += c;
            }
            else if (integerString.Length >0)
            {
              
                final+=integerString;
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

        foreach(char c in textTrim)
        {
            if (char.IsDigit(c) )
            {
                integerString += c;
            }
            else if (integerString.Length >0)
            {
              
                final+=integerString;
                integerString = "";
                
            }
        }

        return int.Parse(final);
    }
    
    public static string onlyLetters(string epoca)
    {
        
        string textTrim = epoca.Trim();
        string final = "";
        string integerString = string.Empty;

        foreach(char c in textTrim)
        {
            if (char.IsLetter(c) )
            {
                integerString += c;
            }
            else if (integerString.Length >0)
            {
              
                final+=integerString;
                integerString = "";
                
            }
        }

        return final;
    }
    
    public static string onlyLettersAndSpace(string epoca)
    {
        
        string textTrim = epoca.Trim();
        string final = "";
        string integerString = string.Empty;

        foreach(char c in textTrim)
        {
            if (char.IsLetter(c) | char.IsWhiteSpace(c) )
            {
                integerString += c;
            }
            else if (integerString.Length >0)
            {
              
                final+=integerString;
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