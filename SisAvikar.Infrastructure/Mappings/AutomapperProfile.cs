using AutoMapper;
using SisAvikar.Core.DTOs;
using SisAvikar.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAvikar.Infrastructure.Mappings
{
    public class AutomapperProfile: Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Mesas, MesaDto>();
            CreateMap<MesaDto, Mesas>();
        }
    }
}
