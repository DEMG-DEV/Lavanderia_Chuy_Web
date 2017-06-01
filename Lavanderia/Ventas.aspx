<%@ Page Title="Ventas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="Lavanderia.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnSalir" CssClass="btn btn-danger btn-xs" runat="server" Text="Salir" OnClick="btnSalir_Click" />
    <div class="row">
        <div class="col-lg-6">
            <div class="form-horizontal">
                <fieldset>
                    <legend>Lavado</legend>
                    <div class="form-group">
                        <div class="col-lg-6">
                            <asp:DropDownList ID="cmbPrendas1" runat="server"></asp:DropDownList>
                            <asp:EntityDataSource ID="EntityDataSource1" runat="server" ConnectionString="name=LavanderiaEntities" DefaultContainerName="LavanderiaEntities" EnableFlattening="False" EntitySetName="prendas" EntityTypeFilter="prenda" Select="it.[nombrePrenda]">
                            </asp:EntityDataSource>
                        </div>
                        <asp:TextBox CssClass="col-lg-2" ID="txtCantLavado" runat="server" placeholder="Cantidad..." />
                        <asp:Button CssClass="col-lg-2 btn btn-default btn-sm" ID="btnAñadir1" runat="server" Text="Añadir" OnClick="btnAñadir1_Click" />
                    </div>
                    <div class="form-group">
                        <div class="col-lg-10">
                            <asp:ListBox ID="lstLavado" runat="server" Width="300px"></asp:ListBox>
                        </div>
                    </div>
                </fieldset>
            </div>
            <div class="form-horizontal">
                <fieldset>
                    <legend>Secado</legend>
                    <div class="form-group">
                        <div class="col-lg-6">
                            <asp:DropDownList ID="cmbPrendas2" runat="server"></asp:DropDownList>
                        </div>
                        <asp:TextBox CssClass="col-lg-2" ID="txtCantSecado" runat="server" placeholder="Cantidad..." />
                        <asp:Button CssClass="col-lg-2 btn btn-default btn-sm" ID="btnAñadir2" runat="server" Text="Añadir" OnClick="btnAñadir2_Click" />
                    </div>
                    <div class="form-group">
                        <div class="col-lg-10">
                            <asp:ListBox ID="lstSecado" runat="server" Width="300px"></asp:ListBox>
                        </div>
                    </div>
                </fieldset>
            </div>
            <div class="form-horizontal">
                <fieldset>
                    <legend>Planchado</legend>
                    <div class="form-group">
                        <div class="col-lg-6">
                            <asp:DropDownList ID="cmbPrendas3" runat="server"></asp:DropDownList>
                        </div>
                        <asp:TextBox CssClass="col-lg-2" ID="txtCantPlanchado" runat="server" placeholder="Cantidad..." />
                        <asp:Button CssClass="col-lg-2 btn btn-default btn-sm" ID="btnAñadir3" runat="server" Text="Añadir" OnClick="btnAñadir3_Click" />
                    </div>
                    <div class="form-group">
                        <div class="col-lg-10">
                            <asp:ListBox ID="lstPlanchado" runat="server" Width="300px"></asp:ListBox>
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="form-horizontal">
                <fieldset>
                    <legend>Total</legend>
                    <div class="form-group">
                        <label for="lblCCL" class="col-lg-4 control-label">Cantidad CargaLigera:</label>
                        <div class="col-lg-8">
                            <asp:TextBox type="text" class="form-control" ID="txtCCL" placeholder="" runat="server" ReadOnly="True" Text="0" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="lblTCL" class="col-lg-4 control-label">Total Carga Ligera:</label>
                        <div class="col-lg-8">
                            <asp:TextBox type="text" class="form-control" ID="txtTCL" placeholder="" runat="server" ReadOnly="True" Text="0" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="lblCCP" class="col-lg-4 control-label">Cantidad Carga Pesada:</label>
                        <div class="col-lg-8">
                            <asp:TextBox type="text" class="form-control" ID="txtCCP" placeholder="" runat="server" ReadOnly="True" Text="0" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="lblTCP" class="col-lg-4 control-label">Total Carga Pesada:</label>
                        <div class="col-lg-8">
                            <asp:TextBox type="text" class="form-control" ID="txtTCP" placeholder="" runat="server" ReadOnly="True" Text="0" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="lblCP" class="col-lg-4 control-label">Cantidad Planchado:</label>
                        <div class="col-lg-8">
                            <asp:TextBox type="text" class="form-control" ID="txtCP" placeholder="" runat="server" ReadOnly="True" Text="0" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="lblTP" class="col-lg-4 control-label">Total Planchado:</label>
                        <div class="col-lg-8">
                            <asp:TextBox type="text" class="form-control" ID="txtTP" placeholder="" runat="server" ReadOnly="True" Text="0" />
                        </div>
                    </div>
                    <div class="form-group">
                        <label for="lblTaP" class="col-lg-4 control-label">Total a Pagar:</label>
                        <div class="col-lg-8">
                            <asp:TextBox type="text" class="form-control" ID="txtTaP" placeholder="" runat="server" ReadOnly="True" Text="0" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-10 col-lg-offset-2">
                            <asp:Button type="reset" class="btn btn-default" Text="Cancelar" runat="server" OnClick="Unnamed1_Click" />
                            <asp:Button type="submit" class="btn btn-primary" Text="Pagar" runat="server" OnClick="Unnamed2_Click" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-3"></div>
                        <div class="col-lg-6">
                            <img id="logo" class="img-thumbnail" src="Content/logo.png" />
                        </div>
                        <div class="col-lg-3"></div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
</asp:Content>
