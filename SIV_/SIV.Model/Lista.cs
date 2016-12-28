using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIV.Model
{
    public class Lista
    {
        private int lista_negra_id_empresa;

        public int id_empresa
        {
            get { return lista_negra_id_empresa; }
            set { lista_negra_id_empresa = value; }
        }

        private string lista_negra_rut;

        public string rut
        {
            get { return lista_negra_rut; }
            set { lista_negra_rut = value; }
        }

        private string lista_negra_apellidos;

        public string apellidos
        {
            get { return lista_negra_apellidos; }
            set { lista_negra_apellidos = value; }
        }

        private string lista_negra_nombres;

        public string nombres
        {
            get { return lista_negra_nombres; }
            set { lista_negra_nombres = value; }
        }

        private string lista_negra_motivo;

        public string motivo
        {
            get { return lista_negra_motivo; }
            set { lista_negra_motivo = value; }
        }

        private Boolean lista_negra_peatonal;

        public Boolean peatonal
        {
            get { return lista_negra_peatonal; }
            set { lista_negra_peatonal = value; }
        }

        private Boolean lista_negra_vehicular;

        public Boolean vehicular
        {
            get { return lista_negra_vehicular; }
            set { lista_negra_vehicular = value; }
        }

        private string lista_negra_fecha;

        public string fecha
        {
            get { return lista_negra_fecha; }
            set { lista_negra_fecha = value; }
        }

        private int lista_negra_nivel;

        public int nivel
        {
            get { return lista_negra_nivel; }
            set { lista_negra_nivel = value; }
        }

    }
}
