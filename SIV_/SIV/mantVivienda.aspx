<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFront.Master" AutoEventWireup="true" CodeBehind="mantVivienda.aspx.cs" Inherits="SIV.mantVivienda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>



        function levantaModal() {
            $("#myModal").modal();
        }
        function bajarModal() {
            $('#myModal').modal('hide');
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="tab-content ">
        <div class="panel container-fluid">
            <br />
            <h2>Mantenedor de viviendas</h2>

            <br />
            <div class="panel ">
                <div class="panel-body">

                    <table>
                        <tbody>
                            <tr>
                                <td class="col-sm-2 text-right">
                                    <asp:Label ID="lblFiltroTipo" runat="server" CssClass="control-label" Text="Tipo: "></asp:Label></td>
                                <td class="col-sm-2">
                                    <asp:DropDownList ID="ddlFiltroNro" runat="server" CssClass="form-control"></asp:DropDownList><br />

                                </td>

                            </tr>
                            <tr>
                                <td class="col-sm-2 text-right">
                                    <asp:Label ID="lblFiltroNro" runat="server" CssClass="control-label" Text="Número: "></asp:Label></td>
                                <td class="col-sm-2">
                                    <asp:TextBox ID="txtFiltroNro" runat="server" CssClass="form-control"></asp:TextBox><br />

                                </td>

                            </tr>
                            <tr>
                                <td class="col-sm-2 text-right">
                                    <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="Nombre: "></asp:Label></td>
                                <td class="col-sm-2">
                                    <asp:TextBox ID="txtFiltroNombre" runat="server" CssClass="form-control"></asp:TextBox><br />

                                </td>

                            </tr>
                            <tr>
                                <td class="col-sm-2 text-center">
                                    <asp:LinkButton ID="lnk_nuevo" runat="server" Text="<i class='glyphicon glyphicon-plus-sign'></i>&nbsp;&nbsp;&nbsp;Nuevo" class="btn btn-primary" OnClick="lnk_nuevo_Click" />
                                </td>
                                <td class="col-sm-2 text-center">
                                    <asp:LinkButton ID="lnk_buscar" runat="server" Text="<i class='glyphicon glyphicon-search'></i>&nbsp;&nbsp;&nbsp;Buscar" class="btn btn-primary" OnClick="lnk_buscar_Click" />
                                </td>

                            </tr>
                        </tbody>
                    </table>



                </div>
            </div>

            <!-- Modal -->
            <div class="modal fade" id="myModal" data-backdrop="static" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">


                        <div class="modal-header">

                            <button type="button" class="close" data-dismiss="modal">×</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModHeader" runat="server"></asp:Label></h4>
                        </div>
                        <table class="table">

                            <tbody>
                                <tr>
                                      <td class="col-sm-2 text-right">
                                        <asp:HiddenField ID="hidId" runat="server" />
                                        <asp:Label ID="lblModTipo" runat="server" CssClass="control-label" Text="Tipo: "></asp:Label></td>
                                    <td class="col-sm-2">
                                        <asp:DropDownList ID="ddlModTipo" runat="server" CssClass="form-control"></asp:DropDownList>
                                      </td>
                                </tr>
                                <tr>
                                    <td class="col-sm-2 text-right">
                                        <asp:Label ID="lblModNro" runat="server" CssClass="control-label" Text="Número: "></asp:Label></td>
                                    <td class="col-sm-2">
                                        <asp:TextBox ID="txtModNro" runat="server" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="text-right">
                                        <asp:Label ID="lblModNombre" runat="server" CssClass="control-label" Text="Nombre usuario:"></asp:Label></td>
                                    <td class="">
                                        <asp:TextBox ID="txtModnombre" runat="server" CssClass="form-control text-uppercase"></asp:TextBox></td>

                                </tr>
                              

                                <tr>
                                    <td class="text-center" colspan="2">
                                        <asp:LinkButton ID="lnkModGuardar" runat="server" Text="<i class='glyphicon glyphicon-floppy-disk'></i>&nbsp;&nbsp;&nbsp;Guardar" class="btn btn-primary" OnClick="lnkModGuardar_Click" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>



            <asp:Table ID="tableVivienda" runat="server" CssClass="table table-hover table-condensed"></asp:Table>

            <div></div>

        </div>
    </div>

</asp:Content>

