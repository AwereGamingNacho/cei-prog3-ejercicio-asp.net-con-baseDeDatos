<%@ Page Title="Buscar Autor" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BusquedaAutor.aspx.cs" Inherits="prog3_ejercicio_bdd_en_asp_net.Pages.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="container">
        <div id="containerBusqueda">
            <asp:DropDownList runat="server" ID="ddwFiltroAutor" OnSelectedIndexChanged="ddwFiltroAutor_SelectedIndexChanged">
                <asp:ListItem>Nombre</asp:ListItem>
                <asp:ListItem>Apellido</asp:ListItem>
                <asp:ListItem>Nacionalidad</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox runat="server" ID="txtBuscarAutor" CssClass="border-primary" placeholder="Buscar..."></asp:TextBox>
            <asp:Button runat="server" ID="btnBuscarAutor" CssClass="btn-primary" Text="Buscar" OnClick="btnBuscarAutor_Click" />
        </div>
        <div id="containerGrilla">
            <asp:GridView runat="server" ID="gvAutores" CssClass="table m-0 p-0" CellSpacing="5" DataKeyNames="" AutoGenerateColumns="True"></asp:GridView>
        </div>
    </div>
</asp:Content>
