﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Master1.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SIV.Default" %>
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
          background-color: #bcb4de;
          background-size:cover;
          background-image: url('css/img/bg1.jpg');
          background-blend-mode: soft-light;
          overflow-y: hidden;
          
        }

        .form-signin {
          max-width: 330px;
          padding: 15px;
          margin: 10% auto;
        }
        .form-signin .form-control {
          position: relative;
          height: auto;
          -webkit-box-sizing: border-box;
             -moz-box-sizing: border-box;
                  box-sizing: border-box;
          padding: 10px;
          font-size: 16px;
          border-radius: 30px;
          margin-top:20px;
        }
        .form-signin .form-control:focus {
          z-index: 2;
        }
        input[type="submit"] {
            border-radius: 30px;
            padding:10px;
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
