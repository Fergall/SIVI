using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SIV.Model;
using SIV.DataAccess;
using SIV.Tools;

namespace SIV.Business
{
    public class ViviendaBS
    {
        public static List<Vivienda> ObtieneViviendas(Vivienda viv)
        {
           
            return ViviendaDA.ObtieneViviendas(viv);
           
        }
        public static List<Vivienda> ObtieneViviendas(Residente res)
        {

            return ViviendaDA.ObtieneViviendas(res);

        }
        public static void GuardaVivienda(Vivienda viv)
        {
            ViviendaBS.GuardaVivienda(viv);
        }

        public static void ActualizaVivienda(Vivienda viv)
        {
            ViviendaBS.ActualizaVivienda(viv);
        }
    }
}
