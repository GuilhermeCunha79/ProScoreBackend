using ConsoleApp1.Domain.DocumentoIdentificacao;
using ConsoleApp1.Domain.Jogador;
using ConsoleApp1.Domain.JogadorVisualizacao;
using ConsoleApp1.Domain.Pessoa;
using ConsoleApp1.Infraestructure;
using ConsoleApp1.Shared;
using Microsoft.AspNetCore.Mvc;

namespace ConsoleApp1.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class JogadorController : ControllerBase
    {
        private readonly IJogadorService _service;
        private readonly IPessoaService _service_pessoa;
        private readonly DDDSample1DbContext _context;

        public JogadorController(IJogadorService service, IPessoaService _service_pessoa1)
        {
            _service = service;
            _service_pessoa = _service_pessoa1;
        }

        // GET: api/Jogadores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogadorDTO>>> GetAll()
        {
            return await _service.GetAllAsync();
        }

        // GET: api/Jogadores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JogadorDTO>> GetById(Guid id)
        {
            var jogador = await _service.GetByIdAsync(new Identifier(id));

            if (jogador == null)
            {
                return NotFound();
            }

            return jogador;
        }

        // GET: api/Warehouses/ById/5M4
        [HttpGet("Licenca/{licenca}")]
        public async Task<ActionResult<JogadorVisualizacaoDTO>> GetByLicencaJogador(string licenca)
        {
            var jogador = await _service.GetByLicencaJogador(licenca);
            var pessoa = await _service_pessoa.GetByIdPessoa(jogador.IdentificadorPessoa.ToString());
            var jogador1 = new JogadorVisualizacaoDTO(pessoa.Nome,jogador.Licenca.ToString(),pessoa.NrIdentificacao,
                pessoa.DataNascimento,pessoa.TipoGenero,
                pessoa.NacionalidadePais,pessoa.NascencaPais,jogador.EstatutoFpF);
            if (jogador == null)
            {
                return NotFound();
            }

            return jogador1;
        }
        
        public async Task<ActionResult<JogadorDTO>> GetByLicencaJog(string licenca)
        {
            var jogador = await _service.GetByLicencaJogador(licenca);
            if (jogador == null)
            {
                return NotFound();
            }

            return jogador;
        }

        // POST: api/Jogadores
        [HttpPost]
        public async Task<ActionResult<JogadorDTO>> Create(JogadorDTO dto)
        {
            var list = await _service.GetAllAsync();
            if (list != null)
            {
                foreach (var jogadorDto in list)
                {
                    if (jogadorDto.Licenca.Equals(dto.Licenca))
                    {
                        return BadRequest(new
                            { Message = "Já existe um 'Jogador' registado com esta 'Licenca'." });
                    }
                    if (jogadorDto.IdentificadorPessoa.Equals(dto.IdentificadorPessoa))
                    {
                        return BadRequest(new
                            { Message = "Já existe um 'Jogador' registado com este 'Identificador de Pessoa'." });
                    }
                }
            }

            dto.Licenca = _service.GetAllAsync().Result.Count+1;
            try
            {
                var jogador = await _service.AddAsync(dto);

                return CreatedAtAction(nameof(GetById), new { id = jogador.Id }, jogador);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }


        // PUT: api/Jogadores/5
        [HttpPut("{id}")]
        public async Task<ActionResult<JogadorDTO>> Update(Guid id, JogadorDTO dto)
        {
            // if (id != dto.Id)
            // {
            //     return BadRequest();
            // }

            dto.Id = id;

            try
            {
                //var showJogador = await GetGetById(id); 

                var jogador = await _service.UpdateAsync(dto);

                if (jogador == null)
                {
                    return NotFound();
                }

                return Ok(jogador);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        // PUT: api/jogador/5
        [HttpPut("ByIdentifier/{licenca}")]
        public async Task<ActionResult<JogadorDTO>> UpdateByLicencaAsync(string licenca,
            JogadorDTO dto)
        {
            dto.Licenca = Int32.Parse(licenca);

            try
            {
                var jogador = await _service.UpdateByJogadorLicencaAsync(dto);

                if (jogador == null)
                {
                    return NotFound();
                }

                return Ok(jogador);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }

        // Inactivate: api/Jogadores/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<JogadorDTO>> SoftDelete(Guid id)
        {
            var jogador = await _service.InactivateAsync(new Identifier(id));

            if (jogador == null)
            {
                return NotFound();
            }

            return Ok(jogador);
        }

        // DELETE: api/Jogadores/5
        [HttpDelete("{id}/hard")]
        public async Task<ActionResult<JogadorDTO>> HardDelete(Guid id)
        {
            try
            {
                var jogador = await _service.DeleteAsync(new Identifier(id));

                if (jogador == null)
                {
                    return NotFound();
                }

                return Ok(jogador);
            }
            catch (BusinessRuleValidationException ex)
            {
                return BadRequest(new { ex.Message });
            }
        }
    }
}