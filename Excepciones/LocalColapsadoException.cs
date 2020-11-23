using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class LocalColapsadoException : Exception
    {
        #region Constructor

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public LocalColapsadoException() : base("El local tiene mas de 15 pedidos en cola.")
        {

        }
        /// <summary>
        /// Excepcion que controla si el local tiene mas de 15 pedidos en cola.
        /// </summary>
        /// <param name="e"> Excepcion </param>
        public LocalColapsadoException(Exception innerException) : base("El local tiene mas de 15 pedidos en cola", innerException)
        {

        }

        #endregion
    }
}
