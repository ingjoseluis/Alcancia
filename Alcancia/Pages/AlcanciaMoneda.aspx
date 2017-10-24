<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/Site.Master" AutoEventWireup="true" CodeBehind="AlcanciaMoneda.aspx.cs" Inherits="Alcancia.Pages.AlcanciaMoneda" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Centro de Ahorros</h1>
    <hr />
    <div class="row">
        <div class="col-md-8">
            <section id="loginForm">
                <div class="form-horizontal">                    
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Codigo Ingreso Moneda</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtIdAlcMoneda" CssClass="form-control" TextMode="Number" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Cantidad Moneda</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="txtCantDenominacion" CssClass="form-control" TextMode="Number" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" CssClass="col-md-2 control-label">Denominación Moneda</asp:Label>
                        <div class="col-md-10">
                            <asp:DropDownList runat="server" ID="ddlDenominacion" DataTextField="Denominacion" DataValueField="IdDenominacion" CssClass="form-control"></asp:DropDownList>                            
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" ID="btnGuardar" Text="Guardar" OnClick="btnGuardar_Click" CssClass="btn btn-success" />                            
                            <asp:Button runat="server" ID="btnEliminar" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger" />
                        </div>
                    </div>
                    <hr />
                    <h2>Ahorros Registrados</h2>
                    <div class="form-group">
                        <div class="col-md-10">
                            <asp:GridView runat="server" ID="GridView1" AutoGenerateColumns="false" CssClass="table table-bordered bs-table">
                                <Columns>
                                    <asp:BoundField DataField="IdAlcMoneda" HeaderText="Codigo Ingreso Moneda" />
                                    <asp:BoundField DataField="IdDenominacion" HeaderText="Denominación Moneda" />
                                    <asp:BoundField DataField="CantDenominacion" HeaderText="Cantidad Moneda" />                                    
                                </Columns>
                            </asp:GridView>                            
                        </div>
                    </div>
                    <hr />
                    <h2>Cantidad y Monto por Moneda</h2>
                    <div class="form-group">
                        <div class="col-md-10">
                            <asp:GridView runat="server" ID="GridView2" AutoGenerateColumns="false" CssClass="table table-bordered bs-table">
                                <Columns>
                                    <asp:BoundField DataField="IdDenominacion" HeaderText="Denominación Moneda" />
                                    <asp:BoundField DataField="CantDenominacion" HeaderText="Cantidad Moneda" />
                                    <asp:BoundField DataField="MontoDenominacion" HeaderText="Monto Moneda" />                                    
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <hr />
                    <h2>Cantidad y Monto Total Alcancia</h2>
                    <div class="form-group">
                        <div class="col-md-10">
                            <asp:GridView runat="server" ID="GridView3" AutoGenerateColumns="false" CssClass="table table-bordered bs-table">
                                <Columns>                                    
                                    <asp:BoundField DataField="CantMonedas" HeaderText="Cantidad Total Monedas" />
                                    <asp:BoundField DataField="MontoMonedas" HeaderText="Monto Total Monedas" />                                    
                                </Columns>
                            </asp:GridView>                            
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
