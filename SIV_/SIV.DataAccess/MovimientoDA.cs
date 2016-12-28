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
    public class MovimientoDA
    {
        public static void GuardaMovimiento(Movimiento mov)
        {
            try
            {

                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("movimiento_add");

                acceso.AgregarSqlParametro("@mov_apellidos", mov.apellidos, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@mov_nombres", mov.nombres, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@mov_doc", mov.documento, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@mov_rut", mov.rut, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@mov_id_empresa", mov.id_empresa, SqlDbType.Int);
                acceso.AgregarSqlParametro("@mov_claves_id", mov.id_claves, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@mov_tipo", mov.tipo, SqlDbType.Int);
                acceso.AgregarSqlParametro("@mov_vivienda", mov.id_vivienda, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@mov_residente", mov.rut_residente, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@mov_fecha_salida", mov.fecha_salida, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@mov_claves_id_salida", mov.id_claves_salida, SqlDbType.Int);
                acceso.AgregarSqlParametro("@mov_cerrado", mov.cerrado, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@mov_estacionamiento", mov.id_estacionamiento, SqlDbType.Int);
                acceso.AgregarSqlParametro("@mov_patente", mov.patente, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@mov_reserva_id", mov.id_reserva, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@mov_observaciones", mov.observaciones, SqlDbType.NVarChar);
                
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

        public static List<Movimiento> ObtieneRepMovmiento(Movimiento mov)
        {
            Movimiento m;
            List<Movimiento> lstMov = new List<Movimiento>();
            try
            {

                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("movimiento_get_reporte");
                if (mov.id_empresa != 0)
                {
                    acceso.AgregarSqlParametro("@mov_id_empresa", mov.id_empresa, SqlDbType.Int);
                }
                if (mov.apellidos != "")
                {
                    acceso.AgregarSqlParametro("@mov_apellidos", mov.apellidos, SqlDbType.NVarChar);
                }
                if (mov.tipo != 0)
                {
                    acceso.AgregarSqlParametro("@mov_tipo", mov.tipo, SqlDbType.Int);
                }


                acceso.AbrirSqlConeccion();
                acceso.EjecutarSqlLector();

                while (acceso.SqlLectorDatos.Read())
                {
                    m = new Movimiento();
                    m.serie = Convert.ToInt32(acceso.SqlLectorDatos["mov_serie"].ToString());
                    m.apellidos = acceso.SqlLectorDatos["mov_apellidos"].ToString();
                    m.nombres = acceso.SqlLectorDatos["mov_nombres"].ToString();
                    m.documento = acceso.SqlLectorDatos["mov_doc"].ToString();
                    m.rut = acceso.SqlLectorDatos["mov_rut"].ToString();
                    m.id_empresa = Convert.ToInt32(acceso.SqlLectorDatos["mov_id_empresa"].ToString());
                    m.fecha = acceso.SqlLectorDatos["mov_fecha"].ToString();
                    m.id_claves = Convert.ToInt32(acceso.SqlLectorDatos["mov_claves_id"].ToString());
                    m.tipo = Convert.ToInt32(acceso.SqlLectorDatos["mov_tipo"].ToString());
                    m.id_vivienda = Convert.ToInt32(acceso.SqlLectorDatos["mov_vivienda"].ToString());
                    m.rut_residente = acceso.SqlLectorDatos["mov_residente"].ToString();
                   
                    lstMov.Add(m);
                }
                acceso.CerrarSqlConexion();
            }
            catch (Exception ex)
            {
                Logger.registrarError("Error MovimientoDA.ObtieneRepMovmiento: " + ex);

                return null;
            }
            if (lstMov.Count != 0)
            {
                return lstMov;
            }
            else
            {
                return null;
            }

        }

        public static DataSet ObtieneRepMovimiento(Movimiento mov)
        {
            DataSet ds = new DataSet();
            try
            {

                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("movimiento_get_reporte");
                if (mov.id_empresa != 0)
                {
                    acceso.AgregarSqlParametro("@mov_id_empresa", mov.id_empresa, SqlDbType.Int);
                }
                if (mov.apellidos != "")
                {
                    acceso.AgregarSqlParametro("@mov_apellidos", mov.apellidos, SqlDbType.NVarChar);
                }
                if (mov.tipo != 0)
                {
                    acceso.AgregarSqlParametro("@mov_tipo", mov.tipo, SqlDbType.Int);
                }


                acceso.AbrirSqlConeccion();
                acceso.EjecutarSqlDataset();

                ds = acceso.resultDS;

              
                acceso.CerrarSqlConexion();
            }
            catch (Exception ex)
            {
                Logger.registrarError("Error MovimientoDA.ObtieneRepMovmiento: " + ex);

                return null;
            }

            return ds;
        }



    }
}
