using ConsoleApp1.Domain.Nacionalidade;
using ConsoleApp1.Domain.ProcessoInscricao;
using ConsoleApp1.Shared;

namespace ConsoleApp1.Domain.Pessoa;


public class PessoaService : IPessoaService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPessoaRepository _repo;
    private readonly INacionalidadeRepository _repo_nacionalidade;

    public PessoaService(IUnitOfWork unitOfWork, IPessoaRepository repo, INacionalidadeRepository repo1)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
        _repo_nacionalidade = repo1;
    }

    public async Task<List<PessoaDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<PessoaDTO> listDto = list.ConvertAll(jogador =>
            new PessoaDTO(jogador.Id.AsGuid(),jogador.IdentificadorPessoa.IdPessoa,jogador.Nome.Nomee,jogador.DataNascimento.DataNasc,jogador.TipoGenero.Genero,jogador.Email.Emaill,jogador.NrIdentificacao.NumeroId.ToString(),jogador.NascencaPais.PaisNascenca,jogador.NacionalidadePais.NacionalidadePaiss));

        return listDto;
    }

    public Task<PessoaDTO> GetByIdAsync(Identifier id)
    {
        throw new NotImplementedException();
    }


    public async Task<PessoaDTO> GetByIdPessoa(string licenca)
    {
        var jogador = await _repo.GetByIdPessoaAsync(licenca);

        if (jogador == null)
            return null;

        return new PessoaDTO(jogador.Id.AsGuid(),jogador.IdentificadorPessoa.IdPessoa,jogador.Nome.Nomee,jogador.DataNascimento.DataNasc,jogador.TipoGenero.Genero,
            jogador.Email.Emaill,jogador.NrIdentificacao.NumeroId.ToString(),jogador.NascencaPais.PaisNascenca,jogador.NacionalidadePais.NacionalidadePaiss);

    }



    public async Task<PessoaDTO> AddAsync(PessoaDTO dto)
    {
        NacionalidadePais result= await _repo_nacionalidade.GetByNomePaisAsync1(dto.NacionalidadePais); 
       
       
        
        var jogador = new Pessoa(dto.Nome,dto.DataNascimento,dto.TipoGenero,dto.Email,dto.NrIdentificacao,dto.NascencaPais,result.NacionalidadePaiss);

        await _repo.AddAsync(jogador);

        await _unitOfWork.CommitAsync();

        return new PessoaDTO(jogador.Id.AsGuid(), jogador.IdentificadorPessoa.IdPessoa,jogador.Nome.Nomee,jogador.DataNascimento.DataNasc,jogador.TipoGenero.Genero,
            jogador.Email.Emaill,jogador.NrIdentificacao.NumeroId.ToString(),jogador.NascencaPais.PaisNascenca,jogador.NacionalidadePais.NacionalidadePaiss);

    }

    public Task<PessoaDTO> UpdateAsync(PessoaDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<PessoaDTO> UpdateByIdPessoaAsync(PessoaDTO dto)
    {
        throw new NotImplementedException();
    }

    public Task<PessoaDTO> InactivateAsync(Identifier id)
    {
        throw new NotImplementedException();
    }

    public Task<PessoaDTO> ActivateAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<PessoaDTO> DeleteAsync(Identifier id)
    {
        throw new NotImplementedException();
    }
}