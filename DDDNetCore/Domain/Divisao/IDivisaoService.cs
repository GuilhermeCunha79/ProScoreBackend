namespace ConsoleApp1.Domain.Divisao;


public interface IDivisaoService
{

    Task<List<DivisaoDTO>> GetAllAsync();
}