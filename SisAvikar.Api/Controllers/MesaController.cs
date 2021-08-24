using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SisAvikar.Api.Response;
using SisAvikar.Core.DTOs;
using SisAvikar.Core.Entity;
using SisAvikar.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisAvikar.Api.Controllers
{
    [Route("api/mesas")]
    [ApiController]
    public class MesaController : ControllerBase
    {

        private readonly IMesaService _mesaService;
        private readonly IMapper _mapper;
        public MesaController(IMesaService mesaService, IMapper mapper)
        {
            _mesaService = mesaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetMesas()
        {
            var mesas = await _mesaService.getMesas();
            var mesasDto = _mapper.Map<IEnumerable<MesaDto>>(mesas);

            var response = new ApiResponse<IEnumerable<MesaDto>>(mesasDto);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getMesasById(int id)
        {
            var resul = await _mesaService.getMesaById(id);
            var mesasDto = _mapper.Map<MesaDto>(resul);

            var response = new ApiResponse<MesaDto>(mesasDto);
            return Ok(response);
        }

        [HttpPost]
        public async  Task<IActionResult> save(MesaDto mesasDto)
        {
 
            var mesas = _mapper.Map<Mesas>(mesasDto);
            await _mesaService.save(mesas);

            mesasDto = _mapper.Map<MesaDto>(mesas);
            var response = new ApiResponse<MesaDto>(mesasDto);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> update(int id, MesaDto mesaDto)
        {
            var resul = _mapper.Map<Mesas>(mesaDto);
            resul.Mesa = id;

            var respuesta = await _mesaService.update(resul);

            var response = new ApiResponse<bool>(respuesta);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> delete(int id)
        {
            var resul = await _mesaService.delete(id);
            var response = new ApiResponse<bool>(resul);
            return Ok(response);
        }
    }
}
