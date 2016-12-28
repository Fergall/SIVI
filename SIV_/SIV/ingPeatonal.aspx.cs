using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SIV.Business;
using SIV.Model;
using SIV.Tools;
using System.Web.Services;
using System.Net;
using System.IO;
using HtmlAgilityPack;
using System.Text;

namespace SIV
{
    public partial class ingPeatonal : System.Web.UI.Page
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
                //cargaResidente();
                //cargaVivienda();
                cargaModRes();
                cargaModVivienda();
                cargaDdlModDocumento();
                cargaDdlModEstado();
                txtModRut.Focus();
               
            }
           
        }

        private void buscarDatos()
        {
            Visita vs = new Visita();
            List<Visita> lstVs = new List<Visita>();
            string rutaImagen = "~\\fotos\\";

            vs.id_empresa = sessionEmp;
            vs.rut = txtModRut.Text;

            lstVs = VisitaBS.ObtieneVisitas(vs);
            if (lstVs != null)
            { 
                txtModNombres.Text = lstVs[0].nombres;
                txtModApellidos.Text = lstVs[0].apellidos;
                rutaImagen += lstVs[0].fotografia;
                serverImg.ImageUrl = rutaImagen;

            }

        }

        private void cargaDdlModEstado()
        {
            ListItem item;
            ddlModEstado.Items.Clear();

            item = new ListItem();
            item.Text = "Vigente";
            item.Value = "Vigente";
            ddlModEstado.Items.Add(item);

            item = new ListItem();
            item.Text = "No vigente";
            item.Value = "No vigente";
            ddlModEstado.Items.Add(item);
        }

        private void cargaDdlModDocumento()
        {
            ListItem item;
            ddlModDoc.Items.Clear();

            item = new ListItem();
            item.Text = "Cedula identidad";
            item.Value = "cedula";
            ddlModDoc.Items.Add(item);

            item = new ListItem();
            item.Text = "Licencia de conducir";
            item.Value = "licencia";
            ddlModDoc.Items.Add(item);

            item = new ListItem();
            item.Text = "Pasaporte";
            item.Value = "pasaporte";
            ddlModDoc.Items.Add(item);

            item = new ListItem();
            item.Text = "Otro";
            item.Value = "otro";
            ddlModDoc.Items.Add(item);


        }

        //private void cargaVivienda()
        //{
        //    Residente r = new Residente();
        //    r.rut = ddlFilResidente.SelectedValue;
        //    r.id_empresa = sessionEmp; 
        //    ListItem vivItem;
        //    List<Vivienda> lstViv = new List<Vivienda>();

        //    lstViv = ViviendaBS.ObtieneViviendas(r);

        //    ddlFilVivienda.Items.Clear();
        //    if(ddlFilResidente.SelectedValue == "0")
        //    {
        //        vivItem = new ListItem();
        //        vivItem.Text = "-Todas-";
        //        vivItem.Value = "0";
        //        ddlFilVivienda.Items.Add(vivItem);

        //    }

        //    foreach (Vivienda item in lstViv) 
        //    {
        //        vivItem = new ListItem();
        //        vivItem.Text = item.tipo + " " + item.nombre + " " + item.numero;
        //        vivItem.Value = item.id.ToString();
        //        ddlFilVivienda.Items.Add(vivItem);

        //    }

        //}

        private void cargaModVivienda()
        {
            Residente r = new Residente();
            r.rut = ddlModRes.SelectedValue;
            r.id_empresa = sessionEmp;
            ListItem vivItem;
            List<Vivienda> lstViv = new List<Vivienda>();

            lstViv = ViviendaBS.ObtieneViviendas(r);


            ddlModViv.Items.Clear();

            if (lstViv != null)
            {

                foreach (Vivienda item in lstViv)
                {
                    vivItem = new ListItem();
                    vivItem.Text = item.tipo + " " + item.nombre + " " + item.numero;
                    vivItem.Value = item.id.ToString();

                    ddlModViv.Items.Add(vivItem);
                }
            }

        }

        //private void cargaResidente()
        //{
        //    Residente r = new Residente();
        //    List<Residente> lstRes = new List<Residente>();
        //    ListItem resItem;
        //    r.id_empresa = sessionEmp;

        //    lstRes = ResidenteBS.ObtieneResidentes(r);

        //    ddlFilResidente.Items.Clear();


        //    resItem = new ListItem();
        //    resItem.Text = "-Todos-";
        //    resItem.Value = "0";
        //    ddlFilResidente.Items.Add(resItem);
        //    foreach (Residente item in lstRes)
        //    {
        //        resItem = new ListItem();
        //        resItem.Text = item.apellido + " " + item.nombre;
        //        resItem.Value = item.rut;

        //        ddlFilResidente.Items.Add(resItem);


        //    }
        //}

        private void cargaModRes()
        {
            Residente r = new Residente();
            List<Residente> lstRes = new List<Residente>();
            ListItem resItem;
            r.id_empresa = sessionEmp;

            lstRes = ResidenteBS.ObtieneResidentes(r);


            ddlModRes.Items.Clear();

            if (lstRes != null)
            {
                foreach (Residente item in lstRes)
                {
                    resItem = new ListItem();
                    resItem.Text = item.apellido + " " + item.nombre;
                    resItem.Value = item.rut;

                    ddlModRes.Items.Add(resItem);

                }
            }
        }

        //private void buscarDatos()
        //{
        //    Visita vis = new Visita();
        //    List<Visita> listVisita = new List<Visita>();
        //    vis.id_empresa = sessionEmp; 
        //    vis.rut = txtFilRut.Text;
        //    vis.apellidos = txtFilApellidos.Text;
        //    vis.nombres = txtFilNombre.Text;

        //    listVisita = VisitaBS.ObtieneVisitas(vis);

        //    creaGrilla(listVisita);
        //}

        //private void creaGrilla(List<Visita> listVisita)
        //{
        //    tableClaves.Controls.Clear();
        //    TableHeaderRow thr;
        //    TableHeaderCell thc;
        //    TableRow tr;
        //    TableCell tc;
        //    Label lbl;
        //    LinkButton lnk;
        //    Literal lit;
        //    if (listVisita != null)
        //    {

        //        thr = new TableHeaderRow();

        //        thc = new TableHeaderCell();
        //        thc.CssClass = "";
        //        lbl = new Label();
        //        lbl.Text = "Rut";
        //        thc.Controls.Add(lbl);
        //        thr.Cells.Add(thc);

        //        thc = new TableHeaderCell();
        //        thc.CssClass = "";
        //        lbl = new Label();
        //        lbl.Text = "Fecha";
        //        thc.Controls.Add(lbl);
        //        thr.Cells.Add(thc);

        //        thc = new TableHeaderCell();
        //        thc.CssClass = "";
        //        lbl = new Label();
        //        lbl.Text = "Apellidos";
        //        thc.Controls.Add(lbl);
        //        thr.Cells.Add(thc);

        //        thc = new TableHeaderCell();
        //        thc.CssClass = "";
        //        lbl = new Label();
        //        lbl.Text = "Nombres";
        //        thc.Controls.Add(lbl);
        //        thr.Cells.Add(thc);

        //        tableClaves.Rows.Add(thr);

        //        foreach (Visita item in listVisita)
        //        {
        //            tr = new TableRow();
        //            tc = new TableCell();
        //            lbl = new Label();
        //            lbl.Text = item.rut;
        //            tc.Controls.Add(lbl);
        //            tr.Cells.Add(tc);

        //            tc = new TableCell();
        //            tc.CssClass = "";
        //            lbl = new Label();
        //            lbl.Text = item.fecha;
        //            tc.Controls.Add(lbl);
        //            tr.Cells.Add(tc);

        //            tc = new TableCell();
        //            tc.CssClass = "";
        //            lbl = new Label();
        //            lbl.Text = item.apellidos;
        //            tc.Controls.Add(lbl);
        //            tr.Cells.Add(tc);

        //            tc = new TableCell();
        //            tc.CssClass = "";
        //            lbl = new Label();
        //            lbl.Text = item.nombres;
        //            tc.Controls.Add(lbl);
        //            tr.Cells.Add(tc);




        //            tableClaves.Rows.Add(tr);
        //        }

        //    }
        //    else
        //    {
        //        thr = new TableHeaderRow();
        //        thc = new TableHeaderCell();
        //        thc.CssClass = "";
        //        lbl = new Label();
        //        lbl.Text = "No se encontraron registros";
        //        thc.Controls.Add(lbl);
        //        thr.Cells.Add(thc);

        //        tableClaves.Rows.Add(thr);

        //    }
        //}


        //protected void lnk_buscar_Click(object sender, EventArgs e)
        //{
        //    buscarDatos();
        //}
        //protected void lnk_nuevo_Click(object sender, EventArgs e)
        //{
        //    //limpiarModal();
        //    lblModHeader.Text = "Nuevo ingreso";
        //    hidId.Value = "0";
        //    ScriptManager.RegisterStartupScript(this, this.GetType(), "openPopup", "levantaModal();", true);
        //}
        protected void lnkModGuardar_Click(object sender, EventArgs e)
        {


            Visita vis = new Visita();
            vis.id_empresa = sessionEmp; 
            vis.rut = txtModRut.Text;
            vis.apellidos = txtModApellidos.Text;
            vis.nombres = txtModNombres.Text;
            vis.id_claves = usuario.id;
            vis.fotografia = Session["filename"].ToString();

            VisitaBS.GuardaVisita(vis);

            Movimiento mov = new Movimiento();
            mov.apellidos = txtModApellidos.Text;
            mov.nombres = txtModNombres.Text;
            mov.documento = ddlModDoc.SelectedValue;
            mov.rut = txtModRut.Text;
            mov.id_empresa = sessionEmp; 
            mov.id_claves = usuario.id;
            mov.tipo = 1; //peatonal
            mov.id_vivienda = Convert.ToInt16(ddlModViv.SelectedValue);
            mov.rut_residente = ddlModRes.SelectedValue;

            MovimientoBS.GuardaMovimiento(mov);


            ScriptManager.RegisterStartupScript(this, GetType(), "guardar", "showalert('Se ha guardado el ingreso exitosamente', 'alert-success')", true);

            txtModRut.Focus();

            buscarDatos();

        }

        protected void ddlFilResidente_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cargaVivienda();

        }
        protected void ddlModRes_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargaModVivienda();
        }
        [WebMethod]
        public static string validaListaNegra(string rut)
        {
            string ret = "";
            string nivelDes = "";
            Lista lst = new Lista();
            List<Lista> lstLista = new List<Lista>();
            lst.rut = rut;

            lstLista = ListaBS.ObtieneListas(lst);
            if (lstLista != null)
            {
                switch (lstLista[0].nivel)
                {
                    case 1:
                        nivelDes = "Imposibilidad de ingreso";
                        break;
                    case 2:
                        nivelDes = "Consulta autorización de ingreso";
                        break;
                    case 3:
                        nivelDes = "Acompañar a vivienda";
                        break;
                    case 4:
                        nivelDes = "Precaución y seguimiento CCTV";
                        break;

                }

                ret = lstLista[0].nivel + ";" + nivelDes + ";" + lstLista[0].rut + ";" + lstLista[0].nombres + ";" + lstLista[0].apellidos + ";" + lstLista[0].motivo + ";" + lstLista[0].fecha;

            }
            else { ret = "-1"; }

            return ret;
            //return "2;Imposibilidad Ingreso;"+ rut + ";Sujeto de prueba;Altamente peligroso;11-12-2016";
        }

        [WebMethod]
        public static void Upload(string base64)
        {
            var parts = base64.Split(new char[] { ',' }, 2);

            string filename = "";
            
            System.Text.StringBuilder sbText = new System.Text.StringBuilder(parts[1], parts[1].Length);

            sbText.Replace("\r\n", String.Empty);
            sbText.Replace(" ", String.Empty);
            sbText.Replace("\"", String.Empty);

            var bytes = Convert.FromBase64String(sbText.ToString());
            filename = string.Format("{0}.jpg", DateTime.Now.Ticks);
            var path = HttpContext.Current.Server.MapPath("~/fotos/"+filename);
            System.IO.File.WriteAllBytes(path, bytes);
            HttpContext.Current.Session.Add("filename", filename);


        }

        protected void lnkBtnValidar_Click(object sender, EventArgs e)
        {
            string source = "";
            string urlAddress = txtModRut.Text;
            txtModRut.Text = "";
            //string urlAddress = "https://portal.sidiv.registrocivil.cl/docstatus?RUN=15766909-5&type=CEDULA&serial=103390800&mrz=103390800484100212410029";
            HttpWebRequest request = null;
            HttpWebResponse response = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(urlAddress);
                response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    string rut = "";
                    string tipoDoc = "";
                    string estado = "";

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    string data = readStream.ReadToEnd();

                    response.Close();
                    readStream.Close();


                    source = WebUtility.HtmlDecode(data);
                    HtmlDocument resultat = new HtmlDocument();
                    resultat.LoadHtml(source);

                    //Extrae datos desde input con rut
                    List<HtmlNode> toftitle = resultat.DocumentNode.Descendants().Where(x => (x.Name == "input" && x.Attributes["id"] != null &&
                    x.Attributes["id"].Value.Contains("form:run"))).ToList();

                    rut = toftitle[0].Attributes[3].Value;

                    //Extrae dato "selected" desde combo (option) con el tipo de documento
                    List<HtmlNode> toftitle1 = resultat.DocumentNode.Descendants().Where(x => (x.Name == "select" && x.Attributes["id"] != null &&
                    x.Attributes["id"].Value.Contains("form:selectDocType"))).ToList();

                    var list = toftitle1[0].Descendants("option").ToList();


                    foreach (var item in list)
                    {
                        if ((item.Attributes.Count > 1) && (item.Attributes["selected"].Value == "selected"))
                        {
                            tipoDoc = item.Attributes["value"].Value;
                        }

                    }

                    //Extrae vigencia desde texto en td
                    List<HtmlNode> toftitle2 = resultat.DocumentNode.Descendants().Where(x => (x.Name == "td" && x.Attributes["class"] != null &&
                    x.Attributes["class"].Value.Contains("setWidthOfSecondColumn"))).ToList();

                    estado = toftitle2[0].InnerText;

                    //Asigna y traduce valores
                    txtModRut.Text = rut;

                    switch (tipoDoc)
                    {
                        case "CEDULA":
                            ddlModDoc.SelectedValue = "cedula";
                            break;
                        case "CEDULA_EXT":
                            ddlModDoc.SelectedValue = "cedula";
                            chkRut.Checked = true;
                            break;
                        case "PASAPORTE_PG":
                            ddlModDoc.SelectedValue = "pasaporte";
                            break;
                        case "PASAPORTE_DIPLOMATICO":
                            ddlModDoc.SelectedValue = "pasaporte";
                            break;
                        case "PASAPORTE_OFICIAL":
                            ddlModDoc.SelectedValue = "pasaporte";
                            break;
                    }

                    ddlModEstado.SelectedValue = estado;
                }
            }
            catch (Exception)
            {
                txtModRut.Text = urlAddress;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "validar", "showalert('Error al validar documento en el registro civil', 'alert-danger')", true);
            }

            if (txtModRut.Text.Length <= 12)
            {
                buscarDatos();
            }                   
            
            }
        }
    }
