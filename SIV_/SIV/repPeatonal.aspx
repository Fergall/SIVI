<%@ Page Title="" Language="C#" MasterPageFile="~/MasterFront.Master" AutoEventWireup="true" CodeBehind="repPeatonal.aspx.cs" Inherits="SIV.repPeatonal" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .formulario{
            margin-bottom:20px;
            display: list-item;
            list-style: none;
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
                    <div class="form-horizontal">

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
                   </div>
                </div>
            </div>

          


            <asp:Table ID="tableRes" runat="server" CssClass="table table-hover table-condensed"></asp:Table>

            <div></div>
    </div>
    <script>
        $(function () {
            window.onload = function () {
                var grid = document.getElementById('ContentPlaceHolder1_tableRes');
                var tbody = grid.getElementsByTagName("tbody")[0]; //gets the first and only tbody
                var firstTr = tbody.getElementsByTagName("tr")[0]; //gets the first tr, hopefully contains the th's

                tbody.removeChild(firstTr); //remove tr's from table

                var newTh = document.createElement('thead'); //creates thead
                newTh.appendChild(firstTr); //puts ths in thead
                grid.insertBefore(newTh, tbody); //puts thead behore tbody


                $('#ContentPlaceHolder1_tableRes').DataTable({
                    "paging": true,
                    "lengthChange": false,
                    "searching": true,
                    "ordering": true,
                    "info": true,
                    "autoWidth": true,
                    "pageLength": 6
                });

            }
		  });
		</script>
</asp:Content>
