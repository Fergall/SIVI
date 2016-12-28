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
    public class VisitaBS
    {
        public static List<Visita> ObtieneVisitas(Visita vis)
        {
            return VisitaDA.ObtieneVisitas(vis);
        }
        public static void GuardaVisita(Visita vis)
        {
            VisitaDA.GuardaVisita(vis);
        }
    }
}