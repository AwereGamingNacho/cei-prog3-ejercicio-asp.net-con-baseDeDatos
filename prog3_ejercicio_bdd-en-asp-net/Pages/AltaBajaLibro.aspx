<%@ Page Title="Alta y Baja de Libro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AltaBajaLibro.aspx.cs" Inherits="prog3_ejercicio_bdd_en_asp_net.Pages.AltaBajaLibro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="container">
        <div id="containerDarAlta">
            <asp:TextBox runat="server" ID="txtIDAutor" placeholder ="ID del Autor" TextMode="Number"></asp:TextBox>
            <asp:TextBox runat="server" ID="txtTitulo" placeholder="Titulo"></asp:TextBox>
            <asp:TextBox runat="server" ID="txtDescripcion" placeholder="Descripcion"></asp:TextBox>
            <asp:TextBox runat="server" ID="txtAno" placeholder="Año" TextMode="Number"></asp:TextBox>
            <asp:Button runat="server" ID="btnAnadir" Text="Añadir Libro" OnClick="btnAnadir_Click" />
        </div>
        <div id="grillaListado">
            <asp:GridView runat="server" ID="gvLibrosAltaYBaja" CssClass="table m-0 p-0" CellSpacing="5" DataKeyNames="" AutoGenerateColumns="True" OnRowDeleting="gvLibrosAltaYBaja_RowDeleting">
                <Columns>
                    <asp:CommandField ButtonType="Button" ShowDeleteButton="true" EditText="Eliminar" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
