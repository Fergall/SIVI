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
    public partial class mantClaves : System.Web.UI.Page
    {
        int nivel;
        Clave usuario = new Clave();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                Response.Redirect("Default.aspx");
            }
            else {
                usuario = (Clave)Session["usuario"];
            }
            nivel = usuario.nivel; 

            if (!IsPostBack)
            {
                cargaChkBoxList();
                cargaDdlEmp();
                cargaDdlEstado();
                cargaDdlNivel();
            }
           
            buscarDatos();
        }

        private void cargaDdlNivel()
        {
            ListItem li;

            ddlModNivel.Items.Clear();
            li = new ListItem();
            li.Text = "Administrador";
            li.Value = "1";
            ddlModNivel.Items.Add(li);
            li = new ListItem();
            li.Text = "Conserje";
            li.Value = "2";
            ddlModNivel.Items.Add(li);

            if (nivel != 1)
            {
                ddlModNivel.Enabled = false;
            }
        }

        private void cargaDdlEstado()
        {
            ListItem li;

            ddlModEstado.Items.Clear();
            li = new ListItem();
            li.Text = "Vigente";
            li.Value = "V";
            ddlModEstado.Items.Add(li);
            li = new ListItem();
            li.Text = "No vigente";
            li.Value = "N";
            ddlModEstado.Items.Add(li);

            if (nivel != 1)
            {
                ddlModEstado.Enabled = false;
            }
        }

        private void cargaDdlEmp()
        {
            Empresa emp = new Empresa();
            List<Empresa> listEmp = new List<Empresa>();
            ListItem li;
            listEmp = EmpresaBS.ObtieneEmpresas(emp);
            ddlModEmp.Items.Clear();
            foreach (var item in listEmp)
            {
                li = new ListItem();
                li.Text = item.nombre;
                li.Value = item.id.ToString();
                ddlModEmp.Items.Add(li);
            }
            if (nivel != 1)
            {
                ddlModEmp.Enabled = false;
            }
        }

        private void cargaChkBoxList()
        {
            chkLstPermisos.Items.Clear();
            ListItem item;
            item = new ListItem();
            item.Text = "Estacionamiento";
            item.Value = "est";
            chkLstPermisos.Items.Add(item);

            item = new ListItem();
            item.Text = "Lista negra";
            item.Value = "lst";
            chkLstPermisos.Items.Add(item);

            item = new ListItem();
            item.Text = "Residentes";
            item.Value = "res";
            chkLstPermisos.Items.Add(item);

            item = new ListItem();
            item.Text = "Proveedores";
            item.Value = "prov";
            chkLstPermisos.Items.Add(item);

            item = new ListItem();
            item.Text = "Empresa";
            item.Value = "emp";
            chkLstPermisos.Items.Add(item);

            item = new ListItem();
            item.Text = "Vivienda";
            item.Value = "viv";
            chkLstPermisos.Items.Add(item);

            if (nivel!=1)
            {
                chkLstPermisos.Enabled = false;
            }

        }

        protected void lnk_nuevo_Click(object sender, EventArgs e)
        {
            limpiarModal();
            lblModHeader.Text = "Nueva clave";
            hidClId.Value = "0";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "openPopup", "levantaModal();", true);
        }

        protected void lnkModGuardar_Click(object sender, EventArgs e)
        {
            Clave  cl = new Clave();
            
            cl.id = Convert.ToInt16(hidClId.Value.ToString());
            cl.empresa.id = Convert.ToInt16(ddlModEmp.SelectedValue); 
            cl.nombre = txtModNombre.Text;
            cl.usuario = txtModUsuario.Text;
            cl.password = txtModPass.Text;
            cl.nivel = Convert.ToInt16( ddlModNivel.SelectedValue);
            cl.estado = ddlModEstado.SelectedValue;
            foreach (ListItem item in chkLstPermisos.Items)
            {
                switch (item.Value)
                {
                    case "est":
                        if (item.Selected)
                        { cl.permiso_estacionamiento = true; } else { cl.permiso_estacionamiento = false; }
                    break;
                    case "lst":
                        if (item.Selected)
                        { cl.permiso_lista_negra = true; }
                        else { cl.permiso_lista_negra = false; }
                        break;
                    case "res":
                        if (item.Selected)
                        { cl.permiso_residentes = true; }
                        else { cl.permiso_residentes = false; }
                        break;
                    case "prov":
                        if (item.Selected)
                        { cl.permiso_proveedores = true; }
                        else { cl.permiso_proveedores = false; }
                        break;
                    case "emp":
                        if (item.Selected)
                        { cl.permiso_empresas = true; }
                        else { cl.permiso_empresas = false; }
                        break;
                    case "viv":
                        if (item.Selected)
                        { cl.permiso_viviendas = true; }
                        else { cl.permiso_viviendas = false; }
                        break;

                }
            }


           if (cl.id == 0)
            {
                ClaveBS.GuardaClave(cl);
                buscarDatos();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "guardar", "showalert('Se ha guardado la clave exitosamente', 'alert-success')", true);
            }
            else
            {
                ClaveBS.ActualizaClave(cl);
                buscarDatos();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "actualizar", "showalert('Se ha actualizado la clave exitosamente', 'alert-success')", true);

            }


        }

        protected void lnk_buscar_Click(object sender, EventArgs e)
        {
            buscarDatos();
        }

        private void buscarDatos()
        {
            Clave cl = new Clave();
            List<Clave> listClave = new List<Clave>();
            cl.nombre = txtFiltroNombre.Text;
            //cl.empresa.id = 1; //TODO: Dinamizar
            listClave = ClaveBS.ObtieneClave(cl);

            creaGrilla(listClave);
        }

        private void creaGrilla(List<Clave> listClaves)
        {

            tableClaves.Controls.Clear();
            TableHeaderRow thr;
            TableHeaderCell thc;
            TableRow tr;
            TableCell tc;
            Label lbl;
            LinkButton lnk;
            Literal lit;
            if (listClaves != null)
            {

                thr = new TableHeaderRow();

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Nombre";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Usuario";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Permisos";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Opciones";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                tableClaves.Rows.Add(thr);

                var counter = 0;

                foreach (Clave item in listClaves)
                {
                    tr = new TableRow();
                    tc = new TableCell();
                    lbl = new Label();
                    lbl.Text = item.nombre;
                    tc.Controls.Add(lbl);
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.CssClass = "";
                    lbl = new Label();
                    lbl.Text = item.usuario;
                    tc.Controls.Add(lbl);
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    counter = 0;
                    

                    if (item.permiso_estacionamiento)
                    {
                        lbl = new Label();
                        
                        if (counter == 0) {
                            lbl.Text = "Estacionamiento";
                            counter++;
                        }
                       tc.Controls.Add(lbl);
                    }
                    if (item.permiso_lista_negra)
                    {
                        lbl = new Label();
                        lbl.Text = "Lista negra<br/>";
                        if ((counter % 2) == 1)
                        {
                            lbl.Text = ", Lista negra<br/>";
                            counter++;
                        }
                        else {
                            lbl.Text = "Lista negra";
                            counter++;
                        }
                        tc.Controls.Add(lbl);
                    }
                    if (item.permiso_residentes)
                    {
                        lbl = new Label();                       
                        
                        if ((counter % 2) == 1)
                        {
                            lbl.Text = ", Residentes<br/>";
                            counter++;
                        }
                        else
                        {
                            lbl.Text = "Residentes";
                            counter++;
                        }
                        tc.Controls.Add(lbl);

                    }
                    if (item.permiso_proveedores)
                    {
                        lbl = new Label();
                        if ((counter % 2) == 1)
                        {
                            lbl.Text = ", Proveedores<br/>";
                            counter++;
                        }
                        else
                        {
                            lbl.Text = "Proveedores";
                            counter++;
                        }
                        tc.Controls.Add(lbl);
                    }
                    if (item.permiso_empresas)
                    {
                        lbl = new Label();
                        if ((counter % 2) == 1)
                        {
                            lbl.Text = ", Empresas<br/>";
                            counter++;
                        }
                        else
                        {
                            lbl.Text = "Empresas";
                            counter++;
                        }
                        tc.Controls.Add(lbl);
                    }
                    if (item.permiso_viviendas)
                    {
                        lbl = new Label();
                        if ((counter % 2) == 1)
                        {
                            lbl.Text = ", Viviendas<br/>";
                            counter++;
                        }
                        else
                        {
                            lbl.Text = "Viviendas";
                            counter++;
                        }
                        tc.Controls.Add(lbl);
                    }
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.CssClass = "";
                    lnk = new LinkButton();
                    lnk.ID = "lnkEdit" + item.id;
                    lnk.CssClass = "btn btn-primary btn-xs";
                    lnk.Text = "<i class='glyphicon glyphicon-pencil'></i>";
                    lnk.CommandArgument = "Editar";
                    lnk.CommandName = item.id.ToString();
                    lnk.Command += new CommandEventHandler(lnk_click);

                    if (nivel == 1) { tc.Controls.Add(lnk); } //Edita todo
                    if ((nivel == 2) && (usuario.id == item.id)) { tc.Controls.Add(lnk); } //No es admin y solo edita sus datos


                    tr.Cells.Add(tc);

                    tableClaves.Rows.Add(tr);
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

                tableClaves.Rows.Add(thr);

            }
        }

        private void lnk_click(object sender, CommandEventArgs e)
        {
            Clave cl = new Clave();
            cl.id = Convert.ToInt32(e.CommandName);

            if (e.CommandArgument.ToString() == "Editar")
            {
                cl = ClaveBS.ObtieneClave(cl)[0];
                //hidId.Value = "";
                //hidId.Value = usr.id.ToString();
                limpiarModal();
                cargarModal(cl);

                lblModHeader.Text = "Editar clave";
                //buscarDatos();
            }
        }

        private void cargarModal(Clave cl)
        {
            ListItem lstItem;
            hidClId.Value = Convert.ToString(cl.id);
            ddlModEmp.SelectedValue = cl.empresa.id.ToString();
            ddlModNivel.SelectedValue = cl.nivel.ToString();
            txtModNombre.Text = cl.nombre;
            txtModUsuario.Text = cl.usuario;
            txtModPass.Text = cl.password;
            txtModPass2.Text = cl.password;
            
            
            lstItem = new ListItem();
            lstItem = chkLstPermisos.Items.FindByValue("est");
            if (cl.permiso_estacionamiento){ lstItem.Selected = true;} else{lstItem.Selected = false;}
            lstItem = new ListItem();
            lstItem = chkLstPermisos.Items.FindByValue("lst");
            if (cl.permiso_lista_negra) { lstItem.Selected = true; } else { lstItem.Selected = false; }
            lstItem = new ListItem();
            lstItem = chkLstPermisos.Items.FindByValue("res");
            if (cl.permiso_residentes) { lstItem.Selected = true; } else { lstItem.Selected = false; }
            lstItem = new ListItem();
            lstItem = chkLstPermisos.Items.FindByValue("prov");
            if (cl.permiso_proveedores) { lstItem.Selected = true; } else { lstItem.Selected = false; }
            lstItem = new ListItem();
            lstItem = chkLstPermisos.Items.FindByValue("emp");
            if (cl.permiso_empresas) { lstItem.Selected = true; } else { lstItem.Selected = false; }
            lstItem = chkLstPermisos.Items.FindByValue("viv");
            if (cl.permiso_viviendas) { lstItem.Selected = true; } else { lstItem.Selected = false; }

            //if ((nivel != 1) && (usuario.id != cl.id)) //si no es admin y no es sí mismo
            //{
            //    ddlModEmp.Enabled = false;
            //    ddlModNivel.Enabled = false;
            //    txtModNombre.Enabled = false;
            //    txtModUsuario.Enabled = false;
            //    txtModPass.Enabled = false;
            //    txtModPass2.Enabled = false;
            //    foreach (ListItem item in chkLstPermisos.Items)
            //    {
            //        item.Enabled = false;
            //    }
            //}


            ScriptManager.RegisterStartupScript(this, this.GetType(), "openPopup", "levantaModal();", true);
        }

        private void limpiarModal()
        {
            hidClId.Value = "";
            txtModNombre.Text = "";
            txtModUsuario.Text = "";
            txtModPass.Text = "";
            txtModPass2.Text = "";
            foreach (ListItem item in chkLstPermisos.Items)
            {
                item.Selected = false;

            }
           
        }
    }
}
