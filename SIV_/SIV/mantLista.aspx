﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFront.Master" AutoEventWireup="true" CodeBehind="mantLista.aspx.cs" Inherits="SIV.mantLista" %>
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
            <h3>Mantenedor lista negra</h3>


<div class="row">       
	<div class="col-md-6"> 
        <div class="box box">
            <div class="box-body">

            	<div class="col-md-12 col-xs-12 text-center">
		            <div class="form-group form-group-lg">
		                    <asp:Label ID="Label1" runat="server" CssClass="control-label" Text="Rut: "></asp:Label>
		                    <asp:TextBox ID="txtFiltroRut" runat="server" CssClass="form-control"></asp:TextBox>
		            </div>
	            </div> <!--col 6 -->

            	<div class="col-md-12 col-xs-12 text-center">
		            <div class="form-group form-group-lg">
		                    <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="Nombre: "></asp:Label>
		                    <asp:TextBox ID="txtfiltroNombre" runat="server" CssClass="form-control"></asp:TextBox>
		            </div> 
            	 </div> <!--col 6 --> 
                
                <div class="col-md-12 col-xs-12 text-center">
		            <div class="form-group form-group-lg">
		                    <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="Apellido: "></asp:Label>
		                    <asp:TextBox ID="txtFiltroApellido" runat="server" CssClass="form-control"></asp:TextBox>
		            </div> 
            	 </div> <!--col 6 -->              

                <div class="col-md-12 col-xs-12 text-center">
		            <div class="form-group form-group-lg">
		                    <asp:Label ID="Label4" runat="server" CssClass="control-label" Text="Tipo: "></asp:Label>
		                    <asp:DropDownList ID="ddlFiltroTipo" runat="server" CssClass="form-control"></asp:DropDownList>
		            </div> 
            	 </div> <!--col 6 -->
                
                <div class="col-md-12 col-xs-12 text-center">
		            <div class="form-group form-group-lg">
		                    <asp:Label ID="Label5" runat="server" CssClass="control-label" Text="Perfil: "></asp:Label>
		                    <asp:DropDownList ID="ddlFiltroPerfil" runat="server" CssClass="form-control"></asp:DropDownList>
		            </div> 
            	 </div> <!--col 6 --> 

                <div class="col-md-12 col-xs-12 text-center">
		            <div class="form-group form-group-lg">
		                   <asp:LinkButton ID="lnk_nuevo" runat="server" Text="<i class='glyphicon glyphicon-plus-sign'></i>&nbsp;&nbsp;&nbsp;Nuevo" class="btn btn-primary" OnClick="lnk_nuevo_Click" />
		                    <asp:LinkButton ID="lnk_buscar" runat="server" Text="<i class='glyphicon glyphicon-search'></i>&nbsp;&nbsp;&nbsp;Buscar" class="btn btn-primary" OnClick="lnk_buscar_Click" />
           
		            </div> 
            	 </div> <!--col 6 --> 
       
      
 
       </div>             
	</div> <!-- /container -->        
</div> <!-- col-md-6 -->

<div class="col-md-6">
          <div class="nav-tabs-custom">
            <ul class="nav nav-tabs">
              <li class="active"><a href="#listado" data-toggle="tab">Listado</a></li>             
            </ul>
            <div class="tab-content">
              
              <div class="tab-pane active" id="Listado">
                <!-- The timeline -->

		            <!-- /.box-header -->
		            <div class="box-body">
		              <asp:Table ID="tableLista" runat="server" CssClass="table table-hover table-condensed"></asp:Table>
		            </div>
		            <!-- /.box-body -->
		          
              </div>
              <!-- /.tab-pane -->

            </div>
            <!-- /.tab-content -->
          </div>
          <!-- /.nav-tabs-custom -->
        </div>
        <!-- /.col -->

</div> <!-- /row -->
            

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

                        <div class="box box">
                            <div class="box-body">
	        	                    <div class="row">	
	        		                    <div class="col-md-6 col-xs-12 text-center">
			                                <div class="form-group form-group-lg">
                                                <asp:HiddenField ID="hidClId" runat="server" />
                                                <asp:Label ID="lblModRut" runat="server" CssClass="control-label" Text="Rut: "></asp:Label>
			                                    <asp:TextBox ID="txtModRut" runat="server" CssClass="form-control"></asp:TextBox>                  
			                                </div>
		                                </div>	
                                        
                                        <div class="col-md-6 col-xs-12 text-center">
			                                <div class="form-group-lg">
	                                            <asp:Label ID="lblModPerfil" runat="server" CssClass="text-right" Text="Perfil:"></asp:Label>
	                                            <asp:DropDownList ID="ddlModPerfil" runat="server" CssClass="form-control"></asp:DropDownList>
	                                        </div>
		                                </div>
                                        	                                
	                                </div>
				
				                    <div class="row">
					                    <div class="col-md-6 col-xs-12 ">
			                                <div class="form-group form-group-lg">
			                                    <asp:Label ID="lblModNombres" runat="server" CssClass="control-label" Text="Nombres:"></asp:Label>
			                                    <asp:TextBox ID="txtModNombres" runat="server" CssClass="form-control text-uppercase"></asp:TextBox>
			                                </div>
		                                </div>

					                    <div class="col-md-6 col-xs-12 ">
			                                <div class="form-group form-group-lg">
			                                    <asp:Label ID="lblModApellidos" runat="server" Text="Apellidos:"></asp:Label>
			                                    <asp:TextBox ID="txtModApellidos" runat="server"  CssClass="form-control text-uppercase"></asp:TextBox>
			                                </div>
		                                </div>
	                                </div>
 

	                                <div class="form-group">
	                                  <asp:Label ID="lblModMotivo" runat="server" Text="Motivo:"></asp:Label>
	                                  <asp:TextBox ID="txtModMotivo" runat="server" TextMode="MultiLine" CssClass="form-control text-uppercase"></asp:TextBox>
	                                </div>
	            
	                                <div class="form-group-justified">
						                      <asp:Label ID="lblModTipo" runat="server" CssClass="text-right" Text="Tipo:"></asp:Label>
						                      <asp:DropDownList ID="ddlModTipo" runat="server" CssClass="form-control"></asp:DropDownList>					  
				                    </div>
	            
	            
	            
	            
	                            </div>
	
	                            <div class="box-footer">
	                                <asp:LinkButton ID="lnkModGuardar" runat="server" Text="<i class='glyphicon glyphicon-floppy-disk'></i>&nbsp;&nbsp;&nbsp;Guardar" class="btn btn-primary" OnClick="lnkModGuardar_Click" />
	                            </div>
	                        </div>


                            </div>
                        
                    
                </div>
            </div>

        </div>

    <script>
        $(function () {
            window.onload = function () {
                var grid = document.getElementById('ContentPlaceHolder1_tableLista');
                var tbody = grid.getElementsByTagName("tbody")[0]; //gets the first and only tbody
                var firstTr = tbody.getElementsByTagName("tr")[0]; //gets the first tr, hopefully contains the th's

                tbody.removeChild(firstTr); //remove tr's from table

                var newTh = document.createElement('thead'); //creates thead
                newTh.appendChild(firstTr); //puts ths in thead
                grid.insertBefore(newTh, tbody); //puts thead behore tbody

                $('#ContentPlaceHolder1_tableLista').DataTable({
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

