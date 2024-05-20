<%@ Page Title="Buscar Libro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BusquedaLibro.aspx.cs" Inherits="prog3_ejercicio_bdd_en_asp_net.Pages.BusquedaLibro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="container" style="margin: 0; padding: 0">
        <div id="containerBusqueda">
            <asp:DropDownList runat="server" ID="ddwFiltroLibro" OnSelectedIndexChanged="ddwFiltroLibro_SelectedIndexChanged">
                <asp:ListItem>Titulo</asp:ListItem>
                <asp:ListItem>Año</asp:ListItem>
                <asp:ListItem>Autor</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox runat="server" ID="txtBuscarLibro" CssClass="border-primary" placeholder="Buscar..."></asp:TextBox>
            <asp:Button runat="server" ID="btnBuscarLibro" CssClass="btn-primary" Text="Buscar" OnClick="btnBuscarLibro_Click" />
        </div>
        <div id="containerGrilla">
            <asp:GridView runat="server" ID="gvLibros" CssClass="table m-0 p-0" CellSpacing="5" DataKeyNames="" AutoGenerateColumns="True"></asp:GridView> 
        </div>
    </div>

</asp:Content>
