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
    public partial class mantEmpresas : System.Web.UI.Page
    {
        Clave usuario = new Clave();
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

            buscarDatos();
           
        }

        protected void lnk_nuevo_Click(object sender, EventArgs e)
        {
            limpiarModal();
            lblModHeader.Text = "Nueva empresa";
            hidEmpId.Value = "0";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "openPopup", "levantaModal();", true);
        }
        protected void lnkModGuardar_Click(object sender, EventArgs e)
        {
            Empresa emp = new Empresa();
            emp.id = Convert.ToInt16(hidEmpId.Value.ToString());
            emp.nombre = txtModRazon.Text.ToUpper();
            emp.direccion = txtModDir.Text.ToUpper();
            emp.telefono = txtModFono.Text;
            emp.correo = txtModCorreo.Text;
            emp.contacto = txtModCont.Text;
            emp.rut = txtModRut.Text;

            if (emp.id == 0)
            {
                EmpresaBS.GuardaEmpresa(emp);
                buscarDatos();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "guardar", "showalert('Se ha guardado la empresa exitosamente', 'alert-success')", true);
            }
            else
            {
                EmpresaBS.ActualizaEmpresa(emp);
                buscarDatos();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "actualizar", "showalert('Se ha actualizado la empresa exitosamente', 'alert-success')", true);

            }
           
           
        }

        protected void lnk_buscar_Click(object sender, EventArgs e)
        {
            buscarDatos();
        }

        private void buscarDatos()
        {
            Empresa emp = new Empresa();
            List<Empresa> listEmpresa = new List<Empresa>();
            emp.rut = txtFiltroRut.Text;
            listEmpresa = EmpresaBS.ObtieneEmpresas(emp);

            creaGrilla(listEmpresa);
        }

        private void creaGrilla(List<Empresa> listEmpresa)
        {

            tableUsuarios.Controls.Clear();
            TableHeaderRow thr;
            TableHeaderCell thc;
            TableRow tr;
            TableCell tc;
            Label lbl;
            LinkButton lnk;
            Literal lit;
            if (listEmpresa != null)
            {

                thr = new TableHeaderRow();

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Rut empresa";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Razón social";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Dirección";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Contacto";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Correo";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Teléfono";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Opciones";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                tableUsuarios.Rows.Add(thr);

                foreach (Empresa item in listEmpresa)
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
                    lbl.Text = item.nombre;
                    tc.Controls.Add(lbl);
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    lbl = new Label();
                    lbl.Text = item.direccion;
                    tc.Controls.Add(lbl);
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    lbl = new Label();
                    lbl.Text = item.contacto;
                    tc.Controls.Add(lbl);
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    lbl = new Label();
                    lbl.Text = item.correo;
                    tc.Controls.Add(lbl);
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    lbl = new Label();
                    lbl.Text = item.telefono;
                    tc.Controls.Add(lbl);
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

                    tc.Controls.Add(lnk);



                    tr.Cells.Add(tc);

                    tableUsuarios.Rows.Add(tr);
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

                tableUsuarios.Rows.Add(thr);

            }
        }

        private void lnk_click(object sender, CommandEventArgs e)
        {
            Empresa emp = new Empresa();
            emp.id = Convert.ToInt32(e.CommandName);

            if (e.CommandArgument.ToString() == "Editar")
            {
                emp = EmpresaBS.ObtieneEmpresa(emp);
                //hidId.Value = "";
                //hidId.Value = usr.id.ToString();
                limpiarModal();
                cargarModal(emp);

                lblModHeader.Text = "Editar empresa";
                //buscarDatos();
            }
        }

        private void cargarModal(Empresa emp)
        {
            hidEmpId.Value = Convert.ToString(emp.id);
            txtModRut.Text = emp.rut;
            txtModRazon.Text = emp.nombre;
            txtModDir.Text = emp.direccion;
            txtModCont.Text = emp.contacto;
            txtModCorreo.Text = emp.correo;
            txtModFono.Text = emp.telefono;
            ScriptManager.RegisterStartupScript(this, this.GetType(), "openPopup", "levantaModal();", true);
        }

        private void limpiarModal()
        {
            hidEmpId.Value = "";
            txtModRut.Text = "";
            txtModRazon.Text = "";
            txtModDir.Text = "";
            txtModCont.Text = "";
            txtModCorreo.Text = "";
            txtModFono.Text = "";
        }
    }
}