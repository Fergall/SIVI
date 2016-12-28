using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using SIV.Model;

namespace SIV
{
    public partial class MasterFront : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Clave usuario = new Clave();

            Page.Title = WebConfigurationManager.AppSettings["SystemVersion"];

            if (Session["usuario"] != null)
            {

                usuario = (Clave)Session["usuario"];
                lblNombreUsuario.Text = usuario.nombre;
                lblArea.Text = usuario.empresa.nombre;
                    
            }
        }

        protected void lnk_cerrar_sesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }
    }
}