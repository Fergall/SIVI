using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HtmlAgilityPack;

namespace SIV
{
    public partial class testing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string source = "";
            string urlAddress = "https://portal.sidiv.registrocivil.cl/docstatus?RUN=15766909-5&type=CEDULA&serial=103390800&mrz=103390800484100212410029";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAddress);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

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

                string rut = toftitle[0].Attributes[3].Value;

                //Extrae dato "selected" desde combo (option) con el tipo de documento
                List<HtmlNode> toftitle1 = resultat.DocumentNode.Descendants().Where(x => (x.Name == "select" && x.Attributes["id"] != null &&
                x.Attributes["id"].Value.Contains("form:selectDocType"))).ToList();

                var list = toftitle1[0].Descendants("option").ToList();


                foreach (var item in list)
                {
                    if ((item.Attributes.Count>1) && ( item.Attributes["selected"].Value == "selected"))
                    {
                        string tipoDoc = item.Attributes["value"].Value;
                    }
                    
                }

                //Extrae vigencia desde texto en td
                List<HtmlNode> toftitle2 = resultat.DocumentNode.Descendants().Where(x => (x.Name == "td" && x.Attributes["class"] != null &&
                x.Attributes["class"].Value.Contains("setWidthOfSecondColumn"))).ToList();

                string title = toftitle2[0].InnerText;
            }
        }
    }
}