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
    public partial class mantVivienda : System.Web.UI.Page
    {
        int emp;
        int sesionval;
        protected void Page_Load(object sender, EventArgs e)
        {
            emp = 1; //TODO: dinamizar
            sesionval = 1; //TODO: dinamizar
            if (!IsPostBack)
            {
                cargaDdlTipo();
                
            }

            //buscarDatos();
        }

        private void cargaDdlTipo()
        {
            ddlFiltroNro.Items.Clear();
            ddlModTipo.Items.Clear();
            ListItem item;

            item = new ListItem();
            item.Text = "-Todos-";
            item.Value = "0";
            ddlFiltroNro.Items.Add(item);

            item = new ListItem();
            item.Text = "Departamento";
            item.Value = "Departamento";
            ddlFiltroNro.Items.Add(item);
            ddlModTipo.Items.Add(item);

            item = new ListItem();
            item.Text = "Oficina";
            item.Value = "Oficina";
            ddlFiltroNro.Items.Add(item);
            ddlModTipo.Items.Add(item);

            item = new ListItem();
            item.Text = "Casa";
            item.Value = "Casa";
            ddlFiltroNro.Items.Add(item);
            ddlModTipo.Items.Add(item);

            item = new ListItem();
            item.Text = "Parcela";
            item.Value = "Parcela";
            ddlFiltroNro.Items.Add(item);
            ddlModTipo.Items.Add(item);


        }
        protected void lnk_nuevo_Click(object sender, EventArgs e)
        {
            limpiarModal();
            lblModHeader.Text = "Nueva clave";
            hidId.Value = "0";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "openPopup", "levantaModal();", true);
        }

        private void limpiarModal()
        {
            ddlModTipo.SelectedValue = "Departamento";
            txtModNro.Text = "";
            txtModnombre.Text = "";


        }
        protected void lnkModGuardar_Click(object sender, EventArgs e)
        {
            Vivienda viv = new Vivienda();

            viv.id_empresa = emp;
            viv.tipo = ddlModTipo.SelectedValue;
            viv.numero = Convert.ToInt16( txtModNro.Text);
            
 
        }
    }
}