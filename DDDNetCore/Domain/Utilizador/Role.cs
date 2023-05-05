using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Utilizador;

public class Role:IValueObject
{
    public int RoleId { get; set; }

    public Role(int role)
    {
        RoleId = validateRole(role);
    }

    public Role()
    {
        
    }


    public int validateRole(int role)
    {
        if (role >= 1 & role <= 5)
        {
            return role;
        }

        throw new BusinessRuleValidationException("Introduza uma 'Role' válida!");
    }
}