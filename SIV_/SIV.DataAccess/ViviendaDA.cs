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
    public class ViviendaDA
    {
        public static List<Vivienda> ObtieneViviendas(Vivienda viv)
        {
            Vivienda vivienda;
            List<Vivienda> lstViviendas = new List<Vivienda>();
            try
            {

                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("vivienda_get");
                if (viv.id_empresa != 0)
                {
                    acceso.AgregarSqlParametro("@vivienda_id_empresa", viv.id_empresa, SqlDbType.Int);
                }
                if (viv.tipo != "")
                {
                    acceso.AgregarSqlParametro("@vivienda_tipo", viv.tipo, SqlDbType.NVarChar);
                }
                if (viv.estado != "")
                {
                    acceso.AgregarSqlParametro("@vivienda_estado", viv.estado, SqlDbType.VarChar);
                }
                if (viv.numero != 0)
                {
                    acceso.AgregarSqlParametro("@vivienda_numero", viv.tipo, SqlDbType.Int);
                }
             
               
                acceso.AbrirSqlConeccion();
                acceso.EjecutarSqlLector();

                while (acceso.SqlLectorDatos.Read())
                {
                    vivienda = new Vivienda();
                    vivienda.id = Convert.ToInt32(acceso.SqlLectorDatos["vivienda_id"].ToString());
                    vivienda.id_empresa = Convert.ToInt32(acceso.SqlLectorDatos["vivienda_id_empresa"].ToString());
                    vivienda.tipo = acceso.SqlLectorDatos["vivienda_tipo"].ToString();
                    vivienda.numero = Convert.ToInt32(acceso.SqlLectorDatos["vivienda_numero"].ToString());
                    vivienda.estado = acceso.SqlLectorDatos["vivienda_estado"].ToString();
                    vivienda.id_claves  = Convert.ToInt32( acceso.SqlLectorDatos["vivienda_claves_id"].ToString());
                    vivienda.nombre = acceso.SqlLectorDatos["vivienda_nombre"].ToString();
                    lstViviendas.Add(vivienda);
                }
                acceso.CerrarSqlConexion();
            }
            catch (Exception ex)
            {
                Logger.registrarError("Error ViviendaDA.ObtieneViviendas: " + ex);

                return null;
            }
            if (lstViviendas.Count != 0)
            {
                return lstViviendas;
            }
            else
            {
                return null;
            }

        }

        public static List<Vivienda> ObtieneViviendas(Residente res)
        {
            Vivienda vivienda;
            List<Vivienda> lstViviendas = new List<Vivienda>();
            try
            {

                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("vivienda_get_residente");
                if (res.rut != "0")
                {
                    acceso.AgregarSqlParametro("@resRut", res.rut, SqlDbType.NVarChar);
                }
               


                acceso.AbrirSqlConeccion();
                acceso.EjecutarSqlLector();

                while (acceso.SqlLectorDatos.Read())
                {
                    vivienda = new Vivienda();
                    vivienda.id = Convert.ToInt32(acceso.SqlLectorDatos["vivienda_id"].ToString());
                    vivienda.id_empresa = Convert.ToInt32(acceso.SqlLectorDatos["vivienda_id_empresa"].ToString());
                    vivienda.tipo = acceso.SqlLectorDatos["vivienda_tipo"].ToString();
                    vivienda.numero = Convert.ToInt32(acceso.SqlLectorDatos["vivienda_numero"].ToString());
                    vivienda.estado = acceso.SqlLectorDatos["vivienda_estado"].ToString();
                    vivienda.id_claves = Convert.ToInt32(acceso.SqlLectorDatos["vivienda_claves_id"].ToString());
                    vivienda.nombre = acceso.SqlLectorDatos["vivienda_nombre"].ToString();
                    lstViviendas.Add(vivienda);
                }
                acceso.CerrarSqlConexion();
            }
            catch (Exception ex)
            {
                Logger.registrarError("Error ViviendaDA.ObtieneViviendas: " + ex);

                return null;
            }
            if (lstViviendas.Count != 0)
            {
                return lstViviendas;
            }
            else
            {
                return null;
            }

        }
        public static void GuardaVivienda(Vivienda viv)
        {
            try
            {

                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("vivienda_add");

                acceso.AgregarSqlParametro("@vivienda_id_empresa", viv.id_empresa, SqlDbType.Int);
                acceso.AgregarSqlParametro("@vivienda_tipo", viv.tipo, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@vivienda_numero", viv.numero, SqlDbType.Int);
                acceso.AgregarSqlParametro("@vivienda_estado", viv.estado, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@vivienda_claves_id", viv.id_claves, SqlDbType.VarChar);
                
                acceso.AbrirSqlConeccion();
                acceso.EjecutarSqlLector();

                while (acceso.SqlLectorDatos.Read())
                {

                }
                acceso.CerrarSqlConexion();
            }
            catch (Exception ex)
            {
                Logger.registrarError("Error ViviendaDA.GuardaVivienda:" + ex);

                //return null;
            }

        }
        public static void ActualizaVivienda(Vivienda viv)
        {


            try
            {

                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("vivienda_upd");

                acceso.AgregarSqlParametro("@vivienda_id", viv.id, SqlDbType.Int);
                acceso.AgregarSqlParametro("@vivienda_id_empresa", viv.id_empresa, SqlDbType.Int);
                acceso.AgregarSqlParametro("@vivienda_tipo", viv.tipo, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@vivienda_numero", viv.numero, SqlDbType.Int);
                acceso.AgregarSqlParametro("@vivienda_estado", viv.estado, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@vivienda_claves_id", viv.id_claves, SqlDbType.VarChar);


                acceso.AbrirSqlConeccion();
                acceso.EjecutarSqlLector();

                while (acceso.SqlLectorDatos.Read())
                {

                }
                acceso.CerrarSqlConexion();
            }
            catch (Exception ex)
            {
                Logger.registrarError("Error ViviendaDA.ActualizaVivienda:" + ex);


            }

        }


    }
}
