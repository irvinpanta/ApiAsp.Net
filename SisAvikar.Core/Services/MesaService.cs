using SisAvikar.Core.Entity;
using SisAvikar.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAvikar.Core.Services
{
    public class MesaService : IMesaService
    {
        private readonly IMesasRepository _mesasRepository;
        private readonly ISalonRepository _salonRepository;
        public MesaService(IMesasRepository mesasRepository, ISalonRepository salonRepository)
        {
            _mesasRepository = mesasRepository;
            _salonRepository = salonRepository;
        }
        
        public async Task<Mesas> getMesaById(int id)
        {
            return await _mesasRepository.getMesaById(id);
        }

        public async Task<IEnumerable<Mesas>> getMesas()
        {
            return await _mesasRepository.getMesas();
        }

        public async Task save(Mesas mesa)
        {
            var salon = await _salonRepository.GetSalonId(mesa.Salon);

            if (salon == null)
            {
                throw new Exception("Salon no existe");
            }
            else
            {
                await _mesasRepository.save(mesa);
            }
            
        }

        public async Task<bool> update(Mesas mesa)
        {
            return await _mesasRepository.update(mesa);
        }

        public async Task<bool> delete(int id)
        {
            return await _mesasRepository.delete(id);
        }
    }
}
