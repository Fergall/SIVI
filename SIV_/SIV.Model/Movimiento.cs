using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIV.Model
{
    public class Movimiento
    {
        private int mov_serie;

        public int serie
        {
            get { return mov_serie; }
            set { mov_serie = value; }
        }

        private string mov_apellidos;

        public string apellidos
        {
            get { return mov_apellidos; }
            set { mov_apellidos = value; }
        }
        private string mov_nombres;

        public string nombres
        {
            get { return mov_nombres; }
            set { mov_nombres = value; }
        }

        private string mov_doc;

        public string documento
        {
            get { return mov_doc; }
            set { mov_doc = value; }
        }

        private string mov_rut;

        public string rut
        {
            get { return mov_rut; }
            set { mov_rut = value; }
        }

        private int mov_id_empresa;

        public int id_empresa
        {
            get { return mov_id_empresa; }
            set { mov_id_empresa = value; }
        }

        private string mov_fecha;

        public string fecha
        {
            get { return mov_fecha; }
            set { mov_fecha = value; }
        }

        private int mov_claves_id;

        public int id_claves
        {
            get { return mov_claves_id; }
            set { mov_claves_id = value; }
        }

        private int mov_tipo;

        public int tipo
        {
            get { return mov_tipo; }
            set { mov_tipo = value; }
        }

        private int mov_vivienda;

        public int id_vivienda
        {
            get { return mov_vivienda; }
            set { mov_vivienda = value; }
        }

        private string mov_residente;

        public string rut_residente
        {
            get { return mov_residente; }
            set { mov_residente = value; }
        }

        private string mov_fecha_salida;

        public string fecha_salida
        {
            get { return mov_fecha_salida; }
            set { mov_fecha_salida = value; }
        }

        private int mov_claves_id_salida;

        public int id_claves_salida
        {
            get { return mov_claves_id_salida; }
            set { mov_claves_id_salida = value; }
        }

        private Boolean mov_cerrado;

        public Boolean cerrado
        {
            get { return mov_cerrado; }
            set { mov_cerrado = value; }
        }

        private int mov_estacionamiento;

        public int id_estacionamiento
        {
            get { return mov_estacionamiento; }
            set { mov_estacionamiento = value; }
        }

        private string mov_patente;

        public string patente
        {
            get { return mov_patente; }
            set { mov_patente = value; }
        }

        private int mov_reserva_id;

        public int id_reserva
        {
            get { return mov_reserva_id; }
            set { mov_reserva_id = value; }
        }

        private string mov_observaciones;

        public string observaciones
        {
            get { return mov_observaciones; }
            set { mov_observaciones = value; }
        }



    }
}
