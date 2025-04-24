using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pedido
    {
        public int Id {  get; set; }
        public DateTime FechaPedido { get; set; }   
        public string MedioPago {  get; set; }
        public decimal Total { get; set; }
        public List<PedidoDetalle> Detalles { get; set; }
    }
}
