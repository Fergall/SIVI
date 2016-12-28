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
    public class VisitaDA
    {
        public static List<Visita> ObtieneVisitas(Visita vis)
        {
            Visita visita;
            List<Visita> lstVisitas = new List<Visita>();
            try
            {

                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("visita_get");
                if (vis.id_empresa != 0)
                {
                    acceso.AgregarSqlParametro("@visitas_id_empresa", vis.id_empresa, SqlDbType.Int);
                }
                if (vis.rut != "")
                {
                    acceso.AgregarSqlParametro("@visitas_rut", vis.rut, SqlDbType.NVarChar);
                }
                if (vis.apellidos != "")
                {
                    acceso.AgregarSqlParametro("@visitas_apellidos", vis.apellidos, SqlDbType.NVarChar);
                }
                if (vis.nombres != "")
                {
                    acceso.AgregarSqlParametro("@visitas_nombres", vis.nombres, SqlDbType.NVarChar);
                }


                acceso.AbrirSqlConeccion();
                acceso.EjecutarSqlLector();

                while (acceso.SqlLectorDatos.Read())
                {
                    visita = new Visita();
                    visita.id_empresa = Convert.ToInt32(acceso.SqlLectorDatos["visitas_id_empresa"].ToString());
                    visita.rut = acceso.SqlLectorDatos["visitas_rut"].ToString();
                    visita.fecha = acceso.SqlLectorDatos["visitas_fecha"].ToString();
                    visita.apellidos = acceso.SqlLectorDatos["visitas_apellidos"].ToString();
                    visita.nombres = acceso.SqlLectorDatos["visitas_nombres"].ToString();
                    visita.id_claves = Convert.ToInt32(acceso.SqlLectorDatos["visitas_claves_id"].ToString());
                    visita.patente = acceso.SqlLectorDatos["visitas_patente"].ToString();
                    visita.fotografia = acceso.SqlLectorDatos["visitas_fotografia"].ToString();
                    lstVisitas.Add(visita);
                }
                acceso.CerrarSqlConexion();
            }
            catch (Exception ex)
            {
                Logger.registrarError("Error VisitaDA.ObtieneVisitas: " + ex);

                return null;
            }
            if (lstVisitas.Count != 0)
            {
                return lstVisitas;
            }
            else
            {
                return null;
            }

        }

        public static void GuardaVisita(Visita vis)
        {
            try
            {

                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("visita_add");

                acceso.AgregarSqlParametro("@visitas_id_empresa", vis.id_empresa, SqlDbType.Int);
                acceso.AgregarSqlParametro("@visitas_rut", vis.rut, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@visitas_apellidos", vis.apellidos, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@visitas_nombres", vis.nombres, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@visitas_claves_id", vis.id_claves, SqlDbType.Int);
                acceso.AgregarSqlParametro("@visitas_patente", vis.patente, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@visitas_fotografia", vis.fotografia, SqlDbType.VarChar);

                acceso.AbrirSqlConeccion();
                acceso.EjecutarSqlLector();

                while (acceso.SqlLectorDatos.Read())
                {

                }
                acceso.CerrarSqlConexion();
            }
            catch (Exception ex)
            {
                Logger.registrarError("Error VisitaDA.GuardaVisita:" + ex);

                //return null;
            }

        }
    }
}
