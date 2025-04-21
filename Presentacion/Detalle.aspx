<%@ Page Title="Detalle del Producto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Detalle.aspx.cs" Inherits="Presentacion.Detalle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row mt-5">

        <div class="col-md-6">
            <asp:Image ID="imgProducto" runat="server" CssClass="img-fluid rounded border" />
        </div>

        <div class="col-md-6">
            <h2><asp:Label ID="lblNombre" runat="server" CssClass="fw-bold" /></h2>
            <p class="text-muted"><asp:Label ID="lblDescripcion" runat="server" /></p>
            <h4 class="text-success mt-3">Precio: <asp:Label ID="lblPrecio" runat="server" /></h4>
            <p class="mt-2">Stock disponible: <asp:Label ID="lblStock" runat="server" /></p>

            <asp:Button ID="btnAgregarCarrito" runat="server" Text="Agregar al carrito" CssClass="btn btn-success" OnClick="btnAgregarCarrito_Click" />
        </div>

    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
