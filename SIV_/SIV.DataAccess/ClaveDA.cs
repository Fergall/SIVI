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
    /// <summary>
    /// Clase de acceso de datos para objetos Clave
    /// </summary>
    public class ClaveDA
    {
        /// <summary>
        /// Obtiene uno o todos los usuarios del sitio clave
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        public static List<Clave> ObtieneClaves(Clave usuario)
        {
            Clave cl;
            List<Clave> lstClaves = new List<Clave>();
            try
            {

                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("claves_get_usuarios");
                if (usuario.id != 0)
                {
                    acceso.AgregarSqlParametro("@claves_id", usuario.id, SqlDbType.Int);
                }
                if (usuario.empresa.id != 0)
                {
                    acceso.AgregarSqlParametro("@claves_id_empresa", usuario.empresa.id, SqlDbType.Int);
                }
                if (usuario.estado != null)
                {
                    acceso.AgregarSqlParametro("@claves_estado", usuario.estado, SqlDbType.VarChar);
                }
                if (usuario.nivel != 0)
                {
                    acceso.AgregarSqlParametro("@claves_nivel", usuario.nivel, SqlDbType.Int);
                }
                if (usuario.nombre != null)
                {

                    acceso.AgregarSqlParametro("@claves_nombre", usuario.nombre, SqlDbType.NVarChar);
                }
                if (usuario.usuario != null)
                {
                    acceso.AgregarSqlParametro("@claves_username", usuario.usuario, SqlDbType.VarChar);
                }
                if (usuario.password != null)
                {
                    acceso.AgregarSqlParametro("@claves_password", usuario.password, SqlDbType.VarChar);
                }

                acceso.AbrirSqlConeccion();
                acceso.EjecutarSqlLector();

                while (acceso.SqlLectorDatos.Read())
                {
                    cl = new Clave();
                    cl.id = Convert.ToInt32(acceso.SqlLectorDatos["claves_id"].ToString());
                    cl.empresa.id = Convert.ToInt32(acceso.SqlLectorDatos["claves_id_empresa"].ToString());
                    cl.estado = acceso.SqlLectorDatos["claves_estado"].ToString();
                    cl.nivel = Convert.ToInt32(acceso.SqlLectorDatos["claves_nivel"].ToString());
                    cl.nombre = acceso.SqlLectorDatos["claves_nombre"].ToString();
                    cl.usuario = acceso.SqlLectorDatos["claves_username"].ToString();
                    cl.password = acceso.SqlLectorDatos["claves_password"].ToString();
                    cl.permiso_estacionamiento = Convert.ToBoolean(acceso.SqlLectorDatos["claves_estacionamiento"].ToString());
                    cl.permiso_residentes = Convert.ToBoolean(acceso.SqlLectorDatos["claves_residentes"].ToString());
                    cl.permiso_lista_negra = Convert.ToBoolean(acceso.SqlLectorDatos["claves_listanegra"].ToString());
                    cl.permiso_proveedores = Convert.ToBoolean(acceso.SqlLectorDatos["claves_proveedores"].ToString());
                    cl.permiso_empresas = Convert.ToBoolean(acceso.SqlLectorDatos["claves_empresa"].ToString());
                    cl.permiso_viviendas = Convert.ToBoolean(acceso.SqlLectorDatos["claves_vivienda"].ToString());
                    lstClaves.Add(cl);
                }
                acceso.CerrarSqlConexion();
            }
            catch (Exception ex)
            {
                Logger.registrarError("Error UsuarioDA: " + ex);

                return null;
            }
            if (lstClaves.Count != 0)
            {
                return lstClaves;
            }
            else
            {
                return null;
            }

        }
        public static void GuardaClave(Clave clave)
        {
            
            List<Clave> lstClaves = new List<Clave>();
            try
            {

                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("clave_add");

                acceso.AgregarSqlParametro("@claves_id_empresa", clave.empresa.id, SqlDbType.Int);
                acceso.AgregarSqlParametro("@claves_estado", clave.estado, SqlDbType.VarChar);
                acceso.AgregarSqlParametro("@claves_nivel", clave.nivel, SqlDbType.Int);
                acceso.AgregarSqlParametro("@claves_nombre", clave.nombre, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@claves_username", clave.usuario, SqlDbType.VarChar);
                acceso.AgregarSqlParametro("@claves_password", clave.password, SqlDbType.VarChar);
                acceso.AgregarSqlParametro("@claves_estacionamiento", clave.permiso_estacionamiento, SqlDbType.Bit);
                acceso.AgregarSqlParametro("@claves_residentes", clave.permiso_residentes, SqlDbType.Bit);
                acceso.AgregarSqlParametro("@claves_listanegra", clave.permiso_lista_negra, SqlDbType.Bit);
                acceso.AgregarSqlParametro("@claves_proveedores", clave.permiso_proveedores, SqlDbType.Bit);
                acceso.AgregarSqlParametro("@claves_empresa", clave.permiso_empresas, SqlDbType.Bit);
                acceso.AgregarSqlParametro("@claves_vivienda", clave.permiso_viviendas, SqlDbType.Bit);

                acceso.AbrirSqlConeccion();
                acceso.EjecutarSqlLector();

                while (acceso.SqlLectorDatos.Read())
                {
                   
                }
                acceso.CerrarSqlConexion();
            }
            catch (Exception ex)
            {
                Logger.registrarError("Error UsuarioDA.GuardaClave:" + ex);

                //return null;
            }
            
        }
        public static void ActualizaClave(Clave clave)
        {

           
            try
            {

                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("clave_upd");

                acceso.AgregarSqlParametro("@claves_id_empresa", clave.empresa.id, SqlDbType.Int);
                acceso.AgregarSqlParametro("@claves_id", clave.id, SqlDbType.Int);
                acceso.AgregarSqlParametro("@claves_estado", clave.estado, SqlDbType.VarChar);
                acceso.AgregarSqlParametro("@claves_nivel", clave.nivel, SqlDbType.Int);
                acceso.AgregarSqlParametro("@claves_nombre", clave.nombre, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@claves_username", clave.usuario, SqlDbType.VarChar);
                acceso.AgregarSqlParametro("@claves_password", clave.password, SqlDbType.VarChar);
                acceso.AgregarSqlParametro("@claves_estacionamiento", clave.permiso_estacionamiento, SqlDbType.Bit);
                acceso.AgregarSqlParametro("@claves_residentes", clave.permiso_residentes, SqlDbType.Bit);
                acceso.AgregarSqlParametro("@claves_listanegra", clave.permiso_lista_negra, SqlDbType.Bit);
                acceso.AgregarSqlParametro("@claves_proveedores", clave.permiso_proveedores, SqlDbType.Bit);
                acceso.AgregarSqlParametro("@claves_empresa", clave.permiso_empresas, SqlDbType.Bit);
                acceso.AgregarSqlParametro("@claves_vivienda", clave.permiso_viviendas, SqlDbType.Bit);


                acceso.AbrirSqlConeccion();
                acceso.EjecutarSqlLector();

                while (acceso.SqlLectorDatos.Read())
                {

                }
                acceso.CerrarSqlConexion();
            }
            catch (Exception ex)
            {
                Logger.registrarError("Error UsuarioDA.ActualizaClave:" + ex);

                
            }

        }


    }
}
       