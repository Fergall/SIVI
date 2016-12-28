using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIV.Business;
using SIV.Model;
using SIV.Tools;

namespace SIV
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            { Session.Remove("usuario"); }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<Clave> lstClaves = new List<Clave>();
            Clave usuario = new Clave();
            usuario.usuario = txtUsuario.Text;
            usuario.password = txtClave.Text;

            lstClaves = ClaveBS.ObtieneClave(usuario);
            if (lstClaves != null)
            {
                usuario = lstClaves[0];
                Session.Add("usuario", usuario);
                Response.Redirect("home.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "openPopup4", "showalert('Usuario o clave incorrecta','alert-danger');", true);
            }
            
            
            
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "openPopup", "showalert('usuario logueado','alert-success');", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "openPopup2", "showalert('usuario logueado','alert-info');", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "openPopup3", "showalert('usuario logueado','alert-warning');", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "openPopup4", "showalert('usuario logueado','alert-danger');", true);
        }
    }
}