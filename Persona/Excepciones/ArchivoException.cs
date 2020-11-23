using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ArchivosException : Exception
    {
        #region Constructor

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public ArchivosException() : base("Error en el archivo")
        {

        }
        /// <summary>
        /// Excepcion que controla si el el archivo es null
        /// </summary>
        /// <param name="e"> Excepcion </param>
        public ArchivosException(Exception innerException) : base("Error en los archivos", innerException)
        {

        }

        #endregion
    }
}
