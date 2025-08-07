using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiPaisesProyecto.Models;
using ApiPaisesProyecto.Entidades;
using ApiPaisesProyecto.Interfaces;
using AutoMapper;

namespace ApiPaisesProyecto.Controllers
{
    [Route("api/apartamentos")]
    [ApiController]
    public class ApartamentosController : ControllerBase
    {
        private readonly IRepository<Apartamento> _apartamentoRepo;
        private readonly ILogger<ApartamentosController> _logger;
        private readonly IMapper _mapper;
        public ApartamentosController(ILogger<ApartamentosController> logger,
                                       IRepository<Apartamento> apartamentoRepo,
                                       IMapper mapper)
        {
            _apartamentoRepo = apartamentoRepo;
            _logger = logger;
            _mapper = mapper;
        }

        // GET: api/apartamentos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApartamentoDto>>> GetApartamentos()
        {
            _logger.LogInformation("Obteniendo lista de apartamentos");
            var apartamentos = await _apartamentoRepo.GetAllAsync();
            if (apartamentos == null || !apartamentos.Any())
            {
                _logger.LogWarning("No se encontraron apartamentos");
                return NotFound("No se encontraron apartamentos");
            }
            var dtoList = _mapper.Map<List<ApartamentoDto>>(apartamentos);
            return Ok(dtoList);
        }

        // GET api/apartamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApartamentoDto>> GetApartamento(int id)
        {
            _logger.LogInformation($"Obteniendo apartamento con ID: {id}");
            var apartamento = await _apartamentoRepo.GetByIdAsync(id);
            if (apartamento == null)
            {
                _logger.LogWarning($"Apartamento con ID: {id} no encontrado");
                return NotFound($"Apartamento con ID: {id} no encontrado");
            }
            var dto = _mapper.Map<ApartamentoDto>(apartamento);
            return Ok(dto);
        }

        // POST api/apartamentos
        [HttpPost]
        public async Task<ActionResult<ApartamentoDto>> CreateApartamento([FromBody] ApartamentoCreateDto dto)
        {
            if (dto == null)
            {
                _logger.LogError("Apartamento no puede ser nulo");
                return BadRequest("Apartamento no puede ser nulo");
            }
            var apartamento = _mapper.Map<Apartamento>(dto);
            await _apartamentoRepo.AddAsync(apartamento);
            _logger.LogInformation($"Apartamento creado con ID: {apartamento.Id}");
            var resultDto = _mapper.Map<ApartamentoDto>(apartamento);
            return CreatedAtAction(nameof(GetApartamento), new { id = apartamento.Id }, resultDto);
        }

        // PUT api/apartamentos/5
        [HttpPut("{id}")]
        public async Task<ActionResult<ApartamentoDto>> UpdateApartamento(int id, [FromBody] ApartamentoUpdateDto dto)
        {
            if (dto == null)
            {
                _logger.LogError("Apartamento no puede ser nulo");
                return BadRequest("Apartamento no puede ser nulo");
            }
            var apartamento = await _apartamentoRepo.GetByIdAsync(id);
            if (apartamento == null)
            {
                _logger.LogWarning($"Apartamento con ID: {id} no encontrado");
                return NotFound($"Apartamento con ID: {id} no encontrado");
            }
            _mapper.Map(dto, apartamento);
            await _apartamentoRepo.UpdateAsync(apartamento);
            var resultDto = _mapper.Map<ApartamentoDto>(apartamento);
            return Ok(resultDto);
        }
    }
}
