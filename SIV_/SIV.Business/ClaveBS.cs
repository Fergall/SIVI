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
    /// <summary>
    /// Clase de logica de negocios para objetos Clave
    /// </summary>
    public class ClaveBS
    {
        /// <summary>
        /// Obtiene uno o todos los usuarios del sitio clave
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static List<Clave> ObtieneClave(Clave usuario)
        {
            List<Clave> lst = new List<Clave>();
            lst = ClaveDA.ObtieneClaves(usuario);
            //Empresa emp;
            if (lst != null)
            {
                foreach (var item in lst)
                {
                    item.empresa = EmpresaDA.ObtieneEmpresas(item.empresa)[0];
                }
            }


            return lst;

        }

        public static void GuardaClave(Clave clave)
        {
            ClaveDA.GuardaClave(clave);
        }

        public static void ActualizaClave(Clave clave)
        {
            ClaveDA.ActualizaClave(clave);
        }
    }
}