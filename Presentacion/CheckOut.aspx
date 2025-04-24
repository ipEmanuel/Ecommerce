<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckOut.aspx.cs" Inherits="Presentacion.CheckOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

	<h2 class="mt-4 mb-4">Resumen de Compras</h2>

    <asp:Panel ID="panelCarrito" runat="server">
        <asp:Repeater ID="rptCarrito" runat="server">
            <HeaderTemplate>
                <div class="row">
            </HeaderTemplate>

            <ItemTemplate>
                <div class="col-md-4 mb-4">
                    <div class="card h-100">
                        <img src='<%# Eval("Producto.ImagenUrl") %>' class="card-img-top" style="max-height:200px; object-fit:cover;" />
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Producto.Nombre") %></h5>
                            <p class="card-text"><%# Eval("Producto.Descripcion") %></p>
                            <p class="card-text">Precio: $<%# Eval("Producto.Precio", "{0:N2}") %></p>
                            <p class="card-text">Cantidad: <%# Eval("Cantidad") %></p>
                            <p class="card-text fw-bold">Subtotal: $<%# ((decimal)Eval("Producto.Precio") * (int)Eval("Cantidad")).ToString("N2") %></p>
                            

                        </div>
                    </div>
                </div>
            </ItemTemplate>

            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater><%--Fin Repeater--%>
        <asp:Label ID="lblTotal" runat="server" CssClass="fw-bold fs-5 mt-4 d-block"></asp:Label>
        <hr />
        <!--Medios de Pago -->
        <asp:Label ID="lblPago" runat="server" Text="Selecciona un medio de pago: " />
        <br />

        <asp:RadioButtonList ID="rbMedioPago" runat="server">
            <asp:ListItem Text="Efectivo" Value="Efectivo" />
            <asp:ListItem Text="Mercado Pago" Value="MercadoPago" />
        </asp:RadioButtonList>

        

        <asp:Button ID="btnFinalizarCompra" runat="server" Text="Finalizar Compra" CssClass="btn btn-primary mt-3" OnClick="btnFinalizarCompra_Click" /> 
        <asp:Label ID="lblMensaje" runat="server" CssClass="text-danger mt-2 d-block" />
    </asp:Panel>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
