using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Infraestructure.Shared;
using ConsoleApp1.Shared;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1.Infraestructure.Jogador;

public class JogadorRepository : BaseRepository<Domain.Jogador.Jogador, Identifier>, IJogadorRepository
{
    private readonly DDDSample1DbContext _context;
        
    public JogadorRepository(DDDSample1DbContext context) : base(context.Jogadores)
    {
        _context = context;
    }
        
    public async Task<Domain.Jogador.Jogador> GetByLicencaAsync(string licenca)
    {
        return await _context.Jogadores.Where(x => licenca.Equals(x.Licenca.Lic)).FirstOrDefaultAsync();

    }

    public Task<List<JogadorDTO>> GetByIdsAsync(List<Licenca> ids)
    {
        throw new System.NotImplementedException();
    }

    public Task<JogadorDTO> AddAsync(JogadorDTO obj)
    {
        throw new System.NotImplementedException();
    }
}