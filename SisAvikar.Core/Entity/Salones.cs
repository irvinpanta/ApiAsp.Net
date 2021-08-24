using System;
using System.Collections.Generic;

#nullable disable

namespace SisAvikar.Core.Entity
{
    public partial class Salones
    {
        public Salones()
        {
            Mesas = new HashSet<Mesas>();
        }

        public int Salon { get; set; }
        public string Descripcion { get; set; }
        public int Capacidad { get; set; }
        public byte Activo { get; set; }

        public virtual ICollection<Mesas> Mesas { get; set; }
    }
}
