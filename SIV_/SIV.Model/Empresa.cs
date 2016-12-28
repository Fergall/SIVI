using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIV.Model
{
    public class Empresa
    {
        private int emp_id_empresa;

        /// <summary>
        /// Id autonumerico
        /// </summary>
        public int id
        {
            get { return emp_id_empresa; }
            set { emp_id_empresa = value; }
        }

        private string emp_nombre_empresa;
        /// <summary>
        /// Nombre
        /// </summary>
        public string nombre
        {
            get { return emp_nombre_empresa; }
            set { emp_nombre_empresa = value; }
        }

        private string emp_direccion;
        /// <summary>
        /// Dirección
        /// </summary>
        public string direccion
        {
            get { return emp_direccion; }
            set { emp_direccion = value; }
        }

        private string emp_telefono;
        /// <summary>
        /// Teléfono
        /// </summary>
        public string telefono
        {
            get { return emp_telefono; }
            set { emp_telefono = value; }
        }

        private string emp_correo;
        /// <summary>
        /// Correo de contacto
        /// </summary>
        public string correo
        {
            get { return emp_correo; }
            set { emp_correo = value; }
        }

        private string emp_nombre_contacto;
        /// <summary>
        /// Nombre del contacto
        /// </summary>
        public string contacto
        {
            get { return emp_nombre_contacto; }
            set { emp_nombre_contacto = value; }
        }

        private string emp_rut;
        /// <summary>
        /// Rut
        /// </summary>
        public string rut
        {
            get { return emp_rut; }
            set { emp_rut = value; }
        }


    }
}
