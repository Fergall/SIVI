using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using SIV.Business;
using SIV.Model;
using SIV.Tools;
using System.IO;

namespace SIV
{
    public partial class repPeatonal : System.Web.UI.Page
    {
        int sessionEmp;
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
                sessionEmp = usuario.empresa.id;
            }

            if (!IsPostBack)
            {
                cargaDdlTipo();
            }
        }

        private void cargaDdlTipo()
        {
            ListItem item;
            ddlFilTipo.Items.Clear();

            item = new ListItem();
            item.Text = "-Todos-";
            item.Value = "0";
            ddlFilTipo.Items.Add(item);

            item = new ListItem();
            item.Text = "Peatonal";
            item.Value = "1";
            ddlFilTipo.Items.Add(item);

            item = new ListItem();
            item.Text = "Vehicular";
            item.Value = "2";
            ddlFilTipo.Items.Add(item);

            item = new ListItem();
            item.Text = "Proveedores";
            item.Value = "3";
            ddlFilTipo.Items.Add(item);
        }

        protected void lnk_buscar_Click(object sender, EventArgs e)
        {
            Movimiento m = new Movimiento();
            List<Movimiento> listMovs = new List<Movimiento>();
            m.id_empresa = sessionEmp; 
            m.apellidos = txtFilApellido.Text;
            m.tipo = Convert.ToInt16( ddlFilTipo.SelectedValue);

            listMovs = MovimientoBS.ObtieneRepMovmiento(m);

            creaGrilla(listMovs);
        }

        private void creaGrilla(List<Movimiento> listMovs)
        {

            tableRes.Controls.Clear();
            TableHeaderRow thr;
            TableHeaderCell thc;
            TableRow tr;
            TableCell tc;
            Label lbl;
            LinkButton lnk;
            Literal lit;
            if (listMovs != null)
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
                lbl.Text = "Fecha";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Documento";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                thc = new TableHeaderCell();
                thc.CssClass = "";
                lbl = new Label();
                lbl.Text = "Tipo";
                thc.Controls.Add(lbl);
                thr.Cells.Add(thc);

                tableRes.Rows.Add(thr);

                foreach (Movimiento item in listMovs)
                {
                    tr = new TableRow();
                    tc = new TableCell();
                    lbl = new Label();
                    lbl.Text = item.apellidos + " " + item.nombres;
                    tc.Controls.Add(lbl);
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.CssClass = "";
                    lbl = new Label();
                    lbl.Text = item.fecha;
                    tc.Controls.Add(lbl);
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.CssClass = "";
                    lbl = new Label();
                    lbl.Text = item.documento;
                    tc.Controls.Add(lbl);
                    tr.Cells.Add(tc);

                    tc = new TableCell();
                    tc.CssClass = "";
                    lbl = new Label();
                    switch (item.tipo)
                    {
                        case 1:
                            lbl.Text = "Peatonal";
                            break;
                        case 2:
                            lbl.Text = "Vehicular";
                            break;
                        case 3:
                            lbl.Text = "Proveedores";
                            break;
                    }
                    
                    tc.Controls.Add(lbl);
                    tr.Cells.Add(tc);




                    tableRes.Rows.Add(tr);
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

                tableRes.Rows.Add(thr);

            }
        }

        protected void lnk_nuevo_Click(object sender, EventArgs e)
        {
            Movimiento m = new Movimiento();
            DataSet ds = new DataSet();
            m.id_empresa = sessionEmp;
            m.apellidos = txtFilApellido.Text;
            m.tipo = Convert.ToInt16(ddlFilTipo.SelectedValue);

            ds = MovimientoBS.ObtieneRepMovimiento(m);

            String filename = "Reporte movimientos ";

            HttpResponse response = HttpContext.Current.Response;

            // first let's clean up the response.object
            response.Clear();
            response.Charset = "";

            // set the response mime type for excel
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment;filename=\"" + filename + "\"");
            Response.ContentEncoding = System.Text.Encoding.Unicode;
            Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());


            // create a string writer
            using (System.IO.StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter htw = new HtmlTextWriter(sw))
                {
                    // instantiate a datagrid
                    DataGrid dg = new DataGrid();
                    dg.DataSource = ds.Tables[0];
                    dg.DataBind();
                    dg.RenderControl(htw);
                    response.Write(sw.ToString());
                    response.End();
                }
            }

        }
    }
}