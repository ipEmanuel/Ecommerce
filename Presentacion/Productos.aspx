<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Presentacion.Productos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="mt-4 mb-4">Productos disponibles</h2>

    <asp:Repeater ID="rptProductos" runat="server">
        <HeaderTemplate>
            <div class="row">
        </HeaderTemplate>

        <ItemTemplate>
            <div class="col-md-4 mb-4">
                <div class="card h-100">
                    <img src='<%# Eval("ImagenUrl") %>' class="card-img-top" alt='<%# Eval("Nombre") %>' style="max-height:200px; object-fit:cover;" />
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Nombre") %></h5>
                        <p class="card-text text-muted"><%# Eval("Descripcion") %></p>
                        <p class="card-text fw-bold text-success">$<%# Eval("Precio", "{0:N2}") %></p>
                        <p class="card-text">Stock disponible: <%# Eval("Stock") %></p>
                    </div>
                </div>
            </div>
        </ItemTemplate>

        <FooterTemplate>
            </div>
        </FooterTemplate>
    </asp:Repeater>

</asp:Content>
