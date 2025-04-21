using Negocio;
using System;
using Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProductoNegocio negocio = new ProductoNegocio();
                List<Producto> lista = negocio.ListarProductos();

                rptProductos.DataSource = lista;
                rptProductos.DataBind();
            }
        }
    }
}