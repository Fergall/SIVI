using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;

namespace SIV
{
    public partial class MasterAjustes : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = WebConfigurationManager.AppSettings["SystemVersion"];
        }

        protected void lnk_cerrar_sesion_Click(object sender, EventArgs e)
        {

        }
    }
}