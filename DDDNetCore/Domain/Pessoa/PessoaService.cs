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
            new PessoaDTO(jogador.Id.AsGuid(), jogador.IdentificadorPessoa.IdPessoa, jogador.Nome.Nomee,
                jogador.DataNascimento.DataNasc, jogador.TipoGenero.Genero,
                jogador.Email.Emaill, jogador.NrIdentificacao.NumeroId.ToString(), jogador.NascencaPais.PaisNascenca,
                jogador.NacionalidadePais.NacionalidadePaiss, CheckStatus(jogador.Active), jogador.Telefone.Telemovel,
                jogador.ConcelhoResidência.Concelho));

        return listDto;
    }

    private string CheckStatus(bool status)
    {
        if (status)
        {
            return "Active";
        }

        return "Inactive";
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

        return new PessoaDTO(jogador.Id.AsGuid(), jogador.IdentificadorPessoa.IdPessoa, jogador.Nome.Nomee,
            jogador.DataNascimento.DataNasc, jogador.TipoGenero.Genero,
            jogador.Email.Emaill, jogador.NrIdentificacao.NumeroId.ToString(), jogador.NascencaPais.PaisNascenca,
            jogador.NacionalidadePais.NacionalidadePaiss, CheckStatus(jogador.Active), jogador.Telefone.Telemovel,
            jogador.ConcelhoResidência.Concelho);
    }


    public async Task<PessoaDTO> GetByNrId(string licenca)
    {
        var jogador = await _repo.GetByNrIdentificacaoAsync(licenca);

        if (jogador == null)
            return null;

        return new PessoaDTO(jogador.Id.AsGuid(), jogador.IdentificadorPessoa.IdPessoa, jogador.Nome.Nomee,
            jogador.DataNascimento.DataNasc, jogador.TipoGenero.Genero,
            jogador.Email.Emaill, jogador.NrIdentificacao.NumeroId.ToString(), jogador.NascencaPais.PaisNascenca,
            jogador.NacionalidadePais.NacionalidadePaiss, CheckStatus(jogador.Active), jogador.Telefone.Telemovel,
            jogador.ConcelhoResidência.Concelho);
    }


    public async Task<PessoaDTO> AddAsync(PessoaDTO dto)
    {
        //NacionalidadePais result= await _repo_nacionalidade.GetByNomePaisAsync1(new NacionalidadePais(dto.NacionalidadePais).NacionalidadePaiss); 


        var jogador = new Pessoa(dto.Nome, dto.IdentificadorPessoa, dto.DataNascimento,dto.Telefone, dto.Email,dto.ConcelhoResidencia,dto.TipoGenero,
            dto.NrIdentificacao, dto.NascencaPais, new NacionalidadePais(dto.NacionalidadePais).NacionalidadePaiss);

        await _repo.AddAsync(jogador);

        await _unitOfWork.CommitAsync();

        return new PessoaDTO(jogador.Id.AsGuid(), jogador.IdentificadorPessoa.IdPessoa, jogador.Nome.Nomee,
            jogador.DataNascimento.DataNasc, jogador.TipoGenero.Genero,
            jogador.Email.Emaill, jogador.NrIdentificacao.NumeroId.ToString(), jogador.NascencaPais.PaisNascenca,
            jogador.NacionalidadePais.NacionalidadePaiss, "false", "--------", "---------");
    }

    public async Task<PessoaDTO> UpdateAsync(PessoaDTO dto)
    {
        var jogador = await _repo.GetByIdAsync(new Identifier(dto.Id));

        if (jogador == null)
            return null;

        // change all fields


        await _unitOfWork.CommitAsync();

        return new PessoaDTO(jogador.Id.AsGuid(), jogador.IdentificadorPessoa.IdPessoa, jogador.Nome.Nomee,
            jogador.DataNascimento.DataNasc, jogador.TipoGenero.Genero,
            jogador.Email.Emaill, jogador.NrIdentificacao.NumeroId.ToString(), jogador.NascencaPais.PaisNascenca,
            jogador.NacionalidadePais.NacionalidadePaiss, "true", jogador.Telefone.Telemovel,
            jogador.ConcelhoResidência.Concelho);
    }

    public async Task<PessoaDTO> UpdateByIdPessoaAsync(PessoaDTO dto)
    {
        var jogador = await _repo.GetByIdAsync(new Identifier(dto.Id));

        if (jogador == null)
            return null;

        // change all fields


        /*jogador.ChangeEmail(dto.Email);
        jogador.ChangeConcelhoResidencia(dto.ConcelhoResidencia);
        jogador.ChangeNome(dto.Nome);
        jogador.ChangeTelefone(dto.Telefone);
        jogador.ChangeDataNascimento(dto.DataNascimento);*/
        jogador.MarkAsAtive();

        await _unitOfWork.CommitAsync();

        return new PessoaDTO(jogador.Id.AsGuid(), jogador.IdentificadorPessoa.IdPessoa,
            jogador.Nome.Nomee, jogador.DataNascimento.DataNasc,
            jogador.TipoGenero.Genero, jogador.Email.Emaill, jogador.NrIdentificacao.NumeroId.ToString(),
            jogador.NascencaPais.PaisNascenca, jogador.Nacionalidade.NacionalidadePais.NacionalidadePaiss,
            CheckStatus(jogador.Active), jogador.Telefone.Telemovel, jogador.ConcelhoResidência.Concelho);
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