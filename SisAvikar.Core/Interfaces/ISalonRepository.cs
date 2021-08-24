using SisAvikar.Core.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisAvikar.Core.Interfaces
{
    public interface ISalonRepository
    {
        Task<IEnumerable<Salones>> GetSalon();
        Task<Salones> GetSalonId(int id);

        Task save(Salones salones);
    }
}
