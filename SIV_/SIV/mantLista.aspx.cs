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
    public partial class mantLista : System.Web.UI.Page
    {
        Clave usuario = new Clave();
        int nivel;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else
            {
                usuario = (Clave)Session["usuario"];
            }
            nivel = usuario.nivel;

            if (!IsPostBack)
            {
                cargaDdlFiltroTipo();
                cargaDdlFiltroPerfil();
                cargaDdlModPerfil();
            }

            buscarDatos();
        }

        private void buscarDatos()
        {
            Lista lst = new Lista();
            List<Lista> listLst = new List<Lista>();
            lst.id_empresa = usuario.empresa.id;
            lst.rut = txtFiltroRut.Text;
            lst.nombres = txtfiltroNombre.Text;
            lst.apellidos = txtFiltroApellido.Text;
            if (ddlFiltroTipo.SelectedValue == "0")
            {
                lst.peatonal = true;
                lst.vehicular = true;
            }
            else if (ddlFiltroTipo.SelectedValue == "1")
            {
                lst.peatonal = true;
            }
            else if (ddlFiltroTipo.SelectedValue == "2")
            {
                lst.vehicular = true;
            }
            lst.nivel = Convert.ToInt16( ddlFiltroPerfil.SelectedValue);

            listLst = ListaBS.ObtieneListas(lst);
            
            creaGrilla(listLst);
        }

        private void creaGrilla(List<Lista> listLst)
        {
            tableLista.Controls.Clear();
            TableHeaderRow thr;
            TableHeaderCell thc;
            TableRow tr;
            TableCell tc;
            Label lbl;
            LinkButton lnk;
            Literal lit;
            if (listLst != null)
            {

                thr = new TableHeaderRow();

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Rut";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Nombre";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Motivo";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Peatonal";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Vehicular";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Fecha";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Nivel";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Opciones";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                tableLista.Rows.Add(thr);

                foreach (Lista item in listLst)
                {
                    tr = new TableRow();
                    tc = new TableCell();
                    lbl = new Label();
                    lbl.Text = item.rut;
                    tc.Controls.Add(lbl);
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.CssClass = "";
                    lbl = new Label();
                    lbl.Text = item.nombres + " " + item.apellidos;
                    tc.Controls.Add(lbl);
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    lbl = new Label();
                    lbl.Text = item.motivo;
                    tc.Controls.Add(lbl);
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    lbl = new Label();
                    switch (item.peatonal)
                    {
                        case true:
                            lbl.Text = "sí";
                            break;
                        case false:
                            lbl.Text = "no";
                            break;
                    }
                    
                    tc.Controls.Add(lbl);
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    lbl = new Label();
                    switch (item.vehicular)
                    {
                        case true:
                            lbl.Text = "sí";
                            break;
                        case false:
                            lbl.Text = "no";
                            break;
                    }
                    tc.Controls.Add(lbl);
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    lbl = new Label();
                    lbl.Text = item.fecha;
                    tc.Controls.Add(lbl);
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    lbl = new Label();
                    switch (item.nivel)
                    {
                        case 1:
                            lbl.Text = "Imposibilidad de ingreso";
                            break;
                        case 2:
                            lbl.Text = "Consulta autorización de ingreso";
                            break;
                        case 3:
                            lbl.Text = "Acompañar a vivienda";
                            break;
                        case 4:
                            lbl.Text = "Precaución y seguimiento CCTV";
                            break;
                    }

                    tc.Controls.Add(lbl);
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.CssClass = "";
                    lnk = new LinkButton();
                    lnk.ID = "lnkEdit" + item.rut;
                    lnk.CssClass = "btn btn-primary btn-xs";
                    lnk.Text = "<i class='glyphicon glyphicon-pencil'></i>";
                    lnk.CommandArgument = "Editar";
                    lnk.CommandName = item.rut.ToString();
                    lnk.Command += new CommandEventHandler(lnk_click);

                    tc.Controls.Add(lnk);

                    lit = new Literal();
                    lit.Text = "&nbsp;&nbsp;";
                    tc.Controls.Add(lit);
                   
                    lnk = new LinkButton();
                    lnk.ID = "lnkDel" + item.rut;
                    lnk.CssClass = "btn btn-primary btn-xs";
                    lnk.Text = "<i class='glyphicon glyphicon-trash'></i>";
                    lnk.CommandArgument = "Eliminar";
                    lnk.CommandName = item.rut.ToString();
                    lnk.Command += new CommandEventHandler(lnk_click);

                    tc.Controls.Add(lnk);



                    tr.Cells.Add(tc);

                    tableLista.Rows.Add(tr);
                }

            }
            else
            {
                thr = new TableHeaderRow();
                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "No se encontraron registros";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                tableLista.Rows.Add(thr);

            }
        }

        private void lnk_click(object sender, CommandEventArgs e)
        {
            Lista lst = new Lista();
            lst.rut = e.CommandName;
            lst.id_empresa = usuario.empresa.id;

            if (e.CommandArgument.ToString() == "Editar")
            {
                lst = ListaBS.ObtieneListas(lst)[0];
                
                limpiarModal();
                cargarModal(lst);

                lblModHeader.Text = "Editar lista negra";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "openPopup", "levantaModal();", true);

            }
            if(e.CommandArgument.ToString() == "Eliminar")
            {
                ListaBS.EliminaLista(lst);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "guardar", "showalert('Se ha eliminado lista negra exitosamente', 'alert-success')", true);
            }
        }

        private void cargarModal(Lista lst)
        {
            hidClId.Value = lst.rut;
            txtModRut.Text = lst.rut;
            txtModNombres.Text = lst.nombres;
            txtModApellidos.Text = lst.apellidos;
            txtModMotivo.Text = lst.motivo;
            if (lst.peatonal && lst.vehicular)
            {
                ddlModTipo.SelectedValue = "0";
            }
            else if (lst.peatonal && !lst.vehicular)
            {
                ddlModTipo.SelectedValue = "1";
            }
            else if (lst.vehicular && !lst.peatonal)
            {
                ddlModTipo.SelectedValue = "2";
            }

            ddlModPerfil.SelectedValue = lst.nivel.ToString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "openPopup", "levantaModal();", true);
        }

        private void limpiarModal()
        {
            txtModRut.Text = "";
            txtModNombres.Text = "";
            txtModApellidos.Text = "";
            txtModMotivo.Text = "";
            ddlModTipo.SelectedValue = "0";
            ddlModPerfil.SelectedValue = "1";
        }

        private void cargaDdlModPerfil()
        {
            ListItem item;
            ddlModPerfil.Items.Clear();

            item = new ListItem();
            item.Text = "Imposibilidad de ingreso";
            item.Value = "1";
            ddlModPerfil.Items.Add(item);

            item = new ListItem();
            item.Text = "Consulta autorización de ingreso";
            item.Value = "2";
            ddlModPerfil.Items.Add(item);

            item = new ListItem();
            item.Text = "Acompañar a vivienda";
            item.Value = "3";
            ddlModPerfil.Items.Add(item);

            item = new ListItem();
            item.Text = "Precaución y seguimiento CCTV";
            item.Value = "4";
            ddlModPerfil.Items.Add(item);
        }

        private void cargaDdlFiltroPerfil()
        {
            ListItem item;
            ddlFiltroPerfil.Items.Clear();

            item = new ListItem();
            item.Text = "-Todos-";
            item.Value = "0";
            ddlFiltroPerfil.Items.Add(item);

            item = new ListItem();
            item.Text = "No ingresa";
            item.Value = "1";
            ddlFiltroPerfil.Items.Add(item);

            item = new ListItem();
            item.Text = "Consulta autorización de ingreso";
            item.Value = "2";
            ddlFiltroPerfil.Items.Add(item);

            item = new ListItem();
            item.Text = "Acompañar a vivienda";
            item.Value = "3";
            ddlFiltroPerfil.Items.Add(item);

            item = new ListItem();
            item.Text = "Precaución y seguimiento CCTV";
            item.Value = "4";
            ddlFiltroPerfil.Items.Add(item);
        }

        private void cargaDdlFiltroTipo()
        {
            ListItem item;
            ddlFiltroTipo.Items.Clear();
            ddlModTipo.Items.Clear();

            item = new ListItem();
            item.Text = "-Todos-";
            item.Value = "0";
            ddlFiltroTipo.Items.Add(item);
            ddlModTipo.Items.Add(item);

            item = new ListItem();
            item.Text = "Peatonal";
            item.Value = "1";
            ddlFiltroTipo.Items.Add(item);
            ddlModTipo.Items.Add(item);

            item = new ListItem();
            item.Text = "Vehicular";
            item.Value = "2";
            ddlFiltroTipo.Items.Add(item);
            ddlModTipo.Items.Add(item);
        }

        protected void lnk_nuevo_Click(object sender, EventArgs e)
        {
            limpiarModal();
            lblModHeader.Text = "Nueva lista negra";
            hidClId.Value = "0";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "openPopup", "levantaModal();", true);
        }

        protected void lnk_buscar_Click(object sender, EventArgs e)
        {
            buscarDatos();
            //Lista lst = new Lista();
            //List<Lista> lstLista = new List<Lista>();

            //lst.id_empresa = usuario.empresa.id;
            //lst.rut = txtModRut.Text;
            //lst.apellidos = txtModApellidos.Text;
            //lst.nombres = txtModNombres.Text;
            //lst.motivo = txtModMotivo.Text;
            //switch (ddlModTipo.SelectedValue)
            //{
            //    case "0":
            //        lst.peatonal = true;
            //        lst.vehicular = true;
            //        break;
            //    case "1":
            //        lst.peatonal = true;
            //        break;
            //    case "2":
            //        lst.vehicular = true;
            //        break;
            //}
            //lst.nivel = Convert.ToInt16(ddlModPerfil.SelectedValue);

            //lstLista = ListaBS.ObtieneListas(lst);
            //creaGrilla(lstLista);
        }
        protected void lnkModGuardar_Click(object sender, EventArgs e)
        {
            Lista lst = new Lista();
            lst.id_empresa = usuario.empresa.id;
            lst.rut = txtModRut.Text;
            lst.apellidos = txtModApellidos.Text;
            lst.nombres = txtModNombres.Text;
            lst.motivo = txtModMotivo.Text;
            switch (ddlModTipo.SelectedValue)
            {
                case "0":
                    lst.peatonal = true;
                    lst.vehicular = true;
                    break;
                case "1":
                    lst.peatonal = true;
                    break;
                case "2":
                    lst.vehicular = true;
                    break;
            }
            lst.nivel = Convert.ToInt16(ddlModPerfil.SelectedValue);
            if (hidClId.Value == "0")
            {
                ListaBS.GuardaLista(lst);
                buscarDatos();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "guardar", "showalert('Se ha guardado nueva lista negra exitosamente', 'alert-success')", true);
            }
            else
            {
                ListaBS.ActualizaLista(lst);
                buscarDatos();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "actualizar", "showalert('Se ha actualizado lista negra exitosamente', 'alert-success')", true);

            }
           
        }
     }
}