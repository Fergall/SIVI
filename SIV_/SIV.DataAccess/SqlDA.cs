using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SIV.DataAccess
{
    internal sealed class SqlDA

    {
        private SqlConnection sqlConeccion;
        private SqlCommand sqlComando;
        private SqlDataReader sqlLectorDatos;
        public DataSet resultDS;
        private Int32 totalFilasAfectadas;
        /// <summary>
        /// Constructor con nombre de conexión.
        /// </summary>
        /// <param name="nombreConexion">Nombre de conexión en web.config</param>
        public SqlDA(String nombreConexion)
        {
            try
            {
                this.sqlConeccion = new SqlConnection(ConfigurationManager.ConnectionStrings[nombreConexion].ConnectionString);
                this.sqlComando = new SqlCommand();
                this.totalFilasAfectadas = 0;
            }
            catch (SqlException excepcion)
            {
                throw (excepcion);
            }
        }
        public void CargarSqlComando(String nombreProcedimiento)
        {
            try
            {
                this.sqlComando.Connection = this.sqlConeccion;
                this.sqlComando.CommandText = nombreProcedimiento;
                this.sqlComando.CommandType = System.Data.CommandType.StoredProcedure;

            }
            catch (SqlException excepcion)
            {
                throw (excepcion);
            }
        }




        public void dsCargarSqlQuery(string nombreProc)
        {
            //DataSet ds = new DataSet();

            try
            {
                this.sqlComando.Connection = this.sqlConeccion;
                this.sqlComando.CommandText = nombreProc;
                this.sqlComando.CommandTimeout = 120;
                this.sqlComando.CommandType = System.Data.CommandType.Text;
                //SqlDataAdapter da = new SqlDataAdapter(sqlComando.CommandText, sqlComando.Connection);

                //da.Fill(resultDS);

            }
            catch (SqlException excepcion)
            {
                throw (excepcion);
            }
            //return ds;
        }
        public void CargarSqlQuery(String Query)
        {
            try
            {
                this.sqlComando.Connection = this.sqlConeccion;
                this.sqlComando.CommandText = Query;
                this.sqlComando.CommandType = System.Data.CommandType.Text;
            }
            catch (SqlException excepcion)
            {
                throw (excepcion);
            }
        }


        public void AgregarSqlParametro(String nombreParametro, Object valorParametro, SqlDbType tipo)
        {
            try
            {
                SqlParameter sqlParametro = this.sqlComando.CreateParameter();
                sqlParametro.ParameterName = nombreParametro;


                if (valorParametro == null)
                {
                    sqlParametro.Value = DBNull.Value;
                }
                else
                {
                    sqlParametro.Value = valorParametro;
                }

                sqlParametro.SqlDbType = tipo;
                this.sqlComando.Parameters.Add(sqlParametro);
            }
            catch (SqlException excepcion)
            {
                throw (excepcion);
            }
        }

        public void LimpiarSqlParametros()
        {
            this.sqlComando.Parameters.Clear();
        }
        public void EjecutarSqlEscritura()
        {
            try
            {
                this.sqlComando.Connection.Open();
                this.totalFilasAfectadas = this.sqlComando.ExecuteNonQuery();
                this.sqlComando.Connection.Close();
            }
            catch (SqlException excepcion)
            {
                throw (excepcion);
            }
        }
        public void AbrirSqlConeccion()
        {
            this.sqlComando.Connection.Open();
        }

        public void EjecutarSqlLector()
        {
            try
            {
                this.sqlLectorDatos = this.sqlComando.ExecuteReader();
            }
            catch (SqlException excepcion)
            {
                throw (excepcion);
            }
        }

        public void EjecutarSqlDataset()
        {
            SqlDataAdapter da = new SqlDataAdapter(sqlComando.CommandText, sqlComando.Connection);
            da.SelectCommand = sqlComando;
            resultDS = new DataSet();

            da.Fill(this.resultDS);
        }




        public void CerrarSqlConexion()
        {
            this.sqlComando.Connection.Close();
        }
        public Boolean SqlLeerDatos()
        {
            return this.sqlLectorDatos.Read();
        }
        public Int32 TotalFilasAfectadas()
        {
            return this.totalFilasAfectadas;
        }
        public SqlDataReader SqlLectorDatos
        {
            get { return sqlLectorDatos; }
            set { sqlLectorDatos = value; }
        }



    }

}

