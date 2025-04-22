<%@ Page Title="Carrito" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="Presentacion.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
	<h2 class="mt-4 mb-4">Carrito de Compras</h2>

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

                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" CommandArgument='<%# Eval("Producto.Id")%>' OnCommand="btnEliminar_Command"/>                                  

                        </div>
                    </div>
                </div>
            </ItemTemplate>

            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater><%--Fin Repeater--%>
    </asp:Panel>
    <asp:Label ID="lblTotal" runat="server" CssClass="fw-bold fs-5 mt-4 d-block"></asp:Label>	
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
	
</asp:Content>
