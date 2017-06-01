<%@ Page Title="Reportes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="Lavanderia.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnSalir" CssClass="btn btn-danger btn-xs" runat="server" Text="Regresar" OnClick="btnSalir_Click" />
    <br />
    <label >Reportes
    </label>
    <asp:GridView ID="GridView1" CssClass="table table-striped table-hover" runat="server"></asp:GridView>
</asp:Content>
