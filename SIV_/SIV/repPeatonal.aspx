<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFront.Master" AutoEventWireup="true" CodeBehind="repPeatonal.aspx.cs" Inherits="SIV.repPeatonal" EnableEventValidation="true" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .formulario{
            margin-bottom:40px;
            display: list-item;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
            <br />
            <h2>Reporte movimientos</h2>

            <br />
            <div class="panel ">
                <div class="panel-body">
                    <form class="form-horizontal">

                      <div class="form-group formulario">
                        <label class="col-sm-2 control-label">Apellido :</label>
                        <div class="col-sm-10">
                            <asp:TextBox ID="txtFilApellido" runat="server" CssClass="form-control-static"></asp:TextBox>
                        </div>
                      </div>
                      <div class="form-group formulario">
                        <label class="col-sm-2 control-label">Tipo :</label>
                        <div class="col-sm-10">
                            <asp:DropDownList ID="ddlFilTipo" runat="server" CssClass="form-control-static"></asp:DropDownList>
                        </div>
                      </div>
                        
                      <div class="form-group">
                        <div class="col-sm-6">
                            <asp:LinkButton ID="lnk_nuevo" runat="server" Text="<i class='glyphicon glyphicon-download'></i>&nbsp;&nbsp;&nbsp;Excel" class="btn btn-primary" OnClick="lnk_nuevo_Click" />

                            <asp:LinkButton ID="lnk_buscar"  runat="server" Text="<i class='glyphicon glyphicon-search'></i>&nbsp;&nbsp;&nbsp;Buscar" class="btn btn-primary" OnClick="lnk_buscar_Click" />
                        </div>
                      </div>
                   </form>
                </div>
            </div>

          


            <asp:Table ID="tableRes" runat="server" CssClass="table table-hover table-condensed"></asp:Table>

            <div></div>
    </div>
</asp:Content>
