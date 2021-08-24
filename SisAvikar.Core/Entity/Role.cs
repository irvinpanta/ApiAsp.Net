using System;
using System.Collections.Generic;

#nullable disable

namespace SisAvikar.Core.Entity
{
    public partial class Role
    {
        public Role()
        {
            Empleados = new HashSet<Empleado>();
        }

        public int Rol { get; set; }
        public string Descripcion { get; set; }
        public int? Orden { get; set; }
        public byte? Activo { get; set; }

        public virtual ICollection<Empleado> Empleados { get; set; }
    }
}
