<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Lavanderia._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <fieldset>
            <legend>Ingresar</legend>

            <div class="form-group">
                <label for="lblIP" class="col-lg-2 control-label">IP Servidor:</label>
                <div class="col-lg-10">
                    <asp:TextBox ID="txtIp" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="lblUsuario" class="col-lg-2 control-label">Usuario:</label>
                <div class="col-lg-10">
                    <asp:TextBox ID="txtUser" class="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <label for="lblIP" class="col-lg-2 control-label">Contraseña:</label>
                <div class="col-lg-10">
                    <asp:TextBox ID="txtPass" class="form-control" runat="server" TextMode="Password"></asp:TextBox>
                </div>
            </div>
            <div class="form-group">
                <div class="col-lg-10 col-lg-offset-2">
                    <asp:Button ID="btnCancelar" CssClass="btn btn-default" runat="server" Text="Cancel" OnClick="btnCancelar_Click"></asp:Button>
                    <asp:Button ID="btnIngresar" CssClass="btn btn-primary" runat="server" OnClick="btnEnviar_Click" Text="Enviar"></asp:Button>
                </div>
            </div>
        </fieldset>
    </div>
</asp:Content>
