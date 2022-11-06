using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Cliente
    {
        public string CodigoCliente { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string TipoSoporte { get; set; }
        public string DescripSolicitud{ get; set; }
        public decimal Precio { get; set; }
        public string DescripRespuesta { get; set; }
        public DateTime Fecha { get; set; }
        public decimal ISV { get; set; }
        public decimal Descuento { get; set; }
      
        public decimal Total { get; set; }
    }
}
