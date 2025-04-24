using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using AccesoDatos;

namespace Negocio
{
    public class PedidoNegocio
    {
        public int GuardarPedido(Pedido pedido)
        {
            PedidoDatos datos = new PedidoDatos();
            int idPedido = datos.Guardar(pedido);
            return idPedido;
        }
    }
}
