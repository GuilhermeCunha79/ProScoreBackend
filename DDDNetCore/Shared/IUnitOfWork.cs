namespace ConsoleApp1.Shared;

public interface IUnitOfWork
{
    
        Task<int> CommitAsync();
    
}