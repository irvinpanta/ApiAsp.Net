using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisAvikar.Core.DTOs
{
    public class SalonDto
    {
        public int Salon { get; set; }
        public string Descripcion { get; set; }
        public int Capacidad { get; set; }
        public byte Activo { get; set; }
    }
}
