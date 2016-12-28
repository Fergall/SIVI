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
    /// Clase de acceso de datos para objetos Empresa
    /// </summary>
    public class EmpresaDA
    {
        /// <summary>
        /// Obtiene una o todas las empresas
        /// </summary>
        /// <param name="emp">Objeto empresa</param>
        /// <returns>Lista de objetos empresa</returns>
        public static List<Empresa> ObtieneEmpresas(Empresa emp)
        {

            Empresa e;
            List<Empresa> Empresas = new List<Empresa>();
            try
            {
                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("empresa_get_empresas");
                if (emp.id != 0)
                {
                    acceso.AgregarSqlParametro("@emp_id", emp.id, SqlDbType.Int);
                }

                if (emp.rut != "")
                {
                    acceso.AgregarSqlParametro("@emp_rut", emp.rut, SqlDbType.NVarChar);
                }



                acceso.AbrirSqlConeccion();
                acceso.EjecutarSqlLector();

                while (acceso.SqlLectorDatos.Read())
                {
                    e = new Empresa();
                    e.id = Convert.ToInt32(acceso.SqlLectorDatos["emp_id_empresa"].ToString());
                    e.nombre = acceso.SqlLectorDatos["emp_nombre_empresa"].ToString();
                    e.direccion = acceso.SqlLectorDatos["emp_direccion"].ToString();
                    e.telefono = acceso.SqlLectorDatos["emp_telefono"].ToString();
                    e.correo = acceso.SqlLectorDatos["emp_correo"].ToString();
                    e.contacto = acceso.SqlLectorDatos["emp_nombre_contacto"].ToString();
                    e.rut = acceso.SqlLectorDatos["emp_rut"].ToString();
                    Empresas.Add(e);
                }
                acceso.CerrarSqlConexion();
            }
            catch (Exception ex)
            {
                Logger.registrarError("Error EmpresaDA ObtieneEmpresas: " + ex);

                return null;
            }
            if (Empresas.Count != 0)
            {
                return Empresas;
            }
            else
            {
                return null;
            }

        }
        /// <summary>
        /// Actualiza datos de empresa
        /// </summary>
        /// <param name="emp">Objeto empresa</param>
        public static void ActualizaEmpresa(Empresa emp)
        {

                     

                try
                {
                    SqlDA acceso = new SqlDA("DB_SOURCE");
                    acceso.CargarSqlComando("empresa_upd");
                    
                    acceso.AgregarSqlParametro("@emp_id_empresa", emp.id, SqlDbType.Int);
                    acceso.AgregarSqlParametro("@emp_nombre_empresa", emp.nombre, SqlDbType.NVarChar);
                    acceso.AgregarSqlParametro("@emp_direccion", emp.direccion, SqlDbType.NVarChar);
                    acceso.AgregarSqlParametro("@emp_telefono", emp.telefono, SqlDbType.NVarChar);
                    acceso.AgregarSqlParametro("@emp_correo", emp.correo, SqlDbType.NVarChar);
                    acceso.AgregarSqlParametro("@emp_nombre_contacto", emp.contacto, SqlDbType.NVarChar);
                    acceso.AgregarSqlParametro("@emp_rut", emp.rut, SqlDbType.NVarChar);



                    acceso.AbrirSqlConeccion();
                    acceso.EjecutarSqlLector();



                    while (acceso.SqlLectorDatos.Read())
                    {
                       

                    }
                    acceso.CerrarSqlConexion();
                }
                catch (Exception ex)
                {
                    Logger.registrarError("Error EmpresaDA.ActualizaEmpresa: " + ex);
                    
                }
 

        }
        /// <summary>
        /// Actualiza datos de empresa
        /// </summary>
        /// <param name="emp">Objeto empresa</param>
        public static void GuardaEmpresa(Empresa emp)
        {



            try
            {
                SqlDA acceso = new SqlDA("DB_SOURCE");
                acceso.CargarSqlComando("empresa_add");
                               
                acceso.AgregarSqlParametro("@emp_nombre_empresa", emp.nombre, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@emp_direccion", emp.direccion, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@emp_telefono", emp.telefono, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@emp_correo", emp.correo, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@emp_nombre_contacto", emp.contacto, SqlDbType.NVarChar);
                acceso.AgregarSqlParametro("@emp_rut", emp.rut, SqlDbType.NVarChar);



                acceso.AbrirSqlConeccion();
                acceso.EjecutarSqlLector();



                while (acceso.SqlLectorDatos.Read())
                {


                }
                acceso.CerrarSqlConexion();
            }
            catch (Exception ex)
            {
                Logger.registrarError("Error EmpresaDA.GuardaEmpresa: " + ex);

            }


        }

    }
}
