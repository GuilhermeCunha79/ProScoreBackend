using Azure;
using Azure.AI.FormRecognizer.DocumentAnalysis;
using ConsoleApp1.Domain.Clube;
using ConsoleApp1.Domain.Equipa;
using ConsoleApp1.Domain.InscricaoProvisoriaClubeJogador;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Domain.Pessoa;
using ConsoleApp1.Domain.VisualizacaoJogador;
using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Domain.ProcessoInscricao;

public class ProcessoInscricaoService : IProcessoInscricaoService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IProcessoInscricaoRepository _repo;
    private readonly DDDSample1DbContext _context;
    private readonly IPessoaRepository _repo_pessoa;
    private readonly IJogadorRepository _repo_jogador;
    private readonly IInscricaoProvisoriaClubeJogadorRepository _repo_clube_jogador;
    private readonly IClubeRepository _repo_clube;
    private readonly IEquipaRepository _repo_equipa;

    public ProcessoInscricaoService(IUnitOfWork unitOfWork, IProcessoInscricaoRepository repo,
        DDDSample1DbContext _context1, IPessoaRepository _repo_pessoa1, IJogadorRepository _repo_jogador1,
        IInscricaoProvisoriaClubeJogadorRepository _repo_clube_jogador1, IClubeRepository _repo_clube1,IEquipaRepository _repo_equipa1,DDDSample1DbContext _ddd1)
    {
        _unitOfWork = unitOfWork;
        _repo = repo;
        _context = _context1;
        _repo_pessoa = _repo_pessoa1;
        _repo_jogador = _repo_jogador1;
        _repo_clube_jogador = _repo_clube_jogador1;
        _repo_clube = _repo_clube1;
        _repo_equipa = _repo_equipa1;
    }

    public async Task<List<ProcessoInscricaoDTO>> GetAllAsync()
    {
        var list = await _repo.GetAllAsync();

        List<ProcessoInscricaoDTO> listDto = list.ConvertAll(jogador =>
            new ProcessoInscricaoDTO(jogador.Id.AsGuid(), jogador.CodOperacao.CodOpe.ToString(), jogador.Estado.Status,
                jogador.DataRegisto.DataReg, jogador.DataSubscricao.DataSubs, jogador.TipoProcesso.ProcessoTipo,
                jogador.EpocaDesportiva.EpocaDesp));

        return listDto;
    }

    public async Task<List<ProcessoJogadorVisualizacaoDTO>> GetAllAsync1()
    {
        var list = await _repo.GetProcessosPendentesAsync();

        List<ProcessoInscricaoDTO> listDto = list.ConvertAll(jogador =>
            new ProcessoInscricaoDTO(jogador.Id.AsGuid(), jogador.CodOperacao.CodOpe.ToString(), jogador.Estado.Status,
                jogador.DataRegisto.DataReg, jogador.DataSubscricao.DataSubs, jogador.TipoProcesso.ProcessoTipo,
                jogador.EpocaDesportiva.EpocaDesp));

        List<ProcessoJogadorVisualizacaoDTO> listFinal= new List<ProcessoJogadorVisualizacaoDTO>();
        foreach (ProcessoInscricaoDTO dto in listDto)
        {
            if (!dto.TipoProcesso.Contains("Equipa"))
            {
                InscricaoProvisoriaClubeJogadorDTO clubeJogadorDto =
                    InscricaoProvisoriaClubeJogadorMapper.toDto(_repo_clube_jogador.GetByCodOperacao(dto.CodOperacao)
                        .Result);
                JogadorDTO jogadorDto =
                    JogadorMapper.toDto(_repo_jogador.GetByLicencaAsync(clubeJogadorDto.Licenca.ToString()).Result);
                PessoaDTO pessoaDto =
                    PessoaMapper.toDto(
                        _repo_pessoa.GetByIdPessoaAsync(jogadorDto.IdentificadorPessoa.ToString()).Result);
                ClubeDTO clubeDto =
                    ClubeMapper.toDto(_repo_clube.GetByCodClubeAsync(clubeJogadorDto.CodigoClube.ToString()).Result);
                EquipaDTO equipaDto = EquipaMapper.toDto(_repo_equipa
                    .GetByIdentificadorEquipaAsync(jogadorDto.IdentificadorEquipa.ToString()).Result);

                listFinal.Add(new ProcessoJogadorVisualizacaoDTO(dto.CodOperacao, pessoaDto.Nome,
                    jogadorDto.Licenca.ToString(), dto.TipoProcesso, clubeDto.NomeClube,
                    equipaDto.Modalidade, equipaDto.Categoria, equipaDto.Divisao, "Amador", dto.DataSubscricao,
                    dto.DataRegisto, dto.Estado));
            }
        }

       
        return listFinal;
    }

    public Task<ProcessoInscricaoDTO> GetByIdAsync(Identifier id)
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


    public async Task<ProcessoInscricaoDTO> GetByCodOperacao(string licenca)
    {
        var jogador = await _repo.GetByCodOperacaoAsync(licenca);

        if (jogador == null)
            return null;

        return new ProcessoInscricaoDTO(jogador.Id.AsGuid(), jogador.CodOperacao.CodOpe.ToString(),
            jogador.Estado.Status, jogador.DataRegisto.DataReg, jogador.DataSubscricao.DataSubs,
            jogador.TipoProcesso.ProcessoTipo, jogador.EpocaDesportiva.EpocaDesp);
    }

    public async Task<List<ProcessoInscricaoDTO>> GetProcessosAssociacaoByNomeAssociacaoAsync(string nomeAss)
    {
        var list = await _repo.GetProcessosAssociacaoByNomeAssociacaoAsync(nomeAss);

        List<ProcessoInscricaoDTO> listDto = list.ConvertAll(jogador =>
            new ProcessoInscricaoDTO(jogador.Id.AsGuid(), jogador.CodOperacao.CodOpe.ToString(), jogador.Estado.Status,
                jogador.DataRegisto.DataReg, jogador.DataSubscricao.DataSubs, jogador.TipoProcesso.ProcessoTipo,
                jogador.EpocaDesportiva.EpocaDesp));

        return listDto;
    }


    public async Task<ProcessoInscricaoDTO> AddAsync(ProcessoInscricaoDTO dto)
    {
        var jogador = new ProcessoInscricao(dto.TipoProcesso, dto.CodOperacao);

        await _repo.AddAsync(jogador);

        await _unitOfWork.CommitAsync();

        return new ProcessoInscricaoDTO(jogador.Id.AsGuid(), jogador.CodOperacao.CodOpe.ToString(),
            jogador.Estado.Status, jogador.DataRegisto.DataReg, jogador.DataSubscricao.DataSubs,
            jogador.TipoProcesso.ProcessoTipo, jogador.EpocaDesportiva.EpocaDesp);
    }

    public async Task<ProcessoInscricaoDTO> UpdateAsync(ProcessoInscricaoDTO dto)
    {
        var jogador = await _repo.GetByIdAsync(new Identifier(dto.Id));

        if (jogador == null)
            return null;

        // change all fields

        jogador.ChangeDataRegisto();
        jogador.ChangeEstadoAprovado();

        await _unitOfWork.CommitAsync();

        return new ProcessoInscricaoDTO(jogador.Id.AsGuid(), jogador.CodOperacao.CodOpe.ToString(),
            jogador.Estado.Status, jogador.DataRegisto.DataReg, jogador.DataSubscricao.DataSubs,
            jogador.TipoProcesso.ProcessoTipo, jogador.EpocaDesportiva.EpocaDesp);
    }

    public async Task<ProcessoInscricaoDTO> UpdateByCodOperacaoAsync(ProcessoInscricaoDTO dto)
    {
        var processo = await _repo.GetByIdAsync(new Identifier(dto.Id));

        if (processo == null)
            return null;

        // change  fields

        processo.ChangeEstadoAprovado();
        processo.ChangeDataRegisto();

        await _unitOfWork.CommitAsync();

        return new ProcessoInscricaoDTO(processo.Id.AsGuid(), processo.CodOperacao.CodOpe.ToString(),
            processo.TipoProcesso.ProcessoTipo,
            processo.Estado.Status, processo.EpocaDesportiva.EpocaDesp, processo.DataRegisto.DataReg,
            processo.DataSubscricao.DataSubs);
    }

    public async Task<AnalyzeResult> AnalyseImage(string caminho, string modelIdDocId)
    {
        string endpoint = "https://cogniteveservices.cognitiveservices.azure.com/";
        string apiKey = "e4d7376d96d8471cba771af20e6d9110";
        var credential = new AzureKeyCredential(apiKey);
        var client = new DocumentAnalysisClient(new Uri(endpoint), credential);
        byte[] imageBytes = Convert.FromBase64String(ConvertTo64(caminho));
        using var stream = new MemoryStream(imageBytes);
        AnalyzeDocumentOperation operation =
            await client.AnalyzeDocumentAsync(WaitUntil.Completed, modelIdDocId, stream);
        AnalyzeResult result = operation.Value;
        stream.Close();
        return result;
    }
    
    private string ConvertTo64(string s)
    {
        if (s.Contains("base64"))
        {
            string keyword = "base64,";
            int startIndex = s.IndexOf(keyword);
            string result = s.Substring(startIndex + keyword.Length);
            return result;
        }

        return s;
    }

    public Task<ProcessoInscricaoDTO> InactivateAsync(Identifier id)
    {
        throw new NotImplementedException();
    }

    public Task<ProcessoInscricaoDTO> ActivateAsync(string id)
    {
        throw new NotImplementedException();
    }

   
    public async Task<ProcessoInscricaoDTO> DeleteAsync(string id)
    {
        var processo = await _repo.GetByCodOperacaoAsync(id);

        if (processo == null)
            return null;
        

        _repo.Remove(processo);
        await _unitOfWork.CommitAsync();

        return new ProcessoInscricaoDTO(processo.Id.AsGuid(), processo.CodOperacao.CodOpe.ToString(),
            processo.TipoProcesso.ProcessoTipo,
            processo.Estado.Status, processo.EpocaDesportiva.EpocaDesp, processo.DataRegisto.DataReg,
            processo.DataSubscricao.DataSubs);
    }
}