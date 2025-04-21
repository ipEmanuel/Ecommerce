using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Presentacion
{
    public partial class Carrito : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarrito();
            }
        }

        private void CargarCarrito()
        {
            List<CarritoItem> carrito = Session["carrito"] as List<CarritoItem>;
            
            if (carrito != null && carrito.Count > 0)
            {
                rptCarrito.DataSource = carrito;
                rptCarrito.DataBind();

                decimal total = carrito.Sum(i => i.Producto.Precio * i.Cantidad);
                lblTotal.Text = "Total: " + total.ToString("N2");
            }
            else
            {
                lblTotal.Text = "Tu carrito está vacío.";
            }
        }
    }
}