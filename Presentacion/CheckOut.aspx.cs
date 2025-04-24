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
    public partial class CheckOut : System.Web.UI.Page
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
            CarritoNegocio negocio = new CarritoNegocio();
            List<CarritoItem> carrito = Session["carrito"] as List<CarritoItem>;

            if (carrito != null && carrito.Count > 0)
            {
                rptCarrito.DataSource = carrito;
                rptCarrito.DataBind();

           
                lblTotal.Text = "Total: $" + negocio.CalcularTotal(carrito).ToString("N2");
            }
            else
            {
                panelCarrito.Visible = false;
                lblTotal.Text = "Tu carrito está vacío.";
            }
        }

        protected void btnFinalizarCompra_Click(object sender, EventArgs e)
        {
            List<CarritoItem> carrito = Session["carrito"] as List<CarritoItem>;

            //verifica si el carrito esta vacio
            if (carrito != null || carrito.Count == 0)
            {
                lblMensaje.Text = "El carrito se encuentra vacio";
                return;
            }
            
            //verifica si no se seleccionaron medios de pago
            if(string.IsNullOrEmpty(rbMedioPago.SelectedValue))
            {
                lblMensaje.Text = "Seleccione un medio de pago";
                return;
            }

            string medioPago = rbMedioPago.SelectedValue;
            decimal total = carrito.Sum(i => i.Producto.Precio * i.Cantidad);

            lblMensaje.CssClass = "text-success mt-2 d-block";

            lblMensaje.Text = $"Compra finalizada. Medio de pago: {medioPago}. Total: ${total:N2}";

            //vacia el carrito
            Session["carrito"] = null;
            rptCarrito.DataSource = null;
            rptCarrito.DataBind();
            lblTotal.Text = "";
        }
    }
}