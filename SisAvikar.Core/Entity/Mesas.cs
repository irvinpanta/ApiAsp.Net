using System;
using System.Collections.Generic;

#nullable disable

namespace SisAvikar.Core.Entity
{
    public partial class Mesas
    {
        public Mesas()
        {
            Pedidos = new HashSet<Pedido>();
        }

        public int Mesa { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public byte Activo { get; set; }
        public DateTime FecSistema { get; set; }
        public int Salon { get; set; }
        public byte MesaRapida { get; set; }

        public virtual Salones SalonNavigation { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }
    }
}
