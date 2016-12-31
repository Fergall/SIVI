<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFront.Master" AutoEventWireup="true" CodeBehind="ingPeatonal.aspx.cs" Inherits="SIV.ingPeatonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(document).ready(function () {
            navigator.getUserMedia = navigator.getUserMedia || navigator.webkitGetUserMedia || navigator.mozGetUserMedia;

            var constraints = { audio: false, video: true };
            var video = document.querySelector("video");
            var canvas = document.querySelector("canvas");
            var img = document.querySelector("img");

            function successCallback(stream) {
                window.stream = stream; // stream available to console
                if (window.URL) {
                    video.src = window.URL.createObjectURL(stream);
                } else {
                    video.src = stream;
                }
            }

            function errorCallback(error) {
                console.log("navigator.getUserMedia error: ", error);
            }

            $("#<%=lnkIniciar.ClientID %>").click(function () {
               
                navigator.getUserMedia(constraints, successCallback, errorCallback);
            });

            $("#<%=lnkTerminar.ClientID %>").click(function () {
                var base64 = $("#<%=serverImg.ClientID %>").prop('src');
                alert(base64);

                PageMethods.Upload(base64, onSucess, onError);

                function onSucess(result) {
                    alert(result);

                }

                function onError(result) {
                    alert('Error al procesar.' + result);
                }
            });

            $("#<%=lnkCapturar.ClientID %>").click(function () {
                var ctx = canvas.getContext('2d');
                ctx.drawImage(video, 180, 80, 280, 380, 0, 0, 140, 190);

                //$("#imagen").attr('src', canvas.toDataURL('image/jpeg'));
                $("#<%=serverImg.ClientID %>").attr('src', canvas.toDataURL('image/jpeg'));
                $("#divCanvas").hide();


            });

            //$("#<%=txtModRut.ClientID %>").rut({ formatOn: 'keyup', ignoreControlKeys: false });


           <%-- $("#<%=txtModRut.ClientID %>").keyup(function () {
                this.value = this.value.replace(/[^0-9-K]/g, '');


            });--%>

            $("#<%=txtModRut.ClientID %>").blur(function () {


                if (($("#<%=txtModRut.ClientID %>").val().length > 0) && ($("#<%=txtModRut.ClientID %>").val().length <= 12)) {
                    if (Fn.validaRut($("#<%=txtModRut.ClientID %>").val())) {
                        $("#<%=txtModRut.ClientID %>").removeClass('alert-danger');
                        validaLista();

                    } else {
                        $("#<%=txtModRut.ClientID %>").addClass('alert-danger');

                        alert("Rut no es válido");
                    }
                }
            });

           
        });

       

        function levantaModal() {
            $("#myModal").modal();

        }
        function bajarModal() {
            $('#myModal').modal('hide');
        }

        function levantaModalAlerta(res) {
            var resArray = res.split(";")
            var tipoAlerta = resArray[0];

            if (tipoAlerta == '1') {
                $('#headModAlerta').addClass('alert-danger');
                $('#btnModAlerta1').show();
                $('#btnModAlerta2').hide();
                $("#<%=lnkModGuardar.ClientID %>").addClass('disabled');
                $("#myModal2").modal();
            }
            else if ((tipoAlerta != '1') && (tipoAlerta != '-1')) {
                $('#headModAlerta').removeClass('alert-danger');
                $('#headModAlerta').addClass('alert-warning');
                $('#btnModAlerta1').hide();
                $('#btnModAlerta2').show();
                $("#<%=lnkModGuardar.ClientID %>").removeClass('disabled');
                $("#myModal2").modal();
            }
            else { $("#<%=lnkModGuardar.ClientID %>").removeClass('disabled'); }

        $("#<%=lblModAlerta.ClientID %>").text(resArray[1]);
            $("#<%=lblModAlertaRut.ClientID %>").text(resArray[2]);
            $("#<%=lblModAlertaNombre.ClientID %>").text(resArray[3] + ' ' + resArray[4]);
            $("#<%=lblModAlertaMotivo.ClientID %>").text(resArray[5]);
            $("#<%=lblModAlertaFecha.ClientID %>").text(resArray[6]);



        }
        function bajarModalAlerta() {
            $('#myModal2').modal('hide');
        }



        function validaLista() {

            var rut = document.getElementById('<%=txtModRut.ClientID %>').value;

            PageMethods.validaListaNegra(rut, onSucess, onError);

            function onSucess(result) {
                //alert(result);
                levantaModalAlerta(result);
            }

            function onError(result) {
                alert('Error al procesar.');
            }
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
    
    <div class="content-wrapper">
	<div class="col-md-8 col-sm-offset-2">
	     <div class="box box">
	        <div class="box-body">
	            <div class="row">
	                <div class="col-md-8 col-xs-8">
			            <div class="input-group input-group-lg">		                
                            <div class="input-group input-group-lg">
                                <asp:HiddenField ID="hidId" runat="server" />

                               
                                <asp:TextBox ID="txtModRut" runat="server" CssClass="form-control" placeholder="Ingrese RUT"></asp:TextBox>
                                <span class="input-group-btn">
                                    <asp:LinkButton ID="lnkBtnValidar" runat="server" class="btn btn-info btn-flat" Text="<i class='glyphicon glyphicon-ok'></i>Validar" OnClick="lnkBtnValidar_Click" />
                                    <%--<asp:Button ID="btnValidar" runat="server" Text="<i class='glyphicon glyphicon-floppy-disk'></i>&nbsp;&nbsp;&nbsp;Guardar" />--%>
                                </span>
                            </div>
			            </div>
			        </div> 
			        <div class="col-md-4 col-xs-4">   
			            <div class="form-group">
			                <div class="col-sm-12 text-center">
			                    <div class="checkbox">
			                        <label>
			                            <asp:CheckBox ID="chkRut" runat="server" CssClass="form-horizontal" Text="Rut extranjero" TextAlign="Right" />
			                        </label>
			                    </div>
			                </div>
			            </div>
	            	</div>
	            </div>
					
	
				<div class="row">
					<div class="col-md-6 col-xs-6">
			            <div class="form-group form-group-lg">
			                <asp:Label ID="lblModNombres" runat="server" CssClass="control-label" Text="Nombres: "></asp:Label>
			                <asp:TextBox ID="txtModNombres" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
			            </div>
			            
			            <div class="form-group form-group-lg">
			                <asp:Label ID="lblModUApelllidos" runat="server" CssClass="control-label" Text="Apellidos:"></asp:Label>
			                <asp:TextBox ID="txtModApellidos" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
			            </div>

			            <div class="form-group-lg">
	                        <!-- <label>Edificio</label> -->
                            <asp:Label ID="lblModEstado" runat="server" CssClass="control-label" Text="Estado:"></asp:Label>
	                         <asp:DropDownList ID="ddlModEstado" runat="server" CssClass="form-control text-uppercase"></asp:DropDownList>
	                    </div>

	                    <div class="form-group-lg">
	                        <!-- <label>Depto</label> -->
                            <asp:Label ID="lblModRes" runat="server" Text="Residente:"></asp:Label>
	                        <asp:DropDownList ID="ddlModRes" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlModRes_SelectedIndexChanged"></asp:DropDownList>
	                    </div>

                        <div class="form-group-lg">
	                        <!-- <label>Depto</label> -->
                            <asp:Label ID="lblModViv" runat="server" CssClass="text-right" Text="Vivienda:"></asp:Label>
	                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:DropDownList ID="ddlModViv" runat="server" CssClass="form-control"></asp:DropDownList>
                                </ContentTemplate>
                                <Triggers>

                                    <asp:AsyncPostBackTrigger ControlID="ddlModRes" EventName="SelectedIndexChanged" />

                                </Triggers>
                            </asp:UpdatePanel>
	                    </div>
		            </div>
					

                  

					<div class="col-md-6 col-xs-6 text-center">
			            <div class="box-body box-profile text-centered">
			                <div id="divVideo">
                                <video autoplay width="320" height="240"></video>
                            </div>
                            <div id="divCanvas" class="col-sm-2" style="display: none;">
                                <canvas width="140" height="190"></canvas>
                            </div>  
                            <div id="divImg" class="col-sm-4 text-center" style="display:none">
                                <img id="imagen"  width="140" height="190" />
                                <asp:Image ID="serverImg" Width="140" Height="190" runat="server" />
                            </div>          
			            </div>

			            <div class="row">
			            	<div class="col-md-4 col-xs-4">
			                    <span class="input-group-btn-lg">			                       
                                    <asp:LinkButton ID="lnkIniciar" runat="server" Text="Iniciar" class="btn btn-sm btn-primary btn-block" OnClientClick="return false;" />
			                    </span>
			                </div>

                            <div class="col-md-4 col-xs-4">
			                    <span class="input-group-btn-lg">
			                        <asp:LinkButton ID="lnkTerminar" runat="server" Text="Finalizar" class="btn btn-sm btn-primary btn-block" OnClientClick="return false;" />
			                    </span>
			                </div>
			
			                <div class="col-md-4 col-xs-4">
			                    <span class="input-group-btn-lg">
			                        <asp:LinkButton ID="lnkCapturar" runat="server" Text="Capturar" class="btn btn-sm btn-primary btn-block" OnClientClick="return false;" />
			                    </span>
			                </div>
			            </div>

                        <div class="form-group-lg text-left">
	                        <asp:Label ID="lblModDocumento" runat="server" CssClass="text-right" Text="Documento:"></asp:Label>
	                        <asp:DropDownList ID="ddlModDoc" runat="server" CssClass="form-control"></asp:DropDownList>
	                    </div>    			           
		            </div>
		            
	            </div>
		            	            

	            
	        </div>
	
	        <div class="box-footer">
	            <div class="row">
	                <div class="col-md-6 col-xs-6">
	                   <span class="input-group-btn-lg">
                            <asp:LinkButton ID="lnkModGuardar" runat="server" Text="<i class='glyphicon glyphicon-floppy-disk'></i> Guardar" class="btn-form btn-primary btn-block" OnClick="lnkModGuardar_Click" />
	                   </span> 
	                </div>
	
	                <div class="col-md-6 col-xs-6">
	                    <span class="input-group-btn-lg">
	                        <button type="submit" name="Limpiar" id="limpiar" class="btn-form btn-primary btn-block">
	                            Limpiar
	                        </button>
	                    </span>
	                </div>
	            </div>
	        </div>
	    </div>
	</div> <!-- /container -->

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

                    </div>
                </div>
            </div>

            <!-- Modal -->
            <div class="modal fade" id="myModal2" data-backdrop="static" role="dialog">
                <div class="modal-dialog">

                    <!-- Modal content-->
                    <div class="modal-content">


                        <div id="headModAlerta" class="modal-header">

                            <button type="button" class="close" data-dismiss="modal">×</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModAlerta" runat="server"></asp:Label></h4>
                        </div>

                        <table class="table">

                            <tbody>
                                <tr>
                                    <td class="col-sm-2 text-right">
                                        <asp:HiddenField ID="HiddenField2" runat="server" />
                                        <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="Rut: "></asp:Label></td>
                                    <td class="col-sm-2">
                                        <asp:Label ID="lblModAlertaRut" runat="server" CssClass="form-control"></asp:Label>

                                    </td>
                                </tr>
                                <tr>
                                    <td class="col-sm-2 text-right">
                                        <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="Nombre: "></asp:Label></td>
                                    <td class="col-sm-2">
                                        <asp:Label ID="lblModAlertaNombre" runat="server" CssClass="form-control text-uppercase"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td class="text-right">
                                        <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="Motivo:"></asp:Label></td>
                                    <td class="">
                                        <asp:Label ID="lblModAlertaMotivo" runat="server" CssClass="form-control text-uppercase"></asp:Label></td>

                                </tr>
                                <tr>
                                    <td class="text-right">
                                        <asp:Label ID="Label4" runat="server" Text="Fecha:"></asp:Label></td>
                                    <td class="">
                                        <asp:Label ID="lblModAlertaFecha" runat="server" CssClass="form-control text-uppercase"></asp:Label></td>

                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <div id="btnModAlerta1" class="text-center">
                                            <asp:LinkButton ID="lnkModAlertaOK" runat="server" Text="<i class='glyphicon glyphicon-ok'></i>&nbsp;&nbsp;&nbsp;OK" class="btn btn-primary" OnClientClick="bajarModalAlerta(); bajarModal(); return false;" />
                                        </div>
                                        <div id="btnModAlerta2" class="text-center">
                                            <asp:LinkButton ID="lnkModAlertaCont" runat="server" Text="<i class='glyphicon glyphicon-ok'></i>&nbsp;&nbsp;&nbsp;Continuar ingreso" class="btn btn-primary" OnClientClick="bajarModalAlerta(); return false;" />
                                        </div>
                                    </td>
                                </tr>
                            </tbody>
                        </table>


                    </div>
                </div>
            </div>

            <asp:Table ID="tableClaves" runat="server" CssClass="table table-hover table-condensed"></asp:Table>

            <div></div>
	
	</div>
    

</asp:Content>
