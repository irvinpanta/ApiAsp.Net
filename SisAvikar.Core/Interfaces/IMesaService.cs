using SisAvikar.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAvikar.Core.Interfaces
{
    public interface IMesaService
    {
        Task<IEnumerable<Mesas>> getMesas();
        Task<Mesas> getMesaById(int id);
        Task save(Mesas mesa);
        Task<bool> update(Mesas mesa);
        Task<bool> delete(int id);
    }
}
