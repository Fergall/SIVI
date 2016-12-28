using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using SIV.Model;
using SIV.Tools;

namespace SIV.DataAccess
{
    public class ResidenteDA
    {
        public static List<Residente> ObtieneResidentes(Residente res)
        {
            Residente r;
            List<Residente> lstResidentes = new List<Residente>();
            try
            {

                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("residente_get");
                if (res.id_empresa != 0)
                {
                    acceso.AgregarSqlParametro("@res_id_empresa", res.id_empresa, SqlDbType.Int);
                }
                if (res.rut != null)
                {
                    acceso.AgregarSqlParametro("@res_rut", res.rut, SqlDbType.NVarChar);
                }
                if (res.nombre != null)
                {
                    acceso.AgregarSqlParametro("@res_nombre", res.nombre, SqlDbType.NVarChar);
                }
                if (res.apellido != null)
                {
                    acceso.AgregarSqlParametro("@res_apellidos", res.apellido, SqlDbType.NVarChar);
                }
                if (res.estado != null)
                {
                    acceso.AgregarSqlParametro("@res_estado", res.estado, SqlDbType.NVarChar);
                }


                acceso.AbrirSqlConeccion();
                acceso.EjecutarSqlLector();

                while (acceso.SqlLectorDatos.Read())
                {
                    r = new Residente();

                    r.fecha =acceso.SqlLectorDatos["res_fecha"].ToString();
                    r.id_empresa = Convert.ToInt32(acceso.SqlLectorDatos["res_id_empresa"].ToString());
                    r.rut = acceso.SqlLectorDatos["res_rut"].ToString();
                    r.nombre = acceso.SqlLectorDatos["res_nombre"].ToString();
                    r.apellido = acceso.SqlLectorDatos["res_apellidos"].ToString();
                    r.estado = acceso.SqlLectorDatos["res_estado"].ToString();
                    r.id_claves = Convert.ToInt32(acceso.SqlLectorDatos["res_claves_id"].ToString());
                    r.id_estacionamiento = Convert.ToInt32(acceso.SqlLectorDatos["res_estacionamiento"].ToString());
                    r.id_vivienda = Convert.ToInt32(acceso.SqlLectorDatos["res_vivienda"].ToString());

                    lstResidentes.Add(r);
                }
                acceso.CerrarSqlConexion();
            }
            catch (Exception ex)
            {
                Logger.registrarError("Error ResidenteDA.ObtieneResidentes: " + ex);

                return null;
            }
            if (lstResidentes.Count != 0)
            {
                return lstResidentes;
            }
            else
            {
                return null;
            }

        }
    }
}
