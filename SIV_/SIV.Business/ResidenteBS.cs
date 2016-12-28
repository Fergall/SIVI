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
    public class ResidenteBS
    {
        public static List<Residente> ObtieneResidentes(Residente res)
        {
            return ResidenteDA.ObtieneResidentes(res);
        }
    }
}
