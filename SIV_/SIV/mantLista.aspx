<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFront.Master" AutoEventWireup="true" CodeBehind="mantLista.aspx.cs" Inherits="SIV.mantLista" %>
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

            <div class="row">
                <div class="col-md-6 col-xs-6 text-center">
	                <div class="col-md-12 col-xs-12 text-center">
	        	        <h2>Lista Negra </h2>
	                </div>
	        	    <div class="row">	
	        		    <div class="col-md-8 col-xs-12 text-center">
			                <div class="form-group form-group-lg">
			                    <asp:TextBox ID="txtFiltroRut" runat="server" CssClass="form-control"></asp:TextBox><br />                  
			                </div>
		                </div>
		                <div class="col-md-4 col-xs-12 ">
			                <div class="form-group">
			                    <div class="col-sm-12 text-center">
			                        <div class="checkbox">
			                            <label>
			                                <input type="checkbox"> Es extranjero?
			                            </label>
			                        </div>
			                    </div>
			                </div>
		                </div>
	                </div>
				
				    <div class="row">
					    <div class="col-md-6 col-xs-12 ">
			                <div class="form-group form-group-lg">
			                    <asp:Label ID="Label2" runat="server" CssClass="control-label" Text="Nombre: "></asp:Label>
			                    <asp:TextBox ID="txtfiltroNombre" runat="server" CssClass="form-control"></asp:TextBox><br />
			                </div>
		                </div>                  

					    <div class="col-md-6 col-xs-12 ">
			                <div class="form-group form-group-lg">
			                    <asp:Label ID="Label3" runat="server" CssClass="control-label" Text="Apellido: "></asp:Label></td>
			                    <asp:TextBox ID="txtFiltroApellido" runat="server" CssClass="form-control"></asp:TextBox><br />
			                </div>
		                </div>
	                </div>

                    <div class="row">
                        <div class="col-md-6 col-xs-12 ">
                            <div class="form-group-lg">
	                             <asp:Label ID="Label5" runat="server" CssClass="control-label" Text="Perfil: "></asp:Label>
	                             <asp:DropDownList ID="ddlFiltroPerfil" runat="server" CssClass="form-control"></asp:DropDownList><br />
	                        </div>
                        </div>

                        <div class="col-md-6 col-xs-12 ">
                            <div class="form-group-lg text-left">
	                            <asp:Label ID="Label4" runat="server" CssClass="control-label" Text="Tipo: "></asp:Label></td>
	                            <asp:DropDownList ID="ddlFiltroTipo" runat="server" CssClass="form-control"></asp:DropDownList><br />
	                        </div> 
                        </div>

                    </div>
		                
	            
	                <div class="form-group">
	                  <label>Nota de bloqueo</label>
	                  <textarea id="nota-bloqueo" class="form-control" rows="3" placeholder="Ingrese nota"></textarea>
	                </div>
	            
                    <!--
	                <div class="btn-group-justified" data-toggle="buttons">
						      <label class="btn btn-primary">
						        <input type="radio" autocomplete="off">Vehicular
						      </label>
						      <label class="btn btn-primary">
						        <input type="radio" autocomplete="off">Peatonal
						      </label>						  
				    </div> -->
                    
                    

                    <div class="box-footer">
	                    <div class="row">
	                        <div class="col-md-6 col-xs-6">
	                            <span class="input-group-btn-lg">
	                                <asp:LinkButton ID="lnk_nuevo" runat="server" Text="<i class='glyphicon glyphicon-plus-sign'></i>&nbsp;&nbsp;&nbsp;Nuevo" class="btn btn-primary" OnClick="lnk_nuevo_Click" />
	                            </span>
	                        </div>
	
	                        <div class="col-md-6 col-xs-6">
	                            <span class="input-group-btn-lg">
	                                <asp:LinkButton ID="lnk_buscar" runat="server" Text="<i class='glyphicon glyphicon-search'></i>&nbsp;&nbsp;&nbsp;Buscar" class="btn btn-primary" OnClick="lnk_buscar_Click" />
	                            </span>
	                        </div>
	                    </div>
	                </div>
                               
	            </div>

                <div class="col-md-6">
                  <div class="nav-tabs-custom">
                    <div class="tab-content">
              
                      <div class="tab-pane active" id="Listado">
                        <!-- The timeline -->

		                    <!-- /.box-header -->
		                    <div class="box-body">
		                      <!-- <table id="example2" class="table table-bordered table-striped"> -->
                              <asp:Table ID="tableLista" runat="server" CssClass="table table-bordered table-striped"></asp:Table>
		                        <thead>
		                        <tr>
		                          <th>Rut</th>
		                          <th>Apellido</th>
		                          <th>Nombres</th>
		                          <th>Tipo</th>
		                          <th>Perfil</th>
		                        </tr>
		                        </thead>
		                        <tbody>
		                        <tr>
		                          <td>Trident</td>
		                          <td>Internet
		                            Explorer 4.0
		                          </td>
		                          <td>Win 95+</td>
		                          <td> 4</td>
		                          <td>X</td>
		                        </tr>
		                        <tr>
		                          <td>Trident</td>
		                          <td>Internet
		                            Explorer 5.0
		                          </td>
		                          <td>Win 95+</td>
		                          <td>5</td>
		                          <td>C</td>
		                        </tr>
		                        <tr>
		                          <td>Trident</td>
		                          <td>Internet
		                            Explorer 5.5
		                          </td>
		                          <td>Win 95+</td>
		                          <td>5.5</td>
		                          <td>A</td>
		                        </tr>
		                        <tr>
		                          <td>Trident</td>
		                          <td>Internet
		                            Explorer 6
		                          </td>
		                          <td>Win 98+</td>
		                          <td>6</td>
		                          <td>A</td>
		                        </tr>
		                        <tr>
		                          <td>Trident</td>
		                          <td>Internet Explorer 7</td>
		                          <td>Win XP SP2+</td>
		                          <td>7</td>
		                          <td>A</td>
		                        </tr>
		                        <tr>
		                          <td>Trident</td>
		                          <td>AOL browser (AOL desktop)</td>
		                          <td>Win XP</td>
		                          <td>6</td>
		                          <td>A</td>
		                        </tr>
		                        <tr>
		                          <td>Gecko</td>
		                          <td>Firefox 1.0</td>
		                          <td>Win 98+ / OSX.2+</td>
		                          <td>1.7</td>
		                          <td>A</td>
		                        </tr>
		                        <tr>
		                          <td>Gecko</td>
		                          <td>Firefox 1.5</td>
		                          <td>Win 98+ / OSX.2+</td>
		                          <td>1.8</td>
		                          <td>A</td>
		                        </tr>
		                        <tr>
		                          <td>Gecko</td>
		                          <td>Firefox 2.0</td>
		                          <td>Win 98+ / OSX.2+</td>
		                          <td>1.8</td>
		                          <td>A</td>
		                        </tr>
		                        <tr>
		                          <td>Gecko</td>
		                          <td>Firefox 3.0</td>
		                          <td>Win 2k+ / OSX.3+</td>
		                          <td>1.9</td>
		                          <td>A</td>
		                        </tr>
		                        <tr>
		                          <td>Gecko</td>
		                          <td>Camino 1.0</td>
		                          <td>OSX.2+</td>
		                          <td>1.8</td>
		                          <td>A</td>
		                        </tr>
		                        <tr>
		                          <td>Gecko</td>
		                          <td>Camino 1.5</td>
		                          <td>OSX.3+</td>
		                          <td>1.8</td>
		                          <td>A</td>
		                        </tr>
		                        <tr>
		                          <td>Gecko</td>
		                          <td>Netscape 7.2</td>
		                          <td>Win 95+ / Mac OS 8.6-9.2</td>
		                          <td>1.7</td>
		                          <td>A</td>
		                        </tr>
		                        <tr>
		                          <td>Gecko</td>
		                          <td>Netscape Browser 8</td>
		                          <td>Win 98SE+</td>
		                          <td>1.7</td>
		                          <td>A</td>
		                        </tr>
		                        <tr>
		                          <td>Gecko</td>
		                          <td>Netscape Navigator 9</td>
		                          <td>Win 98+ / OSX.2+</td>
		                          <td>1.8</td>
		                          <td>A</td>
		                        </tr>
		                
		                        </tfoot>
		                      </table>
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
                        <asp:Table ID="table1" runat="server" CssClass="table"></asp:Table>
                        <table class="table">

                            <tbody>
                               
                                <tr>
                                    <td class="col-sm-2 text-right">
                                        <asp:HiddenField ID="hidClId" runat="server" />
                                        <asp:Label ID="lblModRut" runat="server" CssClass="control-label" Text="Rut: "></asp:Label></td>
                                    <td class="col-sm-2">
                                        <asp:TextBox ID="txtModRut" runat="server" CssClass="form-control"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td class="text-right">
                                        <asp:Label ID="lblModNombres" runat="server" CssClass="control-label" Text="Nombres:"></asp:Label></td>
                                    <td class="">
                                        <asp:TextBox ID="txtModNombres" runat="server" CssClass="form-control text-uppercase"></asp:TextBox></td>

                                </tr>
                                  <tr>
                                    <td class="text-right">
                                        <asp:Label ID="lblModApellidos" runat="server" Text="Apellidos:"></asp:Label></td>
                                    <td class="">
                                        <asp:TextBox ID="txtModApellidos" runat="server"  CssClass="form-control text-uppercase"></asp:TextBox></td>

                                </tr>
                                <tr>
                                    <td class="text-right">
                                        <asp:Label ID="lblModMotivo" runat="server" Text="Motivo:"></asp:Label></td>
                                    <td class="">
                                        <asp:TextBox ID="txtModMotivo" runat="server" TextMode="MultiLine" CssClass="form-control text-uppercase"></asp:TextBox></td>

                                </tr>
                                <tr>
                                    <td class="text-right">
                                        <asp:Label ID="lblModTipo" runat="server" CssClass="text-right" Text="Tipo:"></asp:Label></td>
                                    <td class="">
                                        <asp:DropDownList ID="ddlModTipo" runat="server" CssClass="form-control"></asp:DropDownList></td>

                                </tr>
                                <tr>
                                    <td class="text-right">
                                        <asp:Label ID="lblModPerfil" runat="server" CssClass="text-right" Text="Perfil:"></asp:Label></td>
                                    <td class="">
                                         <asp:DropDownList ID="ddlModPerfil" runat="server" CssClass="form-control"></asp:DropDownList></td>

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



            

            <div></div>

        </div>
    </div>

</asp:Content>

