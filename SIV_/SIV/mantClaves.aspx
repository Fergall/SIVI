<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFront.Master" AutoEventWireup="true" CodeBehind="mantClaves.aspx.cs" Inherits="SIV.mantClaves" %>

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
            <h2>Mantenedor de claves</h2>
            <div class="panel ">
                <div class="panel-body">

                    <table>
                        <tbody>
                            <tr>
                                <td class="col-sm-2 text-right">
                                    <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="Nombre: "></asp:Label></td>
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

                        <div class="box-body">                            
                            <asp:HiddenField ID="hidClId" runat="server" />          

                            <div class="col-md-12 col-xs-12">    
		                        <div class="form-group form-group-lg">
		                            <asp:Label ID="lblModEmp" runat="server" CssClass="control-label" Text="Empresa: "></asp:Label>
		                            <asp:DropDownList ID="ddlModEmp" runat="server" CssClass="form-control"></asp:DropDownList>
		                        </div>
            	            </div>

                            <div class="row">
				                <div class="col-md-6 col-xs-12">    
		                            <div class="form-group form-group-lg">
		                                <asp:Label ID="lblModNombre" runat="server" CssClass="control-label" Text="Nombre: "></asp:Label>
		                                <asp:TextBox ID="txtModNombre" runat="server" CssClass="form-control"></asp:TextBox>
		                            </div>
            	                </div>

            	                <div class="col-md-6 col-xs-12"> 
		                            <div class="form-group form-group-lg">
		                                <asp:Label ID="lblModUsuario" runat="server" CssClass="control-label" Text="Nombre usuario:"></asp:Label>
		                                <asp:TextBox ID="txtModUsuario" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
		                            </div>
		                        </div>
		                    </div>    

			                <div class="row">
				                <div class="col-md-6 col-xs-12"> 
		                            <div class="form-group form-group-lg">
		                                <asp:Label ID="lblModPass" runat="server" Text="Password:"></asp:Label>
		                                <asp:TextBox ID="txtModPass" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
		                            </div>
	                            </div>
	            
	                            <div class="col-md-6 col-xs-12"> 
		                            <div class="form-group form-group-lg">
		                                <asp:Label ID="lblModPass2" runat="server" CssClass="text-right" Text="Repetir password:"></asp:Label>
		                                <asp:TextBox ID="txtModPass2" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
		                            </div>
		                        </div>
			                </div>

                            <div class="row">
				                <div class="col-md-6 col-xs-12"> 
		                            <div class="form-group form-group-lg">
		                                <asp:Label ID="lblModEstado" runat="server" CssClass="text-right" Text="Estado:"></asp:Label>
		                                <asp:DropDownList ID="ddlModEstado" runat="server" CssClass="form-control"></asp:DropDownList>
		                            </div>
	                            </div>
	            
	                            <div class="col-md-6 col-xs-12"> 
		                            <div class="form-group form-group-lg">
		                                <asp:Label ID="lblModNivel" runat="server" CssClass="text-right" Text="Nivel:"></asp:Label>
		                                <asp:DropDownList ID="ddlModNivel" runat="server" CssClass="form-control"></asp:DropDownList>
		                            </div>
		                        </div>
			                </div>
                                        

			                <div class="form-group form-group-lg">
            	                
			
			                    <div class="col-md-4 col-md-offset-4 col-xs-6">
                                    <asp:Label ID="lblModPermisos" runat="server" CssClass="text-right" Text="Permisos:"></asp:Label>
				                    <div class="form-group text-justify">
					                    <asp:CheckBoxList ID="chkLstPermisos" runat="server"></asp:CheckBoxList>   
				                    </div>
			                    </div><!-- col-12 -->
			                </div>
		
                            <div class="box-footer">
                                <div class="row">
                                    <div class="col-md-6 col-xs-6">
                                        <span class="input-group-btn-lg">
                                            <asp:LinkButton ID="lnkModGuardar" runat="server" Text="<i class='glyphicon glyphicon-floppy-disk'></i>&nbsp;&nbsp;&nbsp;Guardar" class="btn btn-primary" OnClick="lnkModGuardar_Click" />
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
                            </div> <!-- box-footer -->
    	                </div><!-- box-body -->

                       
                    </div>
                </div>
            </div>           

            <asp:Table ID="tableClaves" runat="server" CssClass="table table-bordered table-striped"></asp:Table>

            <div></div>

        </div>
    </div>


    <script>
        $(function () {
            window.onload = function () {
                var grid = document.getElementById('ContentPlaceHolder1_tableClaves');
                var tbody = grid.getElementsByTagName("tbody")[0]; //gets the first and only tbody
                var firstTr = tbody.getElementsByTagName("tr")[0]; //gets the first tr, hopefully contains the th's

                tbody.removeChild(firstTr); //remove tr's from table

                var newTh = document.createElement('thead'); //creates thead
                newTh.appendChild(firstTr); //puts ths in thead
                grid.insertBefore(newTh, tbody); //puts thead behore tbody

                $('#ContentPlaceHolder1_tableClaves').DataTable({
                    "paging": true,
                    "lengthChange": false,
                    "searching": false,
                    "ordering": true,
                    "info": true,
                    "autoWidth": true,
                    "pageLength": 2
                });

                $('#tableClaves').DataTable({
                    "paging": true,
                    "lengthChange": false,
                    "searching": false,
                    "ordering": true,
                    "info": true,
                    "autoWidth": true,
                    "pageLength": 6
                });

            }

		    $("#example1").DataTable();
		    $('#example2').DataTable({
		      "paging": true,
		      "lengthChange": false,
		      "searching": true,
		      "ordering": true,
		      "info": true,
		      "autoWidth": true,
		      "pageLength": 6
		    });
		    $('#tableLista').DataTable({
		        "paging": true,
		        "lengthChange": false,
		        "searching": true,
		        "ordering": true,
		        "info": true,
		        "autoWidth": true,
		        "pageLength": 6
		    });

		    

		    $('#example3').DataTable({
		      "paging": true,
		      "lengthChange": false,
		      "searching": true,
		      "ordering": true,
		      "info": true,
		      "autoWidth": true
		    });
		  });
		</script>
</asp:Content>