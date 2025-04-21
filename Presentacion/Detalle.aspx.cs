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
            int id = Convert.ToInt32(Request.QueryString["id"]);
            ProductoNegocio negocio = new ProductoNegocio();
            Producto productoSeleccionado = negocio.ObtenerProductoPorId(id);

            List<CarritoItem> carrito = Session["carrito"] as List<CarritoItem>;

            if(carrito == null)
            {
                carrito = new List<CarritoItem>();
            }

            var itemExistente = carrito.FirstOrDefault(i => i.Producto.Id == id);

            if (itemExistente != null)
            {
                

                if (itemExistente.Cantidad < productoSeleccionado.Stock)
                {
                    itemExistente.Cantidad++;
                }
                else
                {
                    lblStock.Text = "No hay más stock disponible para este producto.";
                }
            }
            else
            {
                carrito.Add(new CarritoItem { Producto = productoSeleccionado, Cantidad = 1 });
            }

            Session["carrito"] = carrito;

            Response.Redirect("Carrito.aspx");
        }
    }
}