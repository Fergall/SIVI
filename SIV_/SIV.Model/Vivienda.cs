using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIV.Model
{
    public class Vivienda
    {
        private int vivienda_id;
        /// <summary>
        /// Id autonumerico
        /// </summary>
        public int id
        {
            get { return vivienda_id; }
            set { vivienda_id = value; }
        }

        private int vivienda_id_empresa;
        /// <summary>
        /// Id empresa asociada
        /// </summary>
        public int id_empresa
        {
            get { return vivienda_id_empresa; }
            set { vivienda_id_empresa = value; }
        }

        private string vivienda_tipo;
        /// <summary>
        /// Tipo de vivienda: DEPARTAMENTO, OFICINA, CASA y PARCELA
        /// </summary>
        public string tipo
        {
            get { return vivienda_tipo; }
            set { vivienda_tipo = value; }
        }
        private int vivienda_numero;
        /// <summary>
        /// numero vivienda
        /// </summary>
        public int numero
        {
            get { return vivienda_numero; }
            set { vivienda_numero = value; }
        }

        private string vivienda_estado;
        /// <summary>
        /// Estado
        /// </summary>
        public string estado
        {
            get { return vivienda_estado; }
            set { vivienda_estado = value; }
        }

        private int vivienda_claves_id;

        public int id_claves
        {
            get { return vivienda_claves_id; }
            set { vivienda_claves_id = value; }
        }


        private string vivienda_nombre;

        public string nombre
        {
            get { return vivienda_nombre; }
            set { vivienda_nombre = value; }
        }



    }
}
