using ConsoleApp1.Domain.Utilizador;
using ConsoleApp1.Infraestructure.DocumentoIdentificacao;
using ConsoleApp1.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Domain.DocumentoIdentificacao;

public class DocIdentificacaoService : IDocIdentificacaoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDocIdentificacaoRepository _repo;

    public DocIdentificacaoService(IUnitOfWork unitOfWork, IDocIdentificacaoRepository repo)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
    }

    public async Task<List<DocIdentificacaoDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<DocIdentificacaoDTO> listDto = list.ConvertAll(jogador =>
            new DocIdentificacaoDTO(jogador.Id.AsGuid(), jogador.NrIdentificacao.NumeroId.ToString(),
                jogador.LetrasDoc.LetrasDocumento,
                jogador.CheckDigit.CheckDig,
                jogador.ValidadeDoc.Data, jogador.Nif.NumIdFis, jogador.NrUtente.NumUtente,
                CheckStatus(jogador.Active)));

        return listDto;
    }

    public async Task<DocIdentificacaoDTO> GetByIdAsync(Identifier id)
    {
        var jogador = await _repo.GetByIdAsync(id);

        if (jogador == null)
            return null;

        return new DocIdentificacaoDTO(jogador.Id.AsGuid(), jogador.NrIdentificacao.NumeroId.ToString(),
            jogador.LetrasDoc.LetrasDocumento,
            jogador.CheckDigit.CheckDig,
            jogador.ValidadeDoc.Data, jogador.Nif.NumIdFis, jogador.NrUtente.NumUtente, CheckStatus(jogador.Active));
    }

    public Task<DocIdentificacaoDTO> GetByLicencaJogador(string licenca)
    {
        throw new NotImplementedException();
    }


    private string CheckStatus(bool status)
    {
        if (status)
        {
            return "Active";
        }
        else
        {
            return "Inactive";
        }
    }


    public async Task<DocIdentificacaoDTO> GetByNrId(string licenca)
    {
        var jogador = await _repo.GetByNrIdAsync(licenca);

        if (jogador == null)
            return null;

        return new DocIdentificacaoDTO(jogador.Id.AsGuid(), jogador.NrIdentificacao.NumeroId.ToString(),
            jogador.LetrasDoc.LetrasDocumento,
            jogador.CheckDigit.CheckDig,
            jogador.ValidadeDoc.Data, jogador.Nif.NumIdFis, jogador.NrUtente.NumUtente, CheckStatus(jogador.Active));
    }


    public async Task<DocIdentificacaoDTO> AddAsync(DocIdentificacaoDTO dto)
    {
        var jogador = new DocIdentificacao(dto.NrIdentificacao.ToString(), "1",
            dto.ValidadeDoc, dto.Nif);

        await _repo.AddAsync(jogador);

        await _unitOfWork.CommitAsync();

        return new DocIdentificacaoDTO(jogador.Id.AsGuid(), jogador.NrIdentificacao.NumeroId.ToString(),
            jogador.LetrasDoc.LetrasDocumento,
            jogador.CheckDigit.CheckDig,
            jogador.ValidadeDoc.Data, jogador.Nif.NumIdFis, jogador.NrUtente.NumUtente, CheckStatus(jogador.Active));
    }


    public async Task<DocIdentificacaoDTO> UpdateAsync(DocIdentificacaoDTO dto)
    {
        var jogador = await _repo.GetByIdAsync(new Identifier(dto.Id));

        if (jogador == null)
            return null;

        // change all fields

     


        await _unitOfWork.CommitAsync();

        return new DocIdentificacaoDTO(jogador.Id.AsGuid(), jogador.NrIdentificacao.NumeroId.ToString(),
            jogador.LetrasDoc.LetrasDocumento,
            jogador.CheckDigit.CheckDig,
            jogador.ValidadeDoc.Data, jogador.Nif.NumIdFis, jogador.NrUtente.NumUtente, "true");
    }
    
    
    public async Task<DocIdentificacaoDTO> UpdateByNrIdAsync(DocIdentificacaoDTO dto)
    {
        
        var jogador = await _repo.GetByIdAsync(new Identifier(dto.Id));

        if (jogador == null)
            return null;

        // change all fields

        
 /*       jogador.ChangeValidadeDoc(dto.ValidadeDoc);
        jogador.ChangeNumUtente(dto.NrUtente);
        jogador.ChangeNrIdentificacao(dto.NrIdentificacao);
        jogador.ChangeNif(dto.Nif);
        jogador.ChangeLetrasDoc(dto.LetrasDoc);
        jogador.ChangeCheckDigit(dto.CheckDigit);*/
 
 jogador.MarkAsAtive();

        await _unitOfWork.CommitAsync();

        return new DocIdentificacaoDTO( jogador.Id.AsGuid(),jogador.NrIdentificacao.NumeroId.ToString(),jogador.LetrasDoc.LetrasDocumento, jogador.CheckDigit.CheckDig,
            jogador.ValidadeDoc.Data,jogador.Nif.NumIdFis,jogador.NrUtente.NumUtente, CheckStatus(jogador.Active));  
    }
    

    public Task<DocIdentificacaoDTO> InactivateAsync(Identifier id)
    {
        throw new NotImplementedException();
    }

    public Task<DocIdentificacaoDTO> ActivateAsync(string id)
    {
        throw new NotImplementedException();
    }

    public Task<DocIdentificacaoDTO> DeleteAsync(Identifier id)
    {
        throw new NotImplementedException();
    }
}