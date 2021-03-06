using System;
using System.Collections.Generic;

#nullable disable

namespace SisAvikar.Core.Entity
{
    public partial class Empleado
    {
        public Empleado()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Empleado1 { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Foto { get; set; }
        public byte Activo { get; set; }
        public string Usuario { get; set; }
        public string Contrasenia { get; set; }
        public int Rol { get; set; }
        public DateTime FecSistema { get; set; }

        public virtual Role RolNavigation { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
