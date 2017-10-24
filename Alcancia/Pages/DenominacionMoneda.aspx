<%@ Page Title="Denominacion" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="DenominacionMoneda.aspx.cs" Inherits="Alcancia.Pages.DenominacionMoneda" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Configuración Denominación Moneda</h1>
    <hr />
    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Denominación Moneda</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtDenominacionValor" CssClass="form-control" TextMode="Number" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" ID="btnBuscar" Text="Buscar" OnClick="btnBuscar_Click" CssClass="btn btn-info" />
                        </div>
                    </div>
                    <hr />
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Codigo Denominación</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtIdDenominacion" CssClass="form-control" TextMode="Number" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Denominación Moneda</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtDenominacion" CssClass="form-control" TextMode="Number" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" />
                            <asp:Button runat="server" ID="btnActualizar" Text="Actualizar" OnClick="btnActualizar_Click" CssClass="btn btn-warning" />
                            <asp:Button runat="server" ID="btnEliminar" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-10">
                            <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" CssClass="table table-bordered bs-table">
                                <Columns>
                                    <asp:BoundField DataField="IdDenominacion" HeaderText="Codigo Denominación" />
                                    <asp:BoundField DataField="Denominacion" HeaderText="Denominación Moneda" />
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
