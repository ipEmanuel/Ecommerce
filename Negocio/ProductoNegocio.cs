using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using Entidades;

namespace Negocio
{
    public class ProductoNegocio
    {   
        private readonly ProductoDatos productoDatos;

        public ProductoNegocio()
        {
            productoDatos = new ProductoDatos();
        }
       
        public List<Producto> ListarProductos()
        {
            return productoDatos.Listar();
        }

    }
}
