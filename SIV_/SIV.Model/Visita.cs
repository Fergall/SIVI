using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIV.Model
{
    public class Visita
    {

        private int visitas_id_empresa;

        public int id_empresa
        {
            get { return visitas_id_empresa; }
            set { visitas_id_empresa = value; }
        }

        private string visitas_rut;

        public string rut
        {
            get { return visitas_rut; }
            set { visitas_rut = value; }
        }

        private string visitas_fecha;

        public string fecha
        {
            get { return visitas_fecha; }
            set { visitas_fecha = value; }
        }

        private string visitas_apellidos;

        public string apellidos
        {
            get { return visitas_apellidos; }
            set { visitas_apellidos = value; }
        }

        private string visitas_nombres;

        public string nombres
        {
            get { return visitas_nombres; }
            set { visitas_nombres = value; }
        }

        private int visitas_claves_id;

        public int id_claves
        {
            get { return visitas_claves_id; }
            set { visitas_claves_id = value; }
        }

        private string visitas_patente;

        public string patente
        {
            get { return visitas_patente; }
            set { visitas_patente = value; }
        }

        private string visitas_fotografia;

        public string fotografia
        {
            get { return visitas_fotografia; }
            set { visitas_fotografia = value; }
        }

    }
}
