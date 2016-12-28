using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Xml;

namespace SIV.Tools
{
    /// <summary>
    /// Clase para uso de libreria log4net. Refleja errores de acceso a nivel de capa DA.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Inicializacion
        /// </summary>
        public static void inicializarLog4Net()
        {
            log4net.Config.XmlConfigurator.Configure();
            
        }

        /// <summary>
        /// Registra mensaje de error
        /// </summary>
        /// <param name="mensajeError">Mensaje de error</param>
        public static void registrarError(string mensajeError)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("File");
            log.Error(mensajeError);
        }

        /// <summary>
        /// Registra mensaje de error y excepcion
        /// </summary>
        /// <param name="mensajeError">Mensaje de error</param>
        /// <param name="excepcion">Excepción</param>
        public static void registrarError(string mensajeError, Exception excepcion)
        {
            log4net.ILog log = log4net.LogManager.GetLogger("File");
            log.Error(mensajeError, excepcion);
        }



    }
}
