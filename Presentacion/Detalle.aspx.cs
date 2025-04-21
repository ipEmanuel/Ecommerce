using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Detalle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int idProducto = int.Parse(Request.QueryString["id"]);
                    CargarProducto(idProducto);
                }
            }
        }

        private void CargarProducto(int id)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            Producto producto = negocio.ObtenerProductoPorId(id);

            if (producto != null)
            {
                lblNombre.Text = producto.Nombre;
                lblDescripcion.Text = producto.Descripcion;
                lblPrecio.Text = producto.Precio.ToString("C");
                lblStock.Text = "Stock: " + producto.Stock.ToString();
                imgProducto.ImageUrl = producto.ImagenUrl;
            }
        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {

        }
    }
}