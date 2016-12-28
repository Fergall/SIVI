using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIV.Model
{
    public class Clave
    {
        private int claves_id;
        /// <summary>
        /// Id autonumerico
        /// </summary>
        public int id
        {
            get { return claves_id; }
            set { claves_id = value; }
        }

        private Empresa emp = new Empresa();
        /// <summary>
        /// Empresa asociada
        /// </summary>
        public Empresa empresa
        {
            get { return emp; }
            set { emp = value; }
        }

        private string claves_estado;
        /// <summary>
        /// Estado
        /// </summary>
        public string estado
        {
            get { return claves_estado; }
            set { claves_estado = value; }
        }

        private int claves_nivel;
        /// <summary>
        /// Rol. 1:Administrador, 2:Conserje
        /// </summary>
        public int nivel
        {
            get { return claves_nivel; }
            set { claves_nivel = value; }
        }

        private string claves_nombre;
        /// <summary>
        /// Nombre
        /// </summary>
        public string nombre
        {
            get { return claves_nombre; }
            set { claves_nombre = value; }
        }

        private string claves_username;
        /// <summary>
        /// Usuario de sistema
        /// </summary>
        public string usuario
        {
            get { return claves_username; }
            set { claves_username = value; }
        }

        private string claves_password;
        /// <summary>
        /// Clave del usuario
        /// </summary>
        public string password
        {
            get { return claves_password; }
            set { claves_password = value; }
        }

        private Boolean claves_estacionamiento;
        /// <summary>
        /// Bandera de acceso al maestro de estacionamientos
        /// </summary>
        public Boolean permiso_estacionamiento
        {
            get { return claves_estacionamiento; }
            set { claves_estacionamiento = value; }
        }

        private Boolean claves_residentes;
        /// <summary>
        /// Bandera de acceso al maestro de residentes
        /// </summary>
        public Boolean permiso_residentes
        {
            get { return claves_residentes; }
            set { claves_residentes = value; }
        }

        private Boolean claves_listanegra;
        /// <summary>
        /// Bandera de acceso al maestro de lista negra
        /// </summary>
        public Boolean permiso_lista_negra
        {
            get { return claves_listanegra; }
            set { claves_listanegra = value; }
        }

        private Boolean claves_proveedores;
        /// <summary>
        /// Bandera de acceso al maestro de proveedores
        /// </summary>
        public Boolean permiso_proveedores
        {
            get { return claves_proveedores; }
            set { claves_proveedores = value; }
        }

        private Boolean claves_empresa;
        /// <summary>
        /// Bandera de acceso al maestro de empresas
        /// </summary>
        public Boolean permiso_empresas
        {
            get { return claves_empresa; }
            set { claves_empresa = value; }
        }

        private Boolean claves_vivienda;
        /// <summary>
        /// Bandera de acceso al maestro de viviendas
        /// </summary>
        public Boolean permiso_viviendas
        {
            get { return claves_vivienda; }
            set { claves_vivienda = value; }
        }

    }
}
