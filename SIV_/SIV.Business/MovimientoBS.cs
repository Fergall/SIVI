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
    public class MovimientoBS
    {
        public static void GuardaMovimiento(Movimiento mov)
        {

            MovimientoDA.GuardaMovimiento(mov);
        }
        public static List<Movimiento> ObtieneRepMovmiento(Movimiento mov)
        {
            return MovimientoDA.ObtieneRepMovmiento(mov);
        }
        public static DataSet ObtieneRepMovimiento(Movimiento mov)
        {
            return MovimientoDA.ObtieneRepMovimiento(mov);
        }


    }
}

