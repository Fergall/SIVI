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
    <style>
        body {
          padding-top: 40px;
          padding-bottom: 40px;
          background-color: #bcb4de;
          background-image: url('css/img/bg1.jpg');
          background-blend-mode: soft-light;
          background-size:cover;
        }

        .form-signin {
          max-width: 330px;
          padding: 15px;
          margin: 20% auto;
        }
        .form-signin .form-signin-heading,
        .form-signin .checkbox {
          margin-bottom: 10px;
        }
        .form-signin .checkbox {
          font-weight: normal;
        }
        .form-signin .form-control {
          position: relative;
          height: auto;
          -webkit-box-sizing: border-box;
             -moz-box-sizing: border-box;
                  box-sizing: border-box;
          padding: 10px;
          font-size: 16px;
        }
        .form-signin .form-control:focus {
          z-index: 2;
        }
        .form-signin input[type="email"] {
          margin-bottom: -1px;
          border-bottom-right-radius: 0;
          border-bottom-left-radius: 0;
        }
        .form-signin input[type="password"] {
          margin-bottom: 10px;
          border-top-left-radius: 0;
          border-top-right-radius: 0;
        }
    </style>
</asp:Content>
    
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <div class="container">
        <div class="form-signin"> 
            <div class="form-signin-heading">
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
                        <br />

                        <asp:TextBox ID="txtUsuario" class="form-control" runat="server" placeholder="Usuario"></asp:TextBox>
                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsuario" ErrorMessage="*)Ingrese Nombre Usuario"></asp:RequiredFieldValidator>--%>

                        <asp:TextBox ID="txtClave" class="form-control" runat="server" placeholder="Contraseña" TextMode="Password"></asp:TextBox>
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
