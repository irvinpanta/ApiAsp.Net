using System;

namespace SisAvikar.Core.DTOs
{
    public class MesaDto
    {

        public int Mesa { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public byte Activo { get; set; }
        public DateTime FecSistema { get; set; }
        public int Salon { get; set; }
        public byte MesaRapida { get; set; }
    }

}
