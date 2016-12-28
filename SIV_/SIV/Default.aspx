<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SIV.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(window).ready(function () {

          
            $('#<%=btnIniciarSesion.ClientID %>').on('click', function () {
                var retorno;
                if ($('#<%=txtUsuario.ClientID %>').val() == '') {
                    bootstrap_alert.warning('Debe ingresar su usuario', 'alert-danger');
                    $('#<%=txtUsuario.ClientID %>').addClass('alert-danger');
                    retorno = false;
                }
                else
                {
                    $('#<%=txtUsuario.ClientID %>').removeClass('alert-danger');
                }
                 if ($('#<%=txtClave.ClientID %>').val() == '') {
                     bootstrap_alert.warning('Debe ingresar su clave', 'alert-danger');
                      $('#<%=txtClave.ClientID %>').addClass('alert-danger');
                     retorno = false;
                }
                else
                {
                     $('#<%=txtClave.ClientID %>').removeClass('alert-danger');
                }
              
               return retorno;
        });
            
           
        });

    </script>

</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <div class="row">
        <div class="col-md-4 col-md-offset-4 text-center"> 
            <div class="divImagen">
                <div>
                    <img style="width: 100%;"  src="css/img/siv-DESA.png" />
                </div>         
            </div>
            <script type="text/javascript">
                $(function () {
                    $('#slider div:gt(0)').hide();
                    setInterval(function () {
                        $('#slider div:first-child').fadeOut(1000)
                        .next('div').fadeIn(1000)
                        .end().appendTo('#slider');
                    }, 3000);
                })

            </script>
            <asp:UpdatePanel ID ="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div id="formularioSesion" class="divLogin">
                        <h2>Bienvenido</h2>
                        <h3 class="tiposesion">Por favor inicie sesión</h3>
                        <br />

                        <asp:TextBox ID="txtUsuario" class="form-control" runat="server" placeholder="&#128273; Usuario"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsuario" ErrorMessage="*)Ingrese Nombre Usuario"></asp:RequiredFieldValidator>--%>
                        <br />

                        <asp:TextBox ID="txtClave" class="form-control" runat="server" placeholder="&#128274; Contraseña" TextMode="Password"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtClave" ErrorMessage="*)Ingrese Password"></asp:RequiredFieldValidator>--%>
                        <br />

                        <asp:Button ID="btnIniciarSesion" class="btn btn-sm btn-primary btn-block" runat="server" OnClick="Button1_Click" Text="Ingresar" />
                        <br />
                        <%--<br />--%>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
                <%-- <div id="menu">
                </div>--%>
            </div>
    </div>
</asp:Content>
