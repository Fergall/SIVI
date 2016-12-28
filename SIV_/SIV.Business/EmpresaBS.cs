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
    public class EmpresaBS
    {
        /// <summary>
        /// Obtiene lista de empresas
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public static List<Empresa> ObtieneEmpresas(Empresa emp)
        {
            return EmpresaDA.ObtieneEmpresas(emp);
        }
        /// <summary>
        /// Obtiene 1 empresa
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        public static Empresa ObtieneEmpresa(Empresa emp)
        {
            List<Empresa> listEmp = new List<Empresa>();
            listEmp = EmpresaDA.ObtieneEmpresas(emp);
            return listEmp[0];
        }
       
        public static void ActualizaEmpresa(Empresa emp)
        {
            EmpresaDA.ActualizaEmpresa(emp);
        }

        public static void GuardaEmpresa(Empresa emp)
        {
            EmpresaDA.GuardaEmpresa(emp);
        }
    }
}
