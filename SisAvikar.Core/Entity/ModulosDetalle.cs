using System;
using System.Collections.Generic;

#nullable disable

namespace SisAvikar.Core.Entity
{
    public partial class ModulosDetalle
    {
        public int Modulo { get; set; }
        public int Rol { get; set; }

        public virtual Modulo ModuloNavigation { get; set; }
        public virtual Role RolNavigation { get; set; }
    }
}
