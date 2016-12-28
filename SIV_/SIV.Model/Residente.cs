using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIV.Model
{
    public class Residente
    {
        private string res_fecha;

        public string fecha
        {
            get { return res_fecha; }
            set { res_fecha = value; }
        }

        private int res_id_empresa;

        public int id_empresa
        {
            get { return res_id_empresa; }
            set { res_id_empresa = value; }
        }

        private string res_rut;

        public string rut
        {
            get { return res_rut; }
            set { res_rut = value; }
        }

        private string res_nombre;

        public string nombre
        {
            get { return res_nombre; }
            set { res_nombre = value; }
        }

        private string res_apellidos;

        public string apellido
        {
            get { return res_apellidos; }
            set { res_apellidos = value; }
        }

        private string res_estado;

        public string estado
        {
            get { return res_estado; }
            set { res_estado = value; }
        }

        private int res_claves_id;

        public int id_claves
        {
            get { return res_claves_id; }
            set { res_claves_id = value; }
        }

        private int res_estacionamiento;

        public int id_estacionamiento
        {
            get { return res_estacionamiento; }
            set { res_estacionamiento = value; }
        }

        private int res_vivienda;

        public int id_vivienda
        {
            get { return res_vivienda; }
            set { res_vivienda = value; }
        }

        private object res_fotografia;

        public object fotografia
        {
            get { return res_fotografia; }
            set { res_fotografia = value; }
        }







    }
}
