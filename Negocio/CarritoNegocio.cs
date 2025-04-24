using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CarritoNegocio
    {
        public List<CarritoItem> ObtenerCarrito(object sessionCarrito)
        {
            return sessionCarrito as List<CarritoItem> ?? new List<CarritoItem>();
        }
        
        public decimal CalcularTotal(List<CarritoItem> carrito)
        {
            return carrito.Sum(i => i.Producto.Precio * i.Cantidad);
        }
    }
}
