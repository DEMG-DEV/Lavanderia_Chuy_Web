<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Ticket.aspx.cs" Inherits="Lavanderia.Ticket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div class="row">
        <div class="col-lg-2"></div>
        <div class="col-lg-8">
            <div class="panel panel-primary">
                <div class="panel-heading">
                    <h3 class="panel-title">Ticket</h3>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-8">
                            <div class="form-group">
                                <div class="col-lg-6">
                                    <asp:Label ID="lblCL" class="text-primary" runat="server" />
                                </div>
                                <div class="col-lg-6">
                                    <asp:Label ID="lblTL" class="text-primary" runat="server" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-lg-6">
                                    <asp:Label ID="lblCP" class="text-primary" runat="server" />
                                </div>
                                <div class="col-lg-6">
                                    <asp:Label ID="lblTP" class="text-primary" runat="server" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-lg-6">
                                    <asp:Label ID="lblcaP" class="text-primary" runat="server" />
                                </div>
                                <div class="col-lg-6">
                                    <asp:Label ID="lbltoP" class="text-primary" runat="server" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-lg-3"></div>
                                <div class="col-lg-6">
                                    <strong>
                                        <asp:Label ID="lblTaP" class="text-success" runat="server" />
                                    </strong>
                                </div>
                                <div class="col-lg-3"></div>
                            </div>
                        </div>
                        <div class="col-lg-2">
                            <asp:Button type="submit" class="btn btn-primary" Text="Aceptar" runat="server" OnClick="Unnamed1_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-2"></div>
    </div>

</asp:Content>
