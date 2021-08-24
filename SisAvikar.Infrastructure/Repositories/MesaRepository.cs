using Microsoft.EntityFrameworkCore;
using SisAvikar.Core.Entity;
using SisAvikar.Core.Interfaces;
using SisAvikar.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisAvikar.Infrastructure.Repositories
{
    public class MesaRepository : IMesasRepository
    {
        private readonly SisAvikarDemoContext _context;
        public MesaRepository(SisAvikarDemoContext contex)
        {
            _context = contex;
        }
        public async Task<IEnumerable<Mesas>> getMesas()
        {
            var mesas = await _context.Mesas.ToListAsync();
            return mesas;
        }
        public async Task<Mesas> getMesaById(int id)
        {
            var mesas = await _context.Mesas.FirstOrDefaultAsync(x => x.Mesa == id);
            return mesas;
        }

        public async Task save(Mesas mesa)
        {
            await _context.Mesas.AddAsync(mesa);
            _context.SaveChanges();
        }

        public async Task<bool> update(Mesas mesas)
        {
            var resul = await getMesaById(mesas.Mesa);
            resul.Descripcion = mesas.Descripcion;
            resul.Cantidad = mesas.Cantidad;
            resul.MesaRapida = mesas.MesaRapida;
            resul.Salon = mesas.Salon;
            resul.Activo = mesas.Activo;

            int n = await _context.SaveChangesAsync();

            return n > 0;
        }

        public async Task<bool> delete(int id)
        {
            var resul = await getMesaById(id);
            _context.Mesas.Remove(resul);
            int n = await _context.SaveChangesAsync();

            return n > 0;

        }
    }
}
