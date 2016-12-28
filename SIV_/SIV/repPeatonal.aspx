<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFront.Master" AutoEventWireup="true" CodeBehind="repPeatonal.aspx.cs" Inherits="SIV.repPeatonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="tab-content ">
        <div class="panel container-fluid">
            <br />
            <h2>Reporte movimientos</h2>

            <br />
            <div class="panel ">
                <div class="panel-body">

                    <table>
                        <tbody>
                          
                             <tr>
                                <td class="col-sm-2 text-right">
                                    <asp:Label ID="lblFilApellido" runat="server" CssClass="control-label" Text="Apellido: "></asp:Label></td>
                                <td class="col-sm-2">
                                    <asp:TextBox ID="txtFilApellido" runat="server" CssClass="form-control"></asp:TextBox><br />

                                </td>

                            </tr>
                             <tr>
                                <td class="col-sm-2 text-right">
                                    <asp:Label ID="lblFilTipo" runat="server" CssClass="control-label" Text="Tipo: "></asp:Label></td>
                                <td class="col-sm-2">
                                    <asp:DropDownList ID="ddlFilTipo" runat="server" CssClass="form-control"></asp:DropDownList><br />

                                </td>

                            </tr>
                         
                            <tr>
                                <td class="col-sm-2 text-center">
                                    <asp:LinkButton ID="lnk_nuevo" runat="server" Text="<i class='glyphicon glyphicon-download'></i>&nbsp;&nbsp;&nbsp;Excel" class="btn btn-primary" OnClick="lnk_nuevo_Click" />
                                </td>
                                <td class="col-sm-2 text-center">
                                    <asp:LinkButton ID="lnk_buscar" runat="server" Text="<i class='glyphicon glyphicon-search'></i>&nbsp;&nbsp;&nbsp;Buscar" class="btn btn-primary" OnClick="lnk_buscar_Click" />
                                </td>

                            </tr>
                        </tbody>
                    </table>



                </div>
            </div>

          


            <asp:Table ID="tableRes" runat="server" CssClass="table table-hover table-condensed"></asp:Table>

            <div></div>

          

        </div>
    </div>
</asp:Content>
