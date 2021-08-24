using Microsoft.AspNetCore.Mvc;
using SisAvikar.Core.DTOs;
using SisAvikar.Core.Entity;
using SisAvikar.Core.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SisAvikar.Api.Controllers
{
    [Route("api/salon")]
    [ApiController]
    public class SalonController : ControllerBase
    {
        private readonly ISalonRepository _salonRepository;
        private String message = "";
        
        public SalonController(ISalonRepository salonRepository)
        {
            _salonRepository = salonRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetSalones()
        {
            var salon = await _salonRepository.GetSalon();
            //Covertir de Salon as SalonDto
            var salonDto = salon.Select(x => new SalonDto
            {
                 Salon = x.Salon,
                 Descripcion = x.Descripcion,
                 Capacidad = x.Capacidad,
                 Activo = x.Activo
            });//Fin Conversion

            return Ok(salonDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getSalonesId(int id)
        {
            var resul = await _salonRepository.GetSalonId(id);
            var salonDto = new SalonDto
            {
                Salon = resul.Salon,
                Descripcion = resul.Descripcion,
                Capacidad = resul.Capacidad,
                Activo = resul.Activo
            };

            return Ok(salonDto);
        }

        [HttpPost]
        public async Task<IActionResult> save(SalonDto salonDto)
        {
            if(salonDto.Descripcion.Length == 0)
            {
                message = "MSG_0005";
                return BadRequest(message);
            }
            else if(salonDto.Capacidad == 0)
            {
                message = "MSG_0006";
                return BadRequest(message);
            }
            else
            {
                //Convertir de SalonDto a Salones
                var salon = new Salones
                {
                    Descripcion = salonDto.Descripcion,
                    Capacidad = salonDto.Capacidad,
                    Activo = salonDto.Activo
                };

                await _salonRepository.save(salon);
                message = "MSG_0001";
                return Ok(message);
            }

            
        }
    }
}
