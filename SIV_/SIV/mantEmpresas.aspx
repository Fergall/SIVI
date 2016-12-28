<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFront.Master" AutoEventWireup="true" CodeBehind="mantEmpresas.aspx.cs" Inherits="SIV.mantEmpresas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {

            $("#<%=txtModRut.ClientID %>").rut({ formatOn: 'keyup', ignoreControlKeys: false });
           

            $("#<%=txtModRut.ClientID %>").keyup(function () {
                this.value = this.value.replace(/[^0-9-K]/g, '');


            });

             $("#<%=txtModRut.ClientID %>").blur(function () {
                 if (Fn.validaRut($("#<%=txtModRut.ClientID %>").val())) {
                     $("#<%=txtModRut.ClientID %>").removeClass('alert-danger');
                     
                    
                 } else {
                     $("#<%=txtModRut.ClientID %>").addClass('alert-danger');
                     
                     alert("Rut no es válido");
                 }
             });

             $("#<%=txtModCorreo.ClientID %>").blur(function () {
                 if (validateEmail($("#<%=txtModCorreo.ClientID %>").val())) {
                     $("#<%=txtModCorreo.ClientID %>").removeClass('alert-danger');
                    
                 } else {
                     $("#<%=txtModCorreo.ClientID %>").addClass('alert-danger');
                     
                     alert("Correo no es válido");
                 }
             });




            $("#<%=lnkModGuardar.ClientID %>").click(function () {
                var ret = true;
                
                var cs = $("#<%=txtModRut.ClientID %>").val();
                var cs1 = $("#<%=txtModRazon.ClientID %>").val();
                var cs2 = $("#<%=txtModDir.ClientID %>").val();
                var validRut = Fn.validaRut($("#<%=txtModRut.ClientID %>").val());
                var validCor = validateEmail($("#<%=txtModCorreo.ClientID %>").val());
                
                if (cs == 0)
                 {
                    
                    $("#<%=txtModRut.ClientID %>").addClass('alert-danger');
                   
                 }
                else {       
                    $("#<%=txtModRut.ClientID %>").removeClass('alert-danger');
                    
                }
                 if (cs1 == 0)
                 {
                    
                    $("#<%=txtModRazon.ClientID %>").addClass('alert-danger');
                    
                 }
                else {       
                     $("#<%=txtModRazon.ClientID %>").removeClass('alert-danger');
                    
                 }
                 if (cs2 == 0)
                 {
                    
                    $("#<%=txtModDir.ClientID %>").addClass('alert-danger');
                   
                 }
                else {       
                     $("#<%=txtModDir.ClientID %>").removeClass('alert-danger');
                     
                }

                if ((cs == 0) || (cs1 == 0) || (cs2 == 0) || (validRut == false) || (validCor == false))
                { ret = false;}
                else { ret = true; }

                
                return ret;
                
            });

        });



        function levantaModal() {
            $("#myModal").modal();
        }
        function bajarModal()
        {
            $('#myModal').modal('hide');
        }

       

        function validateEmail(email) {
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        }


        var Fn = {
            // Valida el rut con su cadena completa "XXXXXXXX-X"
            validaRut: function (rutCompleto) {
                if (!/^[0-9]+-[0-9kK]{1}$/.test(rutCompleto))
                    return false;
                var tmp = rutCompleto.split('-');
                var digv = tmp[1];
                var rut = tmp[0];
                if (digv == 'K') digv = 'k';
                return (Fn.dv(rut) == digv);
            },
            dv: function (T) {
                var M = 0, S = 1;
                for (; T; T = Math.floor(T / 10))
                    S = (S + T % 10 * (9 - M++ % 6)) % 11;
                return S ? S - 1 : 'k';
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
            
    <div class="tab-content ">
        <div class="panel container-fluid">
            <br />
            <h2>Mantenedor de empresas</h2>

            <br />
            <div class="panel ">
                <div class="panel-body">

                    <table>
                        <tbody>
                            <tr>
                                <td class="col-sm-2 text-right">
                                    <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="Rut empresa: "></asp:Label></td>
                                <td class="col-sm-2">
                                    <asp:TextBox ID="txtFiltroRut" runat="server" CssClass="form-control"></asp:TextBox><br />

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
                                        <asp:HiddenField ID="hidEmpId" runat="server" />
                                        <asp:Label ID="lblModRut" runat="server" CssClass="control-label" Text="Rut empresa: "></asp:Label></td>
                                    <td class="col-sm-2">
                                        <asp:TextBox ID="txtModRut" runat="server" CssClass="form-control"></asp:TextBox></td>

                                </tr>
                                <tr>
                                    <td class="text-right">
                                        <asp:Label ID="lblModRazon" runat="server" CssClass="control-label" Text="Razón social:"></asp:Label></td>
                                    <td class="">
                                        <asp:TextBox ID="txtModRazon" runat="server" CssClass="form-control text-uppercase"></asp:TextBox></td>

                                </tr>
                                <tr>
                                    <td class="text-right">
                                        <asp:Label ID="lblModDir" runat="server" Text="Dirección:"></asp:Label></td>
                                    <td class="">
                                        <asp:TextBox ID="txtModDir" runat="server" CssClass="form-control text-uppercase"></asp:TextBox></td>

                                </tr>
                                <tr>
                                    <td class="text-right">
                                        <asp:Label ID="lblModCont" runat="server" CssClass="text-right" Text="Contacto:"></asp:Label></td>
                                    <td class="">
                                        <asp:TextBox ID="txtModCont" runat="server" CssClass="form-control text-uppercase"></asp:TextBox></td>

                                </tr>
                                <tr>
                                    <td class="text-right">
                                        <asp:Label ID="lblModCorreo" runat="server" CssClass="text-right" Text="Correo:"></asp:Label></td>
                                    <td class="">
                                        <asp:TextBox ID="txtModCorreo" runat="server" CssClass="form-control"></asp:TextBox></td>

                                </tr>
                                <tr>
                                    <td class="text-right">
                                        <asp:Label ID="lblModFono" runat="server" CssClass="text-right" Text="Teléfono/celular:"></asp:Label></td>
                                    <td class="">
                                        <asp:TextBox ID="txtModFono" runat="server" CssClass="form-control"></asp:TextBox></td>

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



            <asp:Table ID="tableUsuarios" runat="server" CssClass="table table-hover table-condensed"></asp:Table>

            <div></div>

        </div>
    </div>
           
</asp:Content>
