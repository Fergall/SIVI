using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIV.Model;
using SIV.DataAccess;
using SIV.Tools;

namespace SIV.Business
{
    public class ListaBS
    {
        public static List<Lista> ObtieneListas(Lista list)
        {
            return ListaDA.ObtieneListas(list);
        }
        public static void GuardaLista(Lista lst)
        {
            ListaDA.GuardaLista(lst);
        }
        public static void ActualizaLista(Lista lst)
        {
            ListaDA.ActualizaLista(lst);
        }
        public static void EliminaLista(Lista lst)
        {
            ListaDA.EliminaLista(lst);
        }



        }
}
