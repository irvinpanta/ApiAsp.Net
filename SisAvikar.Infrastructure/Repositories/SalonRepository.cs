using Microsoft.EntityFrameworkCore;
using SisAvikar.Core.Entity;
using SisAvikar.Core.Interfaces;
using SisAvikar.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisAvikar.Infrastructure.Repositories
{
    public class SalonRepository : ISalonRepository
    {
        private readonly SisAvikarDemoContext _context;

        public SalonRepository(SisAvikarDemoContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Salones>> GetSalon()
        {

            var salon = await _context.Salones.ToListAsync();
            
            return salon;
            
        }

        public async Task<Salones> GetSalonId(int id)
        {
            var resul = await _context.Salones.FirstOrDefaultAsync(x => x.Salon == id);
            return resul;
        }


        public async Task save(Salones salones)
        {
            await _context.Salones.AddAsync(salones);
            _context.SaveChanges();

        }
    }
}
