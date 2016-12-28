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
    public class ListaDA
    {
        public static List<Lista> ObtieneListas(Lista list)
        {
            Lista lista;
            List<Lista> lstListas = new List<Lista>();
            try
            {

                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("lista_negra_get");
                if (list.id_empresa != 0)
                {
                    acceso.AgregarSqlParametro("@lista_negra_id_empresa", list.id_empresa, SqlDbType.Int);
                }
                if (list.rut != "")
                {
                    acceso.AgregarSqlParametro("@lista_negra_rut", list.rut, SqlDbType.NVarChar);
                }
                if (list.apellidos != "")
                {
                    acceso.AgregarSqlParametro("@lista_negra_apellidos", list.apellidos, SqlDbType.NVarChar);
                }
                if (list.nombres != "")
                {
                    acceso.AgregarSqlParametro("@lista_negra_nombres", list.nombres, SqlDbType.NVarChar);
                }
                if (list.peatonal)
                {
                    acceso.AgregarSqlParametro("@lista_negra_peatonal", list.peatonal, SqlDbType.Bit);
                }
                if (list.vehicular)
                {
                    acceso.AgregarSqlParametro("@lista_negra_vehicular", list.vehicular, SqlDbType.Bit);
                }
                if (list.nivel != 0)
                {
                    acceso.AgregarSqlParametro("@lista_negra_nivel", list.nivel, SqlDbType.Bit);
                }

                acceso.AbrirSqlConeccion();
                acceso.EjecutarSqlLector();

                while (acceso.SqlLectorDatos.Read())
                {
                    lista = new Lista();
                    lista.id_empresa = Convert.ToInt32(acceso.SqlLectorDatos["lista_negra_id_empresa"].ToString());
                    lista.rut = acceso.SqlLectorDatos["lista_negra_rut"].ToString();
                    lista.apellidos = acceso.SqlLectorDatos["lista_negra_apellidos"].ToString();
                    lista.nombres = acceso.SqlLectorDatos["lista_negra_nombres"].ToString();
                    lista.motivo = acceso.SqlLectorDatos["lista_negra_motivo"].ToString();
                    lista.peatonal = Convert.ToBoolean(acceso.SqlLectorDatos["lista_negra_peatonal"].ToString());
                    lista.vehicular = Convert.ToBoolean (acceso.SqlLectorDatos["lista_negra_vehicular"].ToString());
                    lista.fecha = acceso.SqlLectorDatos["lista_negra_fecha"].ToString();
                    lista.nivel = Convert.ToInt16( acceso.SqlLectorDatos["lista_negra_nivel"].ToString());
                    lstListas.Add(lista);
                }
                acceso.CerrarSqlConexion();
            }
            catch (Exception ex)
            {
                Logger.registrarError("Error ListaDA.ObtieneListas: " + ex);

                return null;
            }
            if (lstListas.Count != 0)
            {
                return lstListas;
            }
            else
            {
                return null;
            }

        }

        public static void GuardaLista(Lista lst)
        {
            try
            {

                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("lista_negra_add");

                acceso.AgregarSqlParametro("@lista_negra_id_empresa", lst.id_empresa, SqlDbType.Int);
                acceso.AgregarSqlParametro("@lista_negra_rut", lst.rut, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@lista_negra_apellidos", lst.apellidos, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@lista_negra_nombres", lst.nombres, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@lista_negra_motivo", lst.motivo, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@lista_negra_peatonal", lst.peatonal, SqlDbType.Bit);
                acceso.AgregarSqlParametro("@lista_negra_vehicular", lst.vehicular, SqlDbType.Bit);
                acceso.AgregarSqlParametro("@lista_negra_nivel", lst.nivel, SqlDbType.Int);

                acceso.AbrirSqlConeccion();
                acceso.EjecutarSqlLector();

                while (acceso.SqlLectorDatos.Read())
                {

                }
                acceso.CerrarSqlConexion();
            }
            catch (Exception ex)
            {
                Logger.registrarError("Error ListaDA.GuardaLista:" + ex);

                //return null;
            }

        }

        public static void ActualizaLista(Lista lst)
        {
            try
            {

                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("lista_negra_upd");

                acceso.AgregarSqlParametro("@lista_negra_id_empresa", lst.id_empresa, SqlDbType.Int);
                acceso.AgregarSqlParametro("@lista_negra_rut", lst.rut, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@lista_negra_apellidos", lst.apellidos, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@lista_negra_nombres", lst.nombres, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@lista_negra_motivo", lst.motivo, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@lista_negra_peatonal", lst.peatonal, SqlDbType.Bit);
                acceso.AgregarSqlParametro("@lista_negra_vehicular", lst.vehicular, SqlDbType.Bit);
                acceso.AgregarSqlParametro("@lista_negra_nivel", lst.nivel, SqlDbType.Int);

                acceso.AbrirSqlConeccion();
                acceso.EjecutarSqlLector();

                while (acceso.SqlLectorDatos.Read())
                {

                }
                acceso.CerrarSqlConexion();
            }
            catch (Exception ex)
            {
                Logger.registrarError("Error ListaDA.ActualizaLista:" + ex);

                //return null;
            }

        }
        public static void EliminaLista(Lista lst)
        {
            try
            {

                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("lista_negra_del");

                acceso.AgregarSqlParametro("@lista_negra_id_empresa", lst.id_empresa, SqlDbType.Int);
                acceso.AgregarSqlParametro("@lista_negra_rut", lst.rut, SqlDbType.NVarChar);
               

                acceso.AbrirSqlConeccion();
                acceso.EjecutarSqlLector();

                while (acceso.SqlLectorDatos.Read())
                {

                }
                acceso.CerrarSqlConexion();
            }
            catch (Exception ex)
            {
                Logger.registrarError("Error ListaDA.EliminaLista:" + ex);

                //return null;
            }

        }
    }
}
