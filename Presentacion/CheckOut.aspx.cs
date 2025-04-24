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
            if (Session["Carrito"] == null)
            {
                lblMensaje.Text = "El carrito se encuentra vacio";
                return;
            }

            List<CarritoItem> carrito = (List<CarritoItem>)Session["Carrito"];

            if(string.IsNullOrEmpty(rbMedioPago.SelectedValue))
            {
                lblMensaje.Text = "Seleccione el medio de pago";
                return;
            }

            Pedido pedido = new Pedido
            {
                FechaPedido = DateTime.Now,
                MedioPago = rbMedioPago.SelectedValue,
                Total = carrito.Sum(ci => ci.Producto.Precio * ci.Cantidad),

                Detalles = carrito.Select(ci => new PedidoDetalle
                {
                    IdProducto = ci.Producto.Id,
                    Cantidad = ci.Cantidad,
                    PrecioUnitario = ci.Producto.Precio
                }).ToList()
            };

            PedidoNegocio negocio = new PedidoNegocio();

            int idPedido = negocio.GuardarPedido(pedido);

            if (idPedido > 0)
            {
                Session["Carrito"] = null;
                Response.Redirect("Confirmacion.aspx?id=" + idPedido);
            }
            else
            {
                lblMensaje.Text = "Error al procesar el pedido. Intente nuevamente.";
            }
        }
    }
}